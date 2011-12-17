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
            this.cbxSideType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuffer = new System.Windows.Forms.TextBox();
            this.rbtBuffer = new System.Windows.Forms.RadioButton();
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
            this.panel1.Size = new System.Drawing.Size(351, 396);
            this.panel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(234, 347);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Create buffer";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(139, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpParameters
            // 
            this.grpParameters.Controls.Add(this.cbxSideType);
            this.grpParameters.Controls.Add(this.label4);
            this.grpParameters.Controls.Add(this.txtBuffer);
            this.grpParameters.Controls.Add(this.rbtBuffer);
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
            this.grpParameters.Size = new System.Drawing.Size(305, 271);
            this.grpParameters.TabIndex = 2;
            this.grpParameters.TabStop = false;
            this.grpParameters.Text = "Define buffer ";
            // 
            // cbxSideType
            // 
            this.cbxSideType.FormattingEnabled = true;
            this.cbxSideType.Location = new System.Drawing.Point(185, 180);
            this.cbxSideType.Name = "cbxSideType";
            this.cbxSideType.Size = new System.Drawing.Size(65, 21);
            this.cbxSideType.TabIndex = 11;
            this.cbxSideType.SelectedIndexChanged += new System.EventHandler(this.cbxSideType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Side Type:";
            // 
            // txtBuffer
            // 
            this.txtBuffer.Location = new System.Drawing.Point(185, 27);
            this.txtBuffer.Name = "txtBuffer";
            this.txtBuffer.Size = new System.Drawing.Size(95, 20);
            this.txtBuffer.TabIndex = 9;
            this.txtBuffer.Tag = "Buffer ";
            // 
            // rbtBuffer
            // 
            this.rbtBuffer.AutoSize = true;
            this.rbtBuffer.Checked = true;
            this.rbtBuffer.Location = new System.Drawing.Point(28, 27);
            this.rbtBuffer.Name = "rbtBuffer";
            this.rbtBuffer.Size = new System.Drawing.Size(117, 17);
            this.rbtBuffer.TabIndex = 8;
            this.rbtBuffer.TabStop = true;
            this.rbtBuffer.Text = "Linear unit  (meters)";
            this.rbtBuffer.UseVisualStyleBackColor = true;
            this.rbtBuffer.CheckedChanged += new System.EventHandler(this.rbtBuffer_CheckedChanged);
            // 
            // cbxDissolve
            // 
            this.cbxDissolve.FormattingEnabled = true;
            this.cbxDissolve.Location = new System.Drawing.Point(196, 224);
            this.cbxDissolve.Name = "cbxDissolve";
            this.cbxDissolve.Size = new System.Drawing.Size(84, 21);
            this.cbxDissolve.TabIndex = 7;
            this.cbxDissolve.Visible = false;
            this.cbxDissolve.SelectedIndexChanged += new System.EventHandler(this.cbxDissolve_SelectedIndexChanged);
            // 
            // chkDissolve
            // 
            this.chkDissolve.AutoSize = true;
            this.chkDissolve.Location = new System.Drawing.Point(29, 224);
            this.chkDissolve.Name = "chkDissolve";
            this.chkDissolve.Size = new System.Drawing.Size(111, 17);
            this.chkDissolve.TabIndex = 6;
            this.chkDissolve.Text = "Dissolve by a field";
            this.chkDissolve.UseVisualStyleBackColor = true;
            this.chkDissolve.Visible = false;
            this.chkDissolve.CheckedChanged += new System.EventHandler(this.chkDissolve_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Field 2 (Left side):";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Field :";
            this.label2.Visible = false;
            // 
            // cbxField2
            // 
            this.cbxField2.FormattingEnabled = true;
            this.cbxField2.Location = new System.Drawing.Point(129, 148);
            this.cbxField2.Name = "cbxField2";
            this.cbxField2.Size = new System.Drawing.Size(121, 21);
            this.cbxField2.TabIndex = 3;
            this.cbxField2.Visible = false;
            // 
            // cbxField1
            // 
            this.cbxField1.FormattingEnabled = true;
            this.cbxField1.Location = new System.Drawing.Point(129, 116);
            this.cbxField1.Name = "cbxField1";
            this.cbxField1.Size = new System.Drawing.Size(121, 21);
            this.cbxField1.TabIndex = 2;
            this.cbxField1.Visible = false;
            // 
            // rbtTwo
            // 
            this.rbtTwo.AutoSize = true;
            this.rbtTwo.Location = new System.Drawing.Point(28, 85);
            this.rbtTwo.Name = "rbtTwo";
            this.rbtTwo.Size = new System.Drawing.Size(130, 17);
            this.rbtTwo.TabIndex = 1;
            this.rbtTwo.Text = "Two fields (Two sides)";
            this.rbtTwo.UseVisualStyleBackColor = true;
            this.rbtTwo.CheckedChanged += new System.EventHandler(this.rbtTwo_CheckedChanged);
            // 
            // rbtOne
            // 
            this.rbtOne.AutoSize = true;
            this.rbtOne.Location = new System.Drawing.Point(28, 57);
            this.rbtOne.Name = "rbtOne";
            this.rbtOne.Size = new System.Drawing.Size(70, 17);
            this.rbtOne.TabIndex = 0;
            this.rbtOne.Text = "One field ";
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
            this.ClientSize = new System.Drawing.Size(351, 396);
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
        private System.Windows.Forms.TextBox txtBuffer;
        private System.Windows.Forms.RadioButton rbtBuffer;
        private System.Windows.Forms.ComboBox cbxSideType;
        private System.Windows.Forms.Label label4;
    }
}