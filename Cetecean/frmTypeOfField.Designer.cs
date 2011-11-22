namespace Cetecean
{
    partial class frmTypeOfField
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpChange = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxTypeOfField = new System.Windows.Forms.ComboBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxLongitude2 = new System.Windows.Forms.ComboBox();
            this.cbxLatitude2 = new System.Windows.Forms.ComboBox();
            this.cbxLongitude1 = new System.Windows.Forms.ComboBox();
            this.cbxLatitude1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvListfields = new System.Windows.Forms.DataGridView();
            this.cbxDateFormat = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.grpChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListfields)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpChange);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnAccept);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.cbxLongitude2);
            this.panel1.Controls.Add(this.cbxLatitude2);
            this.panel1.Controls.Add(this.cbxLongitude1);
            this.panel1.Controls.Add(this.cbxLatitude1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgvListfields);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 352);
            this.panel1.TabIndex = 0;
            // 
            // grpChange
            // 
            this.grpChange.Controls.Add(this.cbxDateFormat);
            this.grpChange.Controls.Add(this.label2);
            this.grpChange.Controls.Add(this.txtNameField);
            this.grpChange.Controls.Add(this.label8);
            this.grpChange.Controls.Add(this.cbxTypeOfField);
            this.grpChange.Controls.Add(this.btnChange);
            this.grpChange.Enabled = false;
            this.grpChange.Location = new System.Drawing.Point(23, 222);
            this.grpChange.Name = "grpChange";
            this.grpChange.Size = new System.Drawing.Size(306, 118);
            this.grpChange.TabIndex = 20;
            this.grpChange.TabStop = false;
            this.grpChange.Text = "Change type of field";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtNameField
            // 
            this.txtNameField.Enabled = false;
            this.txtNameField.Location = new System.Drawing.Point(73, 30);
            this.txtNameField.Name = "txtNameField";
            this.txtNameField.Size = new System.Drawing.Size(101, 20);
            this.txtNameField.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Type";
            // 
            // cbxTypeOfField
            // 
            this.cbxTypeOfField.FormattingEnabled = true;
            this.cbxTypeOfField.Location = new System.Drawing.Point(73, 61);
            this.cbxTypeOfField.Name = "cbxTypeOfField";
            this.cbxTypeOfField.Size = new System.Drawing.Size(101, 21);
            this.cbxTypeOfField.TabIndex = 14;
            this.cbxTypeOfField.SelectedIndexChanged += new System.EventHandler(this.cbxTypeOfField_SelectedIndexChanged);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(213, 89);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 15;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Select the field that you want to change";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(317, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 18;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(390, 252);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(121, 23);
            this.btnAccept.TabIndex = 17;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(390, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbxLongitude2
            // 
            this.cbxLongitude2.FormattingEnabled = true;
            this.cbxLongitude2.Location = new System.Drawing.Point(389, 184);
            this.cbxLongitude2.Name = "cbxLongitude2";
            this.cbxLongitude2.Size = new System.Drawing.Size(121, 21);
            this.cbxLongitude2.TabIndex = 11;
            this.cbxLongitude2.Visible = false;
            // 
            // cbxLatitude2
            // 
            this.cbxLatitude2.FormattingEnabled = true;
            this.cbxLatitude2.Location = new System.Drawing.Point(390, 150);
            this.cbxLatitude2.Name = "cbxLatitude2";
            this.cbxLatitude2.Size = new System.Drawing.Size(121, 21);
            this.cbxLatitude2.TabIndex = 10;
            this.cbxLatitude2.Visible = false;
            // 
            // cbxLongitude1
            // 
            this.cbxLongitude1.FormattingEnabled = true;
            this.cbxLongitude1.Location = new System.Drawing.Point(390, 116);
            this.cbxLongitude1.Name = "cbxLongitude1";
            this.cbxLongitude1.Size = new System.Drawing.Size(121, 21);
            this.cbxLongitude1.TabIndex = 9;
            // 
            // cbxLatitude1
            // 
            this.cbxLatitude1.FormattingEnabled = true;
            this.cbxLatitude1.Location = new System.Drawing.Point(390, 82);
            this.cbxLatitude1.Name = "cbxLatitude1";
            this.cbxLatitude1.Size = new System.Drawing.Size(121, 21);
            this.cbxLatitude1.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "End Latitude";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "End Longitude";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Longitude";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Latitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Required fields";
            // 
            // dgvListfields
            // 
            this.dgvListfields.AllowUserToAddRows = false;
            this.dgvListfields.AllowUserToDeleteRows = false;
            this.dgvListfields.AllowUserToResizeColumns = false;
            this.dgvListfields.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListfields.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListfields.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListfields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListfields.Location = new System.Drawing.Point(30, 64);
            this.dgvListfields.MultiSelect = false;
            this.dgvListfields.Name = "dgvListfields";
            this.dgvListfields.ReadOnly = true;
            this.dgvListfields.RowHeadersVisible = false;
            this.dgvListfields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListfields.Size = new System.Drawing.Size(264, 152);
            this.dgvListfields.TabIndex = 0;
            this.dgvListfields.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListfields_CellContentClick);
            // 
            // cbxDateFormat
            // 
            this.cbxDateFormat.FormattingEnabled = true;
            this.cbxDateFormat.Location = new System.Drawing.Point(180, 61);
            this.cbxDateFormat.Name = "cbxDateFormat";
            this.cbxDateFormat.Size = new System.Drawing.Size(108, 21);
            this.cbxDateFormat.TabIndex = 16;
            this.cbxDateFormat.Visible = false;
            // 
            // frmTypeOfField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 352);
            this.Controls.Add(this.panel1);
            this.Name = "frmTypeOfField";
            this.Text = "Type of field";
            this.Load += new System.EventHandler(this.frmTypeOfField_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpChange.ResumeLayout(false);
            this.grpChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListfields)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvListfields;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.ComboBox cbxTypeOfField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNameField;
        private System.Windows.Forms.ComboBox cbxLongitude2;
        private System.Windows.Forms.ComboBox cbxLatitude2;
        private System.Windows.Forms.ComboBox cbxLongitude1;
        private System.Windows.Forms.ComboBox cbxLatitude1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpChange;
        private System.Windows.Forms.ComboBox cbxDateFormat;
    }
}