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
    public partial class GroupStatDistrAskingForm : BaseAskingFormGroupChar
    {
        public GroupStatDistrAskingForm(string defaulName) : base(defaulName) { }
        protected override void initArray()
        {
            var textBoxProto = GetTextBoxProto();
            textBoxProto.Text = defaultName + "1";
            textBoxProto.Focus();
            textBoxProto.SelectAll();
            var dataGridProto = GetDataGridViewProto();
            AddToGroups(ref textBoxProto, ref dataGridProto);
        }

        protected override void AddToGroups(ref TextBox textBox, ref DataGridView dataGrid)
        {
            var groupEl = new GroupStatDistributionInputElement(ref textBox, ref dataGrid);
            groups.Add(groupEl);
        }

        protected override DataGridView createNewDataGridView()
        {
            var newGrid = new DataGridView();
            newGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            var colX = new DataGridViewTextBoxColumn();
            var colN = new DataGridViewTextBoxColumn();
            colX.Name = "X";
            colX.HeaderText = "X";
            colN.Name = "N";
            colN.HeaderText = "N";
            newGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colX, colN });
            newGrid.Location = new System.Drawing.Point(175, 78);
            newGrid.Name = "newGrid";
            newGrid.Size = new System.Drawing.Size(244, 375);
            newGrid.TabIndex = 0;
            newGrid.Parent = GetPanel();
            return newGrid;
        }

    }

}
