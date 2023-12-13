namespace BloodBank_WindowsForms_.BloodTransferForms
{
    partial class frmBloodTransfer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTransfer = new Guna.UI2.WinForms.Guna2Button();
            this.lblBloodGroup = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvShowPatientsList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvShowBloodStockList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAvailability = new System.Windows.Forms.Label();
            this.btnViewTransferHistory = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowPatientsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBloodStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTransfer.Animated = true;
            this.btnTransfer.AutoRoundedCorners = true;
            this.btnTransfer.BackColor = System.Drawing.Color.Transparent;
            this.btnTransfer.BorderRadius = 23;
            this.btnTransfer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransfer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTransfer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTransfer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTransfer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTransfer.FillColor = System.Drawing.Color.LimeGreen;
            this.btnTransfer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Location = new System.Drawing.Point(622, 664);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(177, 48);
            this.btnTransfer.TabIndex = 306;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.Visible = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // lblBloodGroup
            // 
            this.lblBloodGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloodGroup.ForeColor = System.Drawing.Color.White;
            this.lblBloodGroup.Location = new System.Drawing.Point(780, 392);
            this.lblBloodGroup.Name = "lblBloodGroup";
            this.lblBloodGroup.Size = new System.Drawing.Size(153, 23);
            this.lblBloodGroup.TabIndex = 305;
            this.lblBloodGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(783, 418);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 2);
            this.panel2.TabIndex = 304;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(477, 392);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(153, 23);
            this.lblName.TabIndex = 303;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(480, 418);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 2);
            this.panel1.TabIndex = 302;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(827, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 301;
            this.label4.Text = "Blood Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(534, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 300;
            this.label3.Text = "Name";
            // 
            // dgvShowPatientsList
            // 
            this.dgvShowPatientsList.AllowUserToAddRows = false;
            this.dgvShowPatientsList.AllowUserToDeleteRows = false;
            this.dgvShowPatientsList.AllowUserToOrderColumns = true;
            this.dgvShowPatientsList.AllowUserToResizeRows = false;
            this.dgvShowPatientsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvShowPatientsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowPatientsList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(45)))));
            this.dgvShowPatientsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShowPatientsList.CausesValidation = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowPatientsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvShowPatientsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowPatientsList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvShowPatientsList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(45)))));
            this.dgvShowPatientsList.Location = new System.Drawing.Point(208, 51);
            this.dgvShowPatientsList.Name = "dgvShowPatientsList";
            this.dgvShowPatientsList.ReadOnly = true;
            this.dgvShowPatientsList.Size = new System.Drawing.Size(618, 302);
            this.dgvShowPatientsList.TabIndex = 299;
            this.dgvShowPatientsList.Click += new System.EventHandler(this.dgvShowPatientsList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(208, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 298;
            this.label2.Text = "Patient List:";
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowBloodStockList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvShowBloodStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowBloodStockList.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvShowBloodStockList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(45)))));
            this.dgvShowBloodStockList.Location = new System.Drawing.Point(918, 51);
            this.dgvShowBloodStockList.Name = "dgvShowBloodStockList";
            this.dgvShowBloodStockList.ReadOnly = true;
            this.dgvShowBloodStockList.Size = new System.Drawing.Size(331, 403);
            this.dgvShowBloodStockList.TabIndex = 297;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(918, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 296;
            this.label1.Text = "Blood Stock:";
            // 
            // lblAvailability
            // 
            this.lblAvailability.AutoSize = true;
            this.lblAvailability.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailability.ForeColor = System.Drawing.Color.Firebrick;
            this.lblAvailability.Location = new System.Drawing.Point(627, 446);
            this.lblAvailability.Name = "lblAvailability";
            this.lblAvailability.Size = new System.Drawing.Size(215, 33);
            this.lblAvailability.TabIndex = 307;
            this.lblAvailability.Text = "Stock is available";
            this.lblAvailability.Visible = false;
            // 
            // btnViewTransferHistory
            // 
            this.btnViewTransferHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewTransferHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.btnViewTransferHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewTransferHistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnViewTransferHistory.FlatAppearance.BorderSize = 2;
            this.btnViewTransferHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewTransferHistory.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnViewTransferHistory.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnViewTransferHistory.IconChar = FontAwesome.Sharp.IconChar.List;
            this.btnViewTransferHistory.IconColor = System.Drawing.Color.Gainsboro;
            this.btnViewTransferHistory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnViewTransferHistory.IconSize = 25;
            this.btnViewTransferHistory.Location = new System.Drawing.Point(1214, 674);
            this.btnViewTransferHistory.Name = "btnViewTransferHistory";
            this.btnViewTransferHistory.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnViewTransferHistory.Size = new System.Drawing.Size(181, 38);
            this.btnViewTransferHistory.TabIndex = 308;
            this.btnViewTransferHistory.Text = "   View Transfer History";
            this.btnViewTransferHistory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewTransferHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewTransferHistory.UseVisualStyleBackColor = false;
            this.btnViewTransferHistory.Click += new System.EventHandler(this.btnViewTransferHistory_Click);
            // 
            // frmBloodTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1407, 724);
            this.Controls.Add(this.btnViewTransferHistory);
            this.Controls.Add(this.lblAvailability);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.lblBloodGroup);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvShowPatientsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvShowBloodStockList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBloodTransfer";
            this.Tag = "BLOOD TRANSFER";
            this.Text = "frmBloodTransfer";
            this.Load += new System.EventHandler(this.frmBloodTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowPatientsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBloodStockList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnTransfer;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvShowPatientsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvShowBloodStockList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAvailability;
        private FontAwesome.Sharp.IconButton btnViewTransferHistory;
    }
}