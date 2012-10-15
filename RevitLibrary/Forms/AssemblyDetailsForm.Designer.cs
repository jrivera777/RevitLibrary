namespace RevitLibrary.Forms
{
    partial class AssemblyDetailsForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbMaterials = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpMaterials = new System.Windows.Forms.GroupBox();
            this.lblCO2 = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCO2PerUnit = new System.Windows.Forms.Label();
            this.lblCostPerUnit = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboAlternatives = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblToSwap = new System.Windows.Forms.Label();
            this.btnSaveAssembly = new System.Windows.Forms.Button();
            this.grpMaterials.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assembly Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Materials:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Assembly Code:";
            // 
            // lbMaterials
            // 
            this.lbMaterials.FormattingEnabled = true;
            this.lbMaterials.HorizontalScrollbar = true;
            this.lbMaterials.Location = new System.Drawing.Point(125, 19);
            this.lbMaterials.Name = "lbMaterials";
            this.lbMaterials.Size = new System.Drawing.Size(195, 95);
            this.lbMaterials.TabIndex = 4;
            this.lbMaterials.SelectedIndexChanged += new System.EventHandler(this.lblMaterials_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(125, 17);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(195, 20);
            this.txtName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(125, 51);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(195, 20);
            this.txtCode.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(125, 77);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(195, 50);
            this.txtDescription.TabIndex = 7;
            // 
            // grpMaterials
            // 
            this.grpMaterials.Controls.Add(this.lblCO2);
            this.grpMaterials.Controls.Add(this.lblCost);
            this.grpMaterials.Controls.Add(this.label6);
            this.grpMaterials.Controls.Add(this.label5);
            this.grpMaterials.Controls.Add(this.lbMaterials);
            this.grpMaterials.Controls.Add(this.label2);
            this.grpMaterials.Location = new System.Drawing.Point(11, 275);
            this.grpMaterials.Name = "grpMaterials";
            this.grpMaterials.Size = new System.Drawing.Size(326, 184);
            this.grpMaterials.TabIndex = 8;
            this.grpMaterials.TabStop = false;
            this.grpMaterials.Text = "Material Information";
            // 
            // lblCO2
            // 
            this.lblCO2.AutoSize = true;
            this.lblCO2.Location = new System.Drawing.Point(122, 158);
            this.lblCO2.Name = "lblCO2";
            this.lblCO2.Size = new System.Drawing.Size(0, 13);
            this.lblCO2.TabIndex = 8;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(122, 129);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(0, 13);
            this.lblCost.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "CO2 Emission:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cost:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Cost Per Unit:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "CO2 Per Unit:";
            // 
            // lblCO2PerUnit
            // 
            this.lblCO2PerUnit.AutoSize = true;
            this.lblCO2PerUnit.Location = new System.Drawing.Point(133, 180);
            this.lblCO2PerUnit.Name = "lblCO2PerUnit";
            this.lblCO2PerUnit.Size = new System.Drawing.Size(0, 13);
            this.lblCO2PerUnit.TabIndex = 10;
            // 
            // lblCostPerUnit
            // 
            this.lblCostPerUnit.AutoSize = true;
            this.lblCostPerUnit.Location = new System.Drawing.Point(133, 144);
            this.lblCostPerUnit.Name = "lblCostPerUnit";
            this.lblCostPerUnit.Size = new System.Drawing.Size(0, 13);
            this.lblCostPerUnit.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 490);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Alternative Assemblies:";
            this.label9.Visible = false;
            // 
            // cboAlternatives
            // 
            this.cboAlternatives.FormattingEnabled = true;
            this.cboAlternatives.Location = new System.Drawing.Point(136, 487);
            this.cboAlternatives.Name = "cboAlternatives";
            this.cboAlternatives.Size = new System.Drawing.Size(195, 21);
            this.cboAlternatives.TabIndex = 13;
            this.cboAlternatives.Visible = false;
            this.cboAlternatives.SelectedIndexChanged += new System.EventHandler(this.cboAlternatives_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblCO2PerUnit);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.lblCostPerUnit);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(11, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 204);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Information";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(17, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(113, 13);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "Assembly to Swap:";
            this.lblTitle.Visible = false;
            // 
            // lblToSwap
            // 
            this.lblToSwap.AutoSize = true;
            this.lblToSwap.Location = new System.Drawing.Point(144, 13);
            this.lblToSwap.Name = "lblToSwap";
            this.lblToSwap.Size = new System.Drawing.Size(0, 13);
            this.lblToSwap.TabIndex = 16;
            // 
            // btnSaveAssembly
            // 
            this.btnSaveAssembly.Location = new System.Drawing.Point(82, 522);
            this.btnSaveAssembly.Name = "btnSaveAssembly";
            this.btnSaveAssembly.Size = new System.Drawing.Size(169, 23);
            this.btnSaveAssembly.TabIndex = 11;
            this.btnSaveAssembly.Text = "Save Assembly";
            this.btnSaveAssembly.UseVisualStyleBackColor = true;
            this.btnSaveAssembly.Visible = false;
            this.btnSaveAssembly.Click += new System.EventHandler(this.btnSaveAssembly_Click);
            // 
            // AssemblyDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 557);
            this.Controls.Add(this.lblToSwap);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboAlternatives);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSaveAssembly);
            this.Controls.Add(this.grpMaterials);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AssemblyDetailsForm";
            this.Text = "Assembly Details";
            this.Load += new System.EventHandler(this.AssemblyDetailsForm_Load);
            this.grpMaterials.ResumeLayout(false);
            this.grpMaterials.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbMaterials;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpMaterials;
        private System.Windows.Forms.Label lblCO2;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCO2PerUnit;
        private System.Windows.Forms.Label lblCostPerUnit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboAlternatives;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblToSwap;
        private System.Windows.Forms.Button btnSaveAssembly;
    }
}