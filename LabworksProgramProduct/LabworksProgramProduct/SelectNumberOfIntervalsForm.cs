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
    public partial class SelectNumberOfIntervalsForm : Form
    {
        private int M;
        private SortedDictionary<double, double> Dict;
        public SelectNumberOfIntervalsForm(SortedDictionary<double, double> dict)
        {
            InitializeComponent();
            Dict = dict;
            double mx = Dict.Max(pp => pp.Key);
            double mn = Dict.Min(pp => pp.Key);
            TextBoxRVal.Text = (mx - mn).ToString();
            int n = (int)Dict.Sum(pp => pp.Value);
            TextBoxNVal.Text = n.ToString();
        }

        private void TextBoxMVal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                M = int.Parse(TextBoxMVal.Text.ToString());
            }catch 
            {
                M = 0;
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (M > 0)
            {
                var form = new IntervalTasksForm(Dict, M);
                form.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Кількість інтервалів повинно буде цілим числом", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
