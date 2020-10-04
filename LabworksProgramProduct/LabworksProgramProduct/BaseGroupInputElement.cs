using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabworksProgramProduct
{
    public abstract class BaseGroupInputElement
    {
        public DataGridView dataGrid;
        public TextBox textBox;
        public BaseGroupInputElement(ref TextBox textBox, ref DataGridView dataGridView)
        {
            this.dataGrid = dataGridView;
            this.textBox = textBox;
        }
        protected void check(bool condition, string msg)
        {
            if (!condition)
            {
                throw new Exception(msg);
            }
        }
        public abstract SortedDictionary<double, double> GetDistribution(int groupNum);

    }
}
