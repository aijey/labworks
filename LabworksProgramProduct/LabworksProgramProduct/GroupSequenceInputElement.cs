using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabworksProgramProduct
{
    class GroupSequenceInputElement : BaseGroupInputElement
    {
        public GroupSequenceInputElement(ref TextBox textBox, ref DataGridView dataGridView) : base(ref textBox, ref dataGridView)
        {
        }

        public override SortedDictionary<double, double> GetDistribution(int groupNum)
        {
            var res = new SortedDictionary<double, double>();
            var rows = dataGrid.Rows;
            int rowsLen = rows.Count;
            for (int i = 0; i < rowsLen - 1; i++)
            {
                string xStr = rows[i].Cells[0].Value.ToString();
                double x = 0.0;
                bool parseResult = double.TryParse(xStr, out x);
                check(parseResult, "Не вдалося зчитати число Х в рядку " + i.ToString() + ", групі " + groupNum.ToString());
                if (!res.ContainsKey(x))
                {
                    res[x] = 0;
                }
                res[x]++;
            }
            return res;
        }
    }
}
