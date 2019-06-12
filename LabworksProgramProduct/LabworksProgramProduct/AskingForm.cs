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
    public partial class AskingForm : Form
    {
        private SortedDictionary<double, double> Dict = new SortedDictionary<double, double>();
        private string InputFileName;
        public AskingForm()
        {
            InitializeComponent();
        }
        public AskingForm(string FileName)
        {
            InitializeComponent();
            InputFileName = FileName;
        }

        private void AskingForm_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (ReadFile(InputFileName, 1))
            {

                var tasksForm = new TasksForm1(Dict);
                tasksForm.Show();
                this.Close();
            }
        }

        private bool ReadFile(string fileName, int type)
        {
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
                    for(var i = 0; i < words.Length; i++)
                    {
                        try
                        {
                            tmp[i] = double.Parse(words[i], CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            MessageBox.Show("Не вдалося обробити вхідний файл. Помилка в переведенні " + words[i],"Помилка!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    for(var i = 0; i < tmp.Length; i++)
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
                            Dict.Add(double.Parse(words[0],CultureInfo.InvariantCulture),(double)int.Parse(words[1]));
                        }
                        catch
                        {
                            MessageBox.Show("Не вдалося обробити вхідний файл. Помилка в переведенні рядка " +  $"[ {line} ]", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
               
                }
            }
            return true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (ReadFile(InputFileName, 2))
            { 
                var tasksForm = new TasksForm1(Dict);
                tasksForm.Show();
                this.Close();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int n, m = 0;
            double[,] arr = new double[0, 0];
            using (var reader = new StreamReader(InputFileName))
            {
                List<string> lst = new List<string>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lst.Add(line);
                }
                int cnt = 0;
                n = lst.Count;
                foreach(var line in lst)
                {
                    try
                    {
                        cnt++;
                        var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (cnt == 1)
                        {
                            if (words[0] != "0")
                            {
                                MessageBox.Show("Перше число в першому рядку повинне бути 0. Читайте уважно інструкцію!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            m = words.Length;
                            arr = new double[n, m];
                        }
                        if (words.Length != m)
                        {
                            MessageBox.Show($"Кількість чисел в {cnt} рядку не співпадає з кількістю чисел в першому рядку.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            int pos = 0;
                            foreach (var i in words)
                            {
                                double num = double.Parse(i, CultureInfo.InvariantCulture);
                                arr[cnt - 1, pos++] = num;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show($"Помилка в зчитуванні {cnt} рядка.", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            var form = new TasksForm2(arr);
            form.Show();
            this.Close();
        }
    }
}
