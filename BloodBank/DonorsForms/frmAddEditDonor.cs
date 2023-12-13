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

namespace BloodBank_WindowsForms_.DonorsForms
{
    public partial class frmAddEditDonor : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _DonorID;
        private clsDonor _Donor;

        private Panel _panelChildForm;
        private Label _lblTitleChildForm;

        private ToolTip toolTip1;

        public frmAddEditDonor(int donorID, Panel panelChildForm, Label lblTitleChildForm)
        {
            InitializeComponent();
            this._DonorID = donorID;
            this._panelChildForm = panelChildForm;
            this._lblTitleChildForm = lblTitleChildForm;

            if (this._DonorID != -1)
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
            toolTip1.SetToolTip(txtDonorID, "This field is Read Only!");
            toolTip1.SetToolTip(txtBloodGroup, "This field is Read Only!");
        }

        private void _FillFieldsByDonorInfo()
        {
            string[] arrName = this._Donor.Name.Split();

            txtDonorID.Text = this._DonorID.ToString();
            txtFirstName.Text = arrName[0];

            if (arrName.Length > 1)
            {
                txtLastName.Text = arrName[1];
            }

            txtAge.Text = this._Donor.Age.ToString();
            txtPhone.Text = this._Donor.Phone.ToString();
            txtAddress.Text = this._Donor.Address.ToString();

            if (this._Donor.Gender == 'M')
            {
                _ActivePanelMale();
            }
            else
            {
                _ActivePanelFemale();
            }

            txtBloodGroup.Text = clsBloodGroup.Find(this._Donor.BloodGroupID).BloodGroupName;
        }

        private void _FillDonorByFieldsData()
        {
            _Donor.Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _Donor.Age = Convert.ToByte(txtAge.Text.Trim());

            if (radioMale.Checked)
            {
                _Donor.Gender = 'M';
            }
            else
            {
                _Donor.Gender = 'F';
            }

            _Donor.Phone = txtPhone.Text.Trim();
            _Donor.Address = txtAddress.Text.Trim();

            if (this._Mode == enMode.AddNew)
            {
                _Donor.BloodGroupID = clsBloodGroup.Find(comboBloodGroups.Text).BloodGroupID;
            }
        }

        private void _LoadData()
        {
            if (this._Mode == enMode.AddNew)
            {
                _Donor = new clsDonor();

                lblMode.Text = "Add New Donor";

                this.Tag = "ADD NEW DONOR";

                comboBloodGroups.SelectedIndex = 0;

                txtBloodGroup.Visible = false;
                comboBloodGroups.Visible = true;

                return;
            }

            _Donor = clsDonor.FindDonor(this._DonorID);

            if (this._Donor == null)
            {
                MessageBox.Show("This donor is not available!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillFieldsByDonorInfo();

            lblMode.Text = "Update Donor";
            this.Tag = "UPDATE DONOR";

            txtBloodGroup.Visible = true;
            comboBloodGroups.Visible = false;
        }

        private void _OnlyNumbersInTextBox(KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            // Allow digits and the backspace.
            bool isDigit = Char.IsDigit(inputChar);
            bool isBackspace = (inputChar == '\b');

            // If the input character is not a digit, decimal point, or backspace, suppress it.
            if (!isDigit && !isBackspace)
            {
                e.Handled = true;
            }
        }

        private bool _IsDataCorrect()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                (!radioFemale.Checked && !radioMale.Checked))

            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this._Mode == enMode.Update && string.IsNullOrWhiteSpace(txtBloodGroup.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this._Mode == enMode.AddNew && string.IsNullOrWhiteSpace(comboBloodGroups.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Convert.ToByte(txtAge.Text.Trim()) <= 0)
            {
                MessageBox.Show("The age is invalid.",
                   "Age Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void _ActivePanelMale()
        {
            radioMale.Checked = true;

            panelMale.BorderColor = Color.FromArgb(94, 148, 255);
            panelFemale.BorderColor = Color.FromArgb(64, 64, 64);

            if (radioFemale.Checked)
            {
                radioFemale.Checked = false;
            }
        }

        private void _ActivePanelFemale()
        {
            radioFemale.Checked = true;

            panelFemale.BorderColor = Color.FromArgb(94, 148, 255);
            panelMale.BorderColor = Color.FromArgb(64, 64, 64);

            if (radioMale.Checked)
            {
                radioMale.Checked = false;
            }
        }

        private void panelMale_Click(object sender, EventArgs e)
        {
            _ActivePanelMale();
        }

        private void panelFemale_Click(object sender, EventArgs e)
        {
            _ActivePanelFemale();
        }

        private void frmAddEditDonor_Load(object sender, EventArgs e)
        {
            _LoadData();
            txtAddress.BorderRadius = 20;
        }

        private void lblMale_Click(object sender, EventArgs e)
        {
            _ActivePanelMale();
        }

        private void lblFemale_Click(object sender, EventArgs e)
        {
            _ActivePanelFemale();
        }

        private void radioMale_Click(object sender, EventArgs e)
        {
            _ActivePanelMale(); ;
        }

        private void radioFemale_Click(object sender, EventArgs e)
        {
            _ActivePanelFemale();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmDonors(this._panelChildForm, this._lblTitleChildForm), this._panelChildForm, this._lblTitleChildForm);

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataCorrect())
            {
                return;
            }

            _FillDonorByFieldsData();

            if (_Donor.Save())
            {
                MessageBox.Show("Donor Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "Update Donor";
                this.Tag = "UPDATE DONOR";
                this._Mode = enMode.Update;

                _Donor._DonorMode = clsDonor.enDonorMode.Update;
                _Donor._PersonMode = clsPerson.enPersonMode.Update;

                txtDonorID.Text = _Donor.DonorID.ToString();
            }
            else
            {
                MessageBox.Show("Donor Saved Failed.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            _OnlyNumbersInTextBox(e);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            _OnlyNumbersInTextBox(e);
        }

        private void comboBloodGroups_MouseEnter(object sender, EventArgs e)
        {

        }

        private void comboBloodGroups_MouseLeave(object sender, EventArgs e)
        {

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
