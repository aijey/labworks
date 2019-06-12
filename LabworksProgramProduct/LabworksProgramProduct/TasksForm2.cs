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
    public partial class TasksForm2 : Form
    {
        double[,] arr;
        public TasksForm2(double[,] arr)
        {
            this.arr = arr;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var form = new DataGridForm3(arr);
            form.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SortedDictionary<double, double> Dict = new SortedDictionary<double, double>();
            for (var i = 1; i < arr.GetLength(0); i++)
            {
                double x = arr[i, 0];
                double sum = 0; 
                for (var j = 1; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j];
                }
                Dict[x] = sum;
            }
            var form = new DataGridForm1(Dict, new[] { "x_i", "n_i" });
            form.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SortedDictionary<double, double> Dict = new SortedDictionary<double, double>();
            for (var i = 1; i < arr.GetLength(1); i++)
            {
                double y = arr[0, i];
                double sum = 0;
                for (var j = 1; j < arr.GetLength(0); j++)
                {
                    sum += arr[j, i];
                }
                Dict[y] = sum;
            }
            var form = new DataGridForm1(Dict, new[] { "y_i", "n_i" });
            form.Show();
        }
        private SortedDictionary<double,double> DictX()
        {
            SortedDictionary<double, double> Dict = new SortedDictionary<double, double>();
            for (var i = 1; i < arr.GetLength(0); i++)
            {
                double x = arr[i, 0];
                double sum = 0;
                for (var j = 1; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j];
                }
                Dict[x] = sum;
            }
            return Dict;
        }
        private SortedDictionary<double, double> DictY()
        {
            SortedDictionary<double, double> Dict = new SortedDictionary<double, double>();
            for (var i = 1; i < arr.GetLength(1); i++)
            {
                double y = arr[0, i];
                double sum = 0;
                for (var j = 1; j < arr.GetLength(0); j++)
                {
                    sum += arr[j, i];
                }
                Dict[y] = sum;
            }
            return Dict;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            string res = "";

            var xDict = DictX();
            var yDict = DictY();

            double xN = xDict.Sum(x => x.Value);
            double xavg = xDict.Sum(x => x.Value * x.Key) / xN;

            double yN = yDict.Sum(x => x.Value);
            double yavg = yDict.Sum(x => x.Value * x.Key) / yN;

            res += $"Вибіркове середнє варіант х: {xavg}\n";
            res += $"Вибіркове середнє варіант y: {yavg}\n";

            double xD = xDict.Sum(x => x.Value * sqr(x.Key - xavg)) / xN;
            double yD = yDict.Sum(x => x.Value * sqr(x.Key - yavg)) / yN;

            double xS = Math.Sqrt(xD);
            double yS = Math.Sqrt(yD);

            res += $"Вибіркове середнєквадратичне відхилення варіант х: {xS}\n";
            res += $"Вибіркове середнєквадратичне відхилення варіант y: {yS}\n";

            double sum = 0;
            for(int i = 1; i < arr.GetLength(0); i++)
            {
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j] * arr[i, 0] * arr[0, j];
                }
            }
            double rv = (sum - (xN + yN) * xavg * yavg) / ((xN + yN) * xS * yS);

            res += $"Вибірковий коефіцієнт кореляції: {rv}\n";

            double k = yS * rv / xS;
            double b = yavg - k * xavg;

            res += $"Вибіркове рівняння регресії: y={k}x+{b}\n";

            MessageBox.Show(res, "Результат");

        }
        private double sqr(double a)
        {
            return a * a;
        }

        private void TasksForm2_Load(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            var Dict = DictY_s();
            var form = new FunctionForm(Dict, new[] { "x", "y_xi" }, "3");
            form.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var res = DictX_s();
            var form = new DataGridForm1(res,new[] { "y", "x_yi" });
            form.Show();
        }
        private SortedDictionary<double,double> DictX_s()
        {
            SortedDictionary<double, double> dict = new SortedDictionary<double, double>();
            for (int i = 1; i < arr.GetLength(1); i++)
            {
                double sum = 0;
                double n = 0;
                for (int j = 1; j < arr.GetLength(0); j++)
                {
                    sum += arr[j, i] * arr[j, 0];
                    n += arr[j, i];
                }
                dict[arr[0, i]] = sum / n;
            }
            return dict;
        }
        private SortedDictionary<double,double> DictY_s()
        {
            SortedDictionary<double, double> dict = new SortedDictionary<double, double>();
            for (int i = 1; i < arr.GetLength(1); i++)
            {
                double sum = 0;
                double n = 0;
                for (int j = 1; j < arr.GetLength(0); j++)
                {
                    sum += arr[i, j] * arr[0, j];
                    n += arr[i, j];
                }
                dict[arr[i, 0]] = sum / n;
            }
            return dict;
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            var res = DictY_s();
            var form = new DataGridForm1(res, new[] { "x", "y_xi" });
            form.Show();
        }
    }
}
