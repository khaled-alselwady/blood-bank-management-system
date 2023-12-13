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

namespace BloodBank_WindowsForms_.BloodTransferForms
{
    public partial class frmBloodTransfer : Form
    {
        public frmBloodTransfer()
        {
            InitializeComponent();
        }

        private void _RefreshPatientsList()
        {
            dgvShowPatientsList.DataSource = clsPatient.GetAllPatient();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowPatientsList);
        }

        private void _RefreshBloodStockList()
        {
            dgvShowBloodStockList.DataSource = clsBloodGroup.GetAllBloodGroups();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowBloodStockList);
        }

        private void _RefreshAvailability()
        {
            clsBloodGroup BloodGroup = clsBloodGroup.Find(lblBloodGroup.Text);

            if (BloodGroup != null)
            {
                lblAvailability.Visible = true;

                if (BloodGroup.QuantityInStock > 0)
                {
                    lblAvailability.Text = "Stock is available";
                    lblAvailability.ForeColor = Color.LawnGreen;

                    btnTransfer.Visible = true;
                }
                else
                {
                    lblAvailability.Text = "Stock is not available";
                    lblAvailability.ForeColor = Color.Firebrick;

                    btnTransfer.Visible = false;
                }
            }
        }

        private void _AddTransferRecord()
        {
            clsTransfer Transfer = new clsTransfer();

            Transfer.PatientID = (int)dgvShowPatientsList.CurrentRow.Cells["PatientID"].Value;
            Transfer.BloodGroupName = lblBloodGroup.Text;
            Transfer.TransferDate = DateTime.Now;

            Transfer.Save();
        }

        private void frmBloodTransfer_Load(object sender, EventArgs e)
        {
            _RefreshPatientsList();
            _RefreshBloodStockList();
        }

        private void dgvShowPatientsList_Click(object sender, EventArgs e)
        {
            if ((dgvShowPatientsList.Rows.Count > 0) && dgvShowPatientsList.CurrentCell != null)
            {
                string BloodGroupName = (string)dgvShowPatientsList.CurrentRow.Cells["BloodGroupName"].Value;

                lblName.Text = (string)dgvShowPatientsList.CurrentRow.Cells["Name"].Value;
                lblBloodGroup.Text = BloodGroupName;

                _RefreshAvailability();
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblName.Text) ||
                string.IsNullOrWhiteSpace(lblBloodGroup.Text))
            {
                MessageBox.Show("You have to choose the patient to whom the blood will be transfused first!", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            clsBloodGroup BloodGroup = clsBloodGroup.Find(lblBloodGroup.Text);

            if (BloodGroup != null)
            {
                BloodGroup.QuantityInStock--;

                if (BloodGroup.Save())
                {
                    MessageBox.Show("Transfer Completed Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshAvailability();

                    _AddTransferRecord();

                    lblName.Text = string.Empty;
                    lblBloodGroup.Text = string.Empty;

                    _RefreshBloodStockList();                    
                }
                else
                {
                    MessageBox.Show("Transfer Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Transfer Failed", "Failed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewTransferHistory_Click(object sender, EventArgs e)
        {
            frmViewTransferHistory ViewTransfer = new frmViewTransferHistory();
            ViewTransfer.ShowDialog();
        }
    }
}
