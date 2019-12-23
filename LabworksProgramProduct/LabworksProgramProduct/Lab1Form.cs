using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace LabworksProgramProduct
{

    public partial class Lab1Form : Form
    {
        public Lab1Form()
        {
            
            InitializeComponent();
            panel1.Focus();
            Controls.Remove(panel1);
            Controls.Remove(panel2);
            Controls.Remove(panel3);
            InitializeComponents();
            ResizeForm();
            fakePanel.Focus();

        }
        private void Lab1Form_Resize(object sender, EventArgs e)
        {
            ResizeForm();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Lab1Form_Shown(object sender, EventArgs e)
        {
            
            ResizeForm();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void ToContentsPageButton_Click(object sender, EventArgs e)
        {
            fakePanel.VerticalScroll.Value = 0;
            fakePanel.VerticalScroll.Value = 0;
            fakePanel.VerticalScroll.Value = 0;
            HandleScroll();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus)
            {
                //CurrentZoom += 5;
                ResizeForm();

            }
            if (e.KeyCode == Keys.OemMinus)
            {

                // CurrentZoom -= 5;
                ResizeForm();

            }
            

        }
        void GoToPage(int pageNum)
        {
            if (pageNum < 1 || pageNum > 7)
            {
                return;
            }
            int curPage = 1;
            fakePanel.VerticalScroll.Value = Pages[pageNum - 1].panel.Top;
            fakePanel.VerticalScroll.Value = Pages[pageNum - 1].panel.Top;
            fakePanel.VerticalScroll.Value = Pages[pageNum - 1].panel.Top;
          
            HandleScroll();
        }
        private int GetCurPage()
        {
            int cnt = 1;
            foreach(var page in Pages)
            {
                if (page.panel.Top + page.panel.Height >= fakePanel.VerticalScroll.Value)
                {
                    return cnt;
                }
                cnt++;
            }
            throw new NotImplementedException();
        }
        private void TextBoxPages_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxPages.Focused)
            {
                return;
            }
            try
            {
                int curPage = 1;
                if (textBoxPages.Text == "")
                {
                    return;
                }
                else
                {
                    curPage = int.Parse(textBoxPages.Text);
                    GoToPage(curPage);
                }
            }
            catch
            {
                textBoxPages.Text = GetCurPage().ToString();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void ButtonStatic_Click(object sender, EventArgs e)
        {
            var form = new StaticFormSelectType();
            form.Show();
        }
        private void ButtonInterval_Click(object sender, EventArgs e)
        {
            var form = new IntervalFormSelectType();
            form.Show();
        }

        private void ButtonGraphics_Click(object sender, EventArgs e)
        {
            var form = new GraphicsFormSelectType();
            form.Show();
        }
        private void NextPageButton_Click(object sender, EventArgs e)
        {
            GoToPage(GetCurPage() + 1);
        }

        private void ButtonNumChar_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource2("Числові характеристики");
            form.Show();
        }
        private void HandleScroll()
        {
            //leftPanel.Location = new Point(0, 0);
            textBoxPages.Text = GetCurPage().ToString();
        }
        private void PrevPageButton_Click(object sender, EventArgs e)
        {
            GoToPage(GetCurPage() - 1);
        }

        private void Lab1Form_Load(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void Lab1Form_Scroll(object sender, ScrollEventArgs e)
        {
            HandleScroll();
        }

        private void Lab1Form_fakePanel_MouseEnter(object sender, EventArgs e)
        {
            fakePanel.Focus();
        }

    }
}
