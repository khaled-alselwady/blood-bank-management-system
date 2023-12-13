using BloodBank_BusinessLayer_;
using BloodBank_WindowsForms_.BloodStockForms;
using BloodBank_WindowsForms_.BloodTransferForms;
using BloodBank_WindowsForms_.DashboardFroms;
using BloodBank_WindowsForms_.DonateForms;
using BloodBank_WindowsForms_.DonorsForms;
using BloodBank_WindowsForms_.LoginScreenForms;
using BloodBank_WindowsForms_.PatientForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank_WindowsForms_
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmLoginScreen LoginScreen = new frmLoginScreen();
            LoginScreen.Show();
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnDonors_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmDonors(panelChildForm, lblTitleChildForm), panelChildForm, lblTitleChildForm, sender, panelMenu);
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmPatients(panelChildForm, lblTitleChildForm), panelChildForm, lblTitleChildForm, sender, panelMenu);
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmDonate(), panelChildForm, lblTitleChildForm, sender, panelMenu);
        }

        private void btnBloodStock_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmBloodStock(), panelChildForm, lblTitleChildForm, sender, panelMenu);
        }

        private void btnBloodTransfer_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmBloodTransfer(), panelChildForm, lblTitleChildForm, sender, panelMenu);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmDashboard(), panelChildForm, lblTitleChildForm, sender, panelMenu);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLoginScreen LoginScreen = new frmLoginScreen();
            LoginScreen.Show();
            this.Close();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            lblNumberOfDonors.Text = clsDonor.GetTotalDonors().ToString();
            lblNumberOfPatients.Text = clsPatient.GetTotalPatients().ToString();
            lblNumberOfTransfer.Text = clsTransfer.GetTotalTransfers().ToString();
            lblNumberOfUsers.Text = clsEmployee.GetTotalEmployees().ToString();

            btnDashboard.BackColor = Color.MidnightBlue;
        }
    }
}
