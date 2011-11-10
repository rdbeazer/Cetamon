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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbSaveOptions = new System.Windows.Forms.GroupBox();
            this.radSession = new System.Windows.Forms.RadioButton();
            this.radNewShape = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.grbSaveOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(127, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSplit
            // 
            this.btnSplit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSplit.Location = new System.Drawing.Point(35, 234);
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
            this.cmbLine.Location = new System.Drawing.Point(36, 101);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(166, 21);
            this.cmbLine.TabIndex = 10;
            this.cmbLine.Text = "Select input track layer";
            this.cmbLine.SelectedIndexChanged += new System.EventHandler(this.cmbLine_SelectedIndexChanged);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(10, 84);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(133, 13);
            this.lblLine.TabIndex = 8;
            this.lblLine.Text = "Select Survey Track Layer";
            // 
            // cmbGrid
            // 
            this.cmbGrid.FormattingEnabled = true;
            this.cmbGrid.Location = new System.Drawing.Point(32, 46);
            this.cmbGrid.Name = "cmbGrid";
            this.cmbGrid.Size = new System.Drawing.Size(170, 21);
            this.cmbGrid.TabIndex = 7;
            this.cmbGrid.Text = "Select grid input layer";
            this.cmbGrid.SelectedIndexChanged += new System.EventHandler(this.cmbGrid_SelectedIndexChanged);
            // 
            // lblGrid
            // 
            this.lblGrid.AutoSize = true;
            this.lblGrid.Location = new System.Drawing.Point(6, 29);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(88, 13);
            this.lblGrid.TabIndex = 6;
            this.lblGrid.Text = "Select Grid Layer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLine);
            this.groupBox1.Controls.Add(this.cmbLine);
            this.groupBox1.Controls.Add(this.lblGrid);
            this.groupBox1.Controls.Add(this.cmbGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 128);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Shapefiles";
            // 
            // grbSaveOptions
            // 
            this.grbSaveOptions.Controls.Add(this.radSession);
            this.grbSaveOptions.Controls.Add(this.radNewShape);
            this.grbSaveOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbSaveOptions.Location = new System.Drawing.Point(12, 145);
            this.grbSaveOptions.Name = "grbSaveOptions";
            this.grbSaveOptions.Size = new System.Drawing.Size(224, 72);
            this.grbSaveOptions.TabIndex = 67;
            this.grbSaveOptions.TabStop = false;
            this.grbSaveOptions.Text = "Save Options";
            // 
            // radSession
            // 
            this.radSession.AutoSize = true;
            this.radSession.Location = new System.Drawing.Point(13, 42);
            this.radSession.Name = "radSession";
            this.radSession.Size = new System.Drawing.Size(189, 17);
            this.radSession.TabIndex = 69;
            this.radSession.Text = "Split the tracks for this session only";
            this.radSession.UseVisualStyleBackColor = true;
            // 
            // radNewShape
            // 
            this.radNewShape.AutoSize = true;
            this.radNewShape.Checked = true;
            this.radNewShape.Location = new System.Drawing.Point(13, 19);
            this.radNewShape.Name = "radNewShape";
            this.radNewShape.Size = new System.Drawing.Size(124, 17);
            this.radNewShape.TabIndex = 68;
            this.radNewShape.TabStop = true;
            this.radNewShape.Text = "Save the split tracks ";
            this.radNewShape.UseVisualStyleBackColor = true;
            // 
            // frmSplitTrack
            // 
            this.AcceptButton = this.btnSplit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 274);
            this.Controls.Add(this.grbSaveOptions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSplit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplitTrack";
            this.Text = "Split Survey Tracks by Grid";
            this.Load += new System.EventHandler(this.frmSplitTrack_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbSaveOptions.ResumeLayout(false);
            this.grbSaveOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.ComboBox cmbLine;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.ComboBox cmbGrid;
        private System.Windows.Forms.Label lblGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grbSaveOptions;
        private System.Windows.Forms.RadioButton radSession;
        private System.Windows.Forms.RadioButton radNewShape;
    }
}