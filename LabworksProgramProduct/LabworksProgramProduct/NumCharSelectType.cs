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
    public partial class NumCharSelectType : Form
    {
        public NumCharSelectType()
        {
            InitializeComponent();
        }

        private void ButtonVariantRow_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(AskingForms.VariantRow, Forms.NumCharTasksForm);
            form.Show();
            this.Close();
        }

        private void ButtonStatisticDistr_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(AskingForms.StatisticDistr, Forms.NumCharTasksForm);
            form.Show();
            this.Close();
        }

        private void ButtonStatisticFromFile_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(AskingForms.StatisticDistrFromFile, Forms.NumCharTasksForm);
            this.Close();
        }
    }
}
