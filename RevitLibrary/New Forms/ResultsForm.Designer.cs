namespace RevitLibrary.Forms
{
    partial class ResultsForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbProjects = new System.Windows.Forms.ListBox();
            this.btnTimeVsCost = new System.Windows.Forms.Button();
            this.btnTimeVSEI = new System.Windows.Forms.Button();
            this.btnCostVSEI = new System.Windows.Forms.Button();
            this.btn3D = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(92, 14);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Name:";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(92, 40);
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(100, 20);
            this.txtCost.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total Cost:";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(92, 92);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.ReadOnly = true;
            this.txtDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDuration.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Duration:";
            // 
            // txtEI
            // 
            this.txtEI.Location = new System.Drawing.Point(92, 66);
            this.txtEI.Name = "txtEI";
            this.txtEI.ReadOnly = true;
            this.txtEI.Size = new System.Drawing.Size(100, 20);
            this.txtEI.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total EI:";
            // 
            // lbProjects
            // 
            this.lbProjects.FormattingEnabled = true;
            this.lbProjects.HorizontalScrollbar = true;
            this.lbProjects.Location = new System.Drawing.Point(12, 134);
            this.lbProjects.Name = "lbProjects";
            this.lbProjects.Size = new System.Drawing.Size(512, 173);
            this.lbProjects.TabIndex = 10;
            this.lbProjects.SelectedIndexChanged += new System.EventHandler(this.lbProjects_SelectedIndexChanged);
            // 
            // btnTimeVsCost
            // 
            this.btnTimeVsCost.Location = new System.Drawing.Point(316, 12);
            this.btnTimeVsCost.Name = "btnTimeVsCost";
            this.btnTimeVsCost.Size = new System.Drawing.Size(116, 23);
            this.btnTimeVsCost.TabIndex = 11;
            this.btnTimeVsCost.Text = "View Time VS Cost";
            this.btnTimeVsCost.UseVisualStyleBackColor = true;
            this.btnTimeVsCost.Click += new System.EventHandler(this.btnTimeVsCost_Click);
            // 
            // btnTimeVSEI
            // 
            this.btnTimeVSEI.Location = new System.Drawing.Point(316, 43);
            this.btnTimeVSEI.Name = "btnTimeVSEI";
            this.btnTimeVSEI.Size = new System.Drawing.Size(116, 23);
            this.btnTimeVSEI.TabIndex = 12;
            this.btnTimeVSEI.Text = "View Time VS EI";
            this.btnTimeVSEI.UseVisualStyleBackColor = true;
            this.btnTimeVSEI.Click += new System.EventHandler(this.btnTimeVSEI_Click);
            // 
            // btnCostVSEI
            // 
            this.btnCostVSEI.Location = new System.Drawing.Point(316, 72);
            this.btnCostVSEI.Name = "btnCostVSEI";
            this.btnCostVSEI.Size = new System.Drawing.Size(116, 23);
            this.btnCostVSEI.TabIndex = 13;
            this.btnCostVSEI.Text = "View Cost VS EI";
            this.btnCostVSEI.UseVisualStyleBackColor = true;
            this.btnCostVSEI.Click += new System.EventHandler(this.btnCostVSEI_Click);
            // 
            // btn3D
            // 
            this.btn3D.Enabled = false;
            this.btn3D.Location = new System.Drawing.Point(316, 101);
            this.btn3D.Name = "btn3D";
            this.btn3D.Size = new System.Drawing.Size(116, 23);
            this.btn3D.TabIndex = 14;
            this.btn3D.Text = "View 3D";
            this.btn3D.UseVisualStyleBackColor = true;
            this.btn3D.Visible = false;
            this.btn3D.Click += new System.EventHandler(this.btn3D_Click);
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 385);
            this.Controls.Add(this.btn3D);
            this.Controls.Add(this.btnCostVSEI);
            this.Controls.Add(this.btnTimeVSEI);
            this.Controls.Add(this.btnTimeVsCost);
            this.Controls.Add(this.lbProjects);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "ResultsForm";
            this.Text = "Results";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbProjects;
        private System.Windows.Forms.Button btnTimeVsCost;
        private System.Windows.Forms.Button btnTimeVSEI;
        private System.Windows.Forms.Button btnCostVSEI;
        private System.Windows.Forms.Button btn3D;
    }
}