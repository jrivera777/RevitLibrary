namespace RevitLibrary.New_Forms
{
    partial class MaterialForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCO2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.txtRValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreateMaterial = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDailyOutput = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtlaborHours = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCrewType = new System.Windows.Forms.TextBox();
            this.txtLaborCost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chklbSummaryDetails = new System.Windows.Forms.CheckedListBox();
            this.grdVwMatSum = new System.Windows.Forms.DataGridView();
            this.phaseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwMatSum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(124, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(171, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtCO2
            // 
            this.txtCO2.Location = new System.Drawing.Point(124, 105);
            this.txtCO2.Name = "txtCO2";
            this.txtCO2.Size = new System.Drawing.Size(171, 20);
            this.txtCO2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CO2 Per Unit";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(124, 53);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(171, 20);
            this.txtDesc.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description:";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(124, 79);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(171, 20);
            this.txtCost.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cost Per Unit:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(124, 131);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(171, 20);
            this.txtCode.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Material Code:";
            // 
            // cboUnit
            // 
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Items.AddRange(new object[] {
            "S.F.",
            "C.F.",
            "C.Y.",
            "sq."});
            this.cboUnit.Location = new System.Drawing.Point(302, 77);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(52, 21);
            this.cboUnit.TabIndex = 3;
            // 
            // txtRValue
            // 
            this.txtRValue.Location = new System.Drawing.Point(124, 157);
            this.txtRValue.Name = "txtRValue";
            this.txtRValue.Size = new System.Drawing.Size(171, 20);
            this.txtRValue.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "R-Value:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.txtRValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.cboUnit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.txtCO2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 197);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Primary Material Information";
            // 
            // btnCreateMaterial
            // 
            this.btnCreateMaterial.Location = new System.Drawing.Point(402, 361);
            this.btnCreateMaterial.Name = "btnCreateMaterial";
            this.btnCreateMaterial.Size = new System.Drawing.Size(118, 23);
            this.btnCreateMaterial.TabIndex = 14;
            this.btnCreateMaterial.Text = "Create New Material";
            this.btnCreateMaterial.UseVisualStyleBackColor = true;
            this.btnCreateMaterial.Click += new System.EventHandler(this.btnCreateMaterial_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDailyOutput);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtlaborHours);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCrewType);
            this.groupBox2.Controls.Add(this.txtLaborCost);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 158);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Labor information";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Daily Output:";
            // 
            // txtDailyOutput
            // 
            this.txtDailyOutput.Location = new System.Drawing.Point(124, 103);
            this.txtDailyOutput.Name = "txtDailyOutput";
            this.txtDailyOutput.Size = new System.Drawing.Size(171, 20);
            this.txtDailyOutput.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Labor Hours:";
            // 
            // txtlaborHours
            // 
            this.txtlaborHours.Location = new System.Drawing.Point(124, 77);
            this.txtlaborHours.Name = "txtlaborHours";
            this.txtlaborHours.Size = new System.Drawing.Size(171, 20);
            this.txtlaborHours.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Labor Cost:";
            // 
            // txtCrewType
            // 
            this.txtCrewType.Location = new System.Drawing.Point(124, 51);
            this.txtCrewType.Name = "txtCrewType";
            this.txtCrewType.Size = new System.Drawing.Size(171, 20);
            this.txtCrewType.TabIndex = 8;
            // 
            // txtLaborCost
            // 
            this.txtLaborCost.Location = new System.Drawing.Point(124, 25);
            this.txtLaborCost.Name = "txtLaborCost";
            this.txtLaborCost.Size = new System.Drawing.Size(171, 20);
            this.txtLaborCost.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Crew Type:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chklbSummaryDetails);
            this.groupBox3.Controls.Add(this.grdVwMatSum);
            this.groupBox3.Location = new System.Drawing.Point(396, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 338);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Material Summary";
            // 
            // chklbSummaryDetails
            // 
            this.chklbSummaryDetails.FormattingEnabled = true;
            this.chklbSummaryDetails.Items.AddRange(new object[] {
            "Fossil Fuel Consumption",
            "Weighted Resource Use",
            "Global Warming Potential",
            "Acidification Potential",
            "HH Respiratory Effects Potential",
            "Eutrophication Potential",
            "Ozone Depletion Potential",
            "Smog Potential"});
            this.chklbSummaryDetails.Location = new System.Drawing.Point(6, 46);
            this.chklbSummaryDetails.Name = "chklbSummaryDetails";
            this.chklbSummaryDetails.Size = new System.Drawing.Size(181, 124);
            this.chklbSummaryDetails.TabIndex = 1;
            this.chklbSummaryDetails.SelectedIndexChanged += new System.EventHandler(this.chklbphaseDetails_SelectedIndexChanged);
            // 
            // grdVwMatSum
            // 
            this.grdVwMatSum.AllowUserToAddRows = false;
            this.grdVwMatSum.AllowUserToDeleteRows = false;
            this.grdVwMatSum.AllowUserToResizeColumns = false;
            this.grdVwMatSum.AllowUserToResizeRows = false;
            this.grdVwMatSum.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdVwMatSum.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdVwMatSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwMatSum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phaseColumn,
            this.valueColumn});
            this.grdVwMatSum.Location = new System.Drawing.Point(6, 189);
            this.grdVwMatSum.Name = "grdVwMatSum";
            this.grdVwMatSum.Size = new System.Drawing.Size(257, 143);
            this.grdVwMatSum.TabIndex = 0;
            // 
            // phaseColumn
            // 
            this.phaseColumn.HeaderText = "Phase";
            this.phaseColumn.Name = "phaseColumn";
            this.phaseColumn.Width = 62;
            // 
            // valueColumn
            // 
            this.valueColumn.HeaderText = "Value";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.Width = 59;
            // 
            // MaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 396);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCreateMaterial);
            this.Controls.Add(this.groupBox1);
            this.Name = "MaterialForm";
            this.Text = "Material Form";
            this.Load += new System.EventHandler(this.MaterialForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVwMatSum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCO2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.TextBox txtRValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreateMaterial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCrewType;
        private System.Windows.Forms.TextBox txtLaborCost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtlaborHours;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDailyOutput;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.CheckedListBox chklbSummaryDetails;
        private System.Windows.Forms.DataGridView grdVwMatSum;
    }
}