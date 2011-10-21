namespace Cetecean
{
    partial class frmSplitTrack
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSplit = new System.Windows.Forms.Button();
            this.cmbLine = new System.Windows.Forms.ComboBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.cmbGrid = new System.Windows.Forms.ComboBox();
            this.lblGrid = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(150, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSplit
            // 
            this.btnSplit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSplit.Location = new System.Drawing.Point(38, 115);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(86, 23);
            this.btnSplit.TabIndex = 9;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click_1);
            // 
            // cmbLine
            // 
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.Location = new System.Drawing.Point(38, 78);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(199, 21);
            this.cmbLine.TabIndex = 10;
            this.cmbLine.SelectedIndexChanged += new System.EventHandler(this.cmbLine_SelectedIndexChanged);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(12, 61);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(133, 13);
            this.lblLine.TabIndex = 8;
            this.lblLine.Text = "Select Survey Track Layer";
            // 
            // cmbGrid
            // 
            this.cmbGrid.FormattingEnabled = true;
            this.cmbGrid.Location = new System.Drawing.Point(38, 26);
            this.cmbGrid.Name = "cmbGrid";
            this.cmbGrid.Size = new System.Drawing.Size(199, 21);
            this.cmbGrid.TabIndex = 7;
            this.cmbGrid.SelectedIndexChanged += new System.EventHandler(this.cmbGrid_SelectedIndexChanged);
            // 
            // lblGrid
            // 
            this.lblGrid.AutoSize = true;
            this.lblGrid.Location = new System.Drawing.Point(12, 9);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(88, 13);
            this.lblGrid.TabIndex = 6;
            this.lblGrid.Text = "Select Grid Layer";
            // 
            // frmSplitTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 157);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.cmbLine);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.cmbGrid);
            this.Controls.Add(this.lblGrid);
            this.Name = "frmSplitTrack";
            this.Text = "Split Survey Tracks by Grid";
            this.Load += new System.EventHandler(this.frmSplitTrack_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.ComboBox cmbLine;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.ComboBox cmbGrid;
        private System.Windows.Forms.Label lblGrid;
    }
}