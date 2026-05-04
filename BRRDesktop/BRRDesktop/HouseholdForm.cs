using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace BRRDesktop
{
    public partial class HouseholdForm : Form
    {
        // Keep the original JObject results so we can access nested "members" without extra requests
        private List<JObject> householdsSource = new List<JObject>();

        public HouseholdForm()
        {
            InitializeComponent();

            // wire events in case designer didn't
            if (btnAdd != null) btnAdd.Click += BtnAdd_Click;
            if (btnView != null) btnView.Click += BtnView_Click;

            // load table
            _ = LoadHouseholdsAsync();
        }

        private async Task LoadHouseholdsAsync()
        {
            try
            {
                dgvHousehold.DataSource = null;
                householdsSource.Clear();

                // Try common GET endpoints for households — adjust to match your API if different
                string[] endpoints = { "household", "households", "household/all", "household/getall", "household/list" };
                JToken arr = null;

                foreach (var ep in endpoints)
                {
                    try
                    {
                        var raw = await ApiHelper.Get<string>(ep);
                        if (string.IsNullOrWhiteSpace(raw)) continue;

                        var token = JToken.Parse(raw);

                        if (token.Type == JTokenType.Object)
                        {
                            // Common wrappers
                            var data = token["data"] ?? token["households"] ?? token["items"];
                            if (data != null && data.Type == JTokenType.Array) { arr = data; }
                            else if (token["householdId"] != null || token["id"] != null) // single object -> wrap
                            {
                                arr = new JArray(token);
                            }
                        }
                        else if (token.Type == JTokenType.Array)
                        {
                            arr = token;
                        }

                        if (arr != null) break;
                    }
                    catch
                    {
                        // ignore and try next endpoint
                    }
                }

                if (arr == null)
                {
                    MessageBox.Show("No households found or API endpoint not available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                householdsSource = arr.Children<JObject>().ToList();

                // Map to display model
                var list = new List<object>();
                foreach (var item in householdsSource)
                {
                    // extract id and fields with several common names
                    var idToken = item["householdId"] ?? item["household_id"] ?? item["HouseholdId"] ?? item["id"];
                    var id = idToken?.ToString();

                    var householdName = item.Value<string>("householdName")
                                        ?? item.Value<string>("household_name")
                                        ?? item.Value<string>("name")
                                        ?? item.Value<string>("title");

                    var head = item.Value<string>("headOfHousehold")
                               ?? item.Value<string>("head")
                               ?? item.Value<string>("householdHead")
                               ?? item.Value<string>("householdHeadName");

                    var address = item.Value<string>("address")
                                  ?? item.Value<string>("barangay")
                                  ?? item.Value<string>("addressLine");

                    int membersCount = 0;
                    var membersToken = item["members"] ?? item["Members"];
                    if (membersToken != null && membersToken.Type == JTokenType.Array)
                        membersCount = membersToken.Count();
                    else
                    {
                        // some APIs return count field
                        int? cnt = item.Value<int?>("membersCount") ?? item.Value<int?>("memberCount") ?? item.Value<int?>("count");
                        membersCount = cnt ?? 0;
                    }

                    list.Add(new
                    {
                        Id = id,
                        HouseholdName = householdName ?? "(none)",
                        Head = head ?? "(unknown)",
                        Address = address ?? "(none)",
                        Members = membersCount
                    });
                }

                dgvHousehold.DataSource = list;

                // Hide Id column and tune widths if present
                if (dgvHousehold.Columns["Id"] != null) dgvHousehold.Columns["Id"].Visible = false;
                if (dgvHousehold.Columns["HouseholdName"] != null) dgvHousehold.Columns["HouseholdName"].HeaderText = "Household";
                if (dgvHousehold.Columns["Head"] != null) dgvHousehold.Columns["Head"].HeaderText = "Head of Household";
                if (dgvHousehold.Columns["Members"] != null) dgvHousehold.Columns["Members"].HeaderText = "Members";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed loading households: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔥 FIXED: Pass null, null for new household (no existing data)
                var result = ShowHouseholdEditorDialog(null, null);
                if (!result.Ok) return;

                var payload = new
                {
                    householdId = 0,
                    householdName = result.HouseholdName,
                    address = result.Address ?? string.Empty,
                    headOfHousehold = result.Head,
                    members = result.Members // Now includes members!
                };

                // Try a few likely create endpoints
                string[] endpoints = { "household", "households", "household/create", "household/add" };
                Exception lastEx = null;
                foreach (var ep in endpoints)
                {
                    try
                    {
                        var res = await ApiHelper.Post<string>(ep, payload);
                        MessageBox.Show("Household added successfully with members!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadHouseholdsAsync();
                        return;
                    }
                    catch (Exception ex)
                    {
                        lastEx = ex;
                        // try next endpoint
                    }
                }

                MessageBox.Show("Failed to add household: " + (lastEx?.Message ?? "unknown"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add household failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHousehold.CurrentRow == null)
                {
                    MessageBox.Show("Select a household first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int rowIndex = dgvHousehold.CurrentRow.Index;
                if (householdsSource == null || rowIndex < 0 || rowIndex >= householdsSource.Count)
                {
                    MessageBox.Show("Selected household data not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedHousehold = householdsSource[rowIndex];

                // Get household details for editor
                dynamic householdData = new
                {
                    HouseholdId = selectedHousehold["householdId"]?.ToString() ?? selectedHousehold["id"]?.ToString(),
                    HouseholdName = selectedHousehold.Value<string>("householdName") ?? selectedHousehold.Value<string>("name"),
                    Head = selectedHousehold.Value<string>("headOfHousehold") ?? selectedHousehold.Value<string>("head"),
                    Address = selectedHousehold.Value<string>("address")
                };

                // Get members (try embedded first, then API)
                var membersToken = selectedHousehold["members"] ?? selectedHousehold["Members"];
                List<JObject> membersList = new List<JObject>();

                if (membersToken != null && membersToken.Type == JTokenType.Array)
                {
                    membersList = membersToken.Children<JObject>().ToList();
                }
                else
                {
                    // Fetch from API if not embedded
                    var id = householdData.HouseholdId;
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        membersList = await FetchMembersFromApi(id);
                    }
                }

                // Show editor with existing data
                var result = ShowHouseholdEditorDialog(householdData, membersList);
                if (result.Ok && !string.IsNullOrWhiteSpace(result.HouseholdId))
                {
                    // Update household via API
                    var payload = new
                    {
                        householdId = result.HouseholdId,
                        householdName = result.HouseholdName,
                        address = result.Address ?? string.Empty,
                        headOfHousehold = result.Head,
                        members = result.Members
                    };

                    string[] updateEndpoints = {
                        $"household/{result.HouseholdId}",
                        $"households/{result.HouseholdId}",
                        "household/update",
                        "households/update"
                    };

                    foreach (var ep in updateEndpoints)
                    {
                        try
                        {
                            await ApiHelper.Post(ep, payload);
                            MessageBox.Show("Household updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadHouseholdsAsync();
                            return;
                        }
                        catch { /* try next */ }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load household: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<JObject>> FetchMembersFromApi(string householdId)
        {
            string[] memberEndpoints = {
                $"household/{householdId}/members",
                $"household/{householdId}/residents",
                $"household/members?householdId={householdId}",
                $"households/{householdId}/members",
                $"households/{householdId}/residents"
            };

            foreach (var ep in memberEndpoints)
            {
                try
                {
                    var raw = await ApiHelper.Get<string>(ep);
                    if (!string.IsNullOrWhiteSpace(raw))
                    {
                        var token = JToken.Parse(raw);
                        if (token.Type == JTokenType.Array)
                            return token.Children<JObject>().ToList();
                    }
                }
                catch { /* ignore */ }
            }
            return new List<JObject>();
        }

        // 🔥 ENHANCED HOUSEHOLD EDITOR WITH MEMBERS MANAGEMENT
        private (bool Ok, string HouseholdId, string HouseholdName, string Head, string Address, List<object> Members)
            ShowHouseholdEditorDialog(dynamic existingHousehold, List<JObject> existingMembers)
        {
            using (var dlg = new Form())
            {
                dlg.Text = existingHousehold != null ? "Edit Household & Members" : "Add New Household & Members";
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.Sizable;
                dlg.Width = 900;
                dlg.Height = 650;
                dlg.MinimizeBox = false;
                dlg.MaximizeBox = false;
                dlg.ShowInTaskbar = false;

                // Household Info Panel
                var pnlHousehold = new Panel { Dock = DockStyle.Top, Height = 120, BackColor = Color.FromArgb(240, 240, 240), Padding = new Padding(10) };

                var lblHousehold = new Label { Left = 12, Top = 12, Text = "Household Name:", AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
                var txtHousehold = new TextBox { Left = 12, Top = 34, Width = 380, Font = new Font("Segoe UI", 10F) };

                var lblHead = new Label { Left = 12, Top = 68, Text = "Household Head:", AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
                var txtHead = new TextBox { Left = 12, Top = 90, Width = 380, Font = new Font("Segoe UI", 10F) };

                var lblAddr = new Label { Left = 420, Top = 12, Text = "Address:", AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
                var txtAddr = new TextBox { Left = 420, Top = 34, Width = 380, Font = new Font("Segoe UI", 10F), Multiline = true, Height = 70 };

                pnlHousehold.Controls.AddRange(new Control[] { lblHousehold, txtHousehold, lblHead, txtHead, lblAddr, txtAddr });

                // Members Section
                var pnlMembers = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
                
                var btnAddMember = new Button { Text = "➕ Add Member", Dock = DockStyle.Top, Height = 40, BackColor = Color.FromArgb(0, 122, 204), ForeColor = Color.White, Font = new Font("Segoe UI", 10F, FontStyle.Bold), FlatStyle = FlatStyle.Flat, Margin = new Padding(0, 0, 0, 10) };
                var dgvMembers = new DataGridView { Dock = DockStyle.Fill, ReadOnly = false, AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
                var btnRemoveMember = new Button { Text = "❌ Remove Selected", Dock = DockStyle.Bottom, Height = 35, BackColor = Color.FromArgb(220, 53, 69), ForeColor = Color.White, Font = new Font("Segoe UI", 9F, FontStyle.Bold), FlatStyle = FlatStyle.Flat, Margin = new Padding(0, 10, 0, 0) };

                pnlMembers.Controls.AddRange(new Control[] { btnAddMember, dgvMembers, btnRemoveMember });

                // Buttons Panel
                var pnlButtons = new Panel { Dock = DockStyle.Bottom, Height = 50, BackColor = Color.FromArgb(240, 240, 240) };
                var btnSave = new Button { Text = "💾 Save Household", Left = 600, Width = 100, Top = 10, DialogResult = DialogResult.OK, BackColor = Color.FromArgb(40, 167, 69), ForeColor = Color.White, Font = new Font("Segoe UI", 10F, FontStyle.Bold), FlatStyle = FlatStyle.Flat };
                var btnCancel = new Button { Text = "Cancel", Left = 710, Width = 80, Top = 10, DialogResult = DialogResult.Cancel, BackColor = Color.LightGray, FlatStyle = FlatStyle.Flat };
                pnlButtons.Controls.AddRange(new Control[] { btnSave, btnCancel });

                // Add to dialog
                dlg.Controls.AddRange(new Control[] { pnlHousehold, pnlMembers, pnlButtons });

                // 🔥 FIXED: Load existing household data safely
                if (existingHousehold != null)
                {
                    try
                    {
                        txtHousehold.Text = existingHousehold.HouseholdName ?? "";
                        txtHead.Text = existingHousehold.Head ?? "";
                        txtAddr.Text = existingHousehold.Address ?? "";
                    }
                    catch { /* ignore if properties don't exist */ }
                }

                // Setup Members Grid
                var membersList = new List<object>();
                if (existingMembers != null && existingMembers.Count > 0)
                {
                    foreach (var member in existingMembers)
                    {
                        membersList.Add(new
                        {
                            FullName = member.Value<string>("fullName") ?? member.Value<string>("name") ?? "",
                            Relationship = member.Value<string>("relationship") ?? "Member",
                            BirthDate = member.Value<string>("birthDate") ?? "",
                            Gender = member.Value<string>("gender") ?? "",
                            IsPWD = member.Value<bool?>("isPWD") ?? false
                        });
                    }
                }
                dgvMembers.DataSource = membersList;

                // Member management events
                int memberIndex = membersList.Count;
                btnAddMember.Click += (s, e) =>
                {
                    membersList.Add(new { FullName = $"Member {++memberIndex}", Relationship = "Member", BirthDate = "", Gender = "", IsPWD = false });
                    dgvMembers.DataSource = null;
                    dgvMembers.DataSource = membersList;
                };

                btnRemoveMember.Click += (s, e) =>
                {
                    if (dgvMembers.CurrentRow != null && dgvMembers.CurrentRow.Index < membersList.Count)
                    {
                        int rowIndex = dgvMembers.CurrentRow.Index;
                        membersList.RemoveAt(rowIndex);
                        dgvMembers.DataSource = null;
                        dgvMembers.DataSource = membersList;
                    }
                };

                dlg.AcceptButton = btnSave;
                dlg.CancelButton = btnCancel;

                var result = dlg.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    string householdId = existingHousehold?.HouseholdId?.ToString() ?? "";
                    return (true, householdId, txtHousehold.Text.Trim(), txtHead.Text.Trim(), txtAddr.Text.Trim(), membersList);
                }
                return (false, null, null, null, null, null);
            }
        }
    }
}