using System;
using System.Windows.Forms;

namespace BRRDesktop
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadStats();
        }

        private async void LoadStats()
        {
            try
            {
                // Use designer-created labels (from Dashboard.Designer.cs)
                lblTotalResidents.Text = (await ApiHelper.Get<int>("dashboard/total-residents")).ToString();
                lblChildren.Text = (await ApiHelper.Get<int>("dashboard/children-count")).ToString();
                lblAdults.Text = (await ApiHelper.Get<int>("dashboard/adult-count")).ToString();
                lblSeniors.Text = (await ApiHelper.Get<int>("dashboard/senior-count")).ToString();
                lblPWD.Text = (await ApiHelper.Get<int>("dashboard/pwd-count")).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dashboard load failed: {ex.Message}");
            }
        }
    }
}