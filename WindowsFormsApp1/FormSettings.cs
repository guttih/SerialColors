using SerialColors.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SerialColors.Properties;

namespace SerialColors
{
    public partial class FormSettings : Form
    {
        StepRepository repo;
        private List<Step> steps;
        private Properties.Settings settings;

        public FormSettings()
        {
            this.repo = new StepRepository(Settings.Default);
            InitializeComponent();
            Init();
        }

        private void SortGrid()
        {
            //doesn't work todo: find out how to make grid sort automatically when user has edited row
            dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
        }
        private void Init()
        {

            steps = repo.GetAllSteps();//.OrderBy(o => o.From).ToList();
            var source = new BindingSource(steps, null);
            dataGridView1.DataSource = source;
            
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            GridViewUpdateColorCells();
            timerDataGrid.Enabled = true;
        }

        private void FormClose(bool save)
        {
            if (save)
            {
                repo.Save(steps);
                
            }
            Close();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            FormClose(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            FormClose(false);

        }

        private void GridViewUpdateColorCells()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cell = row.Cells[2];
                var num = cell.Value;
                if (num != null)
                {
                    var col = new SColor((ulong)num);
                    cell.Style.BackColor = Color.FromArgb(col.Red, col.Green, col.Blue);
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            GridViewUpdateColorCells();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerDataGrid.Enabled = false;
            dataGridView1.Refresh();
        }
    }
}
