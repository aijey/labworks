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
    public partial class FunctionForm : Form
    {
        private SortedDictionary<double, double> Dict;
        private string[] coordNames;
        public FunctionForm()
        {
            InitializeComponent();
        }
        public FunctionForm(SortedDictionary<double,double> Dict,string[] coordNames,string type)
        {
            InitializeComponent();
            this.coordNames = coordNames;
            this.Dict = Dict;
            if (type == "1")
            {
                SetupChart1();
            }
            else
            {
                if (type == "2")
                {
                    SetupChart2();
                } else
                {
                    SetupChart3();
                }
            }
        }
        private void SetupChart1()
        {
            double min = Dict.Min(x => x.Key) - 10;
            double max = Dict.Max(x => x.Key) + 10;
            int curSer = 0;
            double prevKey = min;
            chart1.ChartAreas[0].AxisX.Title = coordNames[0];
            chart1.ChartAreas[0].AxisY.Title = coordNames[1];
            foreach(var i in Dict)
            {
                chart1.Series.Add("");
                chart1.Series[curSer].Color = Color.Blue;
                chart1.Series[curSer].MarkerBorderWidth += 5;
                chart1.Series[curSer].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[curSer].IsVisibleInLegend = false;
                chart1.Series[curSer].Points.AddXY(prevKey,i.Value);
                chart1.Series[curSer++].Points.AddXY(i.Key, i.Value);
                prevKey = i.Key;
            }
        }
        private void SetupChart2()
        {
            chart1.ChartAreas[0].AxisX.Title = coordNames[0];
            chart1.ChartAreas[0].AxisY.Title = coordNames[1];
            double min = Dict.Min(x => x.Key) - 1;
            double max = Dict.Max(x => x.Key) + 1;
            chart1.Series.Add("");
            chart1.Series[0].Color = Color.Blue;
            chart1.Series[0].MarkerBorderWidth += 5;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].Points.AddXY(min, 0);
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series[0].IsValueShownAsLabel = true;
            foreach (var i in Dict)
            {
                chart1.Series[0].Points.AddXY(i.Key, i.Value);
            }
            chart1.Series[0].Points.AddXY(max, 1);

        }
        private void SetupChart3()
        {
            chart1.ChartAreas[0].AxisX.Title = coordNames[0];
            chart1.ChartAreas[0].AxisY.Title = coordNames[1];
            chart1.Series.Add("");
            chart1.Series[0].Color = Color.Blue;
            chart1.Series[0].MarkerBorderWidth += 5;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series[0].IsValueShownAsLabel = true;
            foreach (var i in Dict)
            {
                chart1.Series[0].Points.AddXY(i.Key, i.Value);
            }
        }
        private void FunctionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
