namespace Cetecean
{
    partial class frmGridToPoint
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.clsFields = new System.Windows.Forms.CheckedListBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.cmbGrid = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreatePoints = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.cbxSave = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbSelectAll);
            this.groupBox1.Controls.Add(this.clsFields);
            this.groupBox1.Controls.Add(this.lblSelect);
            this.groupBox1.Controls.Add(this.cmbGrid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid Layer";
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Location = new System.Drawing.Point(25, 91);
            this.chbSelectAll.Name = "chbSelectAll";
            this.chbSelectAll.Size = new System.Drawing.Size(70, 17);
            this.chbSelectAll.TabIndex = 4;
            this.chbSelectAll.Text = "Select All";
            this.chbSelectAll.UseVisualStyleBackColor = true;
            this.chbSelectAll.Visible = false;
            this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
            // 
            // clsFields
            // 
            this.clsFields.Location = new System.Drawing.Point(22, 114);
            this.clsFields.Name = "clsFields";
            this.clsFields.Size = new System.Drawing.Size(153, 94);
            this.clsFields.TabIndex = 0;
            this.clsFields.Visible = false;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(15, 74);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(163, 13);
            this.lblSelect.TabIndex = 3;
            this.lblSelect.Text = "Select grid fields to copy to point:";
            this.lblSelect.Visible = false;
            // 
            // cmbGrid
            // 
            this.cmbGrid.FormattingEnabled = true;
            this.cmbGrid.Location = new System.Drawing.Point(22, 36);
            this.cmbGrid.Name = "cmbGrid";
            this.cmbGrid.Size = new System.Drawing.Size(155, 21);
            this.cmbGrid.TabIndex = 1;
            this.cmbGrid.Text = "Select...";
            this.cmbGrid.SelectedIndexChanged += new System.EventHandler(this.cmbGridLayer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Grid Layer";
            // 
            // btnCreatePoints
            // 
            this.btnCreatePoints.Location = new System.Drawing.Point(13, 337);
            this.btnCreatePoints.Name = "btnCreatePoints";
            this.btnCreatePoints.Size = new System.Drawing.Size(95, 23);
            this.btnCreatePoints.TabIndex = 1;
            this.btnCreatePoints.Text = "Create Points";
            this.btnCreatePoints.UseVisualStyleBackColor = true;
            this.btnCreatePoints.Click += new System.EventHandler(this.btnCreatePoints_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(114, 337);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(95, 23);
            this.btnCancle.TabIndex = 2;
            this.btnCancle.Text = "Cancel";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInput);
            this.groupBox2.Controls.Add(this.cbxSave);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 91);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output ";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(22, 37);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(155, 20);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "grid_to_point";
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // frmGridToPoint
            // 
            this.AcceptButton = this.btnCreatePoints;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 376);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnCreatePoints);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGridToPoint";
            this.Text = "Convert Grid to Points";
            this.Load += new System.EventHandler(this.frmGridToPoint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreatePoints;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.CheckBox cbxSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.CheckedListBox clsFields;
        private System.Windows.Forms.CheckBox chbSelectAll;
    }
}