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
    public partial class PropCharResultForm : Form
    {
        List<GroupDistributionData> GroupData;
        public PropCharResultForm(List<GroupDistributionData> groupData)
        {
            GroupData = groupData;
            InitializeComponent();
            InitDataGrid();
            Solve();
        }
        private void InitDataGrid()
        {
            dataGridView1.RowCount = 3;
            dataGridView1.ColumnCount = GroupData.Count;
            dataGridView1.Rows[0].HeaderCell.Value = "Середнє значення";
            dataGridView1.Rows[1].HeaderCell.Value = "Дисперсія";
            dataGridView1.Rows[2].HeaderCell.Value = "Середнє квадратичне відхилення";
            
        }
        private void Solve()
        {

            for (int i = 0; i < GroupData.Count; i++) 
            {
                var item = GroupData[i];
                var avg = Tasks.GetAvg(ref item.Distribution);
                var disp = Tasks.GetDispersion(ref item.Distribution);
                var dev = Tasks.GetSquareDeviation(ref item.Distribution);
                dataGridView1.Columns[i].HeaderCell.Value = item.GroupName;
                dataGridView1[i, 0].Value = avg;
                dataGridView1[i, 1].Value = disp;
                dataGridView1[i, 2].Value = dev;
            }
        }
    }
}
