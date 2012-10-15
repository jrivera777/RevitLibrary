namespace RevitLibrary
{
    partial class AssemblyManagerForm
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
            this.lbAssemblies = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMaterials = new System.Windows.Forms.ListBox();
            this.lbAssemOptions = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalArea = new System.Windows.Forms.TextBox();
            this.txtTotalVolume = new System.Windows.Forms.TextBox();
            this.grpAssemblies = new System.Windows.Forms.GroupBox();
            this.txtAssemblyCO2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAssemblyCost = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCO2 = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.btnWriteOut = new System.Windows.Forms.Button();
            this.btnSaveOptions = new System.Windows.Forms.Button();
            this.lbSelectedOptions = new System.Windows.Forms.ListBox();
            this.grpSelectedOptions = new System.Windows.Forms.GroupBox();
            this.btnRemoveOption = new System.Windows.Forms.Button();
            this.btnCompOrder = new System.Windows.Forms.Button();
            this.grpAssemblies.SuspendLayout();
            this.grpMaterial.SuspendLayout();
            this.grpSelectedOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assemblies Found In Model:";
            // 
            // lbAssemblies
            // 
            this.lbAssemblies.FormattingEnabled = true;
            this.lbAssemblies.Location = new System.Drawing.Point(166, 19);
            this.lbAssemblies.Name = "lbAssemblies";
            this.lbAssemblies.Size = new System.Drawing.Size(187, 82);
            this.lbAssemblies.TabIndex = 1;
            this.lbAssemblies.SelectedIndexChanged += new System.EventHandler(this.lbAssemblies_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Assembly Materials Found:";
            // 
            // lbMaterials
            // 
            this.lbMaterials.FormattingEnabled = true;
            this.lbMaterials.HorizontalScrollbar = true;
            this.lbMaterials.Location = new System.Drawing.Point(163, 19);
            this.lbMaterials.Name = "lbMaterials";
            this.lbMaterials.Size = new System.Drawing.Size(187, 82);
            this.lbMaterials.TabIndex = 3;
            this.lbMaterials.SelectedIndexChanged += new System.EventHandler(this.lbMaterials_SelectedIndexChanged);
            // 
            // lbAssemOptions
            // 
            this.lbAssemOptions.FormattingEnabled = true;
            this.lbAssemOptions.Location = new System.Drawing.Point(166, 238);
            this.lbAssemOptions.Name = "lbAssemOptions";
            this.lbAssemOptions.Size = new System.Drawing.Size(187, 82);
            this.lbAssemOptions.TabIndex = 5;
            this.lbAssemOptions.SelectedIndexChanged += new System.EventHandler(this.lbAssemOptions_SelectedIndexChanged);
            this.lbAssemOptions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbAssemOptions_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Available Assembly Options:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Assembly Category:";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(166, 107);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(187, 20);
            this.txtCategory.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total Volume:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Total Area:";
            // 
            // txtTotalArea
            // 
            this.txtTotalArea.Location = new System.Drawing.Point(166, 186);
            this.txtTotalArea.Name = "txtTotalArea";
            this.txtTotalArea.ReadOnly = true;
            this.txtTotalArea.Size = new System.Drawing.Size(187, 20);
            this.txtTotalArea.TabIndex = 10;
            // 
            // txtTotalVolume
            // 
            this.txtTotalVolume.Location = new System.Drawing.Point(166, 212);
            this.txtTotalVolume.Name = "txtTotalVolume";
            this.txtTotalVolume.ReadOnly = true;
            this.txtTotalVolume.Size = new System.Drawing.Size(187, 20);
            this.txtTotalVolume.TabIndex = 11;
            // 
            // grpAssemblies
            // 
            this.grpAssemblies.Controls.Add(this.txtAssemblyCO2);
            this.grpAssemblies.Controls.Add(this.label10);
            this.grpAssemblies.Controls.Add(this.txtAssemblyCost);
            this.grpAssemblies.Controls.Add(this.label9);
            this.grpAssemblies.Controls.Add(this.lbAssemblies);
            this.grpAssemblies.Controls.Add(this.txtTotalVolume);
            this.grpAssemblies.Controls.Add(this.label1);
            this.grpAssemblies.Controls.Add(this.lbAssemOptions);
            this.grpAssemblies.Controls.Add(this.txtTotalArea);
            this.grpAssemblies.Controls.Add(this.label3);
            this.grpAssemblies.Controls.Add(this.txtCategory);
            this.grpAssemblies.Controls.Add(this.label6);
            this.grpAssemblies.Controls.Add(this.label4);
            this.grpAssemblies.Controls.Add(this.label5);
            this.grpAssemblies.Location = new System.Drawing.Point(12, 12);
            this.grpAssemblies.Name = "grpAssemblies";
            this.grpAssemblies.Size = new System.Drawing.Size(363, 335);
            this.grpAssemblies.TabIndex = 12;
            this.grpAssemblies.TabStop = false;
            this.grpAssemblies.Text = "Assembly Information";
            // 
            // txtAssemblyCO2
            // 
            this.txtAssemblyCO2.Location = new System.Drawing.Point(166, 159);
            this.txtAssemblyCO2.Name = "txtAssemblyCO2";
            this.txtAssemblyCO2.ReadOnly = true;
            this.txtAssemblyCO2.Size = new System.Drawing.Size(187, 20);
            this.txtAssemblyCO2.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Assembly CO2:";
            // 
            // txtAssemblyCost
            // 
            this.txtAssemblyCost.Location = new System.Drawing.Point(166, 133);
            this.txtAssemblyCost.Name = "txtAssemblyCost";
            this.txtAssemblyCost.ReadOnly = true;
            this.txtAssemblyCost.Size = new System.Drawing.Size(187, 20);
            this.txtAssemblyCost.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Assembly Cost:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "CO2 Emission:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Cost:";
            // 
            // txtCO2
            // 
            this.txtCO2.Location = new System.Drawing.Point(163, 139);
            this.txtCO2.Name = "txtCO2";
            this.txtCO2.ReadOnly = true;
            this.txtCO2.Size = new System.Drawing.Size(187, 20);
            this.txtCO2.TabIndex = 14;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(163, 110);
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(187, 20);
            this.txtCost.TabIndex = 15;
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.lbMaterials);
            this.grpMaterial.Controls.Add(this.txtCost);
            this.grpMaterial.Controls.Add(this.label2);
            this.grpMaterial.Controls.Add(this.label8);
            this.grpMaterial.Controls.Add(this.txtCO2);
            this.grpMaterial.Controls.Add(this.label7);
            this.grpMaterial.Location = new System.Drawing.Point(399, 12);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Size = new System.Drawing.Size(359, 177);
            this.grpMaterial.TabIndex = 16;
            this.grpMaterial.TabStop = false;
            this.grpMaterial.Text = "Material Information";
            // 
            // btnWriteOut
            // 
            this.btnWriteOut.Location = new System.Drawing.Point(614, 405);
            this.btnWriteOut.Name = "btnWriteOut";
            this.btnWriteOut.Size = new System.Drawing.Size(135, 23);
            this.btnWriteOut.TabIndex = 17;
            this.btnWriteOut.Text = "Write Out Options";
            this.btnWriteOut.UseVisualStyleBackColor = true;
            this.btnWriteOut.Click += new System.EventHandler(this.btnWriteOut_Click);
            // 
            // btnSaveOptions
            // 
            this.btnSaveOptions.Location = new System.Drawing.Point(614, 376);
            this.btnSaveOptions.Name = "btnSaveOptions";
            this.btnSaveOptions.Size = new System.Drawing.Size(135, 23);
            this.btnSaveOptions.TabIndex = 18;
            this.btnSaveOptions.Text = "Save Options";
            this.btnSaveOptions.UseVisualStyleBackColor = true;
            this.btnSaveOptions.Click += new System.EventHandler(this.btnSaveOptions_Click);
            // 
            // lbSelectedOptions
            // 
            this.lbSelectedOptions.FormattingEnabled = true;
            this.lbSelectedOptions.Location = new System.Drawing.Point(6, 26);
            this.lbSelectedOptions.Name = "lbSelectedOptions";
            this.lbSelectedOptions.Size = new System.Drawing.Size(187, 82);
            this.lbSelectedOptions.TabIndex = 19;
            // 
            // grpSelectedOptions
            // 
            this.grpSelectedOptions.Controls.Add(this.btnRemoveOption);
            this.grpSelectedOptions.Controls.Add(this.lbSelectedOptions);
            this.grpSelectedOptions.Location = new System.Drawing.Point(399, 224);
            this.grpSelectedOptions.Name = "grpSelectedOptions";
            this.grpSelectedOptions.Size = new System.Drawing.Size(359, 123);
            this.grpSelectedOptions.TabIndex = 20;
            this.grpSelectedOptions.TabStop = false;
            this.grpSelectedOptions.Text = "Selected Options";
            // 
            // btnRemoveOption
            // 
            this.btnRemoveOption.Location = new System.Drawing.Point(215, 26);
            this.btnRemoveOption.Name = "btnRemoveOption";
            this.btnRemoveOption.Size = new System.Drawing.Size(135, 23);
            this.btnRemoveOption.TabIndex = 20;
            this.btnRemoveOption.Text = "Remove Option";
            this.btnRemoveOption.UseVisualStyleBackColor = true;
            this.btnRemoveOption.Click += new System.EventHandler(this.btnRemoveOption_Click);
            // 
            // btnCompOrder
            // 
            this.btnCompOrder.Location = new System.Drawing.Point(473, 376);
            this.btnCompOrder.Name = "btnCompOrder";
            this.btnCompOrder.Size = new System.Drawing.Size(135, 23);
            this.btnCompOrder.TabIndex = 21;
            this.btnCompOrder.Text = "Save Component Order";
            this.btnCompOrder.UseVisualStyleBackColor = true;
            this.btnCompOrder.Click += new System.EventHandler(this.btnCompOrder_Click);
            // 
            // AssemblyManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 439);
            this.Controls.Add(this.btnCompOrder);
            this.Controls.Add(this.grpSelectedOptions);
            this.Controls.Add(this.btnSaveOptions);
            this.Controls.Add(this.btnWriteOut);
            this.Controls.Add(this.grpMaterial);
            this.Controls.Add(this.grpAssemblies);
            this.Name = "AssemblyManagerForm";
            this.Text = "Assembly Manager";
            this.Load += new System.EventHandler(this.AssemblyManagerForm_Load);
            this.grpAssemblies.ResumeLayout(false);
            this.grpAssemblies.PerformLayout();
            this.grpMaterial.ResumeLayout(false);
            this.grpMaterial.PerformLayout();
            this.grpSelectedOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbAssemblies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbMaterials;
        private System.Windows.Forms.ListBox lbAssemOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalArea;
        private System.Windows.Forms.TextBox txtTotalVolume;
        private System.Windows.Forms.GroupBox grpAssemblies;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtCO2;
        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.Button btnWriteOut;
        private System.Windows.Forms.TextBox txtAssemblyCost;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAssemblyCO2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSaveOptions;
        private System.Windows.Forms.ListBox lbSelectedOptions;
        private System.Windows.Forms.GroupBox grpSelectedOptions;
        private System.Windows.Forms.Button btnRemoveOption;
        private System.Windows.Forms.Button btnCompOrder;
    }
}