namespace Cetecean
{
    partial class frmPolyEffortByGrid
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.cmbTrack = new System.Windows.Forms.ComboBox();
            this.cmbGrid = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbGridID = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTrackID = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(130, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCalculate.Location = new System.Drawing.Point(38, 203);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(86, 23);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // cmbTrack
            // 
            this.cmbTrack.FormattingEnabled = true;
            this.cmbTrack.Location = new System.Drawing.Point(17, 31);
            this.cmbTrack.Name = "cmbTrack";
            this.cmbTrack.Size = new System.Drawing.Size(173, 21);
            this.cmbTrack.TabIndex = 10;
            this.cmbTrack.Text = "Select Track Layer";
            this.cmbTrack.SelectedIndexChanged += new System.EventHandler(this.cmbLine_SelectedIndexChanged);
            // 
            // cmbGrid
            // 
            this.cmbGrid.FormattingEnabled = true;
            this.cmbGrid.Location = new System.Drawing.Point(20, 19);
            this.cmbGrid.Name = "cmbGrid";
            this.cmbGrid.Size = new System.Drawing.Size(169, 21);
            this.cmbGrid.TabIndex = 7;
            this.cmbGrid.Text = "Select Grid Layer to Update";
            this.cmbGrid.SelectedIndexChanged += new System.EventHandler(this.cmbGrid_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbGridID);
            this.groupBox1.Controls.Add(this.cmbGrid);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 89);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid Selection";
            // 
            // cmbGridID
            // 
            this.cmbGridID.FormattingEnabled = true;
            this.cmbGridID.Location = new System.Drawing.Point(20, 47);
            this.cmbGridID.Name = "cmbGridID";
            this.cmbGridID.Size = new System.Drawing.Size(169, 21);
            this.cmbGridID.TabIndex = 8;
            this.cmbGridID.Text = "Select Grid ID";
            this.cmbGridID.SelectedIndexChanged += new System.EventHandler(this.cmbGridID_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbTrackID);
            this.groupBox2.Controls.Add(this.cmbTrack);
            this.groupBox2.Location = new System.Drawing.Point(11, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 95);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Track Selection";
            // 
            // cmbTrackID
            // 
            this.cmbTrackID.FormattingEnabled = true;
            this.cmbTrackID.Location = new System.Drawing.Point(17, 59);
            this.cmbTrackID.Name = "cmbTrackID";
            this.cmbTrackID.Size = new System.Drawing.Size(173, 21);
            this.cmbTrackID.TabIndex = 11;
            this.cmbTrackID.Text = "Select Grid ID";
            this.cmbTrackID.SelectedIndexChanged += new System.EventHandler(this.cmbTrackID_SelectedIndexChanged);
            // 
            // frmPolyEffortByGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 248);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalculate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPolyEffortByGrid";
            this.Text = "Calculate Survey Effort by Grid";
            this.Load += new System.EventHandler(this.frmPolyEffortByGrid_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ComboBox cmbTrack;
        private System.Windows.Forms.ComboBox cmbGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbGridID;
        private System.Windows.Forms.ComboBox cmbTrackID;
    }
}