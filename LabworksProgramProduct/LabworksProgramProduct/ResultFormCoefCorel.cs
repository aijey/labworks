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
    public partial class ResultFormCoefCorel : Form
    {
        List<int> TasksList;
        double[,] matrix;
        public ResultFormCoefCorel(List<int> ls, double [,] matrix)
        {
            TasksList = ls;
            this.matrix = matrix;
            InitializeComponent();
            Init();
        }
        private void fillDataGrid(ref DataGridView dataGridView, ref SortedDictionary<double, double> dict, string[] headers)
        {
            List<double> keys = dict.Keys.ToList();
            dataGridView.ColumnCount = keys.Count;
            dataGridView.RowCount = 2;
            dataGridView.Rows[0].HeaderCell.Value = headers[0];
            dataGridView.Rows[1].HeaderCell.Value = headers[1];
            int ind = 0;
            foreach(var key in keys)
            {
                dataGridView.Rows[0].Cells[ind].Value = key.ToString();
                dataGridView.Rows[1].Cells[ind++].Value = dict[key].ToString();
            }
        }
        private void Solve(int x)
        {
            var DictX = Tasks.GetDictXFromMatrix(matrix);
            var DictY = Tasks.GetDictYFromMatrix(matrix);
            if (x == 1)
            {
                fillDataGrid(ref dataGridView1, ref DictX, new string[2] { "Xi", "Ni" });
            } else if (x == 2)
            {
                fillDataGrid(ref dataGridView2, ref DictY, new string[] { "Yi", "Ni" });
            } else if (x == 3)
            {
                double coefCorel = Tasks.GetCoefCorel(matrix, ref DictX, ref DictY);
                textBoxCoefCorel.Text = coefCorel.ToString();
                
            } else if (x == 4)
            {
                double avgX = Tasks.GetAvg(ref DictX);
                double avgY = Tasks.GetAvg(ref DictY);
                textBoxAvgX.Text = avgX.ToString();
                textBoxAvgY.Text = avgY.ToString();

            } else if (x == 5)
            {
                double Dx = Tasks.GetDispersion(ref DictX);
                double Dy = Tasks.GetDispersion(ref DictY);
                double CorDx = Tasks.GetCorrectedDispersion(ref DictX);
                double CorDy = Tasks.GetCorrectedDispersion(ref DictY);

                double DevX = Tasks.GetSquareDeviation(ref DictX);
                double DevY = Tasks.GetSquareDeviation(ref DictY);
                double CorDevX = Tasks.GetCorrectedSquareDeviation(ref DictX);
                double CorDevY = Tasks.GetCorrectedSquareDeviation(ref DictY);

                textBoxDx.Text = Dx.ToString();
                textBoxDy.Text = Dy.ToString();
                textBoxCorDx.Text = CorDx.ToString();
                textBoxCorDy.Text = CorDy.ToString();

                textBoxDevX.Text = DevX.ToString();
                textBoxDevY.Text = DevY.ToString();
                textBoxCorDevX.Text = CorDevX.ToString();
                textBoxCorDevY.Text = CorDevY.ToString();
            }
        }
        private void Init()
        {
            int prevTop = 0;
            foreach(int i in TasksList)
            {
                prevTop += 12;
                if (i == 1)
                {
                    panel1.Top = prevTop;
                    Solve(1);
                    prevTop += panel1.Height;
                    panel1.Show();

                } else if (i == 2)
                {
                    panel2.Top = prevTop;
                    Solve(2);
                    prevTop += panel2.Height;
                    panel2.Show();
                } else if (i == 3)
                {
                    panel4.Top = prevTop;
                    Solve(3);
                    prevTop += panel4.Height;
                    panel4.Show();
                } else if (i == 4)
                {
                    panel5.Top = prevTop;
                    Solve(4);
                    prevTop += panel5.Height;
                    panel5.Show();
                } else if (i == 5)
                {
                    panel3.Top = prevTop;
                    Solve(5);
                    prevTop += panel3.Height;
                    panel3.Show();
                } else
                {
                    throw new Exception("Invalid tasks at ResultFormCoefCorel. Task id: " + i);
                }

            }
        }
    }
}
