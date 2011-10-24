namespace Cetecean
{
    partial class frmCalculateBuffer
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpParameters = new System.Windows.Forms.GroupBox();
            this.cbxDissolve = new System.Windows.Forms.ComboBox();
            this.chkDissolve = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxField2 = new System.Windows.Forms.ComboBox();
            this.cbxField1 = new System.Windows.Forms.ComboBox();
            this.rbtTwo = new System.Windows.Forms.RadioButton();
            this.rbtOne = new System.Windows.Forms.RadioButton();
            this.cbxLayer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grpParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.grpParameters);
            this.panel1.Controls.Add(this.cbxLayer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 310);
            this.panel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(264, 273);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Create buffer";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(169, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpParameters
            // 
            this.grpParameters.Controls.Add(this.cbxDissolve);
            this.grpParameters.Controls.Add(this.chkDissolve);
            this.grpParameters.Controls.Add(this.label3);
            this.grpParameters.Controls.Add(this.label2);
            this.grpParameters.Controls.Add(this.cbxField2);
            this.grpParameters.Controls.Add(this.cbxField1);
            this.grpParameters.Controls.Add(this.rbtTwo);
            this.grpParameters.Controls.Add(this.rbtOne);
            this.grpParameters.Location = new System.Drawing.Point(22, 58);
            this.grpParameters.Name = "grpParameters";
            this.grpParameters.Size = new System.Drawing.Size(335, 203);
            this.grpParameters.TabIndex = 2;
            this.grpParameters.TabStop = false;
            this.grpParameters.Text = "Define buffer ";
            // 
            // cbxDissolve
            // 
            this.cbxDissolve.FormattingEnabled = true;
            this.cbxDissolve.Location = new System.Drawing.Point(187, 159);
            this.cbxDissolve.Name = "cbxDissolve";
            this.cbxDissolve.Size = new System.Drawing.Size(84, 21);
            this.cbxDissolve.TabIndex = 7;
            // 
            // chkDissolve
            // 
            this.chkDissolve.AutoSize = true;
            this.chkDissolve.Location = new System.Drawing.Point(30, 161);
            this.chkDissolve.Name = "chkDissolve";
            this.chkDissolve.Size = new System.Drawing.Size(151, 17);
            this.chkDissolve.TabIndex = 6;
            this.chkDissolve.Text = "Dissolve polygon by a field";
            this.chkDissolve.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Field 2 (Left side):";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Field :";
            // 
            // cbxField2
            // 
            this.cbxField2.FormattingEnabled = true;
            this.cbxField2.Location = new System.Drawing.Point(130, 122);
            this.cbxField2.Name = "cbxField2";
            this.cbxField2.Size = new System.Drawing.Size(121, 21);
            this.cbxField2.TabIndex = 3;
            this.cbxField2.Visible = false;
            // 
            // cbxField1
            // 
            this.cbxField1.FormattingEnabled = true;
            this.cbxField1.Location = new System.Drawing.Point(130, 90);
            this.cbxField1.Name = "cbxField1";
            this.cbxField1.Size = new System.Drawing.Size(121, 21);
            this.cbxField1.TabIndex = 2;
            // 
            // rbtTwo
            // 
            this.rbtTwo.AutoSize = true;
            this.rbtTwo.Location = new System.Drawing.Point(30, 57);
            this.rbtTwo.Name = "rbtTwo";
            this.rbtTwo.Size = new System.Drawing.Size(155, 17);
            this.rbtTwo.TabIndex = 1;
            this.rbtTwo.Text = "Two fields (Different widths)";
            this.rbtTwo.UseVisualStyleBackColor = true;
            this.rbtTwo.CheckedChanged += new System.EventHandler(this.rbtTwo_CheckedChanged);
            // 
            // rbtOne
            // 
            this.rbtOne.AutoSize = true;
            this.rbtOne.Checked = true;
            this.rbtOne.Location = new System.Drawing.Point(30, 29);
            this.rbtOne.Name = "rbtOne";
            this.rbtOne.Size = new System.Drawing.Size(182, 17);
            this.rbtOne.TabIndex = 0;
            this.rbtOne.TabStop = true;
            this.rbtOne.Text = "One field (Same width both sides)";
            this.rbtOne.UseVisualStyleBackColor = true;
            this.rbtOne.CheckedChanged += new System.EventHandler(this.rbtOne_CheckedChanged);
            // 
            // cbxLayer
            // 
            this.cbxLayer.FormattingEnabled = true;
            this.cbxLayer.Location = new System.Drawing.Point(80, 21);
            this.cbxLayer.Name = "cbxLayer";
            this.cbxLayer.Size = new System.Drawing.Size(121, 21);
            this.cbxLayer.TabIndex = 1;
            this.cbxLayer.SelectedIndexChanged += new System.EventHandler(this.cbxLayer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line layer:";
            // 
            // frmCalculateBuffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 310);
            this.Controls.Add(this.panel1);
            this.Name = "frmCalculateBuffer";
            this.Text = "Calculate buffer";
            this.Load += new System.EventHandler(this.frmCalculateBuffer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpParameters.ResumeLayout(false);
            this.grpParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpParameters;
        private System.Windows.Forms.ComboBox cbxDissolve;
        private System.Windows.Forms.CheckBox chkDissolve;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxField2;
        private System.Windows.Forms.ComboBox cbxField1;
        private System.Windows.Forms.RadioButton rbtTwo;
        private System.Windows.Forms.RadioButton rbtOne;
        private System.Windows.Forms.ComboBox cbxLayer;
        private System.Windows.Forms.Label label1;
    }
}