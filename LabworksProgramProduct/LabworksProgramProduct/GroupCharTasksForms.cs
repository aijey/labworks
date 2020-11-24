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
    public partial class GroupCharTasksForms : Form
    {
        List<GroupDistributionData> groupData;
        public GroupCharTasksForms(List<GroupDistributionData> groupData)
        {
            this.groupData = groupData;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var tasksList = new List<int>();
            if (checkBox1.Checked)
            {
                tasksList.Add(1);
            }
            if (checkBox2.Checked)
            {
                tasksList.Add(2);
            }
            if (checkBox3.Checked)
            {
                tasksList.Add(3);
            }
            if (checkBox4.Checked)
            {
                tasksList.Add(4);
            }
            if (tasksList.Count == 0)
            {
                MessageBox.Show("Виберіть хоча б одну опцію!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = new GroupCharResultForm(groupData, tasksList);
            form.Show();
            this.Hide();
        }
    }
}
