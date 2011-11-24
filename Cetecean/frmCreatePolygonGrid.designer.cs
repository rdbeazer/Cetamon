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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateGrid = new System.Windows.Forms.Button();
            this.grbParameters = new System.Windows.Forms.GroupBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtGridSizeY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGridSizeX = new System.Windows.Forms.TextBox();
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
            this.rbtBox = new System.Windows.Forms.RadioButton();
            this.rbtPointOrigin = new System.Windows.Forms.RadioButton();
            this.cbxEdit = new System.Windows.Forms.CheckBox();
            this.pnl.SuspendLayout();
            this.grbParameters.SuspendLayout();
            this.rbtPointOrign.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.progressBar1);
            this.pnl.Controls.Add(this.label9);
            this.pnl.Controls.Add(this.btnOK);
            this.pnl.Controls.Add(this.btnCancel);
            this.pnl.Controls.Add(this.btnCreateGrid);
            this.pnl.Controls.Add(this.grbParameters);
            this.pnl.Controls.Add(this.rbtPointOrign);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(426, 371);
            this.pnl.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 346);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(392, 13);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(173, 314);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 26);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(327, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateGrid
            // 
            this.btnCreateGrid.Location = new System.Drawing.Point(19, 314);
            this.btnCreateGrid.Name = "btnCreateGrid";
            this.btnCreateGrid.Size = new System.Drawing.Size(81, 26);
            this.btnCreateGrid.TabIndex = 2;
            this.btnCreateGrid.Text = "Create Grid";
            this.btnCreateGrid.UseVisualStyleBackColor = true;
            this.btnCreateGrid.Click += new System.EventHandler(this.btnCreateGrid_Click);
            // 
            // grbParameters
            // 
            this.grbParameters.Controls.Add(this.cbxEdit);
            this.grbParameters.Controls.Add(this.btnCalculate);
            this.grbParameters.Controls.Add(this.txtGridSizeY);
            this.grbParameters.Controls.Add(this.label8);
            this.grbParameters.Controls.Add(this.txtGridSizeX);
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
            this.grbParameters.Size = new System.Drawing.Size(400, 229);
            this.grbParameters.TabIndex = 1;
            this.grbParameters.TabStop = false;
            this.grbParameters.Text = "Parameters Grid";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(257, 177);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(59, 23);
            this.btnCalculate.TabIndex = 16;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtGridSizeY
            // 
            this.txtGridSizeY.Location = new System.Drawing.Point(174, 190);
            this.txtGridSizeY.Name = "txtGridSizeY";
            this.txtGridSizeY.Size = new System.Drawing.Size(75, 20);
            this.txtGridSizeY.TabIndex = 15;
            this.txtGridSizeY.Tag = "dy";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 14;
            this.label8.Tag = "dy";
            this.label8.Text = "Grid size (dy):";
            // 
            // txtGridSizeX
            // 
            this.txtGridSizeX.Location = new System.Drawing.Point(174, 164);
            this.txtGridSizeX.Name = "txtGridSizeX";
            this.txtGridSizeX.Size = new System.Drawing.Size(75, 20);
            this.txtGridSizeX.TabIndex = 13;
            this.txtGridSizeX.Tag = "dx";
            this.txtGridSizeX.TextChanged += new System.EventHandler(this.txtGridSize_TextChanged);
            // 
            // txtNumRows
            // 
            this.txtNumRows.Location = new System.Drawing.Point(174, 138);
            this.txtNumRows.Name = "txtNumRows";
            this.txtNumRows.Size = new System.Drawing.Size(75, 20);
            this.txtNumRows.TabIndex = 12;
            this.txtNumRows.Tag = "Num of rows";
            this.txtNumRows.TextChanged += new System.EventHandler(this.txtNumRows_TextChanged);
            // 
            // txtNumColumns
            // 
            this.txtNumColumns.Location = new System.Drawing.Point(174, 112);
            this.txtNumColumns.Name = "txtNumColumns";
            this.txtNumColumns.Size = new System.Drawing.Size(75, 20);
            this.txtNumColumns.TabIndex = 11;
            this.txtNumColumns.Tag = "Num of Columns";
            this.txtNumColumns.TextChanged += new System.EventHandler(this.txtNumColumns_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 10;
            this.label7.Tag = "dx";
            this.label7.Text = "Grid size (dx):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Number of Rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Number of Columns:";
            // 
            // txtYmax
            // 
            this.txtYmax.Enabled = false;
            this.txtYmax.Location = new System.Drawing.Point(213, 82);
            this.txtYmax.Name = "txtYmax";
            this.txtYmax.Size = new System.Drawing.Size(118, 20);
            this.txtYmax.TabIndex = 7;
            this.txtYmax.Tag = "Ymax";
            this.txtYmax.Visible = false;
            // 
            // txtXmax
            // 
            this.txtXmax.Enabled = false;
            this.txtXmax.Location = new System.Drawing.Point(211, 40);
            this.txtXmax.Name = "txtXmax";
            this.txtXmax.Size = new System.Drawing.Size(118, 20);
            this.txtXmax.TabIndex = 6;
            this.txtXmax.Tag = "Xmax";
            this.txtXmax.Visible = false;
            // 
            // txtYmin
            // 
            this.txtYmin.Enabled = false;
            this.txtYmin.Location = new System.Drawing.Point(47, 82);
            this.txtYmin.Name = "txtYmin";
            this.txtYmin.Size = new System.Drawing.Size(118, 20);
            this.txtYmin.TabIndex = 5;
            this.txtYmin.Tag = "Ymin";
            // 
            // txtXmin
            // 
            this.txtXmin.Enabled = false;
            this.txtXmin.Location = new System.Drawing.Point(47, 42);
            this.txtXmin.Name = "txtXmin";
            this.txtXmin.Size = new System.Drawing.Size(118, 20);
            this.txtXmin.TabIndex = 4;
            this.txtXmin.Tag = "Xmin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(171, 82);
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
            this.label3.Location = new System.Drawing.Point(171, 43);
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
            this.label2.Location = new System.Drawing.Point(16, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ymin";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Enabled = false;
            this.Label1.Location = new System.Drawing.Point(16, 43);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(30, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Xmin";
            // 
            // rbtPointOrign
            // 
            this.rbtPointOrign.Controls.Add(this.rbtBox);
            this.rbtPointOrign.Controls.Add(this.rbtPointOrigin);
            this.rbtPointOrign.Location = new System.Drawing.Point(12, 12);
            this.rbtPointOrign.Name = "rbtPointOrign";
            this.rbtPointOrign.Size = new System.Drawing.Size(402, 62);
            this.rbtPointOrign.TabIndex = 0;
            this.rbtPointOrign.TabStop = false;
            this.rbtPointOrign.Text = "Based on:";
            // 
            // rbtBox
            // 
            this.rbtBox.AutoSize = true;
            this.rbtBox.Location = new System.Drawing.Point(304, 28);
            this.rbtBox.Name = "rbtBox";
            this.rbtBox.Size = new System.Drawing.Size(43, 17);
            this.rbtBox.TabIndex = 1;
            this.rbtBox.Text = "Box";
            this.rbtBox.UseVisualStyleBackColor = true;
            this.rbtBox.CheckedChanged += new System.EventHandler(this.rbtBox_CheckedChanged);
            this.rbtBox.Click += new System.EventHandler(this.rbtBox_Click);
            // 
            // rbtPointOrigin
            // 
            this.rbtPointOrigin.AutoSize = true;
            this.rbtPointOrigin.Location = new System.Drawing.Point(21, 28);
            this.rbtPointOrigin.Name = "rbtPointOrigin";
            this.rbtPointOrigin.Size = new System.Drawing.Size(89, 17);
            this.rbtPointOrigin.TabIndex = 0;
            this.rbtPointOrigin.Text = "Point of origin";
            this.rbtPointOrigin.UseVisualStyleBackColor = true;
            this.rbtPointOrigin.CheckedChanged += new System.EventHandler(this.rbtPointOrigin_CheckedChanged);
            this.rbtPointOrigin.Click += new System.EventHandler(this.rbtPointOrigin_Click);
            // 
            // cbxEdit
            // 
            this.cbxEdit.AutoSize = true;
            this.cbxEdit.Location = new System.Drawing.Point(350, 19);
            this.cbxEdit.Name = "cbxEdit";
            this.cbxEdit.Size = new System.Drawing.Size(44, 17);
            this.cbxEdit.TabIndex = 17;
            this.cbxEdit.Text = "Edit";
            this.cbxEdit.UseVisualStyleBackColor = true;
            this.cbxEdit.CheckedChanged += new System.EventHandler(this.cbxEdit_CheckedChanged);
            // 
            // frmCreatePolygonGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 371);
            this.ControlBox = false;
            this.Controls.Add(this.pnl);
            this.Name = "frmCreatePolygonGrid";
            this.Text = "Create Polygon Grid";
            this.Load += new System.EventHandler(this.frmCreatePolygonGrid_Load);
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
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
        private System.Windows.Forms.TextBox txtGridSizeX;
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
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtGridSizeY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.CheckBox cbxEdit;
    }
}