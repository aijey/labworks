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
        public IntervalTasksForm()
        {
            InitializeComponent();
        }
        public IntervalTasksForm(SortedDictionary<double, double> dict, int m)
        {
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
    }
}
