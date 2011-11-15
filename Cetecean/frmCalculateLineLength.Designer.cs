namespace Cetecean
{
    partial class frmCalculateLineLength
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
            this.grbLineInput = new System.Windows.Forms.GroupBox();
            this.cmbLine = new System.Windows.Forms.ComboBox();
            this.txtAttributeField = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblAttributeField = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbAttributes = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radSession = new System.Windows.Forms.RadioButton();
            this.radNewShape = new System.Windows.Forms.RadioButton();
            this.radOriginal = new System.Windows.Forms.RadioButton();
            this.grbLineInput.SuspendLayout();
            this.grbAttributes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbLineInput
            // 
            this.grbLineInput.Controls.Add(this.cmbLine);
            this.grbLineInput.Location = new System.Drawing.Point(12, 12);
            this.grbLineInput.Name = "grbLineInput";
            this.grbLineInput.Size = new System.Drawing.Size(220, 53);
            this.grbLineInput.TabIndex = 73;
            this.grbLineInput.TabStop = false;
            this.grbLineInput.Text = "Input Line Shapefile";
            // 
            // cmbLine
            // 
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.Location = new System.Drawing.Point(23, 19);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(170, 21);
            this.cmbLine.TabIndex = 0;
            this.cmbLine.Text = "Select line shapefile";
            this.cmbLine.SelectedIndexChanged += new System.EventHandler(this.cmbLine_SelectedIndexChanged);
            // 
            // txtAttributeField
            // 
            this.txtAttributeField.Location = new System.Drawing.Point(38, 37);
            this.txtAttributeField.Name = "txtAttributeField";
            this.txtAttributeField.Size = new System.Drawing.Size(155, 20);
            this.txtAttributeField.TabIndex = 1;
            this.txtAttributeField.Text = "TrackLength";
            this.txtAttributeField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCalculate.Enabled = false;
            this.btnCalculate.Location = new System.Drawing.Point(35, 274);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(82, 23);
            this.btnCalculate.TabIndex = 75;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblAttributeField
            // 
            this.lblAttributeField.AutoSize = true;
            this.lblAttributeField.Location = new System.Drawing.Point(23, 21);
            this.lblAttributeField.Name = "lblAttributeField";
            this.lblAttributeField.Size = new System.Drawing.Size(148, 13);
            this.lblAttributeField.TabIndex = 0;
            this.lblAttributeField.Text = "Attribute Field for Line Length:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(123, 274);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 23);
            this.btnCancel.TabIndex = 76;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grbAttributes
            // 
            this.grbAttributes.Controls.Add(this.txtAttributeField);
            this.grbAttributes.Controls.Add(this.lblAttributeField);
            this.grbAttributes.Location = new System.Drawing.Point(12, 71);
            this.grbAttributes.Name = "grbAttributes";
            this.grbAttributes.Size = new System.Drawing.Size(220, 73);
            this.grbAttributes.TabIndex = 74;
            this.grbAttributes.TabStop = false;
            this.grbAttributes.Text = "Name Attribute Field";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radSession);
            this.groupBox2.Controls.Add(this.radNewShape);
            this.groupBox2.Controls.Add(this.radOriginal);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 118);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save Options";
            // 
            // radSession
            // 
            this.radSession.AutoSize = true;
            this.radSession.Location = new System.Drawing.Point(6, 91);
            this.radSession.Name = "radSession";
            this.radSession.Size = new System.Drawing.Size(205, 17);
            this.radSession.TabIndex = 69;
            this.radSession.Text = "Update point layer for this session only";
            this.radSession.UseVisualStyleBackColor = true;
            // 
            // radNewShape
            // 
            this.radNewShape.AutoSize = true;
            this.radNewShape.Checked = true;
            this.radNewShape.Location = new System.Drawing.Point(6, 55);
            this.radNewShape.Name = "radNewShape";
            this.radNewShape.Size = new System.Drawing.Size(180, 30);
            this.radNewShape.TabIndex = 68;
            this.radNewShape.TabStop = true;
            this.radNewShape.Text = "Save the updated attributes to a \r\nNEW shapefile";
            this.radNewShape.UseVisualStyleBackColor = true;
            // 
            // radOriginal
            // 
            this.radOriginal.AutoSize = true;
            this.radOriginal.Location = new System.Drawing.Point(6, 19);
            this.radOriginal.Name = "radOriginal";
            this.radOriginal.Size = new System.Drawing.Size(189, 30);
            this.radOriginal.TabIndex = 67;
            this.radOriginal.Text = "Save the updated attributes to the \r\nORIGINAL shapefile";
            this.radOriginal.UseVisualStyleBackColor = true;
            // 
            // frmCalculateLineLength
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 313);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbLineInput);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grbAttributes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCalculateLineLength";
            this.Text = "Calculate Line Length";
            this.Load += new System.EventHandler(this.frmCalculateLineLength_Load);
            this.grbLineInput.ResumeLayout(false);
            this.grbAttributes.ResumeLayout(false);
            this.grbAttributes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbLineInput;
        private System.Windows.Forms.ComboBox cmbLine;
        private System.Windows.Forms.TextBox txtAttributeField;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblAttributeField;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grbAttributes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radSession;
        private System.Windows.Forms.RadioButton radNewShape;
        private System.Windows.Forms.RadioButton radOriginal;
    }
}