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
    public partial class GraphicsTasksForm : Form
    {
        public SortedDictionary<double, double> Dict;
        public SortedDictionary<Interval, double> IntDict;
        public GraphicsTasksForm(SortedDictionary<double, double> dict)
        {
            Dict = dict;
            IntDict = new SortedDictionary<Interval, double>();
            InitializeComponent();
        }
        public GraphicsTasksForm(SortedDictionary<Interval, double> intdict)
        {
            IntDict = intdict;
            Dict = new SortedDictionary<double, double>();
            InitializeComponent();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox2.Checked)
            {
                List<int> TaskList = new List<int>();
                if (checkBox1.Checked)
                {
                    TaskList.Add(1);
                }
                if (checkBox2.Checked)
                {
                    TaskList.Add(2);
                }
                /*
                    SortedDictionary<double, double> toDraw = Tasks.GetEmpFunction(Dict);
                    var form = new FunctionForm(toDraw, new string[2]{ "x", "F*(x)" }, "1");
                */
                if (Dict.Count > 0)
                {
                    var form = new ResultFormGraphics(Dict, TaskList);
                    form.Show();
                    Close();
                } 
                else if (IntDict.Count > 0)
                {
                    var form = new ResultFormGraphics(IntDict, TaskList);
                    form.Show();
                    Close();
                }

            } else
            {
                MessageBox.Show("Виберіть хоча б одну опцію!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
