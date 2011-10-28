namespace Cetecean
{
    partial class frmJoinPointsToPolygons
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
            this.grbOutput = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.grbPoint = new System.Windows.Forms.GroupBox();
            this.cmbInput2 = new System.Windows.Forms.ComboBox();
            this.grbJoin = new System.Windows.Forms.GroupBox();
            this.lstFields = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.grbPolygon = new System.Windows.Forms.GroupBox();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.cmbInput1 = new System.Windows.Forms.ComboBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.grbOutput.SuspendLayout();
            this.grbPoint.SuspendLayout();
            this.grbJoin.SuspendLayout();
            this.grbPolygon.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbOutput
            // 
            this.grbOutput.Controls.Add(this.txtOutput);
            this.grbOutput.Location = new System.Drawing.Point(12, 378);
            this.grbOutput.Name = "grbOutput";
            this.grbOutput.Size = new System.Drawing.Size(269, 59);
            this.grbOutput.TabIndex = 54;
            this.grbOutput.TabStop = false;
            this.grbOutput.Text = "Output Name";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(16, 19);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(224, 20);
            this.txtOutput.TabIndex = 0;
            // 
            // grbPoint
            // 
            this.grbPoint.Controls.Add(this.cmbInput2);
            this.grbPoint.Location = new System.Drawing.Point(12, 126);
            this.grbPoint.Name = "grbPoint";
            this.grbPoint.Size = new System.Drawing.Size(269, 57);
            this.grbPoint.TabIndex = 52;
            this.grbPoint.TabStop = false;
            this.grbPoint.Text = "Point Selection";
            // 
            // cmbInput2
            // 
            this.cmbInput2.FormattingEnabled = true;
            this.cmbInput2.Location = new System.Drawing.Point(6, 19);
            this.cmbInput2.Name = "cmbInput2";
            this.cmbInput2.Size = new System.Drawing.Size(202, 21);
            this.cmbInput2.TabIndex = 23;
            this.cmbInput2.Text = "{ select point layer }";
            this.cmbInput2.SelectedIndexChanged += new System.EventHandler(this.cmbInput2_SelectedIndexChanged);
            // 
            // grbJoin
            // 
            this.grbJoin.Controls.Add(this.lstFields);
            this.grbJoin.Location = new System.Drawing.Point(12, 189);
            this.grbJoin.Name = "grbJoin";
            this.grbJoin.Size = new System.Drawing.Size(231, 183);
            this.grbJoin.TabIndex = 53;
            this.grbJoin.TabStop = false;
            this.grbJoin.Text = "Select Join Fields";
            // 
            // lstFields
            // 
            this.lstFields.FormattingEnabled = true;
            this.lstFields.Location = new System.Drawing.Point(20, 29);
            this.lstFields.Name = "lstFields";
            this.lstFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFields.Size = new System.Drawing.Size(188, 134);
            this.lstFields.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(145, 465);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCalculate.Location = new System.Drawing.Point(53, 465);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(85, 23);
            this.btnCalculate.TabIndex = 49;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // grbPolygon
            // 
            this.grbPolygon.Controls.Add(this.cmbField);
            this.grbPolygon.Controls.Add(this.cmbInput1);
            this.grbPolygon.Location = new System.Drawing.Point(12, 12);
            this.grbPolygon.Name = "grbPolygon";
            this.grbPolygon.Size = new System.Drawing.Size(269, 85);
            this.grbPolygon.TabIndex = 51;
            this.grbPolygon.TabStop = false;
            this.grbPolygon.Text = "Polygon Selection";
            // 
            // cmbField
            // 
            this.cmbField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(21, 46);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(228, 21);
            this.cmbField.TabIndex = 28;
            this.cmbField.Text = "{ select the field with a unique polygon ID }";
            this.cmbField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // cmbInput1
            // 
            this.cmbInput1.FormattingEnabled = true;
            this.cmbInput1.Location = new System.Drawing.Point(6, 19);
            this.cmbInput1.Name = "cmbInput1";
            this.cmbInput1.Size = new System.Drawing.Size(199, 21);
            this.cmbInput1.TabIndex = 20;
            this.cmbInput1.Text = "{ select polygon layer }";
            this.cmbInput1.SelectedIndexChanged += new System.EventHandler(this.cmbInput1_SelectedIndexChanged);
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(30, 186);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(0, 13);
            this.lblPoint.TabIndex = 48;
            // 
            // frmJoinPointsToPolygons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 512);
            this.Controls.Add(this.grbOutput);
            this.Controls.Add(this.grbPoint);
            this.Controls.Add(this.grbJoin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.grbPolygon);
            this.Controls.Add(this.lblPoint);
            this.Name = "frmJoinPointsToPolygons";
            this.Text = "frmJoinPointsToPolygons";
            this.Load += new System.EventHandler(this.frmJoinPointsToPolygons_Load);
            this.grbOutput.ResumeLayout(false);
            this.grbOutput.PerformLayout();
            this.grbPoint.ResumeLayout(false);
            this.grbJoin.ResumeLayout(false);
            this.grbPolygon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox grbPoint;
        private System.Windows.Forms.ComboBox cmbInput2;
        private System.Windows.Forms.GroupBox grbJoin;
        private System.Windows.Forms.ListBox lstFields;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox grbPolygon;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.ComboBox cmbInput1;
        private System.Windows.Forms.Label lblPoint;
    }
}