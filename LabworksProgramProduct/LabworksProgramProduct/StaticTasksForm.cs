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
    public partial class StaticTasksForm : Form
    {
        SortedDictionary<double, double> Dict;
        public StaticTasksForm(SortedDictionary<double,double> Dict)
        {
            this.Dict = Dict;
            InitializeComponent();
        }

        private void CheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
            }
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
            if (checkBox6.Checked)
            {
                TasksList.Add(6);
            }
            if (checkBox7.Checked)
            {
                TasksList.Add(7);
            }
            if (checkBox8.Checked)
            {
                TasksList.Add(8);
            }

            var form = new ResultForm(TasksList, Dict);
            form.Show();
            Close();

        }

        private void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
