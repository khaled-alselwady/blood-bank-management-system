using BloodBank_BusinessLayer_;
using BloodBank_WindowsForms_.DonorsForms;
using BloodBank_WindowsForms_.Properties;
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

namespace BloodBank_WindowsForms_.PatientForms
{
    public partial class frmPatients : Form
    {

        private Panel _panelChildForm;
        private Label _lblTitleChildForm;

        public frmPatients(Panel panelChildForm, Label lblTitleChildForm)
        {
            InitializeComponent();

            this._panelChildForm = panelChildForm;
            this._lblTitleChildForm = lblTitleChildForm;
        }

        private void _RefreshDonorsList()
        {
            dgvShowPatientsList.DataSource = clsPatient.GetAllPatient();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowPatientsList);
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowPatientsList.Columns.Insert(7, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowPatientsList.Columns.Insert(8, DeleteColumn);

        }

        private void _DeleteProductImageColumn()
        {
            if ((dgvShowPatientsList.Columns.Contains("     "))
                && dgvShowPatientsList.Columns.Count <= 2)
            {
                DataGridViewColumn columnToDelete = dgvShowPatientsList.Columns["     "];
                dgvShowPatientsList.Columns.Remove(columnToDelete);

                columnToDelete = dgvShowPatientsList.Columns["     "];
                dgvShowPatientsList.Columns.Remove(columnToDelete);
            }

            if (dgvShowPatientsList.Columns.Count > 2 && !dgvShowPatientsList.Columns.Contains("     "))
            {
                _AddImagesToDataGridView();
            }
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowPatientsList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowPatientsList.Rows.Count)
            {
                dgvShowPatientsList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void _SearchDataByPatientID(string Data, string BloodGroupName)
        {
            dgvShowPatientsList.DataSource = clsPatient.SearchPatientsContainByPatientID(Data, BloodGroupName);
        }

        private void _SearchDataByPatientName(string Data, string BloodGroupName)
        {
            dgvShowPatientsList.DataSource = clsPatient.SearchPatientsContainByPatientName(Data, BloodGroupName);
        }

        private void _GetAllPatientsWithSpecificBloodGroups(string BloodGroupName)
        {
            dgvShowPatientsList.DataSource = clsPatient.GetAllPatientsWithSpecificBloodGroup(BloodGroupName);
        }

        private void combobox_MouseEnter(object sender, EventArgs e)
        {
            ((Guna2ComboBox)sender).BorderColor = Color.FromArgb(245, 47, 84);
        }

        private void combobox_MouseLeave(object sender, EventArgs e)
        {
            ((Guna2ComboBox)sender).BorderColor = Color.FromArgb(64, 64, 64);
        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            _RefreshDonorsList();
            _AddImagesToDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "PatientID":
                    _SearchDataByPatientID(txtSearch.Text, comboBloodGroups.Text);
                    break;

                case "Name":
                    _SearchDataByPatientName(txtSearch.Text, comboBloodGroups.Text);
                    break;
            }

            _DeleteProductImageColumn();
            _ChangeSelectionCellInDataGridView();
        }

        private void comboBloodGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBloodGroups.Text != "All")
            {
                _GetAllPatientsWithSpecificBloodGroups(comboBloodGroups.Text);
            }
            else
            {
                _RefreshDonorsList();
            }

            _DeleteProductImageColumn();
            _ChangeSelectionCellInDataGridView();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
            _ChangeSelectionCellInDataGridView();
        }

        private void dgvShowPatientsList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //0 : Edit
            //1: Delete
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                dgvShowPatientsList.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowPatientsList.Cursor = Cursors.Default;
            }
        }

        private void dgvShowPatientsList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Edit";
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Delete";
            }
        }

        private void dgvShowPatientsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int PatientID = (int)dgvShowPatientsList.CurrentRow.Cells["PatientID"].Value;

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                clsOpenChildForm.OpenChildFormInPanel(new frmAddEditPatient(PatientID, this._panelChildForm, this._lblTitleChildForm), this._panelChildForm, this._lblTitleChildForm);

                _RefreshDonorsList();
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Do you really want to delete this Patient?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (clsPatient.DeletePatient(PatientID))
                    {
                        MessageBox.Show("Patient Deleted Successfully.", "Delete Patient",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Patient Deleted Failed!, This Patient associated with other tables, so you cannot delete it now", "Deleted Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _RefreshDonorsList();

                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmAddEditPatient(-1, this._panelChildForm, this._lblTitleChildForm), this._panelChildForm, this._lblTitleChildForm);

            _RefreshDonorsList();
        }
    }
}
