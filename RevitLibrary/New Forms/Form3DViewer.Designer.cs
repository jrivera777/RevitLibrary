namespace RevitLibrary.New_Forms
{
    partial class Form3DViewer
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
            this.Panel3D = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Panel3D
            // 
            this.Panel3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3D.Location = new System.Drawing.Point(0, 0);
            this.Panel3D.Name = "Panel3D";
            this.Panel3D.Size = new System.Drawing.Size(292, 266);
            this.Panel3D.TabIndex = 0;
            this.Panel3D.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3D_Paint);
            // 
            // Form3DViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.Panel3D);
            this.Name = "Form3DViewer";
            this.Text = "Form3DViewer";
            this.Load += new System.EventHandler(this.Form3DViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel3D;
    }
}