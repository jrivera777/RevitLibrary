namespace RevitLibrary
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
            this.label2 = new System.Windows.Forms.Label();
            this.lbExistingDO = new System.Windows.Forms.ListBox();
            this.grpDesignOption = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtDOName = new System.Windows.Forms.TextBox();
            this.btnCreateOption = new System.Windows.Forms.Button();
            this.btnRoofing = new System.Windows.Forms.Button();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFamily = new System.Windows.Forms.Button();
            this.grpDesignOption.SuspendLayout();
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
            this.btnWalls.Location = new System.Drawing.Point(12, 129);
            this.btnWalls.Name = "btnWalls";
            this.btnWalls.Size = new System.Drawing.Size(159, 23);
            this.btnWalls.TabIndex = 2;
            this.btnWalls.Text = "Select Walls";
            this.toolTip1.SetToolTip(this.btnWalls, "For Testing Purposes.");
            this.btnWalls.UseVisualStyleBackColor = true;
            this.btnWalls.Click += new System.EventHandler(this.btnWalls_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Existing Design Options:";
            // 
            // lbExistingDO
            // 
            this.lbExistingDO.FormattingEnabled = true;
            this.lbExistingDO.HorizontalScrollbar = true;
            this.lbExistingDO.Location = new System.Drawing.Point(204, 34);
            this.lbExistingDO.Name = "lbExistingDO";
            this.lbExistingDO.Size = new System.Drawing.Size(187, 56);
            this.lbExistingDO.TabIndex = 4;
            // 
            // grpDesignOption
            // 
            this.grpDesignOption.Controls.Add(this.btnLoad);
            this.grpDesignOption.Controls.Add(this.txtDOName);
            this.grpDesignOption.Controls.Add(this.btnCreateOption);
            this.grpDesignOption.Controls.Add(this.lbExistingDO);
            this.grpDesignOption.Controls.Add(this.label2);
            this.grpDesignOption.Enabled = false;
            this.grpDesignOption.Location = new System.Drawing.Point(15, 95);
            this.grpDesignOption.Name = "grpDesignOption";
            this.grpDesignOption.Size = new System.Drawing.Size(399, 24);
            this.grpDesignOption.TabIndex = 5;
            this.grpDesignOption.TabStop = false;
            this.grpDesignOption.Text = "Design Options";
            this.grpDesignOption.Visible = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(6, 59);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(159, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load Selected Design Option";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtDOName
            // 
            this.txtDOName.Location = new System.Drawing.Point(204, 111);
            this.txtDOName.Name = "txtDOName";
            this.txtDOName.Size = new System.Drawing.Size(187, 20);
            this.txtDOName.TabIndex = 6;
            // 
            // btnCreateOption
            // 
            this.btnCreateOption.Location = new System.Drawing.Point(6, 109);
            this.btnCreateOption.Name = "btnCreateOption";
            this.btnCreateOption.Size = new System.Drawing.Size(159, 23);
            this.btnCreateOption.TabIndex = 5;
            this.btnCreateOption.Text = "New Design Option";
            this.btnCreateOption.UseVisualStyleBackColor = true;
            this.btnCreateOption.Click += new System.EventHandler(this.btnCreateOption_Click);
            // 
            // btnRoofing
            // 
            this.btnRoofing.Location = new System.Drawing.Point(177, 129);
            this.btnRoofing.Name = "btnRoofing";
            this.btnRoofing.Size = new System.Drawing.Size(116, 23);
            this.btnRoofing.TabIndex = 6;
            this.btnRoofing.Text = "Component Builder";
            this.toolTip1.SetToolTip(this.btnRoofing, "Starts new Simulation.");
            this.btnRoofing.UseVisualStyleBackColor = true;
            this.btnRoofing.Click += new System.EventHandler(this.btnRoofing_Click);
            // 
            // btnViewResults
            // 
            this.btnViewResults.Location = new System.Drawing.Point(299, 129);
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
            this.btnFamily.Location = new System.Drawing.Point(418, 129);
            this.btnFamily.Name = "btnFamily";
            this.btnFamily.Size = new System.Drawing.Size(159, 23);
            this.btnFamily.TabIndex = 9;
            this.btnFamily.Text = "Test Family";
            this.toolTip1.SetToolTip(this.btnFamily, "For Testing Purposes.");
            this.btnFamily.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.btnRoofing);
            this.Controls.Add(this.grpDesignOption);
            this.Controls.Add(this.btnWalls);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label1);
            this.Name = "ModelManagerForm";
            this.Text = "Model Manager";
            this.Load += new System.EventHandler(this.ModelManager_Load);
            this.grpDesignOption.ResumeLayout(false);
            this.grpDesignOption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnWalls;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbExistingDO;
        private System.Windows.Forms.GroupBox grpDesignOption;
        private System.Windows.Forms.Button btnCreateOption;
        private System.Windows.Forms.TextBox txtDOName;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRoofing;
        private System.Windows.Forms.Button btnViewResults;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnFamily;
    }
}