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
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.grbPoint = new System.Windows.Forms.GroupBox();
            this.cmbInput1 = new System.Windows.Forms.ComboBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.grbPolygon = new System.Windows.Forms.GroupBox();
            this.clsFields = new System.Windows.Forms.CheckedListBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.cmbInput2 = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radSession = new System.Windows.Forms.RadioButton();
            this.radNewShape = new System.Windows.Forms.RadioButton();
            this.radOriginal = new System.Windows.Forms.RadioButton();
            this.grbPoint.SuspendLayout();
            this.grbPolygon.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Enabled = false;
            this.chbSelectAll.Location = new System.Drawing.Point(21, 73);
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
            this.grbPoint.Controls.Add(this.cmbInput1);
            this.grbPoint.Location = new System.Drawing.Point(12, 12);
            this.grbPoint.Name = "grbPoint";
            this.grbPoint.Size = new System.Drawing.Size(232, 53);
            this.grbPoint.TabIndex = 68;
            this.grbPoint.TabStop = false;
            this.grbPoint.Text = "Input Point Layer";
            // 
            // cmbInput1
            // 
            this.cmbInput1.FormattingEnabled = true;
            this.cmbInput1.Location = new System.Drawing.Point(6, 19);
            this.cmbInput1.Name = "cmbInput1";
            this.cmbInput1.Size = new System.Drawing.Size(136, 21);
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
            this.grbPolygon.Location = new System.Drawing.Point(12, 71);
            this.grbPolygon.Name = "grbPolygon";
            this.grbPolygon.Size = new System.Drawing.Size(232, 208);
            this.grbPolygon.TabIndex = 67;
            this.grbPolygon.TabStop = false;
            this.grbPolygon.Text = "Input Polygon Layer";
            // 
            // clsFields
            // 
            this.clsFields.Location = new System.Drawing.Point(21, 96);
            this.clsFields.Name = "clsFields";
            this.clsFields.Size = new System.Drawing.Size(192, 94);
            this.clsFields.TabIndex = 21;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Enabled = false;
            this.lblSelect.Location = new System.Drawing.Point(3, 57);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(201, 13);
            this.lblSelect.TabIndex = 22;
            this.lblSelect.Text = "Select polygon fields to join to point layer:";
            // 
            // cmbInput2
            // 
            this.cmbInput2.FormattingEnabled = true;
            this.cmbInput2.Location = new System.Drawing.Point(6, 19);
            this.cmbInput2.Name = "cmbInput2";
            this.cmbInput2.Size = new System.Drawing.Size(136, 21);
            this.cmbInput2.TabIndex = 20;
            this.cmbInput2.Text = "{ select polygon layer }";
            this.cmbInput2.SelectedIndexChanged += new System.EventHandler(this.cmbInput2_SelectedIndexChanged);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCalculate.Enabled = false;
            this.btnCalculate.Location = new System.Drawing.Point(12, 418);
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
            this.btnCancel.Location = new System.Drawing.Point(161, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radSession);
            this.groupBox1.Controls.Add(this.radNewShape);
            this.groupBox1.Controls.Add(this.radOriginal);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 118);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Options";
            // 
            // radSession
            // 
            this.radSession.AutoSize = true;
            this.radSession.Location = new System.Drawing.Point(6, 91);
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
            this.radNewShape.Location = new System.Drawing.Point(6, 55);
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
            this.radOriginal.Location = new System.Drawing.Point(6, 19);
            this.radOriginal.Name = "radOriginal";
            this.radOriginal.Size = new System.Drawing.Size(189, 30);
            this.radOriginal.TabIndex = 67;
            this.radOriginal.Text = "Save the updated attributes to the \r\nORIGINAL point shapefile.";
            this.radOriginal.UseVisualStyleBackColor = true;
            // 
            // frmJoinPolygonsToPoints
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 457);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbPoint);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.grbPolygon);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmJoinPolygonsToPoints";
            this.Text = "Join Polygons To Points";
            this.Load += new System.EventHandler(this.frmJoinPolygonsToPoints_Load);
            this.grbPoint.ResumeLayout(false);
            this.grbPolygon.ResumeLayout(false);
            this.grbPolygon.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbSelectAll;
        private System.Windows.Forms.GroupBox grbPoint;
        private System.Windows.Forms.ComboBox cmbInput1;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.GroupBox grbPolygon;
        private System.Windows.Forms.CheckedListBox clsFields;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.ComboBox cmbInput2;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radSession;
        private System.Windows.Forms.RadioButton radNewShape;
        private System.Windows.Forms.RadioButton radOriginal;
    }
}