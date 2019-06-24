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
    public partial class IntervalForm : Form
    {
        public IntervalForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource2("Інтервальний розподіл");
            form.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource2("Гістограма частот");
            form.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource2("Гістограма відносних частот");
            form.Show();
        }
    }
}
