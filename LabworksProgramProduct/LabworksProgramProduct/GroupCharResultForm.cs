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
    public partial class GroupCharResultForm : Form
    {
        List<GroupDistributionData> GroupData;
        List<int> TasksList;
        public GroupCharResultForm(List<GroupDistributionData> groupData, List<int> tasksList)
        {
            GroupData = groupData;
            TasksList = tasksList;
            InitializeComponent();
            HideAllPanels();
            SolveTasks();
        }
        private void HideAllPanels()
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
        }

        private void SolveTasks()
        {
            foreach(int number in TasksList)
            {
                if (number == 1)
                {
                    panel1.Show();
                    SolveTasksForPanel1();
                }
                if (number == 2)
                {
                    panel2.Show();
                    SolveTasksForPanel2();
                }
                if (number == 3)
                {
                    panel3.Show();
                    SolveTasksForPanel3();
                }
                if (number == 4)
                {
                    panel4.Show();
                    SolveTasksForPanel4();
                }
            }
        }

        private void SetupDataGrid(DataGridView dataGridView)
        {
            dataGridView.ColumnCount = GroupData.Count;
            dataGridView.Rows.Add();
            for (int i = 0; i < GroupData.Count; i++)
            {
                dataGridView.Columns[i].HeaderText = GroupData[i].GroupName;
            }
        }

        private void SolveTasksForPanel1()
        {
            SetupDataGrid(dataGridAvg);
            List<double> avgs = new List<double>();
            for (int i = 0; i < GroupData.Count; i++)
            {
                double avg = Tasks.GetAvg(ref GroupData[i].Distribution);
                dataGridAvg.Rows[0].Cells[i].Value = avg;
                avgs.Add(avg);
            }
            textBoxAvg.Text = Tasks.GetGroupGeneralAvg(GroupData).ToString();
        }

        private void SolveTasksForPanel2()
        {
            SetupDataGrid(dataGridDisp);
            SetupDataGrid(dataGridDispF);
            for (int i = 0; i < GroupData.Count; i++)
            {
                double disp = Tasks.GetDispersion(ref GroupData[i].Distribution);
                dataGridDisp.Rows[0].Cells[i].Value = disp;
                dataGridDispF.Rows[0].Cells[i].Value = Tasks.GetCorrectedDispersion(ref GroupData[i].Distribution);
            }
            textBoxInGroupDisp.Text = Tasks.GetInGroupDispersion(GroupData).ToString();
            textBoxInGroupDispF.Text = Tasks.GetInGroupCorrectedDispersion(GroupData).ToString();
            textBoxBetweenGroupDisp.Text = Tasks.GetBetweenGroupsDispersion(GroupData).ToString();
            textBoxBetweenGroupDispF.Text = Tasks.GetBetweenGroupsCorrectedDispersion(GroupData).ToString();
            textBoxGeneralDisp.Text = Tasks.GetGroupGeneralDisp(GroupData).ToString();
            textBoxGeneralDispF.Text = Tasks.GetGroupGeneralCorrectedDisp(GroupData).ToString();
        }

        private void SolveTasksForPanel3()
        {
            SetupDataGrid(dataGridModa);
            SetupDataGrid(dataGridMedian);
            for (int i = 0; i < GroupData.Count; i++)
            {
                (double[], double) disp = Tasks.GetModAndMed2(GroupData[i].Distribution);
                dataGridModa.Rows[0].Cells[i].Value = GetModStringFromArray(disp.Item1);
                dataGridMedian.Rows[0].Cells[i].Value = disp.Item2.ToString();
            }
        }
        private string GetModStringFromArray(double[] arr)
        {
            string res = "[";
            for (int i = 0; i < arr.Length - 1; i++)
            {
                res += arr[i].ToString() + " ";
            }
            res += arr[arr.Length - 1].ToString() + "]";
            return res;
        }

        private void SolveTasksForPanel4()
        {
            SetupDataGrid(dataGridAssym);
            SetupDataGrid(dataGridExcess);
            for (int i = 0; i < GroupData.Count; i++)
            {
                double assym = Tasks.GetAsymmetry(GroupData[i].Distribution);
                double excess = Tasks.GetExcess(GroupData[i].Distribution);
                dataGridAssym.Rows[0].Cells[i].Value = assym.ToString();
                dataGridExcess.Rows[0].Cells[i].Value = excess.ToString();
            }
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }
    }
}
