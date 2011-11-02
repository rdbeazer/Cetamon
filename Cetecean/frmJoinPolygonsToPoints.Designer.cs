namespace Cetecean
{
    partial class frmJoinPolygonsToPoints
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
            this.grbSaveOptions = new System.Windows.Forms.GroupBox();
            this.chkSaveAs = new System.Windows.Forms.CheckBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.grbPoint = new System.Windows.Forms.GroupBox();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.cmbInput1 = new System.Windows.Forms.ComboBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.grbPolygon = new System.Windows.Forms.GroupBox();
            this.clsFields = new System.Windows.Forms.CheckedListBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.cmbInput2 = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbSaveOptions.SuspendLayout();
            this.grbPoint.SuspendLayout();
            this.grbPolygon.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSaveOptions
            // 
            this.grbSaveOptions.Controls.Add(this.chkSaveAs);
            this.grbSaveOptions.Controls.Add(this.chkSave);
            this.grbSaveOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbSaveOptions.Location = new System.Drawing.Point(12, 302);
            this.grbSaveOptions.Name = "grbSaveOptions";
            this.grbSaveOptions.Size = new System.Drawing.Size(269, 95);
            this.grbSaveOptions.TabIndex = 69;
            this.grbSaveOptions.TabStop = false;
            this.grbSaveOptions.Text = "Save Options";
            // 
            // chkSaveAs
            // 
            this.chkSaveAs.AutoSize = true;
            this.chkSaveAs.Location = new System.Drawing.Point(21, 55);
            this.chkSaveAs.Name = "chkSaveAs";
            this.chkSaveAs.Size = new System.Drawing.Size(230, 30);
            this.chkSaveAs.TabIndex = 1;
            this.chkSaveAs.Text = "Save the updated attributes to a new point \r\nshapefile.";
            this.chkSaveAs.UseVisualStyleBackColor = true;
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Location = new System.Drawing.Point(21, 19);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(226, 30);
            this.chkSave.TabIndex = 0;
            this.chkSave.Text = "Save the updated attributes to the original \r\npoint shapefile.";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Location = new System.Drawing.Point(6, 60);
            this.chbSelectAll.Name = "chbSelectAll";
            this.chbSelectAll.Size = new System.Drawing.Size(70, 17);
            this.chbSelectAll.TabIndex = 23;
            this.chbSelectAll.Text = "Select All";
            this.chbSelectAll.UseVisualStyleBackColor = true;
            this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
            // 
            // grbPoint
            // 
            this.grbPoint.BackColor = System.Drawing.SystemColors.Control;
            this.grbPoint.Controls.Add(this.cmbField);
            this.grbPoint.Controls.Add(this.cmbInput1);
            this.grbPoint.Location = new System.Drawing.Point(12, 12);
            this.grbPoint.Name = "grbPoint";
            this.grbPoint.Size = new System.Drawing.Size(269, 82);
            this.grbPoint.TabIndex = 68;
            this.grbPoint.TabStop = false;
            this.grbPoint.Text = "Point Selection";
            // 
            // cmbField
            // 
            this.cmbField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(21, 49);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(228, 21);
            this.cmbField.TabIndex = 28;
            this.cmbField.Text = "{ select the field with a unique point ID }";
            this.cmbField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // cmbInput1
            // 
            this.cmbInput1.FormattingEnabled = true;
            this.cmbInput1.Location = new System.Drawing.Point(6, 19);
            this.cmbInput1.Name = "cmbInput1";
            this.cmbInput1.Size = new System.Drawing.Size(202, 21);
            this.cmbInput1.TabIndex = 23;
            this.cmbInput1.Text = "{ select point layer }";
            this.cmbInput1.SelectedIndexChanged += new System.EventHandler(this.cmbInput1_SelectedIndexChanged);
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(30, 186);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(0, 13);
            this.lblPoint.TabIndex = 64;
            // 
            // grbPolygon
            // 
            this.grbPolygon.Controls.Add(this.chbSelectAll);
            this.grbPolygon.Controls.Add(this.clsFields);
            this.grbPolygon.Controls.Add(this.lblSelect);
            this.grbPolygon.Controls.Add(this.cmbInput2);
            this.grbPolygon.Location = new System.Drawing.Point(12, 100);
            this.grbPolygon.Name = "grbPolygon";
            this.grbPolygon.Size = new System.Drawing.Size(269, 196);
            this.grbPolygon.TabIndex = 67;
            this.grbPolygon.TabStop = false;
            this.grbPolygon.Text = "Polygon Selection";
            // 
            // clsFields
            // 
            this.clsFields.Location = new System.Drawing.Point(21, 83);
            this.clsFields.Name = "clsFields";
            this.clsFields.Size = new System.Drawing.Size(226, 94);
            this.clsFields.TabIndex = 21;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(3, 44);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(95, 13);
            this.lblSelect.TabIndex = 22;
            this.lblSelect.Text = "Select fields to join";
            // 
            // cmbInput2
            // 
            this.cmbInput2.FormattingEnabled = true;
            this.cmbInput2.Location = new System.Drawing.Point(6, 19);
            this.cmbInput2.Name = "cmbInput2";
            this.cmbInput2.Size = new System.Drawing.Size(199, 21);
            this.cmbInput2.TabIndex = 20;
            this.cmbInput2.Text = "{ select polygon layer }";
            this.cmbInput2.SelectedIndexChanged += new System.EventHandler(this.cmbInput2_SelectedIndexChanged);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCalculate.Location = new System.Drawing.Point(50, 422);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(82, 23);
            this.btnCalculate.TabIndex = 65;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(142, 422);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmJoinPolygonsToPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 474);
            this.Controls.Add(this.grbSaveOptions);
            this.Controls.Add(this.grbPoint);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.grbPolygon);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmJoinPolygonsToPoints";
            this.Text = "Join Polygons To Points";
            this.Load += new System.EventHandler(this.frmJoinPolygonsToPoints_Load);
            this.grbSaveOptions.ResumeLayout(false);
            this.grbSaveOptions.PerformLayout();
            this.grbPoint.ResumeLayout(false);
            this.grbPolygon.ResumeLayout(false);
            this.grbPolygon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSaveOptions;
        private System.Windows.Forms.CheckBox chkSaveAs;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.CheckBox chbSelectAll;
        private System.Windows.Forms.GroupBox grbPoint;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.ComboBox cmbInput1;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.GroupBox grbPolygon;
        private System.Windows.Forms.CheckedListBox clsFields;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.ComboBox cmbInput2;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnCancel;
    }
}