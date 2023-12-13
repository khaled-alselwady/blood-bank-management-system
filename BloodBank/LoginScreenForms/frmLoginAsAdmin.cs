using BloodBank_WindowsForms_.AdminMainMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank_WindowsForms_.LoginScreenForms
{
    public partial class frmLoginAsAdmin : Form
    {
        public frmLoginAsAdmin()
        {
            InitializeComponent();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {

                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblInvalid.Visible = false;

            // the password of admin is `khaled`
            if (txtPassword.Text.Trim() == "khaled")
            {
                frmAdminMainMenu AdminMainMenu = new frmAdminMainMenu();
                AdminMainMenu.Show();

                this.Hide();
            }
            else
            {
                lblInvalid.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmLoginScreen LoginScreen = new frmLoginScreen();
            LoginScreen.Show();
            this.Close();
        }

        private void btnMinmize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmLoginAsAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            panelPassword.BackColor = Color.DodgerBlue;
        }
    }
}
