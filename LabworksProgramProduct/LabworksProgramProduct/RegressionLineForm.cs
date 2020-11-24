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
    public partial class RegressionLineForm : Form
    {
        double[,] Matrix;
        public RegressionLineForm(double[,] matrix)
        {
            Matrix = matrix;
            InitializeComponent();
            DrawChart();
        }

        private void DrawChart()
        {
            var dictX = Tasks.GetDictXFromMatrix(Matrix);
            var dictY = Tasks.GetDictYFromMatrix(Matrix);

            double yAvg = Tasks.GetAvg(ref dictY);
            double xAvg = Tasks.GetAvg(ref dictX);

            double xSqDev = Tasks.GetSquareDeviation(ref dictX);
            double ySqDev = Tasks.GetSquareDeviation(ref dictY);

            double rV = Tasks.GetCoefCorel(Matrix, ref dictX, ref dictY);

            double k = ySqDev / xSqDev * rV;
            double b = -xAvg * k + yAvg;

            chart1.Series[0].BorderWidth = 3;
            chart1.Series[0].Name = $"y = {Math.Round(k, 3)}x + {Math.Round(b, 3)}";
            chart1.Name = "Рівняння регресії";
            for (double x = -5; x <= 5; x++)
            {
                double y = k * x + b;
                chart1.Series[0].Points.AddXY(x, y);
            }
        }

    }
}
