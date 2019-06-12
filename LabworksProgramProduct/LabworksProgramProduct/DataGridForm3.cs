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
    public partial class DataGridForm3 : Form
    {
        private double[,] arr;
        public DataGridForm3(double[,] arr)
        {
            this.arr = arr;
            InitializeComponent();
            dataGridView1.ColumnCount = arr.GetLength(1) - 1;
            for(int i=1; i<arr.GetLength(1); i++)
            {
                dataGridView1.Columns[i-1].Name = arr[0,i].ToString();
            }
            for(int i = 1; i < arr.GetLength(0); i++)
            {
                dataGridView1.Rows.Add();
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        dataGridView1.Rows[i - 1].HeaderCell.Value = arr[i, j].ToString();
                    }
                    else
                    {
                        dataGridView1.Rows[i - 1].Cells[j-1].Value = arr[i, j];
                    }
                }
            }
        }

        private void DataGridForm3_Load(object sender, EventArgs e)
        {

        }
    }
}
