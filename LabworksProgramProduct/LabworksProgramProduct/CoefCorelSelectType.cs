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
        Forms NextForm;
        public CoefCorelSelectType(Forms nextForm)
        {
            NextForm = nextForm;
            InitializeComponent();
        }

        private void ButtonInputPairs_Click(object sender, EventArgs e)
        {
            var form = new AskingFormPairs(AskingForms.Pairs, NextForm);
            form.Show();
            this.Close();
        }

        private void ButtonInputMatrix_Click(object sender, EventArgs e)
        {
            var form = new AskingFormPairs(AskingForms.Matrix, NextForm);
            form.Show();
            this.Close();
        }

        private void ButtonInputMatrixFromFile_Click(object sender, EventArgs e)
        {
            var form = new AskingFormPairs(AskingForms.MatrixFromFile, NextForm);
            this.Close();
        }
    }
}
