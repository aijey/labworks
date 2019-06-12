using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LabworksProgramProduct
{
    public partial class OutputForm : Form
    {
        string Type;
        private string GetOutputData()
        {
            if (Type == "Варіаційний ряд")
            {
                string res = "";
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        res += " ";
                    }
                    res += dataGridView1[i, 0].Value;
                }
                return res;
            }
            if (Type == "Статистичний розподіл")
            {
                string res = "";
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (i > 0)
                    {
                        res += "\n";
                    }
                    res += dataGridView1[0, i].Value + " " + dataGridView1[1, i].Value;
                }
                return res;
            }
            MessageBox.Show("Not implemented");
            throw new NotImplementedException();
        }
        public OutputForm(List<double> lst, string Type)
        {
            InitializeComponent();
            this.Type = Type;
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Rows[0].HeaderCell.Value = "Xi";
            dataGridView1.RowHeadersWidth = 50;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnCount = lst.Count;
            for(int i = 0; i < lst.Count; i++)
            {
                dataGridView1[i, 0].Value = lst[i];
            }
        }
        public OutputForm(SortedDictionary<double,double> Dict, string Type)
        {
            InitializeComponent();
            this.Type = Type;
            dataGridView1.ColumnCount = 2;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderCell.Value = "Xi";
            dataGridView1.Columns[1].HeaderCell.Value = "Ni";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.RowCount = Dict.Keys.Count;
            int cnt = 0;
            foreach(var i in Dict)
            {
                if (i.Key != 1e9)
                {
                    dataGridView1[0, cnt].Value = i.Key;
                }
                dataGridView1[1, cnt++].Value = i.Value;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string res = GetOutputData();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.Title = "Зберегти як";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                using(var writer = new StreamWriter(file))
                {
                    for (int i = 0; i < res.Length; i++)
                    {
                        if (res[i] == '\n')
                        {
                            writer.WriteLine();
                        }
                        else
                        {
                            writer.Write(res[i]);
                        }
                    }
                }
            }
        }
    }
}
