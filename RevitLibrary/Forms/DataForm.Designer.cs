namespace RevitLibrary
{
    partial class Data
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
            this.cboElementType = new System.Windows.Forms.ComboBox();
            this.btnFindElements = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblDone = new System.Windows.Forms.Label();
            this.cboAssemblies = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.cboOptions = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Element Type:";
            // 
            // cboElementType
            // 
            this.cboElementType.FormattingEnabled = true;
            this.cboElementType.Location = new System.Drawing.Point(137, 20);
            this.cboElementType.Name = "cboElementType";
            this.cboElementType.Size = new System.Drawing.Size(183, 21);
            this.cboElementType.TabIndex = 1;
            this.cboElementType.SelectedIndexChanged += new System.EventHandler(this.cboElementType_SelectedIndexChanged);
            // 
            // btnFindElements
            // 
            this.btnFindElements.Location = new System.Drawing.Point(138, 253);
            this.btnFindElements.Name = "btnFindElements";
            this.btnFindElements.Size = new System.Drawing.Size(183, 23);
            this.btnFindElements.TabIndex = 2;
            this.btnFindElements.Text = "Write Selected Elements";
            this.btnFindElements.UseVisualStyleBackColor = true;
            this.btnFindElements.Click += new System.EventHandler(this.btnFindElements_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(14, 220);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(51, 13);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.Text = "Progress:";
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(138, 220);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(183, 19);
            this.pgbProgress.TabIndex = 4;
            // 
            // lblDone
            // 
            this.lblDone.AutoSize = true;
            this.lblDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDone.Location = new System.Drawing.Point(14, 253);
            this.lblDone.Name = "lblDone";
            this.lblDone.Size = new System.Drawing.Size(57, 20);
            this.lblDone.TabIndex = 5;
            this.lblDone.Text = "Done!";
            this.lblDone.Visible = false;
            // 
            // cboAssemblies
            // 
            this.cboAssemblies.FormattingEnabled = true;
            this.cboAssemblies.Location = new System.Drawing.Point(138, 47);
            this.cboAssemblies.Name = "cboAssemblies";
            this.cboAssemblies.Size = new System.Drawing.Size(183, 21);
            this.cboAssemblies.TabIndex = 8;
            this.cboAssemblies.SelectedIndexChanged += new System.EventHandler(this.cboAssemblies_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select Assembly:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Area:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Volume:";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(105, 79);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(0, 13);
            this.lblArea.TabIndex = 11;
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(104, 105);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(0, 13);
            this.lblVolume.TabIndex = 12;
            // 
            // cboOptions
            // 
            this.cboOptions.FormattingEnabled = true;
            this.cboOptions.Location = new System.Drawing.Point(138, 132);
            this.cboOptions.Name = "cboOptions";
            this.cboOptions.Size = new System.Drawing.Size(183, 21);
            this.cboOptions.TabIndex = 14;
            this.cboOptions.SelectedIndexChanged += new System.EventHandler(this.cboOptions_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Assembly Option:";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(135, 180);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(0, 13);
            this.lblTotalCost.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Total Cost for Assembly:";
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 387);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboOptions);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboAssemblies);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDone);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnFindElements);
            this.Controls.Add(this.cboElementType);
            this.Controls.Add(this.label1);
            this.Name = "Data";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboElementType;
        private System.Windows.Forms.Button btnFindElements;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Label lblDone;
        private System.Windows.Forms.ComboBox cboAssemblies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.ComboBox cboOptions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label label7;
    }
}