using BloodBank_BusinessLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank_WindowsForms_.DashboardFroms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblNumberOfDonors.Text = clsDonor.GetTotalDonors().ToString();
            lblNumberOfPatients.Text = clsPatient.GetTotalPatients().ToString();
            lblNumberOfTransfer.Text = clsTransfer.GetTotalTransfers().ToString();
            lblNumberOfUsers.Text = clsEmployee.GetTotalEmployees().ToString();
        }
    }
}
