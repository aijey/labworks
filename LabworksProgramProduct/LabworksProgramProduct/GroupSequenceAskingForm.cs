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
    public partial class GroupSequenceAskingForm : BaseAskingFormGroupChar
    {
        public GroupSequenceAskingForm(string defaultName): base(defaultName)
        {
        }
        protected int XWidth = 0;
        
        protected override void initArray()
        {
            var textBoxProto = GetTextBoxProto();
            var dataGridProto = GetDataGridViewProto();
            textBoxProto.Text = defaultName + "1";
            textBoxProto.Focus();
            textBoxProto.SelectAll();
            AddToGroups(ref textBoxProto, ref dataGridProto);

            var secondColLength = groups[0].dataGrid.Columns[1].Width;
            groups[0].dataGrid.Columns.RemoveAt(groups[0].dataGrid.Columns.Count - 1);
            groups[0].dataGrid.Columns[0].Width += secondColLength;
            XWidth = groups[0].dataGrid.Columns[0].Width;
        }
        protected override void AddToGroups(ref TextBox textBox, ref DataGridView dataGrid)
        {
            var groupEl = new GroupSequenceInputElement(ref textBox, ref dataGrid);
            groups.Add(groupEl);
        }
        protected override DataGridView createNewDataGridView()
        {
            var newGrid = new DataGridView();
            newGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            var colX = new DataGridViewTextBoxColumn();
            colX.Name = "X";
            colX.HeaderText = "X";
            colX.Width = XWidth;
            newGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colX });
            newGrid.Location = new System.Drawing.Point(175, 78);
            newGrid.Name = "newGrid";
            newGrid.Size = new System.Drawing.Size(244, 375);
            newGrid.TabIndex = 0;
            newGrid.Parent = GetPanel();
            return newGrid;
        }
    }
}
