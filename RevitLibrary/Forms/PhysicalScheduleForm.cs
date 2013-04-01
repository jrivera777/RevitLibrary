using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Microsoft.Glee.Drawing;
using Microsoft.Glee.GraphViewerGdi;

namespace RevitLibrary.Forms
{
    public partial class PhysicalScheduleForm : Form
    {
        public List<BuildingComponent> Components { get; set; }
        public PhysicalScheduleForm()
        {
            InitializeComponent();
        }

        private void PhysicalScheduleForm_Load(object sender, EventArgs e)
        {
            //add necessary columns
            dgvSchedule.Columns.Add("category", "Category");
            dgvSchedule.Columns.Add("name", "Component Name");
            dgvSchedule.Columns.Add("pred", "Predecessor");
            dgvSchedule.Columns.Add("succ", "Successor");

            //disable editing certain columns
            dgvSchedule.Columns["name"].ReadOnly = true;
            dgvSchedule.Columns["category"].ReadOnly = true;

            foreach (BuildingComponent bComp in this.Components)
            {
                        
                        //add necessary info
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewTextBoxCell catCell = new DataGridViewTextBoxCell();
                        catCell.Value = bComp.Category;
                        row.Cells.Add(catCell);
                        DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                        nameCell.Value = bComp.Name;
                        row.Cells.Add(nameCell);
                        //DataGridViewTextBoxCell descCell = new DataGridViewTextBoxCell();
                        //descCell.Value = mat.Description;
                        //row.Cells.Add(descCell);
                        

                        Boolean exists = false;
                        foreach (DataGridViewRow r in dgvSchedule.Rows)
                        {
                            if (r.Cells["name"].Value.Equals(row.Cells[1].Value) && r.Cells["category"].Value.Equals(row.Cells[0].Value))
                            {
                                exists = true;
                                break;
                            }
                        }

                        if (!exists)
                            dgvSchedule.Rows.Add(row);
            }
            GViewer gView = new GViewer();
            gView.Name = "GraphViewer";
            gView.PanButtonPressed = true;
            gView.Dock = DockStyle.Fill;
            graphPanel.Controls.Add(gView);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.Rows.Count <= 0)
            {
                MessageBox.Show("Nothing to save...");
                this.DialogResult = DialogResult.Abort;
                return;
            }
            using (SaveFileDialog saveDlg = new SaveFileDialog())
            {
                saveDlg.Title = "Save Component Order";
                saveDlg.Filter = "XML File|*.xml";
                saveDlg.ShowDialog();

                if (!String.IsNullOrEmpty(saveDlg.FileName))
                {
                    try
                    {
                        writeData(saveDlg.FileName, dgvSchedule.Rows);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show(String.Format("{0} - Please Correct.", ex.Message));
                        if(File.Exists(saveDlg.FileName))
                            File.Delete(saveDlg.FileName);
                        
                        this.DialogResult = DialogResult.Abort;
                    }
                }
            }
        }
        private void writeData(String fName, DataGridViewRowCollection rows)
        {
            using (XmlWriter writer = XmlWriter.Create(fName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ComponentOrder");
                foreach (DataGridViewRow row in dgvSchedule.Rows)
                {
                    writer.WriteStartElement("Component");
                    writer.WriteElementString("Category", row.Cells["category"].Value.ToString());
                    writer.WriteElementString("Name", row.Cells["name"].Value.ToString());
                    //writer.WriteElementString("Description", row.Cells["desc"].Value.ToString());

                    //if (row.Cells["duration"].Value == null)
                    //    throw new NullReferenceException("No Duration Found");
                    //writer.WriteElementString("Duration", row.Cells["duration"].Value.ToString());
                    if (row.Cells["pred"].Value == null)
                        throw new NullReferenceException("No Predecessor Found");
                    writer.WriteElementString("PredecessorName", row.Cells["pred"].Value.ToString());
                    if (row.Cells["succ"].Value == null)
                        throw new NullReferenceException("No Successor Found");
                    writer.WriteElementString("SuccessorName", row.Cells["succ"].Value.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count > 0)
            {
                int index = dgvSchedule.SelectedRows[0].Index;
                DataGridViewRow row = dgvSchedule.Rows.SharedRow(index);

                DataGridViewRow copy = new DataGridViewRow();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    DataGridViewTextBoxCell c = new DataGridViewTextBoxCell();
                    c.Value = cell.Value;
                    copy.Cells.Add(c);
                }
                dgvSchedule.Rows.Insert(index, copy);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count > 0)
            {
                int index = dgvSchedule.SelectedRows[0].Index;
                DataGridViewRow row = dgvSchedule.Rows.SharedRow(index);
                
                if (index - 1 >= 0)
                {
                    dgvSchedule.Rows.Remove(row);
                    dgvSchedule.Rows.Insert(--index, row);
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count > 0)
            {
                int index = dgvSchedule.SelectedRows[0].Index;
                DataGridViewRow row = dgvSchedule.Rows.SharedRow(index);

                if (index + 1 < dgvSchedule.Rows.Count)
                {
                    dgvSchedule.Rows.Remove(row);
                    dgvSchedule.Rows.Insert(++index, row);
                }
            }
        }

        private void btnAutofill_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.RowCount > 1)
            {
                //clear old data
                foreach (DataGridViewRow row in dgvSchedule.Rows)
                {
                    row.Cells["pred"].Value = null;
                    row.Cells["succ"].Value = null;
                }


                foreach(DataGridViewRow row in dgvSchedule.Rows)
                {
                    //first row doesn't have a normal predeccesor
                    int index = row.Index;
                    if (index == 0)
                    {
                        row.Cells["pred"].Value = "START";
                        row.Cells["succ"].Value = dgvSchedule.Rows[index + 1].Cells["Name"].Value.ToString(); ;
                    }
                    else if (index == dgvSchedule.Rows.Count - 1) //first row doesn't have a normal succesor
                    {
                        row.Cells["pred"].Value = dgvSchedule.Rows[index - 1].Cells["Name"].Value.ToString();
                        row.Cells["succ"].Value = "END";
                    }
                    else
                    {
                        row.Cells["pred"].Value = dgvSchedule.Rows[index - 1].Cells["Name"].Value.ToString();
                        row.Cells["succ"].Value = dgvSchedule.Rows[index + 1].Cells["Name"].Value.ToString(); ;
                    }
                }
            }
        }

        private void btnDrawGraph_Click(object sender, EventArgs e)
        {
            GViewer gView = (GViewer)graphPanel.Controls["GraphViewer"];
            Graph g = GenerateGraph(dgvSchedule.Rows);
            gView.Graph = g;
        }

        /// <summary>
        /// Generate graph based on given Gridview. Should Represent a project schedule.
        /// </summary>
        /// <param name="rows"></param>
        private Graph GenerateGraph(DataGridViewRowCollection rows)
        {
            Graph g = new Graph("Schedule");
            Edge currEdge;

            Node start = g.AddNode("START");
            start.Attr.Color = Microsoft.Glee.Drawing.Color.Green;
            Node end = g.AddNode("END");
            end.Attr.Color = Microsoft.Glee.Drawing.Color.Red;

            if (rows.Count <= 0)
                g.AddEdge(start.Id, end.Id);

            foreach (DataGridViewRow row in rows)
            {
                if (row.Cells["pred"].Value == null)
                    throw new NullReferenceException("No Predecessor Found");
                if (row.Cells["succ"].Value == null)
                    throw new NullReferenceException("No Successor Found");

                String pred = row.Cells["pred"].Value.ToString();
                String succ = row.Cells["succ"].Value.ToString();
                String curr = row.Cells["name"].Value.ToString();
                Node predNode = g.FindNode(pred);
                Node succNode = g.FindNode(succ);
                Node currNode = g.FindNode(curr);
                if (currNode == null)
                    currNode= g.AddNode(curr);
                if (predNode == null)
                {
                    predNode = g.AddNode(pred);
                    g.AddEdge(predNode.Id, currNode.Id);
                }
                else if (predNode.Id.Equals(start.Id))
                    g.AddEdge(start.Id, currNode.Id);
                if (succNode == null)
                {
                    succNode = g.AddNode(succ);
                    g.AddEdge(currNode.Id, succNode.Id);
                }
                else if (succNode.Id.Equals(end.Id))
                    g.AddEdge(currNode.Id, end.Id);
                else
                    g.AddEdge(currNode.Id, succNode.Id);
            }

            return g;
        }
    }
}
