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
    public partial class AskingFormPairs : Form
    {
        SortedSet<double> Xs;
        SortedSet<double> Ys;
        List<(double, double)> Pairs;
        List<double> SortedXs;
        List<double> SortedYs;
        AskingForms Type;
        public AskingFormPairs(AskingForms Type, Forms nextForm)
        {
            this.Type = Type;

            if (Type == AskingForms.MatrixFromFile)
            {
                InitializeComponent();
                var fileName = getFileName();
                if (fileName != null) {
                    var matrix = readFromFile(fileName);
                    if (matrix != null)
                    {
                        showNextForm(matrix);
                    }
                }
                this.Close();
            }

            InitializeComponent();

            if (Type == AskingForms.Pairs)
            {
                dataGridView1.ColumnCount = 2;
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].HeaderCell.Value = "Xi";
                dataGridView1.Columns[1].HeaderCell.Value = "Yi";
                dataGridView1.RowCount = 1;
            } else if (Type == AskingForms.Matrix)
            {
                label4.Text = "Введіть к-сть стовпчиків: ";

                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.AllowUserToOrderColumns = true;
                dataGridView1.ColumnCount = 1;
                dataGridView1.RowCount = 2;
                dataGridView1[0, 0].Value = "X \\ Y";
            }
        }


        private int find(List<double> ls, double x)
        {
            int l = 0, r = ls.Count;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (ls[m] < x)
                {
                    l = m + 1;
                } else
                {
                    r = m;
                }
            }
            if (ls[l] == x)
            {
                return l;
            } else
            {
                throw new Exception("Expected to find element, but it wasn't found");
                return -1;
            }
        }

        private string getFileName()
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.Title = "Оберіть вхідний файл";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            } else
            {
                return null;
            }
        }

        private (int, int) getCellCoords(double x, double y)
        {
            (int, int) res = (0, 0);
            res.Item1 = find(SortedXs, x);
            res.Item2 = find(SortedYs, y);

            return res;

        }

        private List<double> createListFromSet(SortedSet<double> s)
        {
            var res = new List<double>();
            foreach (var i in s)
            {
                res.Add(i);
            }
            return res;
        }

        private void fill(double[,] matrix)
        {
            SortedXs = createListFromSet(Xs);
            SortedYs = createListFromSet(Ys);

            int cnt = 1;
            foreach (var y in SortedYs)
            {
                matrix[0, cnt++] = y;
            }
            cnt = 1;
            foreach (var x in SortedXs)
            {
                matrix[cnt++, 0] = x;
            }

            foreach (var i in Pairs)
            {
                double x = i.Item1;
                double y = i.Item2;

                (int, int) coords = getCellCoords(x, y);
                coords.Item1++;
                coords.Item2++;

                matrix[coords.Item1, coords.Item2]++;
            }
            
        }

        private void readDataFromGridView()
        {
            Pairs = new List<(double, double)>();
            Xs = new SortedSet<double>();
            Ys = new SortedSet<double>();

            int n = dataGridView1.RowCount;
            for (int i = 0; i < n; i++)
            {
                double x = double.Parse(dataGridView1[0, i].Value.ToString());
                double y = double.Parse(dataGridView1[1, i].Value.ToString());
                Pairs.Add((x, y));
                Xs.Add(x);
                Ys.Add(y);
            }
        }

        private double[,] readFromFile(string fileName)
        {
            using (var reader = new StreamReader(fileName)){
                int lineNum = 0;
                int m = 0, n = 0;
                List<string> strings = new List<string>();
                while (!reader.EndOfStream)
                {
                    lineNum++;
                    string line = reader.ReadLine();
                    strings.Add(line);
                }
                n = lineNum;
                m = strings[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
                var matrix = new double[n, m];
                lineNum = 0;
                foreach (var line in strings)
                {
                    string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (words.Length != m)
                    {
                        MessageBox.Show($"Кількість чисел в рядку {lineNum} не співпадає з кількістю чисел в рядку 1",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    int colNum = 0;
                    foreach(var word in words)
                    { 
                        double num = 0;
                        bool parseResult = double.TryParse(word, NumberStyles.Float, CultureInfo.InvariantCulture, out num);
                        if (parseResult)
                        {
                            matrix[lineNum, colNum] = num;
                        } else
                        {
                            MessageBox.Show($"Не вдалося зчитати число в рядку {lineNum + 1}, стовпчику {colNum + 1}",
                                                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                        colNum++;
                    }

                    lineNum++;
                }

                return matrix;
            }



        }
        private void printMatrixToMessageBox(double[, ] matrix)
        {
            int n = matrix.GetLength(0) - 1;
            int m = matrix.GetLength(1) - 1;


            string dbg_string = "";

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    dbg_string += matrix[i, j].ToString() + " ";
                }

                dbg_string += "\n";
            }


            MessageBox.Show(dbg_string);
        }

        private void printErrToMessageBox(string Err)
        {
            MessageBox.Show(Err, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private double[, ] readMatrixFromGridView()
        {
            int n = dataGridView1.RowCount - 1;
            int m = dataGridView1.ColumnCount;
            var res = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == j && i == 0)
                    {
                        continue;
                    }
                    double parsedNum = 0;
                    var val = dataGridView1[j, i].Value;
                    string word = val != null ? val.ToString() : "0";
                    bool parseResult = double.TryParse(word, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedNum);
                    if (parseResult)
                    {
                        res[i, j] = parsedNum;
                    } else
                    {
                        printErrToMessageBox($"Не вдалося зчитати число в рядку {i + 1}, стовпчику {j + 1}");
                        return null;
                    }
                }
            }
            return res;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (Type == AskingForms.Matrix)
            {
                var matrix = readMatrixFromGridView();
                if (matrix != null)
                {
                    printMatrixToMessageBox(matrix);
                    showNextForm(matrix);
                }
                return;
            }
            else
            {
                readDataFromGridView();
                int n = Xs.Count();
                int m = Ys.Count();

                double[,] matrix = new double[n + 1, m + 1];

                fill(matrix);

                /*

                

                */

                showNextForm(matrix);
            }
        }

        private void showNextForm(double[,] matrix)
        {
            var form = new CoefCorelTasksForm(matrix);
            form.Show();
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            int newVal = 1;
            bool res = int.TryParse(textBoxCount.Text, out newVal);
            if (res)
            {
                if (Type == AskingForms.Pairs)
                {
                    newVal = Math.Max(1, newVal);
                    dataGridView1.RowCount = newVal;
                } else if (Type == AskingForms.Matrix)
                {
                    newVal = Math.Max(2, newVal);
                    dataGridView1.ColumnCount = newVal;
                }
            }
            
        }
    }
}
