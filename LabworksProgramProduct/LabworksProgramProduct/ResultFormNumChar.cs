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
    public partial class ResultFormNumChar : Form
    {
        SortedDictionary<double, double> Dict;
        List<int> TasksList;
        int K;
        public ResultFormNumChar(SortedDictionary<double, double> dict, List<int> tasks, int k)
        {
            Dict = dict;
            TasksList = tasks;
            K = k;
            InitializeComponent();
            SelectPanels();

        }
        private void SelectPanels()
        {
            panel2.Hide();
            panel4.Hide();
            panel3.Hide();
            panel5.Hide();
            panel6.Hide();
            panel6.Hide();
            int prevTop = 0;
            foreach (var item in TasksList) { 
                if (item == 1)
                {
                    panel1.Show();
                    panel1.Top = prevTop + 12;
                    prevTop = panel1.Top + panel1.Height;
                    double avg = Tasks.GetAvg(ref Dict);
                    textBoxAvg.Text = avg.ToString();
                } else if (item == 2)
                {
                    panel2.Show();
                    panel2.Top = prevTop + 12;
                    prevTop = panel2.Top + panel2.Height;
                    double disp = Tasks.GetDispersion(ref Dict);
                    double cdisp = Tasks.GetCorrectedDispersion(ref Dict);
                    textBoxDispersion.Text = disp.ToString();
                    textBoxCorrectedDispersion.Text = cdisp.ToString();
                } else if (item == 3)
                {
                    panel3.Show();
                    panel3.Top = prevTop + 12;
                    prevTop = panel3.Top + panel3.Height;
                    textBoxAvgSquareDeviation.Text = Tasks.GetSquareDeviation(ref Dict).ToString();
                    textBoxCorrectedSquareDeviation.Text = Tasks.GetCorrectedSquareDeviation(ref Dict).ToString();
                    
                } else if (item == 4)
                {
                    panel4.Show();
                    panel4.Top = prevTop + 12;
                    prevTop = panel4.Top + panel4.Height;
                    labelpBegin.Text += K.ToString() + ":";
                    labelpEnd.Text += K.ToString() + ": ";
                    textBoxpBegin.Text = Tasks.pBegin(Dict, K).ToString();
                    textBoxpEnd.Text = Tasks.pEnd(Dict, K).ToString();
                } else if (item == 5)
                {
                    panel5.Show();
                    panel5.Top = prevTop + 12;
                    prevTop = panel5.Top + panel5.Height;
                    (double[], double) modAndMed = Tasks.GetModAndMed2(Dict);
                    textBoxModa.Text = "[" + string.Join(", ", modAndMed.Item1) + "]";
                    textBoxMediana.Text = modAndMed.Item2.ToString();
                } else if (item == 6)
                {
                    // todo;
                    MessageBox.Show("TODO");
                }
            }
        }
    }
}
