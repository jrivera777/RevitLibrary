﻿namespace RevitLibrary.New_Forms
{
    partial class ComponentBuilderForm
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
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSelectedComp = new System.Windows.Forms.TextBox();
            this.lbAssemblies = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompDesc = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFoundInModel = new System.Windows.Forms.ComboBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.grpComponents = new System.Windows.Forms.GroupBox();
            this.btnCombineComp = new System.Windows.Forms.Button();
            this.grpCombined = new System.Windows.Forms.GroupBox();
            this.txtCombinedCategory = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCombinedCompName = new System.Windows.Forms.TextBox();
            this.txtCombinedArea = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCombinedVolume = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkCombineComps = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbComponents = new System.Windows.Forms.ListBox();
            this.btnNSGAII = new System.Windows.Forms.Button();
            this.btnOrderComponents = new System.Windows.Forms.Button();
            this.lbCurrentOptions = new System.Windows.Forms.ListBox();
            this.btnDeleteOption = new System.Windows.Forms.Button();
            this.btnAddOption = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddCrewOption = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lbCrewOptions = new System.Windows.Forms.ListBox();
            this.btnDeleteCrew = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lbCurrentCrew = new System.Windows.Forms.ListBox();
            this.btnCreateNewOption = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblProgress = new System.Windows.Forms.Label();
            this.chkShowIndvComps = new System.Windows.Forms.CheckBox();
            this.grpComponents.SuspendLayout();
            this.grpCombined.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Component Name:";
            // 
            // txtSelectedComp
            // 
            this.txtSelectedComp.Location = new System.Drawing.Point(171, 367);
            this.txtSelectedComp.Name = "txtSelectedComp";
            this.txtSelectedComp.ReadOnly = true;
            this.txtSelectedComp.Size = new System.Drawing.Size(141, 20);
            this.txtSelectedComp.TabIndex = 2;
            // 
            // lbAssemblies
            // 
            this.lbAssemblies.FormattingEnabled = true;
            this.lbAssemblies.Location = new System.Drawing.Point(171, 406);
            this.lbAssemblies.Name = "lbAssemblies";
            this.lbAssemblies.Size = new System.Drawing.Size(141, 121);
            this.lbAssemblies.TabIndex = 3;
            this.lbAssemblies.SelectedIndexChanged += new System.EventHandler(this.lbAssemblies_SelectedIndexChanged);
            this.lbAssemblies.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbAssemblies_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 406);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Available Assembly Options:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Component Name:";
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(512, 35);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(141, 20);
            this.txtCompName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // txtCompDesc
            // 
            this.txtCompDesc.Location = new System.Drawing.Point(512, 61);
            this.txtCompDesc.Name = "txtCompDesc";
            this.txtCompDesc.Size = new System.Drawing.Size(141, 20);
            this.txtCompDesc.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(370, 183);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Component";
            this.toolTip1.SetToolTip(this.btnAdd, "Add a component to the list of available simulated components.");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(370, 212);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete Component";
            this.toolTip1.SetToolTip(this.btnDelete, "Remove a component from the list of simulated components.");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWrite.Location = new System.Drawing.Point(675, 22);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(202, 33);
            this.btnWrite.TabIndex = 6;
            this.btnWrite.Text = "Write Components";
            this.toolTip1.SetToolTip(this.btnWrite, "Write out list of componenets to be simulated to a file.");
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Category:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Component in Model:";
            // 
            // cboFoundInModel
            // 
            this.cboFoundInModel.FormattingEnabled = true;
            this.cboFoundInModel.Location = new System.Drawing.Point(200, 38);
            this.cboFoundInModel.Name = "cboFoundInModel";
            this.cboFoundInModel.Size = new System.Drawing.Size(158, 21);
            this.cboFoundInModel.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cboFoundInModel, "Select an existing component from the BIM model to associate with a new component" +
                    ".");
            this.cboFoundInModel.SelectedIndexChanged += new System.EventHandler(this.cboFoundInModel_SelectedIndexChanged);
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(512, 88);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(141, 20);
            this.txtCategory.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Component Volume:";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(200, 113);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.ReadOnly = true;
            this.txtVolume.Size = new System.Drawing.Size(158, 20);
            this.txtVolume.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Component Area:";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(200, 87);
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(158, 20);
            this.txtArea.TabIndex = 16;
            // 
            // grpComponents
            // 
            this.grpComponents.Controls.Add(this.chkShowIndvComps);
            this.grpComponents.Controls.Add(this.grpCombined);
            this.grpComponents.Controls.Add(this.label3);
            this.grpComponents.Controls.Add(this.txtArea);
            this.grpComponents.Controls.Add(this.lbComponents);
            this.grpComponents.Controls.Add(this.btnNSGAII);
            this.grpComponents.Controls.Add(this.label9);
            this.grpComponents.Controls.Add(this.txtVolume);
            this.grpComponents.Controls.Add(this.btnOrderComponents);
            this.grpComponents.Controls.Add(this.label8);
            this.grpComponents.Controls.Add(this.txtCategory);
            this.grpComponents.Controls.Add(this.cboFoundInModel);
            this.grpComponents.Controls.Add(this.label7);
            this.grpComponents.Controls.Add(this.label4);
            this.grpComponents.Controls.Add(this.btnDelete);
            this.grpComponents.Controls.Add(this.btnAdd);
            this.grpComponents.Controls.Add(this.txtCompDesc);
            this.grpComponents.Controls.Add(this.label2);
            this.grpComponents.Controls.Add(this.txtCompName);
            this.grpComponents.Controls.Add(this.btnWrite);
            this.grpComponents.Controls.Add(this.label1);
            this.grpComponents.Location = new System.Drawing.Point(12, 12);
            this.grpComponents.Name = "grpComponents";
            this.grpComponents.Size = new System.Drawing.Size(883, 342);
            this.grpComponents.TabIndex = 0;
            this.grpComponents.TabStop = false;
            this.grpComponents.Text = "Component Information";
            // 
            // btnCombineComp
            // 
            this.btnCombineComp.Enabled = false;
            this.btnCombineComp.Location = new System.Drawing.Point(189, 137);
            this.btnCombineComp.Name = "btnCombineComp";
            this.btnCombineComp.Size = new System.Drawing.Size(158, 23);
            this.btnCombineComp.TabIndex = 29;
            this.btnCombineComp.Text = "Combine Component";
            this.toolTip1.SetToolTip(this.btnCombineComp, "Combine current component with any \r\npreviously selected components.");
            this.btnCombineComp.UseVisualStyleBackColor = true;
            this.btnCombineComp.Click += new System.EventHandler(this.btnCombineComp_Click);
            // 
            // grpCombined
            // 
            this.grpCombined.Controls.Add(this.btnCombineComp);
            this.grpCombined.Controls.Add(this.txtCombinedCategory);
            this.grpCombined.Controls.Add(this.chkCombineComps);
            this.grpCombined.Controls.Add(this.label16);
            this.grpCombined.Controls.Add(this.txtCombinedCompName);
            this.grpCombined.Controls.Add(this.txtCombinedArea);
            this.grpCombined.Controls.Add(this.label15);
            this.grpCombined.Controls.Add(this.txtCombinedVolume);
            this.grpCombined.Controls.Add(this.label14);
            this.grpCombined.Controls.Add(this.label13);
            this.grpCombined.Enabled = false;
            this.grpCombined.Location = new System.Drawing.Point(11, 158);
            this.grpCombined.Name = "grpCombined";
            this.grpCombined.Size = new System.Drawing.Size(353, 169);
            this.grpCombined.TabIndex = 28;
            this.grpCombined.TabStop = false;
            this.grpCombined.Text = "Combined Component Info";
            // 
            // txtCombinedCategory
            // 
            this.txtCombinedCategory.Location = new System.Drawing.Point(189, 51);
            this.txtCombinedCategory.Name = "txtCombinedCategory";
            this.txtCombinedCategory.Size = new System.Drawing.Size(158, 20);
            this.txtCombinedCategory.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(159, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Combined Component Category:";
            // 
            // txtCombinedCompName
            // 
            this.txtCombinedCompName.Location = new System.Drawing.Point(189, 25);
            this.txtCombinedCompName.Name = "txtCombinedCompName";
            this.txtCombinedCompName.Size = new System.Drawing.Size(158, 20);
            this.txtCombinedCompName.TabIndex = 21;
            // 
            // txtCombinedArea
            // 
            this.txtCombinedArea.Location = new System.Drawing.Point(189, 77);
            this.txtCombinedArea.Name = "txtCombinedArea";
            this.txtCombinedArea.ReadOnly = true;
            this.txtCombinedArea.Size = new System.Drawing.Size(158, 20);
            this.txtCombinedArea.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Combined Volume:";
            // 
            // txtCombinedVolume
            // 
            this.txtCombinedVolume.Location = new System.Drawing.Point(189, 103);
            this.txtCombinedVolume.Name = "txtCombinedVolume";
            this.txtCombinedVolume.ReadOnly = true;
            this.txtCombinedVolume.Size = new System.Drawing.Size(158, 20);
            this.txtCombinedVolume.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Combined Area:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Combined Component Name:";
            // 
            // chkCombineComps
            // 
            this.chkCombineComps.AutoSize = true;
            this.chkCombineComps.Location = new System.Drawing.Point(9, 137);
            this.chkCombineComps.Name = "chkCombineComps";
            this.chkCombineComps.Size = new System.Drawing.Size(129, 17);
            this.chkCombineComps.TabIndex = 27;
            this.chkCombineComps.Text = "Combine Components";
            this.toolTip1.SetToolTip(this.chkCombineComps, "Enable this checkbox to allow the combination of multiple\r\ncomponents from the mo" +
                    "del into a single component\r\nthat can be written to the Component File.");
            this.chkCombineComps.UseVisualStyleBackColor = true;
            this.chkCombineComps.CheckedChanged += new System.EventHandler(this.chkCombineComps_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Components in Simulation:";
            // 
            // lbComponents
            // 
            this.lbComponents.FormattingEnabled = true;
            this.lbComponents.Location = new System.Drawing.Point(509, 178);
            this.lbComponents.Name = "lbComponents";
            this.lbComponents.Size = new System.Drawing.Size(141, 134);
            this.lbComponents.TabIndex = 18;
            this.lbComponents.SelectedIndexChanged += new System.EventHandler(this.lbComponents_SelectedIndexChanged_1);
            // 
            // btnNSGAII
            // 
            this.btnNSGAII.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNSGAII.Location = new System.Drawing.Point(675, 100);
            this.btnNSGAII.Name = "btnNSGAII";
            this.btnNSGAII.Size = new System.Drawing.Size(202, 33);
            this.btnNSGAII.TabIndex = 20;
            this.btnNSGAII.Text = "Run NSGA-II";
            this.toolTip1.SetToolTip(this.btnNSGAII, "Run genetic algorithm simulation. Results can be viewed from the Model Manager Fo" +
                    "rm.");
            this.btnNSGAII.UseVisualStyleBackColor = true;
            this.btnNSGAII.Click += new System.EventHandler(this.btnNSGAII_Click);
            // 
            // btnOrderComponents
            // 
            this.btnOrderComponents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderComponents.Location = new System.Drawing.Point(675, 61);
            this.btnOrderComponents.Name = "btnOrderComponents";
            this.btnOrderComponents.Size = new System.Drawing.Size(202, 33);
            this.btnOrderComponents.TabIndex = 19;
            this.btnOrderComponents.Text = "Write Out Order";
            this.toolTip1.SetToolTip(this.btnOrderComponents, "Create a precedence order file.");
            this.btnOrderComponents.UseVisualStyleBackColor = true;
            this.btnOrderComponents.Click += new System.EventHandler(this.btnOrderComponents_Click);
            // 
            // lbCurrentOptions
            // 
            this.lbCurrentOptions.FormattingEnabled = true;
            this.lbCurrentOptions.Location = new System.Drawing.Point(524, 406);
            this.lbCurrentOptions.Name = "lbCurrentOptions";
            this.lbCurrentOptions.Size = new System.Drawing.Size(141, 121);
            this.lbCurrentOptions.TabIndex = 21;
            this.lbCurrentOptions.SelectedIndexChanged += new System.EventHandler(this.lbCurrentOptions_SelectedIndexChanged);
            this.lbCurrentOptions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCurrentOptions_MouseDoubleClick);
            // 
            // btnDeleteOption
            // 
            this.btnDeleteOption.Location = new System.Drawing.Point(382, 433);
            this.btnDeleteOption.Name = "btnDeleteOption";
            this.btnDeleteOption.Size = new System.Drawing.Size(136, 23);
            this.btnDeleteOption.TabIndex = 20;
            this.btnDeleteOption.Text = "Delete Assembly Option";
            this.toolTip1.SetToolTip(this.btnDeleteOption, "Delete selected option from component.");
            this.btnDeleteOption.UseVisualStyleBackColor = true;
            this.btnDeleteOption.Click += new System.EventHandler(this.btnDeleteOption_Click);
            // 
            // btnAddOption
            // 
            this.btnAddOption.Location = new System.Drawing.Point(20, 433);
            this.btnAddOption.Name = "btnAddOption";
            this.btnAddOption.Size = new System.Drawing.Size(136, 23);
            this.btnAddOption.TabIndex = 19;
            this.btnAddOption.Text = "Add Assembly Option";
            this.toolTip1.SetToolTip(this.btnAddOption, "Add selected option to currently component.");
            this.btnAddOption.UseVisualStyleBackColor = true;
            this.btnAddOption.Click += new System.EventHandler(this.btnAddOption_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(382, 406);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Current Assembly Options:";
            // 
            // btnAddCrewOption
            // 
            this.btnAddCrewOption.Enabled = false;
            this.btnAddCrewOption.Location = new System.Drawing.Point(20, 572);
            this.btnAddCrewOption.Name = "btnAddCrewOption";
            this.btnAddCrewOption.Size = new System.Drawing.Size(136, 23);
            this.btnAddCrewOption.TabIndex = 25;
            this.btnAddCrewOption.Text = "Add Crew Option";
            this.btnAddCrewOption.UseVisualStyleBackColor = true;
            this.btnAddCrewOption.Visible = false;
            this.btnAddCrewOption.Click += new System.EventHandler(this.btnAddCrewOption_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(37, 546);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Available Crew Options:";
            this.label11.Visible = false;
            // 
            // lbCrewOptions
            // 
            this.lbCrewOptions.Enabled = false;
            this.lbCrewOptions.FormattingEnabled = true;
            this.lbCrewOptions.Location = new System.Drawing.Point(171, 546);
            this.lbCrewOptions.Name = "lbCrewOptions";
            this.lbCrewOptions.Size = new System.Drawing.Size(141, 121);
            this.lbCrewOptions.TabIndex = 23;
            this.lbCrewOptions.Visible = false;
            this.lbCrewOptions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCrewOptions_MouseDoubleClick);
            // 
            // btnDeleteCrew
            // 
            this.btnDeleteCrew.Enabled = false;
            this.btnDeleteCrew.Location = new System.Drawing.Point(330, 572);
            this.btnDeleteCrew.Name = "btnDeleteCrew";
            this.btnDeleteCrew.Size = new System.Drawing.Size(136, 23);
            this.btnDeleteCrew.TabIndex = 28;
            this.btnDeleteCrew.Text = "Delete Crew Option";
            this.btnDeleteCrew.UseVisualStyleBackColor = true;
            this.btnDeleteCrew.Visible = false;
            this.btnDeleteCrew.Click += new System.EventHandler(this.btnDeleteCrew_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(330, 546);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Current Crew Options:";
            this.label12.Visible = false;
            // 
            // lbCurrentCrew
            // 
            this.lbCurrentCrew.Enabled = false;
            this.lbCurrentCrew.FormattingEnabled = true;
            this.lbCurrentCrew.Location = new System.Drawing.Point(472, 546);
            this.lbCurrentCrew.Name = "lbCurrentCrew";
            this.lbCurrentCrew.Size = new System.Drawing.Size(141, 121);
            this.lbCurrentCrew.TabIndex = 26;
            this.lbCurrentCrew.Visible = false;
            this.lbCurrentCrew.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCrewOptions_MouseDoubleClick);
            // 
            // btnCreateNewOption
            // 
            this.btnCreateNewOption.Location = new System.Drawing.Point(382, 462);
            this.btnCreateNewOption.Name = "btnCreateNewOption";
            this.btnCreateNewOption.Size = new System.Drawing.Size(136, 23);
            this.btnCreateNewOption.TabIndex = 29;
            this.btnCreateNewOption.Text = "Create New Option";
            this.toolTip1.SetToolTip(this.btnCreateNewOption, "Create new option if desired one is not available.");
            this.btnCreateNewOption.UseVisualStyleBackColor = true;
            this.btnCreateNewOption.Click += new System.EventHandler(this.btnCreateNewOption_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.Red;
            this.lblProgress.Location = new System.Drawing.Point(20, 467);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 20);
            this.lblProgress.TabIndex = 30;
            // 
            // chkShowIndvComps
            // 
            this.chkShowIndvComps.AutoSize = true;
            this.chkShowIndvComps.Location = new System.Drawing.Point(28, 61);
            this.chkShowIndvComps.Name = "chkShowIndvComps";
            this.chkShowIndvComps.Size = new System.Drawing.Size(163, 17);
            this.chkShowIndvComps.TabIndex = 29;
            this.chkShowIndvComps.Text = "Show Individual Components";
            this.chkShowIndvComps.UseVisualStyleBackColor = true;
            this.chkShowIndvComps.CheckedChanged += new System.EventHandler(this.chkShowIndvComps_CheckedChanged);
            // 
            // ComponentBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 539);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnCreateNewOption);
            this.Controls.Add(this.btnDeleteCrew);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbCurrentCrew);
            this.Controls.Add(this.btnAddCrewOption);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbCrewOptions);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbCurrentOptions);
            this.Controls.Add(this.btnDeleteOption);
            this.Controls.Add(this.btnAddOption);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbAssemblies);
            this.Controls.Add(this.txtSelectedComp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpComponents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ComponentBuilderForm";
            this.Text = "SimulEICon - Component Builder";
            this.Load += new System.EventHandler(this.ComponentBuilderForm_Load);
            this.grpComponents.ResumeLayout(false);
            this.grpComponents.PerformLayout();
            this.grpCombined.ResumeLayout(false);
            this.grpCombined.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSelectedComp;
        private System.Windows.Forms.ListBox lbAssemblies;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompDesc;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboFoundInModel;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.GroupBox grpComponents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbComponents;
        private System.Windows.Forms.ListBox lbCurrentOptions;
        private System.Windows.Forms.Button btnDeleteOption;
        private System.Windows.Forms.Button btnAddOption;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddCrewOption;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lbCrewOptions;
        private System.Windows.Forms.Button btnDeleteCrew;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lbCurrentCrew;
        private System.Windows.Forms.Button btnOrderComponents;
        private System.Windows.Forms.Button btnCreateNewOption;
        private System.Windows.Forms.Button btnNSGAII;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCombinedVolume;
        private System.Windows.Forms.TextBox txtCombinedArea;
        private System.Windows.Forms.TextBox txtCombinedCompName;
        private System.Windows.Forms.CheckBox chkCombineComps;
        private System.Windows.Forms.GroupBox grpCombined;
        private System.Windows.Forms.TextBox txtCombinedCategory;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnCombineComp;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.CheckBox chkShowIndvComps;
    }
}