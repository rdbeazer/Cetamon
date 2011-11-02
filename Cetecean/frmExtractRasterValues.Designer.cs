namespace Cetecean
{
    partial class frmExtractRasterValues
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
            this.chkSaveAs = new System.Windows.Forms.CheckBox();
            this.grbSaveOptions = new System.Windows.Forms.GroupBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.cmbPoint = new System.Windows.Forms.ComboBox();
            this.grbPoint = new System.Windows.Forms.GroupBox();
            this.lblNoDataValue = new System.Windows.Forms.Label();
            this.txtNoDataValue = new System.Windows.Forms.TextBox();
            this.grbRaster = new System.Windows.Forms.GroupBox();
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.clsFields = new System.Windows.Forms.CheckedListBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.grbSaveOptions.SuspendLayout();
            this.grbPoint.SuspendLayout();
            this.grbRaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSaveAs
            // 
            this.chkSaveAs.AutoSize = true;
            this.chkSaveAs.Location = new System.Drawing.Point(22, 55);
            this.chkSaveAs.Name = "chkSaveAs";
            this.chkSaveAs.Size = new System.Drawing.Size(178, 30);
            this.chkSaveAs.TabIndex = 1;
            this.chkSaveAs.Text = "Save the updated attributes to a\r\nnew point shapefile.";
            this.chkSaveAs.UseVisualStyleBackColor = true;
            // 
            // grbSaveOptions
            // 
            this.grbSaveOptions.Controls.Add(this.chkSaveAs);
            this.grbSaveOptions.Controls.Add(this.chkSave);
            this.grbSaveOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbSaveOptions.Location = new System.Drawing.Point(12, 294);
            this.grbSaveOptions.Name = "grbSaveOptions";
            this.grbSaveOptions.Size = new System.Drawing.Size(248, 95);
            this.grbSaveOptions.TabIndex = 10;
            this.grbSaveOptions.TabStop = false;
            this.grbSaveOptions.Text = "Save Options";
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Location = new System.Drawing.Point(22, 19);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(190, 30);
            this.chkSave.TabIndex = 0;
            this.chkSave.Text = "Save the updated attributes to the \r\noriginal point shapefile.";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(134, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(34, 407);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(94, 23);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // cmbPoint
            // 
            this.cmbPoint.FormattingEnabled = true;
            this.cmbPoint.Location = new System.Drawing.Point(6, 19);
            this.cmbPoint.Name = "cmbPoint";
            this.cmbPoint.Size = new System.Drawing.Size(236, 21);
            this.cmbPoint.TabIndex = 0;
            this.cmbPoint.Text = "{ select a point shapefile }";
            this.cmbPoint.SelectedIndexChanged += new System.EventHandler(this.cmbPoint_SelectedIndexChanged);
            // 
            // grbPoint
            // 
            this.grbPoint.Controls.Add(this.cmbPoint);
            this.grbPoint.Location = new System.Drawing.Point(12, 12);
            this.grbPoint.Name = "grbPoint";
            this.grbPoint.Size = new System.Drawing.Size(248, 52);
            this.grbPoint.TabIndex = 7;
            this.grbPoint.TabStop = false;
            this.grbPoint.Text = "Point Input";
            // 
            // lblNoDataValue
            // 
            this.lblNoDataValue.AutoSize = true;
            this.lblNoDataValue.Location = new System.Drawing.Point(10, 166);
            this.lblNoDataValue.Name = "lblNoDataValue";
            this.lblNoDataValue.Size = new System.Drawing.Size(80, 13);
            this.lblNoDataValue.TabIndex = 8;
            this.lblNoDataValue.Text = "No Data Value:";
            // 
            // txtNoDataValue
            // 
            this.txtNoDataValue.Location = new System.Drawing.Point(13, 182);
            this.txtNoDataValue.Name = "txtNoDataValue";
            this.txtNoDataValue.Size = new System.Drawing.Size(73, 20);
            this.txtNoDataValue.TabIndex = 0;
            this.txtNoDataValue.Text = "-99999";
            // 
            // grbRaster
            // 
            this.grbRaster.Controls.Add(this.lblNoDataValue);
            this.grbRaster.Controls.Add(this.txtNoDataValue);
            this.grbRaster.Controls.Add(this.chbSelectAll);
            this.grbRaster.Controls.Add(this.clsFields);
            this.grbRaster.Controls.Add(this.lblSelect);
            this.grbRaster.Location = new System.Drawing.Point(12, 73);
            this.grbRaster.Name = "grbRaster";
            this.grbRaster.Size = new System.Drawing.Size(248, 215);
            this.grbRaster.TabIndex = 6;
            this.grbRaster.TabStop = false;
            this.grbRaster.Text = "Raster Input";
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Location = new System.Drawing.Point(9, 35);
            this.chbSelectAll.Name = "chbSelectAll";
            this.chbSelectAll.Size = new System.Drawing.Size(70, 17);
            this.chbSelectAll.TabIndex = 7;
            this.chbSelectAll.Text = "Select All";
            this.chbSelectAll.UseVisualStyleBackColor = true;
            this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
            // 
            // clsFields
            // 
            this.clsFields.Location = new System.Drawing.Point(22, 58);
            this.clsFields.Name = "clsFields";
            this.clsFields.Size = new System.Drawing.Size(220, 94);
            this.clsFields.TabIndex = 5;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(6, 18);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(178, 13);
            this.lblSelect.TabIndex = 6;
            this.lblSelect.Text = "Select rasters to extract values from:";
            // 
            // frmExtractRasterValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 453);
            this.Controls.Add(this.grbSaveOptions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.grbPoint);
            this.Controls.Add(this.grbRaster);
            this.Name = "frmExtractRasterValues";
            this.Text = "frmExtractRasterValues";
            this.Load += new System.EventHandler(this.frmExtractRasterValues_Load);
            this.grbSaveOptions.ResumeLayout(false);
            this.grbSaveOptions.PerformLayout();
            this.grbPoint.ResumeLayout(false);
            this.grbRaster.ResumeLayout(false);
            this.grbRaster.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSaveAs;
        private System.Windows.Forms.GroupBox grbSaveOptions;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ComboBox cmbPoint;
        private System.Windows.Forms.GroupBox grbPoint;
        private System.Windows.Forms.Label lblNoDataValue;
        private System.Windows.Forms.TextBox txtNoDataValue;
        private System.Windows.Forms.GroupBox grbRaster;
        private System.Windows.Forms.CheckBox chbSelectAll;
        private System.Windows.Forms.CheckedListBox clsFields;
        private System.Windows.Forms.Label lblSelect;
    }
}