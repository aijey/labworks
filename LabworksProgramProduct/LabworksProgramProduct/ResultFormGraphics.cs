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
    public partial class ResultFormGraphics : Form
    {
        private SortedDictionary<double, double> Dict;
        private SortedDictionary<Interval, double> IntDict;
        private List<int> TaskList;
        public ResultFormGraphics(SortedDictionary<double, double> dict, List<int> lst)
        {
            InitializeComponent();
            Dict = dict;
            TaskList = lst;
            IntDict = new SortedDictionary<Interval, double>();
            DrawPanels();
        }
        public ResultFormGraphics(SortedDictionary<Interval, double> intdict, List<int> lst)
        {
            InitializeComponent();
            Dict = new SortedDictionary<double, double>();
            IntDict = intdict;
            TaskList = lst;
            DrawPanels();
        }
        private void InitPanel1()
        {
            if (Dict.Count > 0)
            {
                SortedDictionary<double, double> toDraw = Tasks.GetEmpFunction(Dict);
                int num = 1;
                labelFuncValue.Text = "";
                double prevKey = -1000;
                foreach (var i in toDraw)
                {
                    string row = "";
                    if (num == 1)
                    {
                        row = "0, при x <= " + i.Key.ToString() + "\n";
                    }
                    else if (num < toDraw.Count())
                    {
                        row = i.Value.ToString() + ", при " + prevKey.ToString() + " < x <= " + i.Key.ToString() + "\n";
                    }
                    else
                    {
                        row = "1, при x > " + prevKey.ToString() + "\n";
                    }
                    labelFuncValue.Text += row;
                    prevKey = i.Key;
                    num++;
                }
            } else
            {
                SortedDictionary<double, double> toDraw = Tasks.GetIntEmpFunction(IntDict);

            }
                // ALIGN STAFF //
                labelFunc.Top = labelFuncValue.Bottom - labelFuncValue.Height / 2;
                int w = panel1.Width;
                int wl = labelFuncValue.Right - labelFunc.Left;
                int x = (w - wl) / 2;
                int d = x - labelFunc.Left;
                labelFunc.Left += d;
                labelFuncValue.Left += d;
            
        }

        private void InitPanel2()
        {
            SortedDictionary<double, double> toDraw = Tasks.GetEmpFunction(Dict);
            double min = toDraw.Min(x => x.Key) - 10;
            double max = toDraw.Max(x => x.Key) + 10;
            int curSer = 0;
            double prevKey = min;
            chart1.ChartAreas[0].AxisX.Title = "x";
            chart1.ChartAreas[0].AxisY.Title = "F*(x)";
            foreach (var i in toDraw)
            {
                chart1.Series.Add("");
                chart1.Series[curSer].Color = Color.Blue;
                chart1.Series[curSer].MarkerBorderWidth += 15;
                chart1.Series[curSer].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[curSer].IsVisibleInLegend = false;
                chart1.Series[curSer].Points.AddXY(prevKey, i.Value);
                chart1.Series[curSer++].Points.AddXY(i.Key, i.Value);
                prevKey = i.Key;
            }
        }
        private void DrawPanels()
        {
            int spaceSize = 12;
            int prevTop = 0;
            panel1.Hide();
            panel2.Hide();
            foreach(int index in TaskList)
            {
                if (index == 1)
                {
                    panel1.Top = prevTop + spaceSize;
                    InitPanel1();
                    prevTop = panel1.Top + panel1.Height;
                    panel1.Show();
                } else if (index == 2)
                {
                    panel2.Top = prevTop + spaceSize;
                    InitPanel2();
                    prevTop = panel2.Top + panel2.Height;
                    panel2.Show();
                } else
                {
                    throw new NotImplementedException();
                }
            }
        }

    }
}
