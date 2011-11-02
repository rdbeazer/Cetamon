namespace Cetecean
{
    partial class frmJoinPointsToPolygons
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
            this.grbPoint = new System.Windows.Forms.GroupBox();
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.clsFields = new System.Windows.Forms.CheckedListBox();
            this.cmbInput2 = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.grbPolygon = new System.Windows.Forms.GroupBox();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.cmbInput1 = new System.Windows.Forms.ComboBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.grbSaveOptions = new System.Windows.Forms.GroupBox();
            this.chkSaveAs = new System.Windows.Forms.CheckBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.grbPoint.SuspendLayout();
            this.grbPolygon.SuspendLayout();
            this.grbSaveOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPoint
            // 
            this.grbPoint.Controls.Add(this.chbSelectAll);
            this.grbPoint.Controls.Add(this.lblSelect);
            this.grbPoint.Controls.Add(this.clsFields);
            this.grbPoint.Controls.Add(this.cmbInput2);
            this.grbPoint.Location = new System.Drawing.Point(12, 103);
            this.grbPoint.Name = "grbPoint";
            this.grbPoint.Size = new System.Drawing.Size(269, 202);
            this.grbPoint.TabIndex = 52;
            this.grbPoint.TabStop = false;
            this.grbPoint.Text = "Point Selection";
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Location = new System.Drawing.Point(9, 76);
            this.chbSelectAll.Name = "chbSelectAll";
            this.chbSelectAll.Size = new System.Drawing.Size(70, 17);
            this.chbSelectAll.TabIndex = 29;
            this.chbSelectAll.Text = "Select All";
            this.chbSelectAll.UseVisualStyleBackColor = true;
            this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(6, 59);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(89, 13);
            this.lblSelect.TabIndex = 28;
            this.lblSelect.Text = "Select Join Fields";
            // 
            // clsFields
            // 
            this.clsFields.Location = new System.Drawing.Point(21, 99);
            this.clsFields.Name = "clsFields";
            this.clsFields.Size = new System.Drawing.Size(228, 94);
            this.clsFields.TabIndex = 27;
            // 
            // cmbInput2
            // 
            this.cmbInput2.FormattingEnabled = true;
            this.cmbInput2.Location = new System.Drawing.Point(6, 19);
            this.cmbInput2.Name = "cmbInput2";
            this.cmbInput2.Size = new System.Drawing.Size(202, 21);
            this.cmbInput2.TabIndex = 23;
            this.cmbInput2.Text = "{ select point layer }";
            this.cmbInput2.SelectedIndexChanged += new System.EventHandler(this.cmbInput2_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(148, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCalculate.Location = new System.Drawing.Point(56, 431);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(85, 23);
            this.btnCalculate.TabIndex = 49;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // grbPolygon
            // 
            this.grbPolygon.Controls.Add(this.cmbField);
            this.grbPolygon.Controls.Add(this.cmbInput1);
            this.grbPolygon.Location = new System.Drawing.Point(12, 12);
            this.grbPolygon.Name = "grbPolygon";
            this.grbPolygon.Size = new System.Drawing.Size(269, 85);
            this.grbPolygon.TabIndex = 51;
            this.grbPolygon.TabStop = false;
            this.grbPolygon.Text = "Polygon Selection";
            // 
            // cmbField
            // 
            this.cmbField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(65, 46);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(184, 21);
            this.cmbField.TabIndex = 28;
            this.cmbField.Text = "{ select unique polygon ID field }";
            this.cmbField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // cmbInput1
            // 
            this.cmbInput1.FormattingEnabled = true;
            this.cmbInput1.Location = new System.Drawing.Point(6, 19);
            this.cmbInput1.Name = "cmbInput1";
            this.cmbInput1.Size = new System.Drawing.Size(199, 21);
            this.cmbInput1.TabIndex = 20;
            this.cmbInput1.Text = "{ select polygon layer }";
            this.cmbInput1.SelectedIndexChanged += new System.EventHandler(this.cmbInput1_SelectedIndexChanged);
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(30, 186);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(0, 13);
            this.lblPoint.TabIndex = 48;
            // 
            // grbSaveOptions
            // 
            this.grbSaveOptions.Controls.Add(this.chkSaveAs);
            this.grbSaveOptions.Controls.Add(this.chkSave);
            this.grbSaveOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbSaveOptions.Location = new System.Drawing.Point(12, 311);
            this.grbSaveOptions.Name = "grbSaveOptions";
            this.grbSaveOptions.Size = new System.Drawing.Size(269, 95);
            this.grbSaveOptions.TabIndex = 65;
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
            // frmJoinPointsToPolygons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 477);
            this.Controls.Add(this.grbSaveOptions);
            this.Controls.Add(this.grbPoint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.grbPolygon);
            this.Controls.Add(this.lblPoint);
            this.Name = "frmJoinPointsToPolygons";
            this.Text = "Join Points to Polygons";
            this.Load += new System.EventHandler(this.frmJoinPointsToPolygons_Load);
            this.grbPoint.ResumeLayout(false);
            this.grbPoint.PerformLayout();
            this.grbPolygon.ResumeLayout(false);
            this.grbSaveOptions.ResumeLayout(false);
            this.grbSaveOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPoint;
        private System.Windows.Forms.ComboBox cmbInput2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox grbPolygon;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.ComboBox cmbInput1;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.CheckBox chbSelectAll;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.CheckedListBox clsFields;
        private System.Windows.Forms.GroupBox grbSaveOptions;
        private System.Windows.Forms.CheckBox chkSaveAs;
        private System.Windows.Forms.CheckBox chkSave;
    }
}