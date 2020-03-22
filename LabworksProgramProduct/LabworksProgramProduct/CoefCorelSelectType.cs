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
    public partial class CoefCorelSelectType : Form
    {
        public CoefCorelSelectType()
        {
            InitializeComponent();
        }

        private void ButtonInputPairs_Click(object sender, EventArgs e)
        {
            var form = new AskingFormPairs(AskingForms.Pairs, Forms.CoefCorelTasksForm);
            form.Show();
            this.Close();
        }

        private void ButtonInputMatrix_Click(object sender, EventArgs e)
        {
            var form = new AskingFormPairs(AskingForms.Matrix, Forms.CoefCorelTasksForm);
            form.Show();
            this.Close();
        }

        private void ButtonInputMatrixFromFile_Click(object sender, EventArgs e)
        {
            var form = new AskingFormPairs(AskingForms.MatrixFromFile, Forms.CoefCorelTasksForm);
            this.Close();
        }
    }
}
