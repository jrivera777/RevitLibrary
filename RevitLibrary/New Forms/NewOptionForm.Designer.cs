namespace RevitLibrary.New_Forms
{
    partial class NewOptionForm
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
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtEI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbMaterials = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnaddMaterial = new System.Windows.Forms.Button();
            this.btnDeleteMaterial = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveOption = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Information for new Option:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cost Per Unit:";
            // 
            // txtCost
            // 
            this.txtCost.Enabled = false;
            this.txtCost.Location = new System.Drawing.Point(130, 228);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(144, 20);
            this.txtCost.TabIndex = 1;
            // 
            // txtEI
            // 
            this.txtEI.Enabled = false;
            this.txtEI.Location = new System.Drawing.Point(130, 254);
            this.txtEI.Name = "txtEI";
            this.txtEI.Size = new System.Drawing.Size(144, 20);
            this.txtEI.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "EI Per Unit:";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(130, 280);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(144, 20);
            this.txtDuration.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Duration For Project:";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(85, 344);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(144, 23);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create New Option";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(144, 20);
            this.txtName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Name:";
            // 
            // lbMaterials
            // 
            this.lbMaterials.FormattingEnabled = true;
            this.lbMaterials.Location = new System.Drawing.Point(130, 127);
            this.lbMaterials.Name = "lbMaterials";
            this.lbMaterials.Size = new System.Drawing.Size(144, 95);
            this.lbMaterials.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Materials:";
            // 
            // btnaddMaterial
            // 
            this.btnaddMaterial.Location = new System.Drawing.Point(12, 160);
            this.btnaddMaterial.Name = "btnaddMaterial";
            this.btnaddMaterial.Size = new System.Drawing.Size(103, 23);
            this.btnaddMaterial.TabIndex = 11;
            this.btnaddMaterial.Text = "Add Material";
            this.btnaddMaterial.UseVisualStyleBackColor = true;
            this.btnaddMaterial.Click += new System.EventHandler(this.btnaddMaterial_Click);
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.Location = new System.Drawing.Point(12, 189);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(103, 23);
            this.btnDeleteMaterial.TabIndex = 12;
            this.btnDeleteMaterial.Text = "Delete Material";
            this.btnDeleteMaterial.UseVisualStyleBackColor = true;
            this.btnDeleteMaterial.Click += new System.EventHandler(this.btnDeleteMaterial_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(130, 58);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(144, 20);
            this.txtDesc.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Description:";
            // 
            // btnSaveOption
            // 
            this.btnSaveOption.Location = new System.Drawing.Point(85, 315);
            this.btnSaveOption.Name = "btnSaveOption";
            this.btnSaveOption.Size = new System.Drawing.Size(144, 23);
            this.btnSaveOption.TabIndex = 15;
            this.btnSaveOption.Text = "Save Option";
            this.btnSaveOption.UseVisualStyleBackColor = true;
            this.btnSaveOption.Click += new System.EventHandler(this.btnSaveOption_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(130, 84);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(144, 20);
            this.txtCode.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Assembly Code:";
            // 
            // NewOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 388);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSaveOption);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDeleteMaterial);
            this.Controls.Add(this.btnaddMaterial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbMaterials);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewOptionForm";
            this.Text = "Create new Option";
            this.Load += new System.EventHandler(this.NewOptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtEI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbMaterials;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnaddMaterial;
        private System.Windows.Forms.Button btnDeleteMaterial;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSaveOption;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label8;
    }
}