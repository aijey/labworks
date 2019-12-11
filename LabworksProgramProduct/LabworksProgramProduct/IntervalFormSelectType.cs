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
    public partial class IntervalFormSelectType : Form
    {
        public IntervalFormSelectType()
        {
            InitializeComponent();
        }

        private void ButtonVariantRow_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(1, Forms.SelectNumberOfIntervalsForm);
            form.Show();
            this.Close();
        }

        private void ButtonStatisticDistr_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(2, Forms.SelectNumberOfIntervalsForm);
            form.Show();
            this.Close();
        }

        private void ButtonStatisticFromFile_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(4, Forms.SelectNumberOfIntervalsForm);
            this.Close();
        }
    }
}
