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
    public partial class frmViewTransferHistory : Form
    {
        public frmViewTransferHistory()
        {
            InitializeComponent();
        }

        private void _RefreshTransferList()
        {
            dgvShowTransferList.DataSource = clsTransfer.GetAllTransfer();
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowTransferList);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmViewTransferHistory_Load(object sender, EventArgs e)
        {
            _RefreshTransferList();
        }
    }
}
