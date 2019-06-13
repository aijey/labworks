using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace LabworksProgramProduct
{
    class Page
    {
        public string[] Definitions;
        public Panel panel;
        public List<PictureBox> PictureBoxes = new List<PictureBox>();
        public Page(string[] definitions)
        {
            Definitions = definitions;
            panel = new Panel();
        }
    }
}
