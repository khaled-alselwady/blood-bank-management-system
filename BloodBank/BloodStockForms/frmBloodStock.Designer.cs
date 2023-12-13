namespace BloodBank_WindowsForms_.BloodStockForms
{
    partial class frmBloodStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBloodGroups = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvShowBloodStockList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBloodStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBloodGroups
            // 
            this.comboBloodGroups.AutoRoundedCorners = true;
            this.comboBloodGroups.BackColor = System.Drawing.Color.White;
            this.comboBloodGroups.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBloodGroups.BorderRadius = 17;
            this.comboBloodGroups.BorderThickness = 2;
            this.comboBloodGroups.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBloodGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBloodGroups.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.comboBloodGroups.FocusedColor = System.Drawing.Color.Empty;
            this.comboBloodGroups.FocusedState.ForeColor = System.Drawing.Color.White;
            this.comboBloodGroups.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.comboBloodGroups.ForeColor = System.Drawing.Color.White;
            this.comboBloodGroups.ItemHeight = 30;
            this.comboBloodGroups.Items.AddRange(new object[] {
            "All",
            "A+",
            "B+",
            "AB+",
            "O+",
            "A-",
            "B-",
            "AB-",
            "O-"});
            this.comboBloodGroups.ItemsAppearance.BackColor = System.Drawing.Color.White;
            this.comboBloodGroups.ItemsAppearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBloodGroups.ItemsAppearance.ForeColor = System.Drawing.Color.Black;
            this.comboBloodGroups.Location = new System.Drawing.Point(252, 12);
            this.comboBloodGroups.Name = "comboBloodGroups";
            this.comboBloodGroups.Size = new System.Drawing.Size(75, 36);
            this.comboBloodGroups.StartIndex = 0;
            this.comboBloodGroups.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.comboBloodGroups.TabIndex = 121;
            this.comboBloodGroups.SelectedIndexChanged += new System.EventHandler(this.comboBloodGroups_SelectedIndexChanged);
            this.comboBloodGroups.MouseEnter += new System.EventHandler(this.combobox_MouseEnter);
            this.comboBloodGroups.MouseLeave += new System.EventHandler(this.combobox_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(203, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 120;
            this.label2.Text = "Filter:";
            // 
            // dgvShowBloodStockList
            // 
            this.dgvShowBloodStockList.AllowUserToAddRows = false;
            this.dgvShowBloodStockList.AllowUserToDeleteRows = false;
            this.dgvShowBloodStockList.AllowUserToOrderColumns = true;
            this.dgvShowBloodStockList.AllowUserToResizeRows = false;
            this.dgvShowBloodStockList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvShowBloodStockList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowBloodStockList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(45)))));
            this.dgvShowBloodStockList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShowBloodStockList.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowBloodStockList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowBloodStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowBloodStockList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShowBloodStockList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(45)))));
            this.dgvShowBloodStockList.Location = new System.Drawing.Point(203, 70);
            this.dgvShowBloodStockList.Name = "dgvShowBloodStockList";
            this.dgvShowBloodStockList.ReadOnly = true;
            this.dgvShowBloodStockList.Size = new System.Drawing.Size(616, 311);
            this.dgvShowBloodStockList.TabIndex = 115;
            // 
            // frmBloodStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(904, 573);
            this.Controls.Add(this.comboBloodGroups);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvShowBloodStockList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBloodStock";
            this.Tag = "BLOOD STOCK";
            this.Text = "frmBloodStock";
            this.Load += new System.EventHandler(this.frmBloodStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBloodStockList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox comboBloodGroups;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvShowBloodStockList;
    }
}