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
            this.grbPoint = new System.Windows.Forms.GroupBox();
            this.cmbInput2 = new System.Windows.Forms.ComboBox();
            this.cmbSpecies = new System.Windows.Forms.ComboBox();
            this.grbPolygon = new System.Windows.Forms.GroupBox();
            this.cmbInput1 = new System.Windows.Forms.ComboBox();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblPoint = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSpeciesCount = new System.Windows.Forms.TextBox();
            this.lblSightings = new System.Windows.Forms.Label();
            this.txtSightings = new System.Windows.Forms.TextBox();
            this.ckbIncludeTotalSpecis = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radSession = new System.Windows.Forms.RadioButton();
            this.radNewShape = new System.Windows.Forms.RadioButton();
            this.radOriginal = new System.Windows.Forms.RadioButton();
            this.grbPoint.SuspendLayout();
            this.grbPolygon.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPoint
            // 
            this.grbPoint.Controls.Add(this.cmbInput2);
            this.grbPoint.Controls.Add(this.cmbSpecies);
            this.grbPoint.Location = new System.Drawing.Point(12, 107);
            this.grbPoint.Name = "grbPoint";
            this.grbPoint.Size = new System.Drawing.Size(293, 80);
            this.grbPoint.TabIndex = 39;
            this.grbPoint.TabStop = false;
            this.grbPoint.Text = "Point Selection";
            // 
            // cmbInput2
            // 
            this.cmbInput2.FormattingEnabled = true;
            this.cmbInput2.Location = new System.Drawing.Point(21, 19);
            this.cmbInput2.Name = "cmbInput2";
            this.cmbInput2.Size = new System.Drawing.Size(202, 21);
            this.cmbInput2.TabIndex = 23;
            this.cmbInput2.Text = "{ select point layer }";
            this.cmbInput2.SelectedIndexChanged += new System.EventHandler(this.cmbInput2_SelectedIndexChanged_1);
            // 
            // cmbSpecies
            // 
            this.cmbSpecies.FormattingEnabled = true;
            this.cmbSpecies.Location = new System.Drawing.Point(58, 46);
            this.cmbSpecies.Name = "cmbSpecies";
            this.cmbSpecies.Size = new System.Drawing.Size(228, 21);
            this.cmbSpecies.TabIndex = 29;
            this.cmbSpecies.Text = "{ select the field with species count data }";
            this.cmbSpecies.SelectedIndexChanged += new System.EventHandler(this.cmbSpecies_SelectedIndexChanged_1);
            // 
            // grbPolygon
            // 
            this.grbPolygon.Controls.Add(this.cmbInput1);
            this.grbPolygon.Controls.Add(this.cmbField);
            this.grbPolygon.Location = new System.Drawing.Point(12, 12);
            this.grbPolygon.Name = "grbPolygon";
            this.grbPolygon.Size = new System.Drawing.Size(298, 80);
            this.grbPolygon.TabIndex = 38;
            this.grbPolygon.TabStop = false;
            this.grbPolygon.Text = "Polygon Selection";
            // 
            // cmbInput1
            // 
            this.cmbInput1.FormattingEnabled = true;
            this.cmbInput1.Location = new System.Drawing.Point(17, 19);
            this.cmbInput1.Name = "cmbInput1";
            this.cmbInput1.Size = new System.Drawing.Size(199, 21);
            this.cmbInput1.TabIndex = 20;
            this.cmbInput1.Text = "{ select polygon layer }";
            this.cmbInput1.SelectedIndexChanged += new System.EventHandler(this.cmbInput1_SelectedIndexChanged_1);
            // 
            // cmbField
            // 
            this.cmbField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(58, 46);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(228, 21);
            this.cmbField.TabIndex = 27;
            this.cmbField.Text = "{ select the field with a unique polygon ID }";
            this.cmbField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged_1);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(146, 475);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCalculate.Location = new System.Drawing.Point(54, 475);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(85, 23);
            this.btnCalculate.TabIndex = 36;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click_1);
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(30, 130);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(0, 13);
            this.lblPoint.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSpeciesCount);
            this.groupBox1.Controls.Add(this.lblSightings);
            this.groupBox1.Controls.Add(this.txtSightings);
            this.groupBox1.Controls.Add(this.ckbIncludeTotalSpecis);
            this.groupBox1.Location = new System.Drawing.Point(12, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 127);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Attribute Fields";
            // 
            // txtSpeciesCount
            // 
            this.txtSpeciesCount.Location = new System.Drawing.Point(17, 98);
            this.txtSpeciesCount.Name = "txtSpeciesCount";
            this.txtSpeciesCount.Size = new System.Drawing.Size(110, 20);
            this.txtSpeciesCount.TabIndex = 34;
            this.txtSpeciesCount.Text = "species_count";
            // 
            // lblSightings
            // 
            this.lblSightings.AutoSize = true;
            this.lblSightings.Location = new System.Drawing.Point(14, 24);
            this.lblSightings.Name = "lblSightings";
            this.lblSightings.Size = new System.Drawing.Size(238, 13);
            this.lblSightings.TabIndex = 33;
            this.lblSightings.Text = "Attribute field for number of sightings per polygon.";
            // 
            // txtSightings
            // 
            this.txtSightings.Location = new System.Drawing.Point(17, 40);
            this.txtSightings.Name = "txtSightings";
            this.txtSightings.Size = new System.Drawing.Size(110, 20);
            this.txtSightings.TabIndex = 32;
            this.txtSightings.Text = "sightings";
            // 
            // ckbIncludeTotalSpecis
            // 
            this.ckbIncludeTotalSpecis.AutoSize = true;
            this.ckbIncludeTotalSpecis.Checked = true;
            this.ckbIncludeTotalSpecis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIncludeTotalSpecis.Location = new System.Drawing.Point(17, 75);
            this.ckbIncludeTotalSpecis.Name = "ckbIncludeTotalSpecis";
            this.ckbIncludeTotalSpecis.Size = new System.Drawing.Size(269, 17);
            this.ckbIncludeTotalSpecis.TabIndex = 25;
            this.ckbIncludeTotalSpecis.Text = "Include attribute field for species count per polygon.";
            this.ckbIncludeTotalSpecis.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radSession);
            this.groupBox2.Controls.Add(this.radNewShape);
            this.groupBox2.Controls.Add(this.radOriginal);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(29, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 118);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save Options";
            // 
            // radSession
            // 
            this.radSession.AutoSize = true;
            this.radSession.Location = new System.Drawing.Point(19, 88);
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
            this.radNewShape.Location = new System.Drawing.Point(19, 52);
            this.radNewShape.Name = "radNewShape";
            this.radNewShape.Size = new System.Drawing.Size(209, 30);
            this.radNewShape.TabIndex = 68;
            this.radNewShape.TabStop = true;
            this.radNewShape.Text = "Save the updated attributes to a NEW \r\npoint shapefile";
            this.radNewShape.UseVisualStyleBackColor = true;
            // 
            // radOriginal
            // 
            this.radOriginal.AutoSize = true;
            this.radOriginal.Location = new System.Drawing.Point(19, 16);
            this.radOriginal.Name = "radOriginal";
            this.radOriginal.Size = new System.Drawing.Size(243, 30);
            this.radOriginal.TabIndex = 67;
            this.radOriginal.Text = "Save the updated attributes to the ORIGINAL \r\npoint shapefile";
            this.radOriginal.UseVisualStyleBackColor = true;
            // 
            // frmCountSpecies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 510);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbPoint);
            this.Controls.Add(this.grbPolygon);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblPoint);
            this.Name = "frmCountSpecies";
            this.Text = "Count Species per Polygon";
            this.Load += new System.EventHandler(this.frmCountSpecies_Load);
            this.grbPoint.ResumeLayout(false);
            this.grbPolygon.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPoint;
        private System.Windows.Forms.ComboBox cmbInput2;
        private System.Windows.Forms.ComboBox cmbSpecies;
        private System.Windows.Forms.GroupBox grbPolygon;
        private System.Windows.Forms.ComboBox cmbInput1;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSpeciesCount;
        private System.Windows.Forms.Label lblSightings;
        private System.Windows.Forms.TextBox txtSightings;
        private System.Windows.Forms.CheckBox ckbIncludeTotalSpecis;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radSession;
        private System.Windows.Forms.RadioButton radNewShape;
        private System.Windows.Forms.RadioButton radOriginal;

    }
}