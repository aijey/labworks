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
    public partial class BaseAskingFormGroupChar : Form
    {
        List<SortedDictionary<double, double>> distrs = new List<SortedDictionary<double, double>>();
        protected string defaultName = "";
        int offset = 50;
        protected List<BaseGroupInputElement> groups = new List<BaseGroupInputElement>();
        public BaseAskingFormGroupChar(string defaultName)
        {
            InitializeComponent();
            this.defaultName = defaultName;
            initArray();      
        }
        protected virtual void initArray()
        {
            textBoxProto.Text = defaultName + "1";
            textBoxProto.Focus();
            textBoxProto.SelectAll();
            var groupEl = new GroupStatDistributionInputElement(ref textBoxProto, ref dataGridProto);
            groups.Add(groupEl);
        }
        private TextBox createNewTextBox()
        {
            var newTextBox = new TextBox();
            newTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            newTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            newTextBox.Location = new System.Drawing.Point(175, 50);
            newTextBox.Multiline = true;
            newTextBox.Name = "textBoxProto";
            newTextBox.Size = new System.Drawing.Size(244, 27);
            newTextBox.TabIndex = 1;
            newTextBox.Text = "Група1";
            newTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            newTextBox.Parent = panel1;
            return newTextBox;
        }
        private void ReadData()
        {
            distrs = new List<SortedDictionary<double, double>>();
            for (var i = 0; i < groups.Count; i++)
            {
                var group = groups[i];
                var distr = group.GetDistribution(i);
                distrs.Add(distr);
            }   
        }
        protected Panel GetPanel()
        {
            return panel1;
        }
        protected TextBox GetTextBoxProto()
        {
            return textBoxProto;
        }
        protected DataGridView GetDataGridViewProto()
        {
            return dataGridProto;
        }
        protected virtual DataGridView createNewDataGridView()
        {
            var newGrid = new DataGridView();
            newGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            var colX = new DataGridViewTextBoxColumn();
            var colN = new DataGridViewTextBoxColumn();
            colX.Name = "X";
            colX.HeaderText = "X";
            colN.Name = "N";
            colN.HeaderText = "N";
            newGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {colX, colN});
            newGrid.Location = new System.Drawing.Point(175, 78);
            newGrid.Name = "newGrid";
            newGrid.Size = new System.Drawing.Size(244, 375);
            newGrid.TabIndex = 0;
            newGrid.Parent = panel1;
            return newGrid;
        }
        protected virtual void AddToGroups(ref TextBox textBox, ref DataGridView dataGrid)
        {
            var groupEl = new GroupStatDistributionInputElement(ref textBox, ref dataGrid);
            groups.Add(groupEl);
        }
        protected void AddElement()
        {
            var newBox = createNewTextBox();
            var newGrid = createNewDataGridView();
            newBox.Left = textBoxProto.Left;
            newGrid.Left = dataGridProto.Left;
            newBox.Top = groups[groups.Count - 1].dataGrid.Bottom + offset;
            newGrid.Top = newBox.Bottom;
            newBox.Text = defaultName + (groups.Count + 1).ToString();
            newGrid.Focus();
            newBox.Focus();
            newBox.SelectAll();

            AddToGroups(ref newBox, ref newGrid);
           // newBox.Location = new Point(textBoxProto)
        }
        private void ShowError(string msg)
        {
            MessageBox.Show(msg, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void RemoveElement()
        {
            if (groups.Count > 1)
            {
                var last = groups[groups.Count - 1];
                panel1.Controls.Remove(last.dataGrid);
                panel1.Controls.Remove(last.textBox);
                groups.RemoveAt(groups.Count - 1);
            }
            else
            {
                ShowError("Неможливо видалити групу. Мінімальна кількість груп - 1");
            }
        }
        private void LaunchNextForm()
        {
            //todo
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddElement();
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            RemoveElement();
        }
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            try
            {
                ReadData();
            }
            catch(Exception error)
            {
                ShowError(error.Message);
            }
            LaunchNextForm();
        }
    }
}
