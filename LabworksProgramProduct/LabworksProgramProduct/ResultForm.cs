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
    public partial class ResultForm : Form
    {
        private List<int> TasksList;
        private SortedDictionary<double, double> Dict;
        public ResultForm(List<int> _Tasks, SortedDictionary<double,double> _Dict)
        {
            InitializeComponent();
            TasksList = _Tasks;
            Dict = _Dict;
            SelectPanels();
        }
        private void SelectPanels()
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            int prevTop = 0;
            foreach (var item in TasksList)
            {
                if (item == 1)
                {
                    panel1.Show();
                    panel1.Top = prevTop + 12;
                    prevTop = panel1.Top + panel1.Height;
                    List<double> lst = Tasks.BuildVariantRow(Dict);
                    dataGridVariantRow.RowCount = 1;
                    dataGridVariantRow.ColumnHeadersVisible = false;
                    dataGridVariantRow.Rows[0].HeaderCell.Value = "Xi";
                    dataGridVariantRow.RowHeadersWidth = 50;
                    dataGridVariantRow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridVariantRow.ColumnCount = lst.Count;
                    for (int i = 0; i < lst.Count; i++)
                    {
                        dataGridVariantRow[i, 0].Value = lst[i];
                    }
                }
                else if (item == 2)
                {
                    panel2.Show();
                    panel2.Top = prevTop + 12;
                    prevTop = panel2.Top + panel2.Height;
                    dataGridStaticDistrRow.RowCount = 2;
                    dataGridStaticDistrRow.ColumnHeadersVisible = false;
                    dataGridStaticDistrRow.RowHeadersWidth = 60;
                    dataGridStaticDistrRow.Rows[0].HeaderCell.Value = "Xi";
                    dataGridStaticDistrRow.Rows[1].HeaderCell.Value = "Ni";
                    dataGridStaticDistrRow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridStaticDistrRow.ColumnCount = Dict.Keys.Count;
                    int cnt = 0;
                    foreach (var i in Dict)
                    {
                        if (i.Key != 1e9)
                        {
                            dataGridStaticDistrRow[cnt, 0].Value = i.Key;
                        }
                        dataGridStaticDistrRow[cnt++, 1].Value = i.Value;
                    }
                }
                else if (item == 3)
                {
                    panel3.Show();
                    panel3.Top = prevTop + 12;
                    prevTop = panel3.Top + panel3.Height;
                    var resDict = Tasks.BuildRelDistr(Dict);
                    dataGridStaticRelDistr.RowCount = 2;
                    dataGridStaticRelDistr.ColumnHeadersVisible = false;
                    dataGridStaticRelDistr.RowHeadersWidth = 60;
                    dataGridStaticRelDistr.Rows[0].HeaderCell.Value = "Xi";
                    dataGridStaticRelDistr.Rows[1].HeaderCell.Value = "Wi";
                    dataGridStaticRelDistr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridStaticRelDistr.ColumnCount = resDict.Keys.Count;
                    int cnt = 0;
                    foreach (var i in resDict)
                    {
                        if (i.Key != 1e9)
                        {
                            dataGridStaticRelDistr[cnt, 0].Value = i.Key;
                        }
                        dataGridStaticRelDistr[cnt++, 1].Value = i.Value;
                    }
                }
                else if (item == 4)
                {
                    panel4.Show();
                    panel4.Top = prevTop + 12;
                    prevTop = panel4.Top + panel4.Height;
                    var resDict = Tasks.BuildIncDistr(Dict);
                    dataGridStaticIncDistr.RowCount = 2;
                    dataGridStaticIncDistr.ColumnHeadersVisible = false;
                    dataGridStaticIncDistr.RowHeadersWidth = 75;
                    dataGridStaticIncDistr.Rows[0].HeaderCell.Value = "Xi";
                    dataGridStaticIncDistr.Rows[1].HeaderCell.Value = "Ni(нак)";
                    dataGridStaticIncDistr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridStaticIncDistr.ColumnCount = resDict.Keys.Count;
                    int cnt = 0;
                    foreach (var i in resDict)
                    {
                        if (i.Key != 1e9)
                        {
                            dataGridStaticIncDistr[cnt, 0].Value = i.Key;
                        }
                        dataGridStaticIncDistr[cnt++, 1].Value = i.Value;
                    }
                }
                else if (item == 5)
                {
                    panel5.Show();
                    panel5.Top = prevTop + 12;
                    prevTop = panel5.Top + panel5.Height;
                    var resDict = Tasks.BuildIncRelDistr(Dict);
                    dataGridStaticRelIncDistr.RowCount = 2;
                    dataGridStaticRelIncDistr.ColumnHeadersVisible = false;
                    dataGridStaticRelIncDistr.RowHeadersWidth = 75;
                    dataGridStaticRelIncDistr.Rows[0].HeaderCell.Value = "Xi";
                    dataGridStaticRelIncDistr.Rows[1].HeaderCell.Value = "Wi(нак)";
                    dataGridStaticRelIncDistr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridStaticRelIncDistr.ColumnCount = resDict.Keys.Count;
                    int cnt = 0;
                    foreach (var i in resDict)
                    {
                        if (i.Key != 1e9)
                        {
                            dataGridStaticRelIncDistr[cnt, 0].Value = i.Key;
                        }
                        dataGridStaticRelIncDistr[cnt++, 1].Value = i.Value;
                    }
                }
                else if (item == 6)
                {
                    panel6.Show();
                    panel6.Top = prevTop + 12;
                    prevTop = panel6.Top + panel6.Height;
                    GetFreqPolygonChart();
                }
                else if (item == 7)
                {
                    panel7.Show();
                    panel7.Top = prevTop + 12;
                    prevTop = panel7.Top + panel7.Height;
                    GetRelFreqPolygonChart();
                }
            }
        }

        private void ButtonSaveVariantRow_Click(object sender, EventArgs e)
        {
            string res = GetOutputData(1);
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.Title = "Зберегти як";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                using (var writer = new StreamWriter(file))
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
        private string GetOutputData(int Type)
        {
            if (Type == 1)
            {
                string res = "";
                for (int i = 0; i < dataGridVariantRow.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        res += " ";
                    }
                    res += dataGridVariantRow[i, 0].Value;
                }
                return res;
            }
            else if (Type == 2)
            {
                string res = "";
                for (int i = 0; i < dataGridStaticDistrRow.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        res += "\n";
                    }
                    res += dataGridStaticDistrRow[i, 0].Value + " " + dataGridStaticDistrRow[i, 1].Value;
                }
                return res;
            }
            else
            {
                MessageBox.Show("Not implemented");
                throw new NotImplementedException();
            }
        }

        private void ButtonSaveStaticDistr_Click(object sender, EventArgs e)
        {
            string res = GetOutputData(2);
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.Title = "Зберегти як";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                using (var writer = new StreamWriter(file))
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
        private void GetFreqPolygonChart()
        {
            FreqPolygon.ChartAreas[0].AxisX.Title = "Xi";
            FreqPolygon.ChartAreas[0].AxisY.Title = "Ni";
            FreqPolygon.Series[0].Color = Color.Blue;
            FreqPolygon.Series[0].MarkerBorderWidth += 5;
            FreqPolygon.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            FreqPolygon.Series[0].IsVisibleInLegend = false;
            FreqPolygon.Series[0].IsValueShownAsLabel = true;
            foreach (var i in Dict)
            {
                FreqPolygon.Series[0].Points.AddXY(i.Key, i.Value);
            }
        }
        private void GetRelFreqPolygonChart()
        {
            var resDict = Tasks.BuildRelDistr(Dict);
            RelFreqPolygon.ChartAreas[0].AxisX.Title = "Xi";
            RelFreqPolygon.ChartAreas[0].AxisY.Title = "Wi";
            RelFreqPolygon.Series[0].Color = Color.Blue;
            RelFreqPolygon.Series[0].MarkerBorderWidth += 5;
            RelFreqPolygon.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            RelFreqPolygon.Series[0].IsVisibleInLegend = false;
            RelFreqPolygon.Series[0].IsValueShownAsLabel = true;
            foreach (var i in resDict)
            {
                RelFreqPolygon.Series[0].Points.AddXY(i.Key, i.Value);
            }
        }
    }
}
