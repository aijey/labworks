using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabworksProgramProduct
{
    public partial class DataGridForm2 : Form
    {
        private SortedDictionary<Interval, double> Dict;
        private string[] colNames;
        public DataGridForm2()
        {
            InitializeComponent();
        }
        public DataGridForm2(SortedDictionary<Interval, double> Dict, string[] colNames)
        {
            InitializeComponent();
            this.Dict = Dict;
            this.colNames = (string[])colNames.Clone();
            SetupDataGrid();
        }
        private void SetupDataGrid()
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = colNames[0];
            dataGridView1.Columns[1].Name = colNames[1];
            int pos = 0;
            foreach (var i in Dict)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[pos].Cells[0].Value = i.Key.ToString();
                dataGridView1.Rows[pos++].Cells[1].Value = i.Value;
            }
        }

        private void DataGridForm2_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
