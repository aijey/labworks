using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabworksProgramProduct
{
    public class GroupStatDistributionInputElement: BaseGroupInputElement
    {
        
        public GroupStatDistributionInputElement(ref TextBox textBox, ref DataGridView dataGridView): base(ref textBox, ref dataGridView)
        {
        }

        public override SortedDictionary<double, double> GetDistribution(int groupNum)
        {
            SortedDictionary<double, double> res = new SortedDictionary<double, double>();
            var rows = dataGrid.Rows;
            int rowsLen = rows.Count;
            for (int i = 0; i < rowsLen - 1; i++)
            {
                string xStr = rows[i].Cells[0].Value.ToString();
                string nStr = rows[i].Cells[1].Value.ToString();
                double x = 0.0;
                int nInt = 0;
                bool parseResult = double.TryParse(xStr, out x);
                check(parseResult, "Не вдалося зчитати число Х в рядку " + i.ToString() + ", групі " + groupNum.ToString());
                parseResult = int.TryParse(nStr, out nInt);
                double n = nInt;
                check(parseResult, "Не вдалося зчитати число N в рядку " + i.ToString() + ", групі " + groupNum.ToString());
                if (!res.ContainsKey(x))
                {
                    res[x] = 0;
                }
                res[x] += n;
            }
            return res;

        }
    }
}
