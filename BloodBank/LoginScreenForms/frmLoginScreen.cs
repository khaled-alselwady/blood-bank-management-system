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

namespace BloodBank_WindowsForms_.LoginScreenForms
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {

                txtUsername.Text = "";
                txtUsername.ForeColor = Color.LightGray;

            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.DimGray;
            }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinmize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmLoginScreen_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            panelUsername.BackColor = Color.DodgerBlue;
            panelPassword.BackColor = Color.DimGray;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            panelPassword.BackColor = Color.DodgerBlue;
            panelUsername.BackColor = Color.DimGray;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsEmployee.IsEmployeeExists(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
            {
                lblInvalid.Visible = false;
                clsEmployee Employee = clsEmployee.FindEmployee(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                if (Employee != null)
                {
                    frmMainMenu OpenMainMenu = new frmMainMenu();
                    OpenMainMenu.Show();

                    this.Hide();
                }
            }
            else
            {
                lblInvalid.Visible = true;
            }
        }

        private void linklblLoginAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLoginAsAdmin LoginAsAmin = new frmLoginAsAdmin();
            LoginAsAmin.Show();

            this.Hide();
        }
    }
}
