namespace RevitLibrary.Forms
{
    partial class BuildingComponentForm
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
            this.lblDO = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDODescription = new System.Windows.Forms.TextBox();
            this.grpComponents = new System.Windows.Forms.GroupBox();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.grpMaterials = new System.Windows.Forms.GroupBox();
            this.btnRemoveAssembly = new System.Windows.Forms.Button();
            this.btnAddAssembly = new System.Windows.Forms.Button();
            this.btnAssemblyDetails = new System.Windows.Forms.Button();
            this.lbCompAssemblies = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbExistingComps = new System.Windows.Forms.ListBox();
            this.btnSaveDO = new System.Windows.Forms.Button();
            this.grpComponents.SuspendLayout();
            this.grpMaterials.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Design Option:";
            // 
            // lblDO
            // 
            this.lblDO.AutoSize = true;
            this.lblDO.Location = new System.Drawing.Point(155, 13);
            this.lblDO.Name = "lblDO";
            this.lblDO.Size = new System.Drawing.Size(0, 13);
            this.lblDO.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // txtDODescription
            // 
            this.txtDODescription.Location = new System.Drawing.Point(158, 43);
            this.txtDODescription.Multiline = true;
            this.txtDODescription.Name = "txtDODescription";
            this.txtDODescription.Size = new System.Drawing.Size(233, 57);
            this.txtDODescription.TabIndex = 3;
            // 
            // grpComponents
            // 
            this.grpComponents.Controls.Add(this.txtCompName);
            this.grpComponents.Controls.Add(this.btnAddComponent);
            this.grpComponents.Controls.Add(this.grpMaterials);
            this.grpComponents.Controls.Add(this.label3);
            this.grpComponents.Controls.Add(this.lbExistingComps);
            this.grpComponents.Location = new System.Drawing.Point(12, 106);
            this.grpComponents.Name = "grpComponents";
            this.grpComponents.Size = new System.Drawing.Size(701, 227);
            this.grpComponents.TabIndex = 4;
            this.grpComponents.TabStop = false;
            this.grpComponents.Text = "Components";
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(6, 163);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(211, 20);
            this.txtCompName.TabIndex = 4;
            // 
            // btnAddComponent
            // 
            this.btnAddComponent.Location = new System.Drawing.Point(6, 189);
            this.btnAddComponent.Name = "btnAddComponent";
            this.btnAddComponent.Size = new System.Drawing.Size(105, 23);
            this.btnAddComponent.TabIndex = 3;
            this.btnAddComponent.Text = "Add Component";
            this.btnAddComponent.UseVisualStyleBackColor = true;
            this.btnAddComponent.Click += new System.EventHandler(this.btnAddComponent_Click);
            // 
            // grpMaterials
            // 
            this.grpMaterials.Controls.Add(this.btnRemoveAssembly);
            this.grpMaterials.Controls.Add(this.btnAddAssembly);
            this.grpMaterials.Controls.Add(this.btnAssemblyDetails);
            this.grpMaterials.Controls.Add(this.lbCompAssemblies);
            this.grpMaterials.Location = new System.Drawing.Point(369, 19);
            this.grpMaterials.Name = "grpMaterials";
            this.grpMaterials.Size = new System.Drawing.Size(326, 143);
            this.grpMaterials.TabIndex = 2;
            this.grpMaterials.TabStop = false;
            this.grpMaterials.Text = "Assemblies";
            // 
            // btnRemoveAssembly
            // 
            this.btnRemoveAssembly.Location = new System.Drawing.Point(207, 48);
            this.btnRemoveAssembly.Name = "btnRemoveAssembly";
            this.btnRemoveAssembly.Size = new System.Drawing.Size(113, 23);
            this.btnRemoveAssembly.TabIndex = 3;
            this.btnRemoveAssembly.Text = "Remove Assembly";
            this.btnRemoveAssembly.UseVisualStyleBackColor = true;
            this.btnRemoveAssembly.Click += new System.EventHandler(this.btnRemoveAssembly_Click);
            // 
            // btnAddAssembly
            // 
            this.btnAddAssembly.Location = new System.Drawing.Point(207, 19);
            this.btnAddAssembly.Name = "btnAddAssembly";
            this.btnAddAssembly.Size = new System.Drawing.Size(113, 23);
            this.btnAddAssembly.TabIndex = 2;
            this.btnAddAssembly.Text = "Add Assembly";
            this.btnAddAssembly.UseVisualStyleBackColor = true;
            this.btnAddAssembly.Click += new System.EventHandler(this.btnAddAssembly_Click);
            // 
            // btnAssemblyDetails
            // 
            this.btnAssemblyDetails.Location = new System.Drawing.Point(207, 77);
            this.btnAssemblyDetails.Name = "btnAssemblyDetails";
            this.btnAssemblyDetails.Size = new System.Drawing.Size(113, 23);
            this.btnAssemblyDetails.TabIndex = 1;
            this.btnAssemblyDetails.Text = "Swap Assembly";
            this.btnAssemblyDetails.UseVisualStyleBackColor = true;
            this.btnAssemblyDetails.Click += new System.EventHandler(this.btnAssemblyDetails_Click);
            // 
            // lbCompAssemblies
            // 
            this.lbCompAssemblies.FormattingEnabled = true;
            this.lbCompAssemblies.HorizontalScrollbar = true;
            this.lbCompAssemblies.Location = new System.Drawing.Point(6, 19);
            this.lbCompAssemblies.Name = "lbCompAssemblies";
            this.lbCompAssemblies.Size = new System.Drawing.Size(195, 108);
            this.lbCompAssemblies.TabIndex = 0;
            this.lbCompAssemblies.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCompAssemblies_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Existing Components:";
            // 
            // lbExistingComps
            // 
            this.lbExistingComps.FormattingEnabled = true;
            this.lbExistingComps.HorizontalScrollbar = true;
            this.lbExistingComps.Location = new System.Drawing.Point(6, 38);
            this.lbExistingComps.Name = "lbExistingComps";
            this.lbExistingComps.Size = new System.Drawing.Size(211, 108);
            this.lbExistingComps.TabIndex = 0;
            this.lbExistingComps.SelectedIndexChanged += new System.EventHandler(this.lblExistingComps_SelectedIndexChanged);
            // 
            // btnSaveDO
            // 
            this.btnSaveDO.Location = new System.Drawing.Point(588, 77);
            this.btnSaveDO.Name = "btnSaveDO";
            this.btnSaveDO.Size = new System.Drawing.Size(113, 23);
            this.btnSaveDO.TabIndex = 5;
            this.btnSaveDO.Text = "Save Design Option";
            this.btnSaveDO.UseVisualStyleBackColor = true;
            this.btnSaveDO.Click += new System.EventHandler(this.btnSaveDO_Click);
            // 
            // BuildingComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 346);
            this.Controls.Add(this.btnSaveDO);
            this.Controls.Add(this.grpComponents);
            this.Controls.Add(this.txtDODescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDO);
            this.Controls.Add(this.label1);
            this.Name = "BuildingComponentForm";
            this.Text = "Building Components";
            this.Load += new System.EventHandler(this.BuildingComponentForm_Load);
            this.grpComponents.ResumeLayout(false);
            this.grpComponents.PerformLayout();
            this.grpMaterials.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDODescription;
        private System.Windows.Forms.GroupBox grpComponents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbExistingComps;
        private System.Windows.Forms.GroupBox grpMaterials;
        private System.Windows.Forms.ListBox lbCompAssemblies;
        private System.Windows.Forms.Button btnAssemblyDetails;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.Button btnAddComponent;
        private System.Windows.Forms.Button btnAddAssembly;
        private System.Windows.Forms.Button btnSaveDO;
        private System.Windows.Forms.Button btnRemoveAssembly;
    }
}