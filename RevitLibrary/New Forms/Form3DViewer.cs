using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RevitLibrary.DataClasses;

namespace RevitLibrary.New_Forms
{
    public partial class Form3DViewer : Form
    {
        public List<ProjectResult> Projects { get; set; }
        public Form3DViewer()
        {
            InitializeComponent();
        }

        private void Form3DViewer_Load(object sender, EventArgs e)
        {
            
        }

        private void Panel3D_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
