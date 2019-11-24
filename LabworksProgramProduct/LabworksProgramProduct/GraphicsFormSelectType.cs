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
    public partial class GraphicsFormSelectType : Form
    {
        public GraphicsFormSelectType()
        {
            InitializeComponent();
        }

        private void ButtonManual1_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(1, Forms.GraphicsTasksForm);
            form.Show();
            Close();
        }

        private void ButtonManualStatic_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(2, Forms.GraphicsTasksForm);
            form.Show();
            Close();
        }

        private void ButtonManualInterval_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonStaticFromFile_Click(object sender, EventArgs e)
        {
            var form = new AskingFormDataSource(4, Forms.GraphicsTasksForm);
            Close();
        }
    }
}
