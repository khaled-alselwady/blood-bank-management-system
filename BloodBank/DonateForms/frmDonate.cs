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

namespace BloodBank_WindowsForms_.DonateForms
{
    public partial class frmDonate : Form
    {
        public frmDonate()
        {
            InitializeComponent();
        }

        private void _RefreshBloodStockList()
        {
            dgvShowBloodStockList.DataSource = clsBloodGroup.GetAllBloodGroups();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowBloodStockList);
        }

        private void _RefreshDonorsList()
        {
            dgvShowDonorsList.DataSource = clsDonor.GetAllDonors();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowDonorsList);
        }

        private void frmDonate_Load(object sender, EventArgs e)
        {
            _RefreshBloodStockList();
            _RefreshDonorsList();
        }

        private void dgvShowDonorsList_Click(object sender, EventArgs e)
        {
            if ((dgvShowDonorsList.Rows.Count > 0) && dgvShowDonorsList.CurrentCell != null)
            {
                lblName.Text = (string)dgvShowDonorsList.CurrentRow.Cells["Name"].Value;
                lblBloodGroup.Text = (string)dgvShowDonorsList.CurrentRow.Cells["BloodGroupName"].Value;
            }
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblName.Text) ||
                string.IsNullOrWhiteSpace(lblBloodGroup.Text))
            {
                MessageBox.Show("You have to choose the donor who will donate first!", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            clsBloodGroup BloodGroup = clsBloodGroup.Find(lblBloodGroup.Text);

            if (BloodGroup != null)
            {
                BloodGroup.QuantityInStock++;

                if (BloodGroup.Save())
                {
                    MessageBox.Show("Donation Completed Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblName.Text = string.Empty;
                    lblBloodGroup.Text = string.Empty;

                    _RefreshBloodStockList();
                }
                else
                {
                    MessageBox.Show("Donation Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Donation Failed", "Failed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
