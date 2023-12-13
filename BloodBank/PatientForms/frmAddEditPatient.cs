using BloodBank_BusinessLayer_;
using BloodBank_WindowsForms_.DonorsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank_WindowsForms_.PatientForms
{
    public partial class frmAddEditPatient : Form
    {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _PatientID;
        private clsPatient _Patient;

        private Panel _panelChildForm;
        private Label _lblTitleChildForm;

        public frmAddEditPatient(int donorID, Panel panelChildForm, Label lblTitleChildForm)
        {
            InitializeComponent();

            this._PatientID = donorID;
            this._panelChildForm = panelChildForm;
            this._lblTitleChildForm = lblTitleChildForm;

            if (this._PatientID != -1)
            {
                this._Mode = enMode.Update;
            }
            else
            {
                this._Mode = enMode.AddNew;
            }
        }


        private void _FillFieldsByDonorInfo()
        {
            string[] arrName = this._Patient.Name.Split();

            txtPatientID.Text = this._Patient.PatientID.ToString();
            txtFirstName.Text = arrName[0];

            if (arrName.Length > 1)
            {
                txtLastName.Text = arrName[1];
            }

            txtAge.Text = this._Patient.Age.ToString();
            txtPhone.Text = this._Patient.Phone.ToString();
            txtAddress.Text = this._Patient.Address.ToString();

            if (this._Patient.Gender == 'M')
            {
                _ActivePanelMale();
            }
            else
            {
                _ActivePanelFemale();
            }

            comboBloodGroups.SelectedIndex = comboBloodGroups.FindString(clsBloodGroup.Find(this._Patient.BloodGroupID).BloodGroupName);
        }

        private void _FillDonorByFieldsData()
        {
            _Patient.Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _Patient.Age = Convert.ToByte(txtAge.Text.Trim());

            if (radioMale.Checked)
            {
                _Patient.Gender = 'M';
            }
            else
            {
                _Patient.Gender = 'F';
            }

            _Patient.Phone = txtPhone.Text.Trim();
            _Patient.Address = txtAddress.Text.Trim();
        }

        private void _LoadData()
        {
            if (this._Mode == enMode.AddNew)
            {
                _Patient = new clsPatient();

                lblMode.Text = "Add New Patient";

                this.Tag = "ADD NEW PATIENT";

                comboBloodGroups.SelectedIndex = 0;

                return;
            }

            _Patient = clsPatient.FindPatient(this._PatientID);

            if (this._Patient == null)
            {
                MessageBox.Show("This patient is not available!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillFieldsByDonorInfo();

            lblMode.Text = "Update Patient";
            this.Tag = "UPDATE PATIENT";
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
                string.IsNullOrWhiteSpace(comboBloodGroups.Text) ||
                (!radioFemale.Checked && !radioMale.Checked))

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmPatients(this._panelChildForm, this._lblTitleChildForm), this._panelChildForm, this._lblTitleChildForm);

            this.Close();
        }

        private void frmAddEditPatient_Load(object sender, EventArgs e)
        {
            _LoadData();
            txtAddress.BorderRadius = 20;
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
            comboBloodGroups.BorderColor = Color.FromArgb(94, 148, 255);
        }

        private void comboBloodGroups_MouseLeave(object sender, EventArgs e)
        {
            comboBloodGroups.BorderColor = Color.FromArgb(64, 64, 64);
        }

        private void panelMale_Click(object sender, EventArgs e)
        {
            _ActivePanelMale();
        }

        private void lblMale_Click(object sender, EventArgs e)
        {
            _ActivePanelMale();
        }

        private void radioMale_Click(object sender, EventArgs e)
        {
            _ActivePanelMale();
        }

        private void panelFemale_Click(object sender, EventArgs e)
        {
            _ActivePanelFemale();
        }

        private void lblFemale_Click(object sender, EventArgs e)
        {
            _ActivePanelFemale();
        }

        private void radioFemale_Click(object sender, EventArgs e)
        {
            _ActivePanelFemale();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataCorrect())
            {
                return;
            }

            _FillDonorByFieldsData();

            if (_Patient.Save())
            {
                MessageBox.Show("Patient Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "Update Patient";
                this.Tag = "UPDATE PATIENT";
                this._Mode = enMode.Update;

                _Patient._PatientMode = clsPatient.enPatientMode.Update;
                _Patient._PersonMode = clsPerson.enPersonMode.Update;
            }
            else
            {
                MessageBox.Show("Patient Saved Failed.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
