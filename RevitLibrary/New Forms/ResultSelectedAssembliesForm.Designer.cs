namespace RevitLibrary.New_Forms
{
    partial class ResultSelectedAssembliesForm
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
            this.txtAssemblies = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAssemblies
            // 
            this.txtAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAssemblies.Location = new System.Drawing.Point(13, 80);
            this.txtAssemblies.Multiline = true;
            this.txtAssemblies.Name = "txtAssemblies";
            this.txtAssemblies.ReadOnly = true;
            this.txtAssemblies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAssemblies.Size = new System.Drawing.Size(406, 242);
            this.txtAssemblies.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selected Components:";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(12, 9);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(35, 13);
            this.lblProject.TabIndex = 2;
            this.lblProject.Text = "label2";
            // 
            // ResultSelectedAssembliesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 336);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAssemblies);
            this.Name = "ResultSelectedAssembliesForm";
            this.Text = "Selected Components";
            this.Load += new System.EventHandler(this.ResultSelectedAssembliesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAssemblies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProject;
    }
}