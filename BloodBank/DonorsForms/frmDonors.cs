using BloodBank_BusinessLayer_;
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

namespace BloodBank_WindowsForms_.DonorsForms
{
    public partial class frmDonors : Form
    {

        private Panel _panelChildForm;
        private Label _lblTitleChildForm;

        public frmDonors(Panel panelChildForm, Label lblTitleChildForm)
        {
            InitializeComponent();

            this._panelChildForm = panelChildForm;
            this._lblTitleChildForm = lblTitleChildForm;
        }

        private void _RefreshDonorsList()
        {
            dgvShowDonorsList.DataSource = clsDonor.GetAllDonors();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowDonorsList);
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowDonorsList.Columns.Insert(7, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowDonorsList.Columns.Insert(8, DeleteColumn);

        }

        private void _DeleteProductImageColumn()
        {
            if ((dgvShowDonorsList.Columns.Contains("     "))
                && dgvShowDonorsList.Columns.Count <= 2)
            {
                DataGridViewColumn columnToDelete = dgvShowDonorsList.Columns["     "];
                dgvShowDonorsList.Columns.Remove(columnToDelete);

                columnToDelete = dgvShowDonorsList.Columns["     "];
                dgvShowDonorsList.Columns.Remove(columnToDelete);
            }

            if (dgvShowDonorsList.Columns.Count > 2 && !dgvShowDonorsList.Columns.Contains("     "))
            {
                _AddImagesToDataGridView();
            }
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowDonorsList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowDonorsList.Rows.Count)
            {
                dgvShowDonorsList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void _SearchDataByDonorID(string Data, string BloodGroupName)
        {
            dgvShowDonorsList.DataSource = clsDonor.SearchDonorsContainByDonorID(Data, BloodGroupName);
        }

        private void _SearchDataByDonorName(string Data, string BloodGroupName)
        {
            dgvShowDonorsList.DataSource = clsDonor.SearchDonorsContainByDonorName(Data, BloodGroupName);
        }

        private void _GetAllDonorsWithSpecificBloodGroups(string BloodGroupName)
        {
            dgvShowDonorsList.DataSource = clsDonor.GetAllDonorsWithSpecificBloodGroup(BloodGroupName);
        }

        private void frmDonors_Load(object sender, EventArgs e)
        {
            _RefreshDonorsList();
            _AddImagesToDataGridView();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
            _ChangeSelectionCellInDataGridView();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "DonorID":
                    _SearchDataByDonorID(txtSearch.Text, comboBloodGroups.Text);
                    break;

                case "Name":
                    _SearchDataByDonorName(txtSearch.Text, comboBloodGroups.Text);
                    break;
            }

            _DeleteProductImageColumn();
            _ChangeSelectionCellInDataGridView();
        }

        private void comboBloodGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBloodGroups.Text != "All")
            {
                _GetAllDonorsWithSpecificBloodGroups(comboBloodGroups.Text);
            }
            else
            {
                _RefreshDonorsList();
            }

            _DeleteProductImageColumn();
            _ChangeSelectionCellInDataGridView();
        }

        private void dgvShowDonorsList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //0 : Edit
            //1: Delete
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                dgvShowDonorsList.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowDonorsList.Cursor = Cursors.Default;
            }
        }

        private void dgvShowDonorsList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
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

        private void dgvShowDonorsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int DonorID = (int)dgvShowDonorsList.CurrentRow.Cells["DonorID"].Value;

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                clsOpenChildForm.OpenChildFormInPanel(new frmAddEditDonor(DonorID, this._panelChildForm, this._lblTitleChildForm), this._panelChildForm, this._lblTitleChildForm);

                _RefreshDonorsList();
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Do you really want to delete this Donor?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (clsDonor.DeleteDonor(DonorID))
                    {
                        MessageBox.Show("Donor Deleted Successfully.", "Delete Donor",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Donor Deleted Failed!, This Donor associated with other tables, so you cannot delete it now", "Deleted Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _RefreshDonorsList();

                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmAddEditDonor(-1, this._panelChildForm, this._lblTitleChildForm), this._panelChildForm, this._lblTitleChildForm);

            _RefreshDonorsList();
        }

        private void combobox_MouseEnter(object sender, EventArgs e)
        {
            ((Guna2ComboBox)sender).BorderColor = Color.FromArgb(245, 47, 84);
        }

        private void combobox_MouseLeave(object sender, EventArgs e)
        {
            ((Guna2ComboBox)sender).BorderColor = Color.FromArgb(64, 64, 64);
        }
    }
}
