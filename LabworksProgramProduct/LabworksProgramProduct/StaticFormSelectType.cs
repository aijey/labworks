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
    public partial class StaticFormSelectType : Form
    {
        public StaticFormSelectType()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(AskingForms.VariantRow, Forms.StaticTasksForm);
            form.Show();
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(AskingForms.StatisticDistr, Forms.StaticTasksForm);
            form.Show();
            Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(AskingForms.VariantRowFromFile, Forms.StaticTasksForm);
            Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(AskingForms.StatisticDistrFromFile, Forms.StaticTasksForm);
            Close();
        }
    }
}
