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
            this.cmbInputGrid = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrack = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInputTrack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTrackLength = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTrackID = new System.Windows.Forms.ComboBox();
            this.grbSaveOptions = new System.Windows.Forms.GroupBox();
            this.radSession = new System.Windows.Forms.RadioButton();
            this.radNewShape = new System.Windows.Forms.RadioButton();
            this.radOriginal = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbSaveOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(143, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCalculate.Enabled = false;
            this.btnCalculate.Location = new System.Drawing.Point(37, 415);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 23);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // cmbTrack
            // 
            this.cmbTrack.FormattingEnabled = true;
            this.cmbTrack.Location = new System.Drawing.Point(19, 19);
            this.cmbTrack.Name = "cmbTrack";
            this.cmbTrack.Size = new System.Drawing.Size(185, 21);
            this.cmbTrack.TabIndex = 10;
            this.cmbTrack.Text = "Select Track Layer";
            this.cmbTrack.SelectedIndexChanged += new System.EventHandler(this.cmbLine_SelectedIndexChanged);
            // 
            // cmbInputGrid
            // 
            this.cmbInputGrid.FormattingEnabled = true;
            this.cmbInputGrid.Location = new System.Drawing.Point(19, 19);
            this.cmbInputGrid.Name = "cmbInputGrid";
            this.cmbInputGrid.Size = new System.Drawing.Size(185, 21);
            this.cmbInputGrid.TabIndex = 7;
            this.cmbInputGrid.Text = "Select Grid Layer to Update";
            this.cmbInputGrid.SelectedIndexChanged += new System.EventHandler(this.cmbGrid_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTrack);
            this.groupBox1.Controls.Add(this.cmbInputGrid);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 104);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input grid layer to be updated:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Enter field name to hold effort value:";
            // 
            // txtTrack
            // 
            this.txtTrack.Location = new System.Drawing.Point(64, 70);
            this.txtTrack.Name = "txtTrack";
            this.txtTrack.Size = new System.Drawing.Size(170, 20);
            this.txtTrack.TabIndex = 8;
            this.txtTrack.Text = "trackEffort";
            this.txtTrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInputTrack);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbTrackLength);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbTrackID);
            this.groupBox2.Controls.Add(this.cmbTrack);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 149);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input survey track layer";
            // 
            // btnInputTrack
            // 
            this.btnInputTrack.Location = new System.Drawing.Point(243, 17);
            this.btnInputTrack.Name = "btnInputTrack";
            this.btnInputTrack.Size = new System.Drawing.Size(21, 23);
            this.btnInputTrack.TabIndex = 15;
            this.btnInputTrack.Text = "?";
            this.btnInputTrack.UseVisualStyleBackColor = true;
            this.btnInputTrack.Click += new System.EventHandler(this.btnInputTrack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Select track length field:";
            // 
            // cmbTrackLength
            // 
            this.cmbTrackLength.FormattingEnabled = true;
            this.cmbTrackLength.Location = new System.Drawing.Point(55, 115);
            this.cmbTrackLength.Name = "cmbTrackLength";
            this.cmbTrackLength.Size = new System.Drawing.Size(185, 21);
            this.cmbTrackLength.TabIndex = 13;
            this.cmbTrackLength.Text = "Select Length Field";
            this.cmbTrackLength.SelectedIndexChanged += new System.EventHandler(this.cmbTrackArea_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Select field with input grid ID:";
            // 
            // cmbTrackID
            // 
            this.cmbTrackID.FormattingEnabled = true;
            this.cmbTrackID.Location = new System.Drawing.Point(55, 65);
            this.cmbTrackID.Name = "cmbTrackID";
            this.cmbTrackID.Size = new System.Drawing.Size(185, 21);
            this.cmbTrackID.TabIndex = 11;
            this.cmbTrackID.Text = "Select Grid ID";
            this.cmbTrackID.SelectedIndexChanged += new System.EventHandler(this.cmbTrackID_SelectedIndexChanged);
            // 
            // grbSaveOptions
            // 
            this.grbSaveOptions.Controls.Add(this.radSession);
            this.grbSaveOptions.Controls.Add(this.radNewShape);
            this.grbSaveOptions.Controls.Add(this.radOriginal);
            this.grbSaveOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbSaveOptions.Location = new System.Drawing.Point(12, 291);
            this.grbSaveOptions.Name = "grbSaveOptions";
            this.grbSaveOptions.Size = new System.Drawing.Size(270, 118);
            this.grbSaveOptions.TabIndex = 67;
            this.grbSaveOptions.TabStop = false;
            this.grbSaveOptions.Text = "Save Options";
            // 
            // radSession
            // 
            this.radSession.AutoSize = true;
            this.radSession.Location = new System.Drawing.Point(19, 91);
            this.radSession.Name = "radSession";
            this.radSession.Size = new System.Drawing.Size(199, 17);
            this.radSession.TabIndex = 69;
            this.radSession.Text = "Update grid layer for this session only";
            this.radSession.UseVisualStyleBackColor = true;
            // 
            // radNewShape
            // 
            this.radNewShape.AutoSize = true;
            this.radNewShape.Location = new System.Drawing.Point(19, 55);
            this.radNewShape.Name = "radNewShape";
            this.radNewShape.Size = new System.Drawing.Size(180, 30);
            this.radNewShape.TabIndex = 68;
            this.radNewShape.Text = "Save the updated attributes to a \r\nNEW grid shapefile";
            this.radNewShape.UseVisualStyleBackColor = true;
            // 
            // radOriginal
            // 
            this.radOriginal.AutoSize = true;
            this.radOriginal.Checked = true;
            this.radOriginal.Location = new System.Drawing.Point(19, 19);
            this.radOriginal.Name = "radOriginal";
            this.radOriginal.Size = new System.Drawing.Size(189, 30);
            this.radOriginal.TabIndex = 67;
            this.radOriginal.TabStop = true;
            this.radOriginal.Text = "Save the updated attributes to the \r\nORIGINAL grid shapefile";
            this.radOriginal.UseVisualStyleBackColor = true;
            // 
            // frmPolyEffortByGrid
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 457);
            this.Controls.Add(this.grbSaveOptions);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalculate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPolyEffortByGrid";
            this.Text = "Survey Effort by Grid (Tracks)";
            this.Load += new System.EventHandler(this.frmPolyEffortByGrid_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbSaveOptions.ResumeLayout(false);
            this.grbSaveOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ComboBox cmbTrack;
        private System.Windows.Forms.ComboBox cmbInputGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbTrackID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTrackLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrack;
        private System.Windows.Forms.Button btnInputTrack;
        private System.Windows.Forms.GroupBox grbSaveOptions;
        private System.Windows.Forms.RadioButton radSession;
        private System.Windows.Forms.RadioButton radNewShape;
        private System.Windows.Forms.RadioButton radOriginal;
    }
}