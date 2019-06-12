using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabworksProgramProduct
{
    partial class Lab1Form
    {
        void InitializeComponents()
        {
            MouseWheel += Lab1Form_MouseWheel1;
            // leftPanel
            leftPanel = new Panel();
            leftPanel.BackColor = System.Drawing.SystemColors.Window;
            leftPanel.Scroll += LeftPanel_Scroll;
            Controls.Add(leftPanel);
            // leftPanelButtons
            for (int i = 0; i < leftPanelButtons.Length; i++)
            {
                leftPanelButtons[i] = new Button();
                leftPanel.Controls.Add(leftPanelButtons[i]);
            }
            // mainPanel
            mainPanel = new Panel();
            mainPanel.BackColor =  System.Drawing.SystemColors.Window;
            mainPanel.Controls.Add(panel1);
            mainPanel.Controls.Add(panel2);
            mainPanel.Controls.Add(panel3);
            Controls.Add(mainPanel);



            leftPanel.Width = 250;
            leftPanel.Height = Height - 100;
            mainPanel.Location = new System.Drawing.Point(leftPanel.Left + leftPanel.Width + 5, 0);
        }


        private void LeftPanel_Scroll(object sender, ScrollEventArgs e)
        {
            leftPanel.Location = new System.Drawing.Point(0, 0);
        }

        void ResizeForm()
        {
            int wasScroll = VerticalScroll.Value;
            // leftPanel
            leftPanel.Location = new System.Drawing.Point(0, 0);
            // leftPanelButtons
            for (int i = 0; i < leftPanelButtons.Length; i++)
            {
                leftPanelButtons[i].Width = 200;
                leftPanelButtons[i].Height = 50;
                if (i == 0)
                {
                    leftPanelButtons[i].Location = new System.Drawing.Point(10, 10);
                }
                else
                {
                    leftPanelButtons[i].Left = leftPanelButtons[i - 1].Left;
                    leftPanelButtons[i].Top = leftPanelButtons[i - 1].Top + leftPanelButtons[i - 1].Height + 10;
                }
            }
            // mainPanel
            mainPanel.Width = Math.Max(Width - leftPanel.Width - 5 - 40, panel1.Width + panel1.Left);
            mainPanel.Height = Math.Max(panel3.Top + panel3.Height, Height - 100);

       
        }

        private Panel leftPanel;
        private Panel mainPanel;
        private Button[] leftPanelButtons = new Button[4];

    }
}
