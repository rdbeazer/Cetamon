namespace Cetecean
{
    partial class frmSplitPolygons
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPolygon1 = new System.Windows.Forms.ComboBox();
            this.cbxPolygon2 = new System.Windows.Forms.ComboBox();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Survey Swathes (Polygon)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Polygon Layer";
            // 
            // cbxPolygon1
            // 
            this.cbxPolygon1.FormattingEnabled = true;
            this.cbxPolygon1.Location = new System.Drawing.Point(36, 36);
            this.cbxPolygon1.Name = "cbxPolygon1";
            this.cbxPolygon1.Size = new System.Drawing.Size(238, 21);
            this.cbxPolygon1.TabIndex = 2;
            this.cbxPolygon1.SelectedIndexChanged += new System.EventHandler(this.cbxPolygon1_SelectedIndexChanged);
            // 
            // cbxPolygon2
            // 
            this.cbxPolygon2.FormattingEnabled = true;
            this.cbxPolygon2.Location = new System.Drawing.Point(36, 93);
            this.cbxPolygon2.Name = "cbxPolygon2";
            this.cbxPolygon2.Size = new System.Drawing.Size(238, 21);
            this.cbxPolygon2.TabIndex = 3;
            this.cbxPolygon2.SelectedIndexChanged += new System.EventHandler(this.cbxPolygon2_SelectedIndexChanged);
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(36, 140);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 4;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(199, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSplitPolygons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 175);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.cbxPolygon2);
            this.Controls.Add(this.cbxPolygon1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSplitPolygons";
            this.Text = "Split Survey Swathes By Polygons ";
            this.Load += new System.EventHandler(this.frmSplitPolygons_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxPolygon1;
        private System.Windows.Forms.ComboBox cbxPolygon2;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnCancel;
    }
}