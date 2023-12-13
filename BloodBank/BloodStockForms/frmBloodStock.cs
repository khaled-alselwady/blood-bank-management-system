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

namespace BloodBank_WindowsForms_.BloodStockForms
{
    public partial class frmBloodStock : Form
    {
        public frmBloodStock()
        {
            InitializeComponent();
        }

        private void _RefreshBloodStockList()
        {
            dgvShowBloodStockList.DataSource = clsBloodGroup.GetAllBloodGroups();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowBloodStockList);
        }

        private void _GetSpecificBloodGroup(string BloodGroupName)
        {
            dgvShowBloodStockList.DataSource = clsBloodGroup.GetSpecificBloodGroup(BloodGroupName);
        }

        private void frmBloodStock_Load(object sender, EventArgs e)
        {
            _RefreshBloodStockList();
        }

        private void combobox_MouseEnter(object sender, EventArgs e)
        {
            ((Guna2ComboBox)sender).BorderColor = Color.FromArgb(245, 47, 84);
        }

        private void combobox_MouseLeave(object sender, EventArgs e)
        {
            ((Guna2ComboBox)sender).BorderColor = Color.FromArgb(64, 64, 64);
        }

        private void comboBloodGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBloodGroups.Text != "All")
            {
                _GetSpecificBloodGroup(comboBloodGroups.Text);
            }
            else
            {
                _RefreshBloodStockList();
            }
        }
    }
}
