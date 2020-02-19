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
    public partial class NumCharTasksForm : Form
    {
        SortedDictionary<double, double> Dict;
        public NumCharTasksForm(SortedDictionary<double, double> dict)
        {
            Dict = dict;
            InitializeComponent();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                checkBoxAll.Checked = false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                checkBoxAll.Checked = false;
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
            {
                checkBoxAll.Checked = false;
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox4.Checked)
            {
                checkBoxAll.Checked = false;
            }
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox5.Checked)
            {
                checkBoxAll.Checked = false;
            }
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox6.Checked)
            {
                checkBoxAll.Checked = false;
            }
        }

        private void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
            } 

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<int> tasks = new List<int>();
            int k = 0;
            if (checkBox1.Checked)
            {
                tasks.Add(1);
            }
            if (checkBox2.Checked)
            {
                tasks.Add(2);
            }
            if (checkBox3.Checked)
            {
                tasks.Add(3);
            }
            if (checkBox4.Checked)
            {
                tasks.Add(4);
                bool res = int.TryParse(textBox1.Text, out k);
                if (!res)
                {
                    MessageBox.Show("Введіть коректне значення k", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (checkBox5.Checked)
            {
                tasks.Add(5);
               
            }
            if (checkBox6.Checked)
            {
                tasks.Add(6);
            }
            var form = new ResultFormNumChar(Dict, tasks, k);
            form.Show();
            Close();
        }
    }
}
