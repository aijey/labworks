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
    public partial class StaticForm : Form
    {
        public StaticForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource("Варіаційний ряд");
            form.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource("Статистичний розподіл");
            form.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource("Статистичний розподіл відносних частот");
            form.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource("Статистичний розподіл накопичуваних частот");
            form.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource("Статистичний розподіл відносних накопичуваних частот");
            form.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource("Полігон частот");
            form.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource("Полігон відносних частот");
            form.Show();
        }
    }
}
