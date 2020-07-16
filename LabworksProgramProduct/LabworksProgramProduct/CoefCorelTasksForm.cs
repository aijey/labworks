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
    public partial class CoefCorelTasksForm : Form
    {
        double[,] matrix;
        public CoefCorelTasksForm(double[, ] matrix)
        {
            this.matrix = matrix;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<int> TasksList = new List<int>();
            if (checkBox1.Checked)
            {
                TasksList.Add(1);
            }
            if (checkBox2.Checked)
            {
                TasksList.Add(2);
            }
            if (checkBox3.Checked)
            {
                TasksList.Add(3);
            }
            if (checkBox4.Checked)
            {
                TasksList.Add(4);
            }
            if (checkBox5.Checked)
            {
                TasksList.Add(5);
            }
            if (TasksList.Count == 0)
            {
                printErrToMessageBox("Виберіть хоча би одну опцію");
            } else
            {
                var form = new ResultFormCoefCorel(TasksList, matrix);
                form.Show();
            }
        }
        private void printErrToMessageBox(string Err)
        {
            MessageBox.Show(Err, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
