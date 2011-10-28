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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbGridID = new System.Windows.Forms.ComboBox();
            this.cmbGrid = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbSwatheID = new System.Windows.Forms.ComboBox();
            this.cmbSwathe = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbGridID);
            this.groupBox1.Controls.Add(this.cmbGrid);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid Layer";
            // 
            // cmbGridID
            // 
            this.cmbGridID.FormattingEnabled = true;
            this.cmbGridID.Location = new System.Drawing.Point(32, 46);
            this.cmbGridID.Name = "cmbGridID";
            this.cmbGridID.Size = new System.Drawing.Size(177, 21);
            this.cmbGridID.TabIndex = 1;
            this.cmbGridID.Text = "Select Grid ID field";
            this.cmbGridID.SelectedIndexChanged += new System.EventHandler(this.cmbGridID_SelectedIndexChanged);
            // 
            // cmbGrid
            // 
            this.cmbGrid.FormattingEnabled = true;
            this.cmbGrid.Location = new System.Drawing.Point(32, 19);
            this.cmbGrid.Name = "cmbGrid";
            this.cmbGrid.Size = new System.Drawing.Size(177, 21);
            this.cmbGrid.TabIndex = 0;
            this.cmbGrid.Text = "Select Grid Layer";
            this.cmbGrid.SelectedIndexChanged += new System.EventHandler(this.cmbGrid_SelectedIndexChanged_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbSwatheID);
            this.groupBox2.Controls.Add(this.cmbSwathe);
            this.groupBox2.Location = new System.Drawing.Point(13, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 98);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Survey Swathe Layer";
            // 
            // cmbSwatheID
            // 
            this.cmbSwatheID.FormattingEnabled = true;
            this.cmbSwatheID.Location = new System.Drawing.Point(23, 59);
            this.cmbSwatheID.Name = "cmbSwatheID";
            this.cmbSwatheID.Size = new System.Drawing.Size(186, 21);
            this.cmbSwatheID.TabIndex = 1;
            this.cmbSwatheID.Text = "Select Swathe ID Field";
            this.cmbSwatheID.SelectedIndexChanged += new System.EventHandler(this.cmbSwatheID_SelectedIndexChanged);
            // 
            // cmbSwathe
            // 
            this.cmbSwathe.FormattingEnabled = true;
            this.cmbSwathe.Location = new System.Drawing.Point(23, 32);
            this.cmbSwathe.Name = "cmbSwathe";
            this.cmbSwathe.Size = new System.Drawing.Size(186, 21);
            this.cmbSwathe.TabIndex = 0;
            this.cmbSwathe.Text = "Select Swathe Layer";
            this.cmbSwathe.SelectedIndexChanged += new System.EventHandler(this.cmbSwathe_SelectedIndexChanged);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(24, 229);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPolyEffortBySwathe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 267);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPolyEffortBySwathe";
            this.Text = "Calculate Survey Effort by Polygon (Survey Swathes)";
            this.Load += new System.EventHandler(this.polyEffortBySwathe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbSwathe;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbGridID;
        private System.Windows.Forms.ComboBox cmbSwatheID;
    }
}