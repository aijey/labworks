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
    public partial class AskingFormDataSource : Form
    {
        private string Type;
        public AskingFormDataSource(string Type)
        {
            this.Type = Type;
            InitializeComponent();
            dataGridView1.RowCount = 1;
            dataGridView1.Rows[0].HeaderCell.Value = "Xi";
            dataGridView1.RowHeadersWidth = 50;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                return;
            }
            label4.Text = "Введіть к-сть чисел:";
            dataGridView1.RowCount = 1;
            dataGridView1.Rows[0].HeaderCell.Value = "Xi";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
            {
                return;
            }
            label4.Text = "Введіть к-сть комірок: ";
            dataGridView1.RowCount = 2;
            dataGridView1.Rows[0].HeaderCell.Value = "Xi";
            dataGridView1.Rows[1].HeaderCell.Value = "Ni";
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
        {
            var Dict = new SortedDictionary<double, double>();
            for (int i=0; i<dataGridView1.ColumnCount; i++)
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
                    MessageBox.Show($"Помилка в зчитуванні {i+1} колонки. Перевірьте правильність даних.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                } else
                {
                    type = 2;
                }
                if (ReadFile(file, type,out Dict))
                {
                    ShowResult(Dict);
                }
            }

        }
        private void ShowResult(SortedDictionary<double,double> Dict)
        {
            if (Type == "Варіаційний ряд")
            {
                var res = Tasks.BuildVariantRow(Dict);
                var form = new OutputForm(res, "Варіаційний ряд");
                form.Show();
            }
            if (Type == "Статистичний розподіл")
            {
                var form = new OutputForm(Dict, Type);
                form.Show();
            }
            if (Type == "Статистичний розподіл відносних частот")
            {
                var res = Tasks.BuildRelDistr(Dict);
                var form = new OutputForm(res, "Статистичний розподіл");
                form.Show();
            }
            if (Type == "Статистичний розподіл накопичуваних частот")
            {
                var res = Tasks.BuildIncDistr(Dict);
                var form = new OutputForm(res, "Статистичний розподіл");
                form.Show();
            }
            if (Type == "Статистичний розподіл відносних накопичуваних частот")
            {
                var res = Tasks.BuildIncRelDistr(Dict);
                var form = new OutputForm(res, "Статистичний розподіл");
                form.Show();
            }
            if (Type == "Полігон частот")
            {
                var chartForm = new ChartForm1(Dict, new[] { "x", "n" });
                chartForm.Show();
            }
            if (Type == "Полігон відносних частот")
            {
                var res = Tasks.BuildRelDistr(Dict);
                var chartForm = new ChartForm1(res, new[] { "x", "w" });
                chartForm.Show();
            }
            if (Type == "Емпірична функція розподілу")
            {
                var res = Tasks.GetEmpFunction(Dict);
                var form = new FunctionForm(res, new[] { "x", "F*(x)" }, "1");
                form.Show();
            }
            if (Type == "Мода та медіана")
            {
                var res = Tasks.GetModAndMed(Dict);
                MessageBox.Show(res, Type);
            }
            Close();
        }
        private bool ReadFile(string fileName, int type, out SortedDictionary<double,double> Dict)
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
    }
}
