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
    public partial class ChartForm1 : Form
    {
        private SortedDictionary<double, double> Dict;
        private string[] coordNames;
        public ChartForm1()
        {
            InitializeComponent();
        }
        public ChartForm1(SortedDictionary<double,double> Dict, string[] coordNames)
        {
            InitializeComponent();
            this.Dict = Dict;
            this.coordNames = coordNames;
            SetupChart();
        }
        private void SetupChart()
        {
            chart1.ChartAreas[0].AxisX.Title = coordNames[0];
            chart1.ChartAreas[0].AxisY.Title = coordNames[1];
            foreach (var i in Dict)
            {
                chart1.Series[0].Points.AddXY(i.Key,i.Value);
            }
        }
        private void ChartForm1_Load(object sender, EventArgs e)
        {

        }
    }
}
