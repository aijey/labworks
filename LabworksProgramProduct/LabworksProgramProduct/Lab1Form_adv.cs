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
            // leftPanel
            leftPanel = new Panel();
            leftPanel.BackColor = System.Drawing.SystemColors.Window;
            leftPanel.Scroll += LeftPanel_Scroll;
            leftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left))));
            Controls.Add(leftPanel);
            // leftPanelButtons
            for (int i = 0; i < leftPanelButtons.Length; i++)
            {
                leftPanelButtons[i] = new Button();
                leftPanelButtons[i].UseVisualStyleBackColor = true;
                leftPanel.Controls.Add(leftPanelButtons[i]);
                AssignActionsToLeftPanelButtons(i);
            }
            // mainPanel
            
            fakePanel = new Panel();
            mainPanel = new Panel();
            fakePanel.MouseWheel += Lab1Form_MouseWheel1;
            fakePanel.Scroll += Lab1Form_Scroll;
            fakePanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.BackColor =  System.Drawing.SystemColors.Control;
            fakePanel.AutoScroll = true;
            Controls.Add(fakePanel);
            fakePanel.Controls.Add(mainPanel);
            // label
            pagesLabel = new Label();
            pagesLabel.Text = "Сторінка: ";
            leftPanel.Controls.Add(pagesLabel);
            // textBox
            textBoxPages = new TextBox();
            leftPanel.Controls.Add(textBoxPages);
            textBoxPages.TextChanged += TextBoxPages_TextChanged;

            leftPanel.Width = 250;
            leftPanel.Height = Height - 50;
            fakePanel.Location = new System.Drawing.Point(leftPanel.Left + leftPanel.Width + 5, 0);
            mainPanel.Location = new System.Drawing.Point(0, 0);
            fakePanel.Width = (Width - leftPanel.Width - 5);
            mainPanel.Width = fakePanel.Width - 100;
            InitPages();
            fakePanel.Height = Height - 50;
            mainPanel.Height = Pages.Last().panel.Top + Pages.Last().panel.Height;
            foreach(var control in mainPanel.Controls)
            {
                var contr = control as Panel;
                if (contr != null)
                {
                    contr.Anchor = AnchorStyles.Top;
                }
            }
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
                if (i == 1 || i == 2)
                {
                    leftPanelButtons[i].Width = 95;
                    leftPanelButtons[i].Height = 50;
                    if (i == 1)
                    {
                        leftPanelButtons[i].Left = leftPanelButtons[i - 1].Left;
                        leftPanelButtons[i].Top = leftPanelButtons[i - 1].Top + leftPanelButtons[i - 1].Height + 10;
                        pagesLabel.Location = new System.Drawing.Point(leftPanelButtons[i].Left, leftPanelButtons[i].Top + leftPanelButtons[i].Height + 10);
                        textBoxPages.Location = new System.Drawing.Point(pagesLabel.Left + pagesLabel.Width, leftPanelButtons[i].Top + leftPanelButtons[i].Height + 10);
                    }
                    else
                    {
                        leftPanelButtons[i].Left = leftPanelButtons[i - 1].Left + leftPanelButtons[i - 1].Width + 10;
                        leftPanelButtons[i].Top = leftPanelButtons[i - 2].Top + leftPanelButtons[i - 2].Height + 10;
                    }
                }
                else
                {
                    if (i == 3)
                    {
                        leftPanelButtons[i].Width = 200;
                        leftPanelButtons[i].Height = 50;
                        leftPanelButtons[i].Left = leftPanelButtons[0].Left;
                        leftPanelButtons[i].Top = pagesLabel.Top + pagesLabel.Height + 10;
                    }
                    else
                    {
                        leftPanelButtons[i].Width = 200;
                        leftPanelButtons[i].Height = 50;
                        if (i == 0)
                        {
                            leftPanelButtons[i].Location = new System.Drawing.Point(10, 10);
                        }
                        else
                        {
                            leftPanelButtons[i].Left = leftPanelButtons[0].Left;
                            leftPanelButtons[i].Top = leftPanelButtons[i - 1].Top + leftPanelButtons[i - 1].Height + 10;
                        }
                    }
                }
            }
            // mainPanel
            fakePanel.Width = (Width - leftPanel.Width - 5 - 40);
            mainPanel.Width = fakePanel.Width - 100;
            ResizePages();
            mainPanel.Height = Pages.Last().panel.Top + Pages.Last().panel.Height;

        }
        void InitPages()
        {
            // 
            // page1
            //
            int prevY = -5;
            for (int i = 1; i <= 7; i++) {
                var page = InitPage(i);
                page.panel.Location = new System.Drawing.Point(0, prevY + 5);
                SetupPanel(page, i);
                prevY = page.panel.Height + page.panel.Top;
                mainPanel.Controls.Add(page.panel);
                Pages.Add(page);
            }
            //
            // page2
            //

        }
        void ResizePages()
        {
            int prevY = -5;
            int index = 1;
            foreach(var page in Pages)
            {
                page.panel.Location = new System.Drawing.Point(0, prevY + 5);
                ResizePanel(page.panel, index++);
                prevY = page.panel.Height + page.panel.Top;
            }
        }
        void ResizePanel(Panel panel, int index)
        {
            panel.Width = mainPanel.Width;
            if (index <= 3 || index >= 5 && index <= 6)
            {
                var img = Pages[index - 1].PictureBoxes[0];
                ResizePictureBox(ref img, ref panel, index);
                panel.Height = img.Height;
            }
            if (index == 4)
            {
                var img = Pages[index - 1].PictureBoxes[0];
                ResizePictureBox(ref img, ref panel, index, 1);
                panel1.Location = new System.Drawing.Point(0, img.Top + img.Height);
                panel1.Width = mainPanel.Width;
                img = Pages[index - 1].PictureBoxes[1];
                ResizePictureBox(ref img, ref panel, index, 2);
                panel.Height = img.Top + img.Height;
            }
            if (index == 7)
            {
                var img = Pages[index - 1].PictureBoxes[0];
                ResizePictureBox(ref img, ref panel, index, 1);
                panel2.Location = new System.Drawing.Point(0, img.Top + img.Height);
                panel2.Width = mainPanel.Width;
                img = Pages[index - 1].PictureBoxes[1];
                ResizePictureBox(ref img, ref panel, index, 2);
                panel.Height = img.Top + img.Height;
            }
        }
        private Page InitPage(int index)
        {
            if (index == 1)
            {
                return new Page(new[] { "1", "2" });
            }
            if (index == 2 || index == 3)
            {
                return new Page(new string[] { });
            }
            return new Page(new string[] { });
        }
        private void SetupPanel(Page page, int index)
        {
            page.panel.Width = mainPanel.Width;
            if (index <= 3 || index >= 5 && index <= 6)
            {
                var img = InitPictureBox(index, ref page.panel);
                page.PictureBoxes.Add(img);
                page.panel.Controls.Add(img);
                page.panel.Height = img.Height;
            }
            if (index == 4)
            {
                var img = InitPictureBox(index, ref page.panel, 1);
                page.panel.Controls.Add(img);
                page.PictureBoxes.Add(img);
                panel1.Location = new System.Drawing.Point(0, img.Top + img.Height);
                page.panel.Controls.Add(panel1);
                img = InitPictureBox(index, ref page.panel, 2);
                page.PictureBoxes.Add(img);
                page.panel.Controls.Add(img);
                page.panel.Height = img.Top + img.Height;
            }
            if (index == 7)
            {
                var img = InitPictureBox(index, ref page.panel, 1);
                page.panel.Controls.Add(img);
                page.PictureBoxes.Add(img);
                panel2.Location = new System.Drawing.Point(0, img.Top + img.Height);
                page.panel.Controls.Add(panel2);
                img = InitPictureBox(index, ref page.panel, 2);
                page.PictureBoxes.Add(img);
                page.panel.Controls.Add(img);
                page.panel.Height = img.Top + img.Height;
            }
        }
        private void ResizePictureBox(ref PictureBox img, ref Panel panel, int index, int subindex = 0)
        {
            if (index == 1)
            {
                img.Location = new System.Drawing.Point(0, 0);
            }
            if (index == 2)
            {
                img.Location = new System.Drawing.Point(0, 0);
            }
            if (index == 3)
            {
                img.Location = new System.Drawing.Point(0, 0);
            }
            if (index == 4)
            {
                if (subindex == 1)
                {
                    img.Location = new System.Drawing.Point(0, 0);
                }
                if (subindex == 2)
                {
                    img.Location = new System.Drawing.Point(0, panel1.Top + panel1.Height + 5);
                }
            }
            if (index == 5)
            {
                img.Location = new System.Drawing.Point(0, 0);
            }
            if (index == 6)
            {
                img.Location = new System.Drawing.Point(0, 0);
            }
            if (index == 7)
            {
                if (subindex == 1)
                {
                    img.Location = new System.Drawing.Point(0, 0);
                }
                else
                {
                    img.Location = new System.Drawing.Point(0, panel2.Top + panel2.Height + 5);
                }
            }
            img.SizeMode = PictureBoxSizeMode.AutoSize;
            double vidn = (double)img.Height / (double)img.Width;
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.Width = panel.Width;
            img.Height = (int)(img.Width * vidn);
        }
        private PictureBox InitPictureBox(int index, ref Panel panel, int subindex = 0)
        {
            var img = new PictureBox();
            if (index == 1)
            {
                img.Image = global::LabworksProgramProduct.Properties.Resources.matyahsa_1;
                img.Location = new System.Drawing.Point(0, 0);
            }
            if (index == 2)
            {
                img.Image = global::LabworksProgramProduct.Properties.Resources.matyahsa_2;
                img.Location = new System.Drawing.Point(0, 0);
            }
            if (index == 3)
            {
                img.Image = global::LabworksProgramProduct.Properties.Resources.matyahsa_3;
                img.Location = new System.Drawing.Point(0, 0);
            }
            if (index == 4)
            {
                if (subindex == 1)
                {
                    img.Image = global::LabworksProgramProduct.Properties.Resources.matyahsa_4;
                    img.Location = new System.Drawing.Point(0, 0);
                }
                if (subindex == 2)
                {
                    img.Image = img.Image = global::LabworksProgramProduct.Properties.Resources.matyahsa_4_2;
                    img.Location = new System.Drawing.Point(0, panel1.Top + panel1.Height+5);
                }
            }
            if (index == 5)
            {
                img.Image = global::LabworksProgramProduct.Properties.Resources.matyahsa_5;
                img.Location = new System.Drawing.Point(0, 0);
            }
            if (index == 6)
            {
                img.Image = global::LabworksProgramProduct.Properties.Resources.matyahsa_6;
                img.Location = new System.Drawing.Point(0, 0);
            }
            if (index == 7)
            {
                if (subindex == 1)
                {
                    img.Image = global::LabworksProgramProduct.Properties.Resources.matyahsa_7_1;
                    img.Location = new System.Drawing.Point(0, 0);
                } else
                {
                    img.Image = global::LabworksProgramProduct.Properties.Resources.matyahsa_7_2;
                    img.Location = new System.Drawing.Point(0, panel2.Top + panel2.Height + 5);
                }
            }
            img.SizeMode = PictureBoxSizeMode.AutoSize;
            double vidn = (double)img.Height / img.Width;
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.Width = panel.Width;
            img.Height = (int)(img.Width * vidn);
            return img;
        }
        void AssignActionsToLeftPanelButtons(int index)
        {
            index++;
            if (index == 1)
            {
                leftPanelButtons[0].Click += ToContentsPageButton_Click;
                leftPanelButtons[0].Text = "Зміст";
            }
            if (index == 2)
            {
                leftPanelButtons[1].Click += PrevPageButton_Click;
                leftPanelButtons[1].Text = "<";
            }
            if (index == 3)
            {
                leftPanelButtons[2].Click += NextPageButton_Click;
                leftPanelButtons[2].Text = ">";
            }
            if (index == 4)
            {
                leftPanelButtons[3].Click += ButtonStatic_Click;
                leftPanelButtons[3].Text = "Побудова статистичних розподілів та їх графічних характеристик";
            }
            if (index == 5)
            {
                leftPanelButtons[4].Click += ButtonInterval_Click;
                leftPanelButtons[4].Text = "Побудова інтервальних розподілів та їх графічних характеристик";
            }
            if (index == 6)
            {
                leftPanelButtons[5].Click += ButtonGraphics_Click;
                leftPanelButtons[5].Text = "Знаходження та побудова графіку емпіричної функції";
            }
            if (index == 7)
            {
                leftPanelButtons[6].Click += ButtonNumChar_Click;
                leftPanelButtons[6].Text = "Знаходження числових характеристик статистичних розподілів";
            }
            if (index == 8)
            {
                //leftPanelButtons[7].Click += ;
                leftPanelButtons[7].Text = "Знаходження групових та загальних числових характеристик";
            }
            if (index == 9)
            {
                //leftPanelButtons[8].Click += ;
                leftPanelButtons[8].Text = "Визначення коефіцієнту кореляції";
            }
            if (index == 10)
            {
                //leftPanelButtons[9].Click += ;
                leftPanelButtons[9].Text = "Побудова лінії регресії";
            }
        }
        private Panel leftPanel;
        private Panel mainPanel;
        private Panel fakePanel;
        private Button[] leftPanelButtons = new Button[10];
        private List<Page> Pages = new List<Page>();
        private Label pagesLabel;
        private TextBox textBoxPages;
    }
}
