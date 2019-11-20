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
        private int Type;
        private Forms NextForm;
        
        public AskingFormDataSource(int Type, Forms nextForm)
        {
            NextForm = nextForm;
            if (Type == 3 || Type == 4)
            {
                InitializeComponent();
                openFileDialog1.Filter = "txt files (*.txt)|*.txt";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.Title = "Оберіть вхідний файл";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var Dict = new SortedDictionary<double, double>();
                    if (ReadFile(openFileDialog1.FileName, Type - 2, out Dict)){
                        var form = new StaticTasksForm(Dict);
                        form.Show();
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
            if (Type == 1)
            {
                label4.Text = "Введіть к-сть чисел:";
                dataGridView1.RowCount = 1;
                dataGridView1.Rows[0].HeaderCell.Value = "Xi";
            } 
            else if (Type == 2)
            {
                label4.Text = "Введіть к-сть комірок: ";
                dataGridView1.RowCount = 2;
                dataGridView1.Rows[0].HeaderCell.Value = "Xi";
                dataGridView1.Rows[1].HeaderCell.Value = "Ni";
            }
            else
            {
                throw new NotImplementedException();
            }
        }

       
        private void Button1_Click(object sender, EventArgs e)
        {
            
            var Dict = new SortedDictionary<double, double>();
            for (int i=0; i<dataGridView1.ColumnCount; i++)
            {
                try
                {
                    if (Type == 1)
                    {
                        double val = double.Parse(dataGridView1[i, 0].Value.ToString(), CultureInfo.InvariantCulture);
                        if (!Dict.ContainsKey(val))
                        {
                            Dict[val] = 0;
                        }
                        Dict[val]++;
                    }
                    else if (Type == 2)
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
            if (NextForm == Forms.StaticTasksForm)
            {
                var form = new StaticTasksForm(Dict);
                form.Show();
                this.Close();
            } else if (NextForm == Forms.GraphicsTasksForm)
            {
                var form = new GraphicsTasksForm(Dict);
                form.Show();
                this.Close();
            }
            
        }

        private bool ReadFile(string fileName, int type, out SortedDictionary<double,double> Dict)
        {
            Dict = new SortedDictionary<double, double>();
            if (type == 1) // VariantRow
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
            if (type == 2) // StaticDistr
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
            }
            catch
            {
                dataGridView1.ColumnCount = 1;
            }
        }
    }
}
