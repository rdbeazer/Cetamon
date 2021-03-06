﻿namespace Cetecean
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radSession = new System.Windows.Forms.RadioButton();
            this.radNewShape = new System.Windows.Forms.RadioButton();
            this.radOriginal = new System.Windows.Forms.RadioButton();
            this.grbPoint.SuspendLayout();
            this.grbRaster.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(102, 412);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Enabled = false;
            this.btnCalculate.Location = new System.Drawing.Point(12, 412);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(84, 23);
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
            this.cmbPoint.Size = new System.Drawing.Size(135, 21);
            this.cmbPoint.TabIndex = 0;
            this.cmbPoint.Text = "{ select point layer }";
            this.cmbPoint.SelectedIndexChanged += new System.EventHandler(this.cmbPoint_SelectedIndexChanged);
            // 
            // grbPoint
            // 
            this.grbPoint.Controls.Add(this.cmbPoint);
            this.grbPoint.Location = new System.Drawing.Point(12, 12);
            this.grbPoint.Name = "grbPoint";
            this.grbPoint.Size = new System.Drawing.Size(239, 52);
            this.grbPoint.TabIndex = 7;
            this.grbPoint.TabStop = false;
            this.grbPoint.Text = "Input Point Layer";
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
            this.txtNoDataValue.Location = new System.Drawing.Point(96, 163);
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
            this.grbRaster.Size = new System.Drawing.Size(239, 198);
            this.grbRaster.TabIndex = 6;
            this.grbRaster.TabStop = false;
            this.grbRaster.Text = "Raster Input";
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Location = new System.Drawing.Point(22, 35);
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
            this.clsFields.Size = new System.Drawing.Size(195, 94);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radSession);
            this.groupBox1.Controls.Add(this.radNewShape);
            this.groupBox1.Controls.Add(this.radOriginal);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 118);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Options";
            // 
            // radSession
            // 
            this.radSession.AutoSize = true;
            this.radSession.Location = new System.Drawing.Point(19, 88);
            this.radSession.Name = "radSession";
            this.radSession.Size = new System.Drawing.Size(208, 17);
            this.radSession.TabIndex = 69;
            this.radSession.Text = "Update point layer for this session only.";
            this.radSession.UseVisualStyleBackColor = true;
            // 
            // radNewShape
            // 
            this.radNewShape.AutoSize = true;
            this.radNewShape.Checked = true;
            this.radNewShape.Location = new System.Drawing.Point(19, 52);
            this.radNewShape.Name = "radNewShape";
            this.radNewShape.Size = new System.Drawing.Size(180, 30);
            this.radNewShape.TabIndex = 68;
            this.radNewShape.TabStop = true;
            this.radNewShape.Text = "Save the updated attributes to a \r\nNEW point shapefile.";
            this.radNewShape.UseVisualStyleBackColor = true;
            // 
            // radOriginal
            // 
            this.radOriginal.AutoSize = true;
            this.radOriginal.Location = new System.Drawing.Point(19, 16);
            this.radOriginal.Name = "radOriginal";
            this.radOriginal.Size = new System.Drawing.Size(189, 30);
            this.radOriginal.TabIndex = 67;
            this.radOriginal.Text = "Save the updated attributes to the \r\nORIGINAL point shapefile.";
            this.radOriginal.UseVisualStyleBackColor = true;
            // 
            // frmExtractRasterValues
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 449);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.grbPoint);
            this.Controls.Add(this.grbRaster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmExtractRasterValues";
            this.Text = "Extract Raster Values";
            this.Load += new System.EventHandler(this.frmExtractRasterValues_Load);
            this.grbPoint.ResumeLayout(false);
            this.grbRaster.ResumeLayout(false);
            this.grbRaster.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radSession;
        private System.Windows.Forms.RadioButton radNewShape;
        private System.Windows.Forms.RadioButton radOriginal;
    }
}