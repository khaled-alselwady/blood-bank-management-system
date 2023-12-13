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

namespace BloodBank_WindowsForms_.AdminMainMenu
{
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
        }

        private void _RefreshEmployeesList()
        {
            dgvShowEmployeesList.DataSource = clsEmployee.GetAllEmployees();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowEmployeesList);
        }

        private void _AddImagesToDataGridView()
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowEmployeesList.Columns.Insert(3, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowEmployeesList.Columns.Insert(4, DeleteColumn);

        }

        private void _DeleteProductImageColumn()
        {
            if ((dgvShowEmployeesList.Columns.Contains("     "))
                && dgvShowEmployeesList.Columns.Count <= 2)
            {
                DataGridViewColumn columnToDelete = dgvShowEmployeesList.Columns["     "];
                dgvShowEmployeesList.Columns.Remove(columnToDelete);

                columnToDelete = dgvShowEmployeesList.Columns["     "];
                dgvShowEmployeesList.Columns.Remove(columnToDelete);
            }

            if (dgvShowEmployeesList.Columns.Count > 2 && !dgvShowEmployeesList.Columns.Contains("     "))
            {
                _AddImagesToDataGridView();
            }
        }

        private void _ChangeSelectionCellInDataGridView()
        {
            dgvShowEmployeesList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowEmployeesList.Rows.Count)
            {
                dgvShowEmployeesList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        private void _SearchEmployeesByEmployeeID(string Date)
        {
            dgvShowEmployeesList.DataSource = clsEmployee.SearchEmployeesContainByEmployeeID(Date);
        }

        private void _SearchEmployeesByUsername(string Date)
        {
            dgvShowEmployeesList.DataSource = clsEmployee.SearchEmployeesContainByUsername(Date);
        }

        private void dgvShowEmployeesList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
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

        private void dgvShowEmployeesList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //0 : Edit
            //1: Delete
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                dgvShowEmployeesList.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowEmployeesList.Cursor = Cursors.Default;
            }
        }

        private void dgvShowEmployeesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int EmployeeID = (int)dgvShowEmployeesList.CurrentRow.Cells["EmployeeID"].Value;

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                frmAddEditEmployee AddNewEmployee = new frmAddEditEmployee(EmployeeID);
                AddNewEmployee.ShowDialog();

                _RefreshEmployeesList();
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Do you really want to delete this Employee?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (clsEmployee.DeleteEmployee(EmployeeID))
                    {
                        MessageBox.Show("Employee Deleted Successfully.", "Delete Donor",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Employee Deleted Failed!", "Deleted Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _RefreshEmployeesList();

                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "EmployeeID":
                    _SearchEmployeesByEmployeeID(txtSearch.Text);
                    break;

                case "Username":
                    _SearchEmployeesByUsername(txtSearch.Text);
                    break;
            }


            _DeleteProductImageColumn();
            _ChangeSelectionCellInDataGridView();

        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
            _ChangeSelectionCellInDataGridView();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditEmployee AddNewEmployee = new frmAddEditEmployee(-1);
            AddNewEmployee.ShowDialog();

            _RefreshEmployeesList();
        }

        private void combobox_MouseEnter(object sender, EventArgs e)
        {
            ((Guna2ComboBox)sender).BorderColor = Color.FromArgb(245, 47, 84);
        }

        private void combobox_MouseLeave(object sender, EventArgs e)
        {
            ((Guna2ComboBox)sender).BorderColor = Color.FromArgb(64, 64, 64);
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            _RefreshEmployeesList();
            _AddImagesToDataGridView();
        }
    }
}
