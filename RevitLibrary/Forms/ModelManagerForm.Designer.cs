﻿namespace RevitLibrary
{
    partial class ModelManagerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnWalls = new System.Windows.Forms.Button();
            this.btnComponentBuilder = new System.Windows.Forms.Button();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFamily = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Name:";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(98, 79);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 13);
            this.lblFileName.TabIndex = 1;
            // 
            // btnWalls
            // 
            this.btnWalls.Enabled = false;
            this.btnWalls.Location = new System.Drawing.Point(253, 129);
            this.btnWalls.Name = "btnWalls";
            this.btnWalls.Size = new System.Drawing.Size(159, 23);
            this.btnWalls.TabIndex = 2;
            this.btnWalls.Text = "Select Walls";
            this.toolTip1.SetToolTip(this.btnWalls, "For Testing Purposes.");
            this.btnWalls.UseVisualStyleBackColor = true;
            this.btnWalls.Visible = false;
            this.btnWalls.Click += new System.EventHandler(this.btnWalls_Click);
            // 
            // btnComponentBuilder
            // 
            this.btnComponentBuilder.Location = new System.Drawing.Point(12, 129);
            this.btnComponentBuilder.Name = "btnComponentBuilder";
            this.btnComponentBuilder.Size = new System.Drawing.Size(116, 23);
            this.btnComponentBuilder.TabIndex = 6;
            this.btnComponentBuilder.Text = "Component Builder";
            this.toolTip1.SetToolTip(this.btnComponentBuilder, "Starts new Simulation.");
            this.btnComponentBuilder.UseVisualStyleBackColor = true;
            this.btnComponentBuilder.Click += new System.EventHandler(this.btnComponentBuilder_Click);
            // 
            // btnViewResults
            // 
            this.btnViewResults.Location = new System.Drawing.Point(131, 129);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(116, 23);
            this.btnViewResults.TabIndex = 7;
            this.btnViewResults.Text = "View Results";
            this.toolTip1.SetToolTip(this.btnViewResults, "View results of previous simulation runs.");
            this.btnViewResults.UseVisualStyleBackColor = true;
            this.btnViewResults.Click += new System.EventHandler(this.btnViewResults_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 54);
            this.label3.TabIndex = 8;
            this.label3.Text = "Welcome to the SimulEICon simulation tool. Click the \"Component Builder\" button t" +
                "o start a new simulation.\r\n\r\nOr, click the \"View Results\" button to view previou" +
                "s simulation results.";
            // 
            // btnFamily
            // 
            this.btnFamily.Enabled = false;
            this.btnFamily.Location = new System.Drawing.Point(418, 129);
            this.btnFamily.Name = "btnFamily";
            this.btnFamily.Size = new System.Drawing.Size(159, 23);
            this.btnFamily.TabIndex = 9;
            this.btnFamily.Text = "Test Family";
            this.toolTip1.SetToolTip(this.btnFamily, "For Testing Purposes.");
            this.btnFamily.UseVisualStyleBackColor = true;
            this.btnFamily.Visible = false;
            this.btnFamily.Click += new System.EventHandler(this.btnFamily_Click);
            // 
            // ModelManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 166);
            this.Controls.Add(this.btnFamily);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnViewResults);
            this.Controls.Add(this.btnComponentBuilder);
            this.Controls.Add(this.btnWalls);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModelManagerForm";
            this.Text = "Model Manager";
            this.Load += new System.EventHandler(this.ModelManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnWalls;
        private System.Windows.Forms.Button btnComponentBuilder;
        private System.Windows.Forms.Button btnViewResults;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnFamily;
    }
}