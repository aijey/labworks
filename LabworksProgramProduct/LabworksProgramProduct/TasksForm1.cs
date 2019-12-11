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
    public partial class TasksForm1 : Form
    {
        private SortedDictionary<double, double> Dict;
        public TasksForm1()
        {
            InitializeComponent();
        }
        public TasksForm1(SortedDictionary<double,double> Dict)
        {
            InitializeComponent();
            label1.Font = new Font("Microsoft Sans Serif", 24);
            this.Dict = Dict;
        }

        private void TasksForm1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string res = "";
            foreach(var i in Dict)
            {
                double cnt = i.Value;
                while (cnt>0)
                {
                    cnt--;
                    res += i.Key + " ";
                }
            }
            MessageBox.Show(res, "Варіаційний ряд");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var dataGridForm = new DataGridForm1(Dict,new[] { "x", "n" });
            dataGridForm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var tmpDict = new SortedDictionary<double, double>();
            var N = Dict.Sum(x => x.Value);
            foreach(var i in Dict)
            {
                tmpDict[i.Key] = (double)i.Value / N;
            }
            var dataGridForm = new DataGridForm1(tmpDict, new[] { "x", "w" });
            dataGridForm.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var tmpDict = new SortedDictionary<double, double>();
            double sum = 0;
            foreach (var i in Dict)
            {
                tmpDict[i.Key] = sum;
                sum += i.Value;
            }
            tmpDict[1e9] = sum;
            var dataGridForm = new DataGridForm1(tmpDict, new[] { "x", "n_i^нак" });
            dataGridForm.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var tmpDict = new SortedDictionary<double, double>();
            var N = Dict.Sum(x => x.Value);
            double sum = 0;
            foreach (var i in Dict)
            {
                tmpDict[i.Key] = sum;
                sum += i.Value/N;
            }
            tmpDict[1e9] = sum;
            var dataGridForm = new DataGridForm1(tmpDict, new[] { "x", "w_i^нак" });
            dataGridForm.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var chartForm = new ChartForm1(Dict, new[] { "x", "n" });
            chartForm.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            var tmpDict = new SortedDictionary<double, double>();
            var N = Dict.Sum(x => x.Value);
            foreach (var i in Dict)
            {
                tmpDict[i.Key] = (double)i.Value / N;
            }
            var chartForm = new ChartForm1(tmpDict, new[] { "x", "w" });
            chartForm.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            double mxN = Dict.Max(x => x.Value);
            var Mo = from d in Dict
                     where d.Value == mxN
                     select d.Key;
            double Me;
            int sum = 0;
            double N = Dict.Sum(x => x.Value);
            if (N % 2 == 0)
            {
                Me = (GetKey(N / 2) + GetKey((int)N / 2 + 1)) / 2;
            }
            else
            {
                Me = GetKey((int)N / 2 + 1);
            }
            string res = "Mo: [ " + string.Join(", ", Mo.ToArray()) + " ]" + "\n\n";
            res += "Me: " + Me;
            MessageBox.Show(res,"Результат");
        }
        private double GetKey(double k )
        {
            var tmpDict = new SortedDictionary<double, double>();
            double sum = 0;
            foreach (var i in Dict)
            {
                tmpDict[i.Key] = sum;
                if (sum + i.Value >= k)
                {
                    return i.Key;
                }
                sum += i.Value;
                
            }
            return -1;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            var tmpDict = new SortedDictionary<double, double>();
            var N = Dict.Sum(x => x.Value);
            double sum = 0;
            double last = 0;
            foreach (var i in Dict)
            {
                
                tmpDict[i.Key] = sum;
                sum += i.Value / N;
                last = i.Key;
            }
            tmpDict[last+10] = sum;
            var form = new FunctionForm(tmpDict,new[] { "x", "F*(x)" }, "1");
            form.Show();
        }

        private void Button10_Click(object sender, EventArgs e) // INTERVAL COUNT
        {
            try
            {
                var intDict = MakeIntervalDict();
                var form = new DataGridForm2(intDict, new[] { "I", "n" });
                form.Show();
            }
            catch
            {
                return;
            }

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            try
            {
                var intDict = MakeIntervalDict();
                var keys = intDict.Keys.ToList();
                foreach (var i in keys)
                {
                    intDict[i] /= 4;
                }
                var form = new HistogramForm1(intDict, new[] { "I (номер інтервалу)", "n/4" });
                form.Show();
            }
            catch
            {
                return;
            }
           
        }
        private SortedDictionary<Interval,double> MakeIntervalDict()
        {
            int m;
            double h;
            try
            {
                m = int.Parse(TextBoxIntervalCount.Text);
                h = (Dict.Max(x => x.Key) - Dict.Min(x => x.Key)) / m;
            }
            catch
            {
                MessageBox.Show("Число кількості інтервалів задано невірно", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new InvalidExpressionException();
            }
            SortedDictionary<Interval, double> intDict = new SortedDictionary<Interval, double>();
            Interval[] intervals = new Interval[m];
            intervals[0] = new Interval();
            intervals[0].LeftBound = Dict.Min(x => x.Key);
            intervals[0].IsIncludedLeftBound = true;
            intervals[0].RightBound = intervals[0].LeftBound + h;
            intervals[0].IsIncludedRightBound = true;
            intDict[intervals[0]] = 0;
            for (int i = 1; i < m; i++)
            {
                intervals[i] = new Interval();
                intervals[i].LeftBound = intervals[i - 1].RightBound;
                intervals[i].IsIncludedLeftBound = false;
                intervals[i].RightBound = intervals[i].LeftBound + h;
                intervals[i].IsIncludedRightBound = true;
                intDict[intervals[i]] = 0;
            }
            foreach (var i in Dict)
            {
                foreach (var j in intervals)
                {
                    if (j.IsIncludedInInterval(i.Key))
                    {

                        intDict[j] += i.Value;

                    }
                }
            }
            return intDict;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            try
            {
                var intDict = MakeIntervalDict();
                var keys = intDict.Keys.ToList();
                double n = intDict.Sum(x => x.Value);
                foreach(var i in keys)
                {
                    intDict[i] /= 4 * n;
                }
                var form = new HistogramForm1(intDict, new[] { "I (номер інтервалу)", "w/4" });
                form.Show();
            }
            catch
            {
                return;
            }
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            try
            {
                var intDict = MakeIntervalDict();
                var tmpDict = FindEmpiricFunction(intDict);
                var form = new FunctionForm(tmpDict, new[] { "I", "F*(x)" }, "2");
                form.Show();
            }
            catch
            {
                return;
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            try
            {
                List<double> Mo = new List<double>();
                double Me;
                var intDict = MakeIntervalDict();
                var tmpDict = FindEmpiricFunction(intDict);
                double x1=0,x2=0;
                double prevKey = 0;
                foreach(var i in tmpDict)
                {
                    if (i.Value >= 0.5)
                    {
                        x1 = prevKey;
                        x2 = i.Key;
                        break;
                    }
                    prevKey = i.Key;
                }
                double Fxp = tmpDict[x1];
                double Fx = tmpDict[x2];
                double m = int.Parse(TextBoxIntervalCount.Text);
                double h = (Dict.Max(x => x.Key) - Dict.Min(x => x.Key)) / m;
                Me = x1 + h * ((0.5 - Fxp) / (Fx - Fxp));
                string res = "";
                res += $"Медіана: {Me}\n";

                var q = from i in intDict
                        where (i.Value == intDict.Values.Max())
                        select i.Key;

                foreach(var i in q)
                {
                    double Nmo = intDict[i];
                    double l = i.LeftBound - h;
                    double r = i.LeftBound;
                    var interv = new Interval(l, false, r, true);
                    double Nmo1 = intDict.ContainsKey(interv) ? intDict[interv] : 0;
                    l = i.RightBound;
                    r = i.RightBound + h;
                    interv = new Interval(l, false, r, true);
                    double Nmo2 = intDict.ContainsKey(interv) ? intDict[interv] : 0;
                    Mo.Add(i.LeftBound + h*(Nmo-Nmo1)/(2*Nmo-Nmo1-Nmo2));
                }
                res += "Мода: [ " + string.Join(", ", Mo) + " ]\n";
                MessageBox.Show(res, "Результат");
            }
            catch
            {
                return;
            }


        }
        private SortedDictionary<double,double> FindEmpiricFunction(SortedDictionary<Interval,double> intDict)
        {
            SortedDictionary<double, double> tmpDict = new SortedDictionary<double, double>();
            double sum = 0;
            tmpDict[intDict.Keys.ToList()[0].LeftBound] = 0;
            double n = intDict.Sum(x => x.Value);
            foreach (var i in intDict)
            {
                sum += (i.Value / n);
                tmpDict[i.Key.RightBound] = sum;
            }
            return tmpDict;
        }

        // LABWORK 3
        private void Button15_Click(object sender, EventArgs e)
        {
            try
            {
                int k = int.Parse(TextBoxKValue.Text);
                string res = "";
                double n = Dict.Sum(x => x.Value);
                double avg = Dict.Sum(x => (x.Key * x.Value)) / n;
                res += $"Вибіркове середнє: {avg}\n";
                double d1 = Dict.Sum(x => x.Value * sqr(x.Key - avg)) / n;
                double g1 = Math.Sqrt(d1);

                res += $"Дисперсія: {d1}\n";
                res += $"Cереднє квадратичне відхилення: {g1}\n";

                double d2 = d1 * n / (n - 1);
                double g2 = Math.Sqrt(d2);

                res += $"Виправлена дисперсія: {d2}\n";
                res += $"Виправлене середнє квадратичне відхилення: {g2}\n";

                res += $"Емпіричний початковий момент порядку {k}: {pBegin(k)}\n";
                res += $"Емпіричний центральний момент порядку {k}: {pEnd(k)}\n";

                res += $"Асиметрія: {pEnd(3) / Math.Pow(g1, 3)}\n";
                res += $"Ексцес: {pEnd(4) / Math.Pow(g1, 4) - 3}\n";

                res += $"Розмах: {Dict.Max(x => x.Key) - Dict.Min(x => x.Key)}\n";
                res += $"Коефіцієнт варіацій: {g1/avg *100}%\n";

                MessageBox.Show(res,"Результат");
            }
            catch
            {
                MessageBox.Show("Число k задано невірно", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private double pBegin(int k)
        {
            double n = Dict.Sum(x => x.Value);
            return Dict.Sum(x => x.Value * Math.Pow(x.Key, k)) / n;
        }
        private double pEnd(int k)
        {
            double n = Dict.Sum(x => x.Value);
            double avg = Dict.Sum(x => (x.Key * x.Value)) / n;
            return Dict.Sum(x => x.Value * Math.Pow((x.Key - avg),k)) / n;
        }
        private double sqr(double a)
        {
            return a * a;
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.Title = "Оберіть вхідний файл";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog1.FileName;
                var form = new AskingForm2(Dict,filepath);
                form.Show();
            }
            
        }
    }
    public class Interval : IComparable
    {
        public double LeftBound;
        public double RightBound;
        public bool IsIncludedLeftBound, IsIncludedRightBound;
        public Interval()
        {

        }
        public Interval(double LeftBound, bool IsIncludedLeftBound, double RightBound, bool IsIncludedRightBound)
        {
            this.LeftBound = LeftBound;
            this.RightBound = RightBound;
            this.IsIncludedLeftBound = IsIncludedLeftBound;
            this.IsIncludedRightBound = IsIncludedRightBound;
        }
        public bool IsIncludedInInterval(double el)
        {
            if (IsIncludedLeftBound && el >= LeftBound)
            {
                if (IsIncludedRightBound && el <= RightBound)
                {
                    return true;
                } else
                {
                    if (!IsIncludedRightBound && el < RightBound)
                    {
                        return true;
                    }
                }
            } else
            {
                if (!IsIncludedLeftBound && el > LeftBound)
                {
                    if (IsIncludedRightBound && el <= RightBound)
                    {
                        return true;
                    }
                    else
                    {
                        if (!IsIncludedRightBound && el < RightBound)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            var obj1 = obj as Interval;
            if (obj1 == null)
            {
                return 1;
            }
            if (this < obj1)
            {
                return -1;
            } 
            if (this > obj1)
            {
                return 1;
            }
            return 0;
        }

        public static bool operator < (Interval a, Interval b)
        {
            return a.LeftBound < b.LeftBound;
        }
        public static bool operator > (Interval a, Interval b)
        {
            return b.LeftBound < a.LeftBound;
        }
        public override string ToString()
        {
            string res = "";
            if (IsIncludedLeftBound)
            {
                res += "[ ";
            } else
            {
                res += "( ";
            }
            res += LeftBound + "; ";
            res += RightBound + " ";
            if (IsIncludedRightBound)
            {
                res += "]";
            } else
            {
                res += ")";
            }
            return res;
        }
    }
}
