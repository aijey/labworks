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
        Forms[] AvailableNextForms = new Forms[2] { Forms.GroupCharTasksForm, Forms.PropCharResultForm };
        public GroupCharSelectType()
        {
            InitializeComponent();
        }

        private void ButtonSeq_Click(object sender, EventArgs e)
        {
            int flag = checkBox1.Checked ? 1 : 0;
            var form = new GroupSequenceAskingForm(defaultNames[flag], AvailableNextForms[flag]);
            form.Show();
            
        }

        private void ButtonStatDistr_Click(object sender, EventArgs e)
        {
            int flag = checkBox1.Checked ? 1 : 0;
            var form = new GroupStatDistrAskingForm(defaultNames[flag], AvailableNextForms[flag]);
            form.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                buttonStatDistr.Enabled = false;
                buttonStatDistrFromFile.Enabled = false;
                ButtonSeq.Enabled = true;
            } else
            {
                ButtonSeq.Enabled = true;
                buttonStatDistr.Enabled = true;
                buttonStatDistrFromFile.Enabled = true;
            }
        }
    }
}
