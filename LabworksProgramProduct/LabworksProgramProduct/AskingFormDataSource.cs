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
        private AskingForms Type;
        private Forms NextForm;
        
        public AskingFormDataSource(AskingForms Type, Forms nextForm)
        {
            NextForm = nextForm;
            if (Type == AskingForms.VariantRowFromFile || Type == AskingForms.StatisticDistrFromFile || Type == AskingForms.IntervalDistrFromFile)
            {
                InitializeComponent();
                openFileDialog1.Filter = "txt files (*.txt)|*.txt";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.Title = "Оберіть вхідний файл";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (Type == AskingForms.IntervalDistrFromFile)
                    {
                        var Dict = new SortedDictionary<Interval, double>();
                        if (ReadIntervalFile(openFileDialog1.FileName, Type, out Dict))
                        {
                            if (nextForm == Forms.IntervalTasksForm)
                            {
                                var form = new IntervalTasksForm(Dict);
                                form.Show();
                            }
                        }
                    }
                    else
                    {
                        var Dict = new SortedDictionary<double, double>();
                        if (ReadFile(openFileDialog1.FileName, Type, out Dict))
                        {
                            if (nextForm == Forms.StaticTasksForm)
                            {
                                var form = new StaticTasksForm(Dict);
                                form.Show();
                            }
                            else if (nextForm == Forms.GraphicsTasksForm)
                            {
                                var form = new GraphicsTasksForm(Dict);
                                form.Show();
                            }
                            else if (nextForm == Forms.SelectNumberOfIntervalsForm)
                            {
                                var form = new SelectNumberOfIntervalsForm(Dict);
                                form.Show();
                            }
                            else if (nextForm == Forms.NumCharTasksForm)
                            {
                                var form = new NumCharTasksForm(Dict);
                                form.Show();
                            }
                            else
                            {
                                throw new InvalidDataException();
                            }
                        }
                    }
                }
                Close();
                return;
            }
            this.Type = Type;
            InitializeComponent();
            dataGridView1.RowCount = 1;
            dataGridView1.Rows[0].HeaderCell.Value = "Xi";
            dataGridView1.RowHeadersWidth = 50;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (AskingForms.VariantRow == Type)
            {
                label1.Text = "";
                label4.Text = "Введіть к-сть чисел:";
                dataGridView1.RowCount = 1;
                dataGridView1.Rows[0].HeaderCell.Value = "Xi";
            } 
            else if (Type == AskingForms.StatisticDistr)
            {
                label1.Text = "";
                label4.Text = "Введіть к-сть комірок: ";
                dataGridView1.RowCount = 2;
                dataGridView1.Rows[0].HeaderCell.Value = "Xi";
                dataGridView1.Rows[1].HeaderCell.Value = "Ni";
            }
            else if (Type == AskingForms.IntervalDistr)
            {
                label4.Text = "Введіть к-сть інтервалів: ";
                dataGridView1.RowCount = 2;
                dataGridView1.Rows[0].HeaderCell.Value = "I";
                dataGridView1.Rows[1].HeaderCell.Value = "Ni";
            }
            else
            {
                throw new InvalidDataException();
            }
        }

        private static bool ReadIntervalFile(string fileName, AskingForms type, out SortedDictionary<Interval, double> dict)
        {
            dict = new SortedDictionary<Interval, double>();
            using (var reader = new StreamReader(fileName))
            {
                int num = 0;
                while (!reader.EndOfStream)
                {
                    num++;
                    try
                    {
                        string line = reader.ReadLine();
                        string[] words = line.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Interval inter = new Interval();
                        inter.IsIncludedLeftBound = words[0][0] == '[';
                        inter.IsIncludedRightBound = words[1][words[1].Length - 1] == ']';
                        inter.LeftBound = double.Parse(words[0].Substring(1, words[0].Length - 2), CultureInfo.InvariantCulture);
                        inter.RightBound = double.Parse(words[1].Substring(0, words[1].Length - 1), CultureInfo.InvariantCulture);
                        double Value = (double)int.Parse(words[2]);
                        if (inter.LeftBound > inter.RightBound)
                        {
                            throw new IOException("L > R");
                        }
                        dict[inter] = Value;
                    }
                    catch
                    {
                        MessageBox.Show($"Не вдалося обробити вхідний файл. Помилка в зчитуванні {num} рядка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            var Dict = new SortedDictionary<double, double>();
            double prevR = 0;
            var IntDict = new SortedDictionary<Interval, double>();
            for (int i=0; i<dataGridView1.ColumnCount; i++)
            {
                try
                {
                    if (Type == AskingForms.VariantRow)
                    {
                        double val = double.Parse(dataGridView1[i, 0].Value.ToString(), CultureInfo.InvariantCulture);
                        if (!Dict.ContainsKey(val))
                        {
                            Dict[val] = 0;
                        }
                        Dict[val]++;
                    }
                    else if (Type == AskingForms.StatisticDistr)
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
                    else if (Type == AskingForms.IntervalDistr)
                    {
                        string st = dataGridView1[i, 0].Value.ToString();
                        var strs = st.Split(',');
                        double l = double.Parse(strs[0].Substring(1), CultureInfo.InvariantCulture);
                        double r = double.Parse(strs[1].Substring(1, strs[1].Length - 2), CultureInfo.InvariantCulture);
                        
                        if (i > 0)
                        {
                          
                            if (prevR != l)
                            {
                                throw new InvalidDataException("prevR is not Equal current L");
                            }
                        }
                        Interval intr = new Interval(l, (strs[0][0] == '['), r, (strs[1][strs[1].Length - 1] == ']'));
                        double n2 = (double)int.Parse(dataGridView1[i, 1].Value.ToString());
                        IntDict[intr] = n2;
                        prevR = r;
                    }
                }
                catch
                {
                    MessageBox.Show($"Помилка в зчитуванні {i+1} колонки. Перевірьте правильність даних.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (NextForm == Forms.StaticTasksForm)
            {
                var form = new StaticTasksForm(Dict);
                form.Show();
                this.Close();
            } else if (NextForm == Forms.GraphicsTasksForm)
            {
                if (Type == AskingForms.IntervalDistr)
                {
                    var form = new GraphicsTasksForm(IntDict);
                    form.Show();
                    Close();
                }
                else
                {
                    var form = new GraphicsTasksForm(Dict);
                    form.Show();
                    this.Close();
                }
            } else if (NextForm == Forms.SelectNumberOfIntervalsForm)
            {
                var form = new SelectNumberOfIntervalsForm(Dict);
                form.Show();
                this.Close();
            } else if (NextForm == Forms.IntervalTasksForm)
            {
                var form = new IntervalTasksForm(IntDict);
                form.Show();
                this.Close();
            } else if (NextForm == Forms.NumCharTasksForm)
            {
                var form = new NumCharTasksForm(Dict);
                form.Show();
                this.Close();
            }
            else
            {
                throw new InvalidDataException();
            }
            
        }

        private bool ReadFile(string fileName, AskingForms type, out SortedDictionary<double,double> Dict)
        {
            Dict = new SortedDictionary<double, double>();
            if (type == AskingForms.VariantRowFromFile) // VariantRow
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
            else if (type == AskingForms.StatisticDistrFromFile) // StaticDistr
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
            } else
            {
                throw new InvalidDataException();
            }
            return true;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(textBox1.Text);
                if (n > 0)
                { 
                    dataGridView1.ColumnCount = n;
                } else
                {
                    dataGridView1.ColumnCount = 1;
                }
                if (Type == AskingForms.IntervalDistr)
                {
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dataGridView1.Columns[i].MinimumWidth = 50;
                        dataGridView1.Rows[0].Cells[i].Value = "[a, b)";
                    }
                    dataGridView1.AutoResizeColumns();
                }
            }
            catch
            {
                dataGridView1.ColumnCount = 1;
            }
        }
    }
}
