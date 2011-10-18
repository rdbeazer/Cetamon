namespace Cetecean
{
    partial class frmCreatePolygonGrid
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
            this.pnl = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateGrid = new System.Windows.Forms.Button();
            this.grbParameters = new System.Windows.Forms.GroupBox();
            this.txtGridSize = new System.Windows.Forms.TextBox();
            this.txtNumRows = new System.Windows.Forms.TextBox();
            this.txtNumColumns = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYmax = new System.Windows.Forms.TextBox();
            this.txtXmax = new System.Windows.Forms.TextBox();
            this.txtYmin = new System.Windows.Forms.TextBox();
            this.txtXmin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.rbtPointOrign = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCaptureArea = new System.Windows.Forms.Button();
            this.rbtBox = new System.Windows.Forms.RadioButton();
            this.rbtPointOrigin = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnl.SuspendLayout();
            this.grbParameters.SuspendLayout();
            this.rbtPointOrign.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.btnOK);
            this.pnl.Controls.Add(this.btnCancel);
            this.pnl.Controls.Add(this.btnCreateGrid);
            this.pnl.Controls.Add(this.grbParameters);
            this.pnl.Controls.Add(this.rbtPointOrign);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(399, 309);
            this.pnl.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(305, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateGrid
            // 
            this.btnCreateGrid.Location = new System.Drawing.Point(108, 276);
            this.btnCreateGrid.Name = "btnCreateGrid";
            this.btnCreateGrid.Size = new System.Drawing.Size(81, 26);
            this.btnCreateGrid.TabIndex = 2;
            this.btnCreateGrid.Text = "Create Grid";
            this.btnCreateGrid.UseVisualStyleBackColor = true;
            this.btnCreateGrid.Click += new System.EventHandler(this.btnCreateGrid_Click);
            // 
            // grbParameters
            // 
            this.grbParameters.Controls.Add(this.txtGridSize);
            this.grbParameters.Controls.Add(this.txtNumRows);
            this.grbParameters.Controls.Add(this.txtNumColumns);
            this.grbParameters.Controls.Add(this.label7);
            this.grbParameters.Controls.Add(this.label6);
            this.grbParameters.Controls.Add(this.label5);
            this.grbParameters.Controls.Add(this.txtYmax);
            this.grbParameters.Controls.Add(this.txtXmax);
            this.grbParameters.Controls.Add(this.txtYmin);
            this.grbParameters.Controls.Add(this.txtXmin);
            this.grbParameters.Controls.Add(this.label4);
            this.grbParameters.Controls.Add(this.label3);
            this.grbParameters.Controls.Add(this.label2);
            this.grbParameters.Controls.Add(this.Label1);
            this.grbParameters.Enabled = false;
            this.grbParameters.Location = new System.Drawing.Point(14, 79);
            this.grbParameters.Name = "grbParameters";
            this.grbParameters.Size = new System.Drawing.Size(372, 191);
            this.grbParameters.TabIndex = 1;
            this.grbParameters.TabStop = false;
            this.grbParameters.Text = "Parameters Grid";
            // 
            // txtGridSize
            // 
            this.txtGridSize.Location = new System.Drawing.Point(184, 158);
            this.txtGridSize.Name = "txtGridSize";
            this.txtGridSize.Size = new System.Drawing.Size(75, 20);
            this.txtGridSize.TabIndex = 13;
            this.txtGridSize.TextChanged += new System.EventHandler(this.txtGridSize_TextChanged);
            // 
            // txtNumRows
            // 
            this.txtNumRows.Location = new System.Drawing.Point(184, 132);
            this.txtNumRows.Name = "txtNumRows";
            this.txtNumRows.Size = new System.Drawing.Size(75, 20);
            this.txtNumRows.TabIndex = 12;
            this.txtNumRows.TextChanged += new System.EventHandler(this.txtNumRows_TextChanged);
            // 
            // txtNumColumns
            // 
            this.txtNumColumns.Location = new System.Drawing.Point(184, 106);
            this.txtNumColumns.Name = "txtNumColumns";
            this.txtNumColumns.Size = new System.Drawing.Size(75, 20);
            this.txtNumColumns.TabIndex = 11;
            this.txtNumColumns.TextChanged += new System.EventHandler(this.txtNumColumns_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Grid size:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Number of Rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Number of Columns:";
            // 
            // txtYmax
            // 
            this.txtYmax.Enabled = false;
            this.txtYmax.Location = new System.Drawing.Point(223, 76);
            this.txtYmax.Name = "txtYmax";
            this.txtYmax.Size = new System.Drawing.Size(118, 20);
            this.txtYmax.TabIndex = 7;
            this.txtYmax.Visible = false;
            // 
            // txtXmax
            // 
            this.txtXmax.Enabled = false;
            this.txtXmax.Location = new System.Drawing.Point(221, 34);
            this.txtXmax.Name = "txtXmax";
            this.txtXmax.Size = new System.Drawing.Size(118, 20);
            this.txtXmax.TabIndex = 6;
            this.txtXmax.Visible = false;
            // 
            // txtYmin
            // 
            this.txtYmin.Enabled = false;
            this.txtYmin.Location = new System.Drawing.Point(57, 76);
            this.txtYmin.Name = "txtYmin";
            this.txtYmin.Size = new System.Drawing.Size(118, 20);
            this.txtYmin.TabIndex = 5;
            // 
            // txtXmin
            // 
            this.txtXmin.Enabled = false;
            this.txtXmin.Location = new System.Drawing.Point(57, 36);
            this.txtXmin.Name = "txtXmin";
            this.txtXmin.Size = new System.Drawing.Size(118, 20);
            this.txtXmin.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(181, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ymax";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(181, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Xmax";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(26, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ymin";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Enabled = false;
            this.Label1.Location = new System.Drawing.Point(26, 37);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(30, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Xmin";
            // 
            // rbtPointOrign
            // 
            this.rbtPointOrign.Controls.Add(this.label8);
            this.rbtPointOrign.Controls.Add(this.btnCaptureArea);
            this.rbtPointOrign.Controls.Add(this.rbtBox);
            this.rbtPointOrign.Controls.Add(this.rbtPointOrigin);
            this.rbtPointOrign.Location = new System.Drawing.Point(12, 12);
            this.rbtPointOrign.Name = "rbtPointOrign";
            this.rbtPointOrign.Size = new System.Drawing.Size(375, 62);
            this.rbtPointOrign.TabIndex = 0;
            this.rbtPointOrign.TabStop = false;
            this.rbtPointOrign.Text = "Based on:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(171, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Please pick an origin:";
            // 
            // btnCaptureArea
            // 
            this.btnCaptureArea.Location = new System.Drawing.Point(293, 23);
            this.btnCaptureArea.Name = "btnCaptureArea";
            this.btnCaptureArea.Size = new System.Drawing.Size(32, 26);
            this.btnCaptureArea.TabIndex = 2;
            this.btnCaptureArea.Text = "...";
            this.btnCaptureArea.UseVisualStyleBackColor = true;
            this.btnCaptureArea.Click += new System.EventHandler(this.btnCaptureArea_Click);
            // 
            // rbtBox
            // 
            this.rbtBox.AutoSize = true;
            this.rbtBox.Location = new System.Drawing.Point(116, 28);
            this.rbtBox.Name = "rbtBox";
            this.rbtBox.Size = new System.Drawing.Size(43, 17);
            this.rbtBox.TabIndex = 1;
            this.rbtBox.Text = "Box";
            this.rbtBox.UseVisualStyleBackColor = true;
            this.rbtBox.Click += new System.EventHandler(this.rbtBox_Click);
            // 
            // rbtPointOrigin
            // 
            this.rbtPointOrigin.AutoSize = true;
            this.rbtPointOrigin.Checked = true;
            this.rbtPointOrigin.Location = new System.Drawing.Point(21, 28);
            this.rbtPointOrigin.Name = "rbtPointOrigin";
            this.rbtPointOrigin.Size = new System.Drawing.Size(89, 17);
            this.rbtPointOrigin.TabIndex = 0;
            this.rbtPointOrigin.TabStop = true;
            this.rbtPointOrigin.Text = "Point of origin";
            this.rbtPointOrigin.UseVisualStyleBackColor = true;
            this.rbtPointOrigin.Click += new System.EventHandler(this.rbtPointOrigin_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(210, 276);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 26);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmCreatePolygonGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 309);
            this.Controls.Add(this.pnl);
            this.Name = "frmCreatePolygonGrid";
            this.Text = "Create Polygon Grid";
            this.pnl.ResumeLayout(false);
            this.grbParameters.ResumeLayout(false);
            this.grbParameters.PerformLayout();
            this.rbtPointOrign.ResumeLayout(false);
            this.rbtPointOrign.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreateGrid;
        private System.Windows.Forms.GroupBox grbParameters;
        private System.Windows.Forms.TextBox txtGridSize;
        private System.Windows.Forms.TextBox txtNumRows;
        private System.Windows.Forms.TextBox txtNumColumns;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYmax;
        private System.Windows.Forms.TextBox txtXmax;
        private System.Windows.Forms.TextBox txtYmin;
        private System.Windows.Forms.TextBox txtXmin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox rbtPointOrign;
        private System.Windows.Forms.RadioButton rbtBox;
        private System.Windows.Forms.RadioButton rbtPointOrigin;
        private System.Windows.Forms.Button btnCaptureArea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOK;
    }
}