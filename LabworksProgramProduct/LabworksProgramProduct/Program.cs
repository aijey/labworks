﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabworksProgramProduct
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Lab1Form( );
            var startForm = new Form1();
            if (startForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(form);
            } else
            {
                Application.Exit();
            }
        }
    }
}
