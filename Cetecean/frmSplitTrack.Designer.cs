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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cbxSave = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(125, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSplit
            // 
            this.btnSplit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSplit.Enabled = false;
            this.btnSplit.Location = new System.Drawing.Point(33, 243);
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
            this.lblLine.Size = new System.Drawing.Size(123, 13);
            this.lblLine.TabIndex = 8;
            this.lblLine.Text = "Select survey track layer";
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
            this.lblGrid.Size = new System.Drawing.Size(82, 13);
            this.lblGrid.TabIndex = 6;
            this.lblGrid.Text = "Select grid layer";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInput);
            this.groupBox2.Controls.Add(this.cbxSave);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 91);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output ";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(22, 37);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(155, 20);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "split_tracks";
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbxSave
            // 
            this.cbxSave.AutoSize = true;
            this.cbxSave.Checked = true;
            this.cbxSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSave.Location = new System.Drawing.Point(25, 63);
            this.cbxSave.Name = "cbxSave";
            this.cbxSave.Size = new System.Drawing.Size(122, 17);
            this.cbxSave.TabIndex = 3;
            this.cbxSave.Text = "Save point shapefile";
            this.cbxSave.UseVisualStyleBackColor = true;
            this.cbxSave.CheckedChanged += new System.EventHandler(this.cbxSave_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enter an output layer name:";
            // 
            // frmSplitTrack
            // 
            this.AcceptButton = this.btnSplit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 293);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSplit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplitTrack";
            this.Text = "Split Survey Tracks by Grid";
            this.Load += new System.EventHandler(this.frmSplitTrack_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.CheckBox cbxSave;
        private System.Windows.Forms.Label label2;
    }
}