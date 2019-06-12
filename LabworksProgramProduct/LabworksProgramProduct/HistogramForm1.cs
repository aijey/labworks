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
    public partial class HistogramForm1 : Form
    {
        private SortedDictionary<Interval, double> intDict;
        private string[] colNames;
        public HistogramForm1()
        {
            InitializeComponent();
        }
        public HistogramForm1(SortedDictionary<Interval,double> intDict, string[] colNames)
        {
            this.colNames = colNames;
            this.intDict = intDict;
            InitializeComponent();
            int cnt = 1;
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.ChartAreas[0].AxisX.Title = colNames[0];
            chart1.ChartAreas[0].AxisY.Title = colNames[1]; 
            foreach(var i in intDict)
            {
                chart1.Series[0].Points.AddXY(cnt++, i.Value);
            }
        }


        private void HistogramForm1_Load(object sender, EventArgs e)
        {

        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
