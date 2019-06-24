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
using System.Globalization;

namespace LabworksProgramProduct
{
    public partial class AskingFormDataSource2 : Form
    {
        private string Type;
        public AskingFormDataSource2(string Type)
        {
            this.Type = Type;
            InitializeComponent();
            dataGridView1.RowCount = 1;
            dataGridView1.Rows[0].HeaderCell.Value = "Xi";
            dataGridView1.RowHeadersWidth = 50;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (Type == "Числові характеристики")
            {
                label5.Text = "Введіть порядок емпіричного моменту";
                label4.Text = "k =";
            }
        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                return;
            }
            label6.Text = "Введіть к-сть чисел:";
            dataGridView1.RowCount = 1;
            dataGridView1.Rows[0].HeaderCell.Value = "Xi";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
            {
                return;
            }
            label6.Text = "Введіть к-сть комірок: ";
            dataGridView1.RowCount = 2;
            dataGridView1.Rows[0].HeaderCell.Value = "Xi";
            dataGridView1.Rows[1].HeaderCell.Value = "Ni";
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(textBox1.Text);
                if (n > 0)
                {
                    dataGridView1.ColumnCount = n;
                }
            }
            catch
            {
                dataGridView1.ColumnCount = 1;
            }
        }
        private bool ReadFile(string fileName, int type, out SortedDictionary<double, double> Dict)
        {
            Dict = new SortedDictionary<double, double>();
            if (type == 1)
            {
                using (var reader = new StreamReader(fileName))
                {
                    string wholeFile = "";
                    while (!reader.EndOfStream)
                    {

                        wholeFile += reader.ReadLine() + " ";
                    }
                    var words = wholeFile.Split(new[] { '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var tmp = new double[words.Length];
                    for (var i = 0; i < words.Length; i++)
                    {
                        try
                        {
                            tmp[i] = double.Parse(words[i], CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            MessageBox.Show("Не вдалося обробити вхідний файл. Помилка в переведенні " + words[i], "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    for (var i = 0; i < tmp.Length; i++)
                    {
                        if (!Dict.ContainsKey(tmp[i]))
                        {
                            Dict[tmp[i]] = 0;
                        }
                        Dict[tmp[i]]++;
                    }
                }
            }
            if (type == 2)
            {
                using (var reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] words = line.Split(' ');
                        try
                        {
                            if (words.Length != 2)
                            {
                                throw new IOException();
                            }
                            Dict.Add(double.Parse(words[0], CultureInfo.InvariantCulture), (double)int.Parse(words[1]));
                        }
                        catch
                        {
                            MessageBox.Show("Не вдалося обробити вхідний файл. Помилка в переведенні рядка " + $"[ {line} ]", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }

                }
            }
            return true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var Dict = new SortedDictionary<double, double>();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                try
                {
                    if (radioButton1.Checked)
                    {
                        double val = double.Parse(dataGridView1[i, 0].Value.ToString(), CultureInfo.InvariantCulture);
                        if (!Dict.ContainsKey(val))
                        {
                            Dict[val] = 0;
                        }
                        Dict[val]++;
                    }
                    else
                    {
                        double val = double.Parse(dataGridView1[i, 0].Value.ToString(), CultureInfo.InvariantCulture);
                        double n2 = (double)int.Parse(dataGridView1[i, 1].Value.ToString());
                        if (Dict.ContainsKey(val))
                        {
                            MessageBox.Show("Помилка в зчитуванні. Числа в першому рядку не повинні повторюватися!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        Dict[val] = n2;
                    }
                }
                catch
                {
                    MessageBox.Show($"Помилка в зчитуванні {i + 1} колонки. Перевірьте правильність даних.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            ShowResult(Dict);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string file = "";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.Title = "Оберіть вхідний файл";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                SortedDictionary<double, double> Dict;
                int type = 0;
                if (radioButton1.Checked)
                {
                    type = 1;
                }
                else
                {
                    type = 2;
                }
                if (ReadFile(file, type, out Dict))
                {
                    ShowResult(Dict);
                }
            }

        }

        private void ShowResult(SortedDictionary<double, double> Dict)
        {
            if (Type == "Інтервальний розподіл")
            {
                int m = 0;
                try
                {
                    m = int.Parse(textBox1.Text);
                    if (m == 0)
                    {
                        throw new IOException();
                    }
                }
                catch
                {
                    MessageBox.Show($"Число m задано неправильно.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var res = Tasks.BuildIntervalDistr(Dict, m);
                var form = new OutputForm(res, "Інтервальний розподіл");
                form.Show();
            }
            if (Type == "Гістограма частот")
            {
                int m = 0;
                try
                {
                    m = int.Parse(textBox1.Text);
                    if (m == 0)
                    {
                        throw new IOException();
                    }
                }
                catch
                {
                    MessageBox.Show($"Число m задано неправильно.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var res = Tasks.BuildIntervalDistr(Dict, m);
                var form = new HistogramForm1(res, new[] { "I (номер інтервалу)", "n/4" });
                form.Show();
            }
            if (Type == "Гістограма відносних частот")
            {
                int m = 0;
                try
                {
                    m = int.Parse(textBox1.Text);
                    if (m == 0)
                    {
                        throw new IOException();
                    }
                }
                catch
                {
                    MessageBox.Show($"Число m задано неправильно.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var res = Tasks.BuildIntervalRelDistr(Dict, m);
                var form = new HistogramForm1(res, new[] { "I (номер інтервалу)", "w/4" });
                form.Show();
            }
            if (Type == "Числові характеристики")
            {
                try
                {
                    int k = int.Parse(textBox1.Text);
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

                    res += $"Емпіричний початковий момент порядку {k}: {Tasks.pBegin(Dict, k)}\n";
                    res += $"Емпіричний центральний момент порядку {k}: {Tasks.pEnd(Dict, k)}\n";

                    res += $"Асиметрія: {Tasks.pEnd(Dict,3) / Math.Pow(g1, 3)}\n";
                    res += $"Ексцес: {Tasks.pEnd(Dict,4) / Math.Pow(g1, 4) - 3}\n";

                    res += $"Розмах: {Dict.Max(x => x.Key) - Dict.Min(x => x.Key)}\n";
                    res += $"Коефіцієнт варіацій: {g1 / avg * 100}%\n";

                    MessageBox.Show(res, "Результат");
                }
                catch
                {
                    MessageBox.Show("Число k задано невірно", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Close();
        }
        
        double sqr(double a)
        {
            return a * a;
        }
    }
}
