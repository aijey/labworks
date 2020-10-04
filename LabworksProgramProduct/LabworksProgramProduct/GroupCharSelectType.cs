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
    public partial class GroupCharSelectType : Form
    {
        string[] defaultNames = new string[2] {"Група", "Ознака"};
        public GroupCharSelectType()
        {
            InitializeComponent();
        }

        private void ButtonSeq_Click(object sender, EventArgs e)
        {
            int flag = checkBox1.Checked ? 1 : 0;
            var form = new BaseAskingFormGroupChar(defaultNames[flag]);
            form.Show();
        }

        private void ButtonStatDistr_Click(object sender, EventArgs e)
        {
            int flag = checkBox1.Checked ? 1 : 0;
            var form = new GroupSequenceAskingForm(defaultNames[flag]);
            form.Show();
        }
    }
}
