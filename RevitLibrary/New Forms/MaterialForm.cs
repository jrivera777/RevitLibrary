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
    public partial class MaterialForm : Form
    {
        public AssemMaterial createdMaterial { get; set; }
        private String[] phases = {"Manufacturing", "Construction", "Maintenance","End of Life","Operation"};
        private MaterialSummary summ;
        public MaterialForm()
        {
            InitializeComponent();
        }
        private void btnCreateMaterial_Click(object sender, EventArgs e)
        {
            AssemMaterial mat = new AssemMaterial();
            double cost = -1;
            double co2 = -1;
            double rval = -1;
            double laborCost = -1;
            double laborHours = -1;
            double dailyOutput = -1;
            
            if(!FoundNulls())
            {
                if(!Double.TryParse(txtCost.Text, out cost))
                    MessageBox.Show("Cost value must be numeric.");
                else if (!Double.TryParse(txtCO2.Text, out co2))
                    MessageBox.Show("CO2 emission value must be numeric.");
                else if (!Double.TryParse(txtRValue.Text, out rval))
                    MessageBox.Show("R-Value value must be numeric.");
                else if (!Double.TryParse(txtLaborCost.Text, out laborCost))
                    MessageBox.Show("Labor cost value must be numeric.");
                else if (!Double.TryParse(txtlaborHours.Text, out laborHours))
                    MessageBox.Show("Labor hours value must be numeric.");
                else if (!Double.TryParse(txtDailyOutput.Text, out dailyOutput))
                    MessageBox.Show("Daily Output value must be numeric.");
                else
                {
                    mat.Name = txtName.Text;
                    mat.Description = txtDesc.Text;
                    mat.CostPerUnit = cost;
                    mat.CO2PerUnit = co2;
                    mat.Unit = cboUnit.Text;
                    mat.RValue = rval;

                    this.createdMaterial = mat;

                    MaterialLabor labor = new MaterialLabor();
                    labor.Cost = laborCost;
                    labor.Hours = laborHours;
                    labor.DailyOutPut = dailyOutput;
                    this.createdMaterial.Labor = labor;
                    this.createdMaterial.Summary = summ;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        public Boolean FoundNulls()
        {
            Boolean success = true;

            if (String.IsNullOrEmpty(txtName.Text))
                MessageBox.Show("Please enter a valid material name.");
            else if (String.IsNullOrEmpty(txtDesc.Text))
                MessageBox.Show("Please enter a valid material description.");
            else if (String.IsNullOrEmpty(txtCost.Text))
                MessageBox.Show("Please enter a valid material cost.");
            else if (String.IsNullOrEmpty(txtCO2.Text))
                MessageBox.Show("Please enter a valid material emission value.");
            else if (String.IsNullOrEmpty(txtRValue.Text))
                MessageBox.Show("Please enter a valid material R-Value.");
            else if (cboUnit.SelectedIndex < 0)
                MessageBox.Show("Please select a unit for the cost and C02 values.");
            else if (String.IsNullOrEmpty(txtLaborCost.Text))
                MessageBox.Show("Please enter a valid labor cost.");
            else if (String.IsNullOrEmpty(txtlaborHours.Text))
                MessageBox.Show("Please enter a valid labor hours value.");
            else if (String.IsNullOrEmpty(txtCrewType.Text))
                MessageBox.Show("Please enter a valid crew type.");
            else
                success = false;

            return success;
        }
        private void MaterialForm_Load(object sender, EventArgs e)
        {
            chklbSummaryDetails.CheckOnClick = false;
            chklbSummaryDetails.MouseClick += new MouseEventHandler(chklbSummaryDetails_DoubleClick);
            grdVwMatSum.CellEndEdit += new DataGridViewCellEventHandler(grdVwMatSum_CellEndEdit);
            //chklbSummaryDetails.DoubleClick += new EventHandler(chklbSummaryDetails_DoubleClick);

            for (int i = 0; i < phases.Length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell phaseCell = new DataGridViewTextBoxCell();
                phaseCell.Value = phases[i];
                row.Cells.Add(phaseCell);               

                grdVwMatSum.Rows.Add(row);
            }
            grdVwMatSum.Columns["phaseColumn"].ReadOnly = true;
            grdVwMatSum.Enabled = false;
            summ = new MaterialSummary();
        }
        private void chklbSummaryDetails_DoubleClick(object sender, System.EventArgs e)
        {
            int index = chklbSummaryDetails.SelectedIndex;
            grdVwMatSum.Enabled = true;
            if (index >= 0)
            {
                if (chklbSummaryDetails.CheckedIndices.Contains(index))
                    chklbSummaryDetails.SetItemChecked(index, true);
                else
                    chklbSummaryDetails.SetItemChecked(index, false);
            }
        }
        private void chklbphaseDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = chklbSummaryDetails.SelectedIndex;
            if (index >= 0)
            {
                grdVwMatSum.Enabled = true;
                loadSummary((MaterialSummary.SummaryType)index);
            }

        }

        private void loadSummary(MaterialSummary.SummaryType type)
        {
            List<double> vals = summ.GetSummaryByType(type);
            Boolean setNull = false;
            if (vals.Count <= 0)
                setNull = true;
            for (int i = 0; i < grdVwMatSum.Rows.Count; i++)
            {
                //value column of each row
                if (setNull)
                    grdVwMatSum[1, i].Value = null;
                else
                    grdVwMatSum[1, i].Value = vals[i];
            }
        }
        private void grdVwMatSum_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string headerText = grdVwMatSum.Columns[e.ColumnIndex].HeaderText;
            if (!headerText.Equals("Value"))
                return;
            double val = 0.0;
            if (grdVwMatSum[e.ColumnIndex, e.RowIndex].Value == null)
                return;
            if (!Double.TryParse(grdVwMatSum[e.ColumnIndex, e.RowIndex].FormattedValue.ToString(), out val))
            {
                MessageBox.Show("Value must be numeric");
                grdVwMatSum.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                return;
            }
            
            if(isValueColumnFull(grdVwMatSum) && chklbSummaryDetails.SelectedIndex >= 0)
            {
                MaterialSummary.SummaryType type = (MaterialSummary.SummaryType)chklbSummaryDetails.SelectedIndex;
                for (int i = 0; i < grdVwMatSum.Rows.Count; i++)
                {
                    summ.SetSummaryValue(type, (MaterialSummary.SummaryPhase)i, Double.Parse(grdVwMatSum[1, i].Value.ToString()));
                }
                chklbSummaryDetails.SetItemChecked(chklbSummaryDetails.SelectedIndex, true);
                clearValueColumn(grdVwMatSum);
                chklbSummaryDetails.SelectedIndex = -1;
                grdVwMatSum.Enabled = false;
            }
        }
        private Boolean isValueColumnFull(DataGridView grd)
        {
            foreach(DataGridViewRow row in grd.Rows)
                if(row.Cells[1].Value == null)
                    return false;
            
            return true;
        }
        private void clearValueColumn(DataGridView grd)
        {
            foreach (DataGridViewRow row in grd.Rows)
                row.Cells[1].Value = null;
        }
    }
}
