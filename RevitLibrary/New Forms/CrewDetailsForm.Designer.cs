namespace RevitLibrary.New_Forms
{
    partial class CrewDetailsForm
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
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHourlyCost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDailyCost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crew Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(117, 10);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(143, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(117, 36);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.Size = new System.Drawing.Size(143, 71);
            this.txtDetails.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Details:";
            // 
            // txtHourlyCost
            // 
            this.txtHourlyCost.Location = new System.Drawing.Point(117, 123);
            this.txtHourlyCost.Name = "txtHourlyCost";
            this.txtHourlyCost.ReadOnly = true;
            this.txtHourlyCost.Size = new System.Drawing.Size(143, 20);
            this.txtHourlyCost.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bare Hourly Cost:";
            // 
            // txtDailyCost
            // 
            this.txtDailyCost.Location = new System.Drawing.Point(117, 149);
            this.txtDailyCost.Name = "txtDailyCost";
            this.txtDailyCost.ReadOnly = true;
            this.txtDailyCost.Size = new System.Drawing.Size(143, 20);
            this.txtDailyCost.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bare Daily Cost:";
            // 
            // CrewDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 182);
            this.Controls.Add(this.txtDailyCost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHourlyCost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "CrewDetailsForm";
            this.Text = "CrewDetailsForm";
            this.Load += new System.EventHandler(this.CrewDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHourlyCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDailyCost;
        private System.Windows.Forms.Label label4;
    }
}