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
    public partial class IntervalTasksForm : Form
    {
        SortedDictionary<Interval, double> IntDict;
        public IntervalTasksForm()
        {
            InitializeComponent();
        }
        public IntervalTasksForm(SortedDictionary<double, double> dict, int m)
        {
            IntDict = Tasks.GetIntDict(dict, m);
            InitializeComponent();
        }

        public IntervalTasksForm(SortedDictionary<Interval, double> intDict)
        {
            IntDict = intDict;
            InitializeComponent();
        }

        private void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<int> tasks = new List<int>();
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
            var form = new ResultFormInterval(IntDict, tasks);
            form.Show();
            Close();
        }
    }
}
