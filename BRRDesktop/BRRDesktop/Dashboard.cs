using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRRDesktop.Models;
using BRRDesktop.Services;
using BRRDesktop.Helpers;
using Newtonsoft.Json;

namespace BRRDesktop
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
           
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblUsername.Text = SessionManager.Username;

            await LoadResidents();
        }

        private async Task LoadResidents()
        {
            var response = await ApiService.GetData("residents");

            var residents = JsonConvert.DeserializeObject<List<Resident>>(response);

            dgvResidents.DataSource = residents;

            lblTotalResidents.Text = residents.Count.ToString();

            lblMale.Text = residents.Count(x => x.Gender == "Male").ToString();

            lblFemale.Text = residents.Count(x => x.Gender == "Female").ToString();
        }
    }
}