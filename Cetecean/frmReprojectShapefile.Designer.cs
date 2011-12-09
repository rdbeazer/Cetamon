namespace Cetecean
{
    partial class frmReprojectShapefile
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
            this.grbProjectionType = new System.Windows.Forms.GroupBox();
            this.radGeographic = new System.Windows.Forms.RadioButton();
            this.cmbMinorCategory = new System.Windows.Forms.ComboBox();
            this.radProjected = new System.Windows.Forms.RadioButton();
            this.cmbMajorCategory = new System.Windows.Forms.ComboBox();
            this.grbShapefile = new System.Windows.Forms.GroupBox();
            this.cmbShapefile = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.grbProjectionType.SuspendLayout();
            this.grbShapefile.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbProjectionType
            // 
            this.grbProjectionType.Controls.Add(this.radGeographic);
            this.grbProjectionType.Controls.Add(this.cmbMinorCategory);
            this.grbProjectionType.Controls.Add(this.radProjected);
            this.grbProjectionType.Controls.Add(this.cmbMajorCategory);
            this.grbProjectionType.Location = new System.Drawing.Point(12, 60);
            this.grbProjectionType.Name = "grbProjectionType";
            this.grbProjectionType.Size = new System.Drawing.Size(203, 133);
            this.grbProjectionType.TabIndex = 0;
            this.grbProjectionType.TabStop = false;
            this.grbProjectionType.Text = "Projection Type";
            // 
            // radGeographic
            // 
            this.radGeographic.AutoSize = true;
            this.radGeographic.Location = new System.Drawing.Point(16, 42);
            this.radGeographic.Name = "radGeographic";
            this.radGeographic.Size = new System.Drawing.Size(80, 17);
            this.radGeographic.TabIndex = 1;
            this.radGeographic.TabStop = true;
            this.radGeographic.Text = "Geographic";
            this.radGeographic.UseVisualStyleBackColor = true;
            // 
            // cmbMinorCategory
            // 
            this.cmbMinorCategory.FormattingEnabled = true;
            this.cmbMinorCategory.Location = new System.Drawing.Point(6, 92);
            this.cmbMinorCategory.Name = "cmbMinorCategory";
            this.cmbMinorCategory.Size = new System.Drawing.Size(191, 21);
            this.cmbMinorCategory.TabIndex = 2;
            this.cmbMinorCategory.SelectedIndexChanged += new System.EventHandler(this.cmbMinorCategory_SelectedIndexChanged);
            // 
            // radProjected
            // 
            this.radProjected.AutoSize = true;
            this.radProjected.Location = new System.Drawing.Point(16, 19);
            this.radProjected.Name = "radProjected";
            this.radProjected.Size = new System.Drawing.Size(70, 17);
            this.radProjected.TabIndex = 0;
            this.radProjected.TabStop = true;
            this.radProjected.Text = "Projected";
            this.radProjected.UseVisualStyleBackColor = true;
            this.radProjected.CheckedChanged += new System.EventHandler(this.radProjected_CheckedChanged);
            // 
            // cmbMajorCategory
            // 
            this.cmbMajorCategory.FormattingEnabled = true;
            this.cmbMajorCategory.Location = new System.Drawing.Point(6, 65);
            this.cmbMajorCategory.Name = "cmbMajorCategory";
            this.cmbMajorCategory.Size = new System.Drawing.Size(191, 21);
            this.cmbMajorCategory.TabIndex = 1;
            this.cmbMajorCategory.SelectedIndexChanged += new System.EventHandler(this.cmbMajorCategory_SelectedIndexChanged);
            // 
            // grbShapefile
            // 
            this.grbShapefile.Controls.Add(this.cmbShapefile);
            this.grbShapefile.Location = new System.Drawing.Point(12, 5);
            this.grbShapefile.Name = "grbShapefile";
            this.grbShapefile.Size = new System.Drawing.Size(203, 49);
            this.grbShapefile.TabIndex = 3;
            this.grbShapefile.TabStop = false;
            this.grbShapefile.Text = "Select Shapefile";
            // 
            // cmbShapefile
            // 
            this.cmbShapefile.FormattingEnabled = true;
            this.cmbShapefile.Location = new System.Drawing.Point(6, 19);
            this.cmbShapefile.Name = "cmbShapefile";
            this.cmbShapefile.Size = new System.Drawing.Size(191, 21);
            this.cmbShapefile.TabIndex = 0;
            this.cmbShapefile.SelectedIndexChanged += new System.EventHandler(this.cmbShapefile_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 211);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "button1";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmReprojectShapefile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 262);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grbShapefile);
            this.Controls.Add(this.grbProjectionType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmReprojectShapefile";
            this.Text = "Reproject Shapefile";
            this.Load += new System.EventHandler(this.frmReprojectShapefile_Load);
            this.grbProjectionType.ResumeLayout(false);
            this.grbProjectionType.PerformLayout();
            this.grbShapefile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbProjectionType;
        private System.Windows.Forms.RadioButton radGeographic;
        private System.Windows.Forms.RadioButton radProjected;
        private System.Windows.Forms.ComboBox cmbMajorCategory;
        private System.Windows.Forms.ComboBox cmbMinorCategory;
        private System.Windows.Forms.GroupBox grbShapefile;
        private System.Windows.Forms.ComboBox cmbShapefile;
        private System.Windows.Forms.Button btnOk;
    }
}