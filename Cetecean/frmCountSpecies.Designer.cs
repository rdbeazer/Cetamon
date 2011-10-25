namespace Cetecean
{
    partial class frmCountSpecies
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
            this.ckbIncludeTotalSpecis = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.cmbInput2 = new System.Windows.Forms.ComboBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.cmbInput1 = new System.Windows.Forms.ComboBox();
            this.lblGrid = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ckbIncludeTotalSpecis
            // 
            this.ckbIncludeTotalSpecis.AutoSize = true;
            this.ckbIncludeTotalSpecis.Location = new System.Drawing.Point(29, 141);
            this.ckbIncludeTotalSpecis.Name = "ckbIncludeTotalSpecis";
            this.ckbIncludeTotalSpecis.Size = new System.Drawing.Size(272, 17);
            this.ckbIncludeTotalSpecis.TabIndex = 25;
            this.ckbIncludeTotalSpecis.Text = "Add the total number of species to the attribute table";
            this.ckbIncludeTotalSpecis.UseVisualStyleBackColor = true;
            this.ckbIncludeTotalSpecis.CheckedChanged += new System.EventHandler(this.ckbIncludeTotalSpecis_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(165, 164);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCalculate.Location = new System.Drawing.Point(73, 164);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(86, 23);
            this.btnCalculate.TabIndex = 22;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // cmbInput2
            // 
            this.cmbInput2.FormattingEnabled = true;
            this.cmbInput2.Location = new System.Drawing.Point(71, 99);
            this.cmbInput2.Name = "cmbInput2";
            this.cmbInput2.Size = new System.Drawing.Size(202, 21);
            this.cmbInput2.TabIndex = 23;
            this.cmbInput2.SelectedIndexChanged += new System.EventHandler(this.cmbInput2_SelectedIndexChanged);
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(48, 69);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(113, 13);
            this.lblPoint.TabIndex = 21;
            this.lblPoint.Text = "Select Input Point File ";
            // 
            // cmbInput1
            // 
            this.cmbInput1.FormattingEnabled = true;
            this.cmbInput1.Location = new System.Drawing.Point(74, 29);
            this.cmbInput1.Name = "cmbInput1";
            this.cmbInput1.Size = new System.Drawing.Size(199, 21);
            this.cmbInput1.TabIndex = 20;
            this.cmbInput1.SelectedIndexChanged += new System.EventHandler(this.cmbInput1_SelectedIndexChanged);
            // 
            // lblGrid
            // 
            this.lblGrid.AutoSize = true;
            this.lblGrid.Location = new System.Drawing.Point(48, 12);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(124, 13);
            this.lblGrid.TabIndex = 19;
            this.lblGrid.Text = "Select Input Polygon File";
            // 
            // frmCountSpecies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 211);
            this.Controls.Add(this.ckbIncludeTotalSpecis);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.cmbInput2);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.cmbInput1);
            this.Controls.Add(this.lblGrid);
            this.Name = "frmCountSpecies";
            this.Text = "Count Species per Polygon";
            this.Load += new System.EventHandler(this.frmCountSpecies_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbIncludeTotalSpecis;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ComboBox cmbInput2;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.ComboBox cmbInput1;
        private System.Windows.Forms.Label lblGrid;
    }
}