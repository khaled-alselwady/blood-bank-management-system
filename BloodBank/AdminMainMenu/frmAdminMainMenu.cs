using BloodBank_BusinessLayer_;
using BloodBank_WindowsForms_.DonorsForms;
using BloodBank_WindowsForms_.LoginScreenForms;
using BloodBank_WindowsForms_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank_WindowsForms_.AdminMainMenu
{
    public partial class frmAdminMainMenu : Form
    {
        public frmAdminMainMenu()
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

        private void frmAdminMainMenu_Load(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmEmployees(), panelChildForm, lblTitleChildForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLoginScreen LoginScreen = new frmLoginScreen();
            LoginScreen.Show();
            this.Close();
        }
    }
}
