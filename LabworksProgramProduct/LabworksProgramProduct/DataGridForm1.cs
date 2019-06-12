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
    public partial class DataGridForm1 : Form
    {
        private SortedDictionary<double, double> Dict;
        private string[] colNames;
        public DataGridForm1()
        {
            InitializeComponent();
        }
        public DataGridForm1(SortedDictionary<double, double> Dict, string[] colNames)
        {
            InitializeComponent();
            this.Dict = Dict;
            this.colNames = colNames;
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
                if (i.Key != 1e9)
                {
                    dataGridView1.Rows[pos].Cells[0].Value = i.Key;
                }
                dataGridView1.Rows[pos++].Cells[1].Value = i.Value;
            }
        }
        private void DataGridForm1_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
