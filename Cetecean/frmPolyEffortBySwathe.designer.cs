namespace Cetecean
{
    partial class frmPolyEffortBySwathe
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInputSwathe = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSwatheArea = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSwatheID = new System.Windows.Forms.ComboBox();
            this.cmbSwathe = new System.Windows.Forms.ComboBox();
            this.txtSwathe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbInputGrid = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInputSwathe);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbSwatheArea);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbSwatheID);
            this.groupBox2.Controls.Add(this.cmbSwathe);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Survey Swathe Layer";
            // 
            // btnInputSwathe
            // 
            this.btnInputSwathe.Location = new System.Drawing.Point(209, 19);
            this.btnInputSwathe.Name = "btnInputSwathe";
            this.btnInputSwathe.Size = new System.Drawing.Size(19, 23);
            this.btnInputSwathe.TabIndex = 11;
            this.btnInputSwathe.Text = "?";
            this.btnInputSwathe.UseVisualStyleBackColor = true;
            this.btnInputSwathe.Click += new System.EventHandler(this.btnInputSwathe_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select swathe area field";
            // 
            // cmbSwatheArea
            // 
            this.cmbSwatheArea.FormattingEnabled = true;
            this.cmbSwatheArea.Location = new System.Drawing.Point(63, 102);
            this.cmbSwatheArea.Name = "cmbSwatheArea";
            this.cmbSwatheArea.Size = new System.Drawing.Size(186, 21);
            this.cmbSwatheArea.TabIndex = 9;
            this.cmbSwatheArea.Text = "Select swathe area field";
            this.cmbSwatheArea.SelectedIndexChanged += new System.EventHandler(this.cmbSwatheArea_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Select field with input grid ID";
            // 
            // cmbSwatheID
            // 
            this.cmbSwatheID.FormattingEnabled = true;
            this.cmbSwatheID.Location = new System.Drawing.Point(63, 59);
            this.cmbSwatheID.Name = "cmbSwatheID";
            this.cmbSwatheID.Size = new System.Drawing.Size(186, 21);
            this.cmbSwatheID.TabIndex = 1;
            this.cmbSwatheID.Text = "Select the Grid ID ";
            this.cmbSwatheID.SelectedIndexChanged += new System.EventHandler(this.cmbSwatheID_SelectedIndexChanged);
            // 
            // cmbSwathe
            // 
            this.cmbSwathe.FormattingEnabled = true;
            this.cmbSwathe.Location = new System.Drawing.Point(17, 19);
            this.cmbSwathe.Name = "cmbSwathe";
            this.cmbSwathe.Size = new System.Drawing.Size(186, 21);
            this.cmbSwathe.TabIndex = 0;
            this.cmbSwathe.Text = "Select Swathe Layer";
            this.cmbSwathe.SelectedIndexChanged += new System.EventHandler(this.cmbSwathe_SelectedIndexChanged);
            // 
            // txtSwathe
            // 
            this.txtSwathe.Location = new System.Drawing.Point(71, 69);
            this.txtSwathe.Name = "txtSwathe";
            this.txtSwathe.Size = new System.Drawing.Size(177, 20);
            this.txtSwathe.TabIndex = 0;
            this.txtSwathe.Text = "swatheEffort";
            this.txtSwathe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter field name to hold effort value:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(39, 283);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(145, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbInputGrid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSwathe);
            this.groupBox1.Location = new System.Drawing.Point(13, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 105);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Grid Layer to be Updated";
            // 
            // cmbInputGrid
            // 
            this.cmbInputGrid.FormattingEnabled = true;
            this.cmbInputGrid.Location = new System.Drawing.Point(16, 19);
            this.cmbInputGrid.Name = "cmbInputGrid";
            this.cmbInputGrid.Size = new System.Drawing.Size(186, 21);
            this.cmbInputGrid.TabIndex = 1;
            this.cmbInputGrid.Text = "Select Grid Layer";
            this.cmbInputGrid.SelectedIndexChanged += new System.EventHandler(this.cmbInputGrid_SelectedIndexChanged);
            // 
            // frmPolyEffortBySwathe
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 321);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPolyEffortBySwathe";
            this.Text = "Calculate Survey Effort by Polygon (Survey Swathes)";
            this.Load += new System.EventHandler(this.polyEffortBySwathe_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbSwathe;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbSwatheID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSwathe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSwatheArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInputSwathe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbInputGrid;
    }
}