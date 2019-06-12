using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabworksProgramProduct
{
    public partial class AskingForm2 : Form
    {
        private SortedDictionary<double, double> Dict1;
        private SortedDictionary<double, double> Dict2;
        private string filepath;
        public AskingForm2(SortedDictionary<double,double> Dict, string filepath)
        {
            this.filepath = filepath;
            this.Dict1 = Dict;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Dict2 = new SortedDictionary<double, double>();
            using(var reader = new StreamReader(filepath))
            {
                try
                {
                    var fileData = reader.ReadToEnd().Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach(var i in fileData)
                    {
                        if (!Dict2.ContainsKey(double.Parse(i, CultureInfo.InvariantCulture)))
                        {
                            Dict2[double.Parse(i, CultureInfo.InvariantCulture)] = 1;
                        } else
                        {
                            Dict2[double.Parse(i, CultureInfo.InvariantCulture)]++;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Помилка в зчитуванні файлу. Перевірте правильність задання даних", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }      
            }
            Solve();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Dict2 = new SortedDictionary<double, double>();
            using (var reader = new StreamReader(filepath))
            {
                int cnt = 0;
                while (!reader.EndOfStream)
                {
                    cnt++;
                    var line = reader.ReadLine().Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        Dict2[double.Parse(line[0], CultureInfo.InvariantCulture)] = double.Parse(line[1], CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        MessageBox.Show($"Помилка в зчитуванні {cnt} рядка файлу. Перевірте правильність задання даних", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Solve();
        }
        private void Solve()
        {
            string res = "";

            double n1 = Dict1.Sum(x => x.Value);
            double n2 = Dict2.Sum(x => x.Value);

            double avg1 = Dict1.Sum(x => x.Value * x.Key) / n1;
            double avg2 = Dict2.Sum(x => x.Value * x.Key) / n2;
            double avg = (avg1*n1 + avg2*n2) / (n1 + n2);

            res += $"Групове середнє: {avg}\n";

            double d1 = Dict1.Sum(x => x.Value * sqr(x.Key - avg1)) / n1;
            double d2 = Dict2.Sum(x => x.Value * sqr(x.Key - avg2)) / n2;

            res += $"Дисперсія першої групи: {d1}\n";
            res += $"Дисперсія другої групи: {d2}\n";

            double di = (n1 * d1 + n2 * d2) / (n1 + n2);

            res += $"Внутрішньогрупова дисперсія: {di}\n";

            double db = (n1 * sqr(avg1 - avg) + n2 * sqr(avg2 - avg)) / (n1 + n2);

            res += $"Міжгрупова дисперсія: {db}\n";

            double dt = di + db;

            res += $"Загальна дисперсія: {dt}\n";

            MessageBox.Show(res, "Результат");
            this.Close();

        }
        private double sqr(double a)
        {
            return a * a;
        }
    }
}
