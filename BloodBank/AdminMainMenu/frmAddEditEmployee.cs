using BloodBank_BusinessLayer_;
using Guna.UI2.WinForms;
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
    public partial class frmAddEditEmployee : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _EmployeeID;
        private clsEmployee _Employee;

        private ToolTip toolTip1;

        public frmAddEditEmployee(int EmployeeID)
        {
            InitializeComponent();

            this._EmployeeID = EmployeeID;

            if (this._EmployeeID != -1)
            {
                this._Mode = enMode.Update;
            }
            else
            {
                this._Mode = enMode.AddNew;
            }

            toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000; // Duration of tooltip display
            toolTip1.InitialDelay = 0; // Delay before showing tooltip
            toolTip1.ReshowDelay = 0;   // Delay before reshowing tooltip

            // Set tooltip text for the TextBox control
            toolTip1.SetToolTip(txtEmployeeID, "This field is Read Only!");
            
        }

        private void _FillFieldWithEmployeeData()
        {
            txtEmployeeID.Text = _Employee.EmployeeID.ToString();
            txtUsername.Text = _Employee.Username;
            txtPassword.Text = _Employee.Password;
        }

        private void _LoadDate()
        {
            if (this._Mode == enMode.AddNew)
            {
                this._Employee = new clsEmployee();

                lblMode.Text = "Add New Employee";

                return;
            }

            this._Employee = clsEmployee.FindEmployee(this._EmployeeID);

            if (this._Employee == null)
            {
                MessageBox.Show("This employee is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillFieldWithEmployeeData();

            lblMode.Text = "Update Employee";
        }

        private bool _IsDataCorrect()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (_Mode == enMode.AddNew && clsEmployee.IsEmployeeExists(txtUsername.Text))
            {
                MessageBox.Show("This username is already exists. Choose another one.", "Exists Username",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (_Mode == enMode.Update &&
                _Employee.Username != txtUsername.Text &&
                clsEmployee.IsEmployeeExists(txtUsername.Text))
            {
                MessageBox.Show("This username is already exists. Choose another one.", "Exists Username",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }


            return true;
        }

        private void _FillEmployeeWithFieldData()
        {
            _Employee.Username = txtUsername.Text.Trim();
            _Employee.Password = txtPassword.Text.Trim();
        }
        
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditEmployee_Load(object sender, EventArgs e)
        {
            _LoadDate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataCorrect())
            {
                return;
            }

            _FillEmployeeWithFieldData();

            if (_Employee.Save())
            {
                MessageBox.Show("Employee Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "Update Employee";
                this._Mode = enMode.Update;

                _Employee._EmployeeMode = clsEmployee.enEmployeeMode.Update;


                txtEmployeeID.Text = _Employee.EmployeeID.ToString();
            }
            else
            {
                MessageBox.Show("Employee Saved Failed.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textbox_MouseEnter(object sender, EventArgs e)
        {
            // Show the tooltip when the mouse enters the TextBox
            toolTip1.Show(toolTip1.GetToolTip(((Guna2TextBox)sender)), ((Guna2TextBox)sender));
        }

        private void textbox_MouseLeave(object sender, EventArgs e)
        {
            // Hide the tooltip when the mouse leaves the TextBox
            toolTip1.Hide(((Guna2TextBox)sender));
        }

    }
}
