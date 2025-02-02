﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace LabworksProgramProduct
{
    public partial class ResultFormInterval : Form
    {
        SortedDictionary<Interval, double> Dict;
        List<int> TasksList;
        public ResultFormInterval(SortedDictionary<Interval, double> dict, List<int> tasks)
        {
            InitializeComponent();
            TasksList = tasks;
            Dict = dict;
            SelectPanels();
        }
        private void SelectPanels()
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            int prevTop = 0;
            foreach (var item in TasksList)
            {
                if (item == 1)
                {
                    panel1.Show();
                    panel1.Top = prevTop + 12;
                    prevTop = panel1.Top + panel1.Height;
                    dataGridView1.RowCount = 2;
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.RowHeadersWidth = 60;
                    dataGridView1.Rows[0].HeaderCell.Value = "I";
                    dataGridView1.Rows[1].HeaderCell.Value = "Ni";
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView1.ColumnCount = Dict.Keys.Count;
                    int cnt = 0;
                    foreach (var i in Dict)
                    {
                        dataGridView1[cnt, 0].Value = i.Key.ToString();
                        dataGridView1[cnt++, 1].Value = i.Value;
                    }
                }
                else if (item == 2)
                {
                    panel2.Show();
                    panel2.Top = prevTop + 12;
                    prevTop = panel2.Top + panel2.Height;
                    dataGridView2.RowCount = 2;
                    dataGridView2.ColumnHeadersVisible = false;
                    dataGridView2.RowHeadersWidth = 60;
                    dataGridView2.Rows[0].HeaderCell.Value = "I";
                    dataGridView2.Rows[1].HeaderCell.Value = "Wi";
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView2.ColumnCount = Dict.Keys.Count;
                    int cnt = 0;
                    double N = Dict.Sum(x => x.Value);
                    foreach (var i in Dict)
                    {
                        dataGridView2[cnt, 0].Value = i.Key.ToString();
                        dataGridView2[cnt++, 1].Value = i.Value / N;
                    }
                }
                else if (item == 3)
                {
                    panel3.Show();
                    panel3.Top = prevTop + 12;
                    prevTop = panel3.Top + panel3.Height;
                    textBoxModa.Text = Tasks.GetIntervalModa(Dict).ToString();
                    textBoxMedian.Text = Tasks.GetIntervalMed(Dict).ToString();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dial = new SaveFileDialog();
            if (dial.ShowDialog() == DialogResult.OK)
            {
                string path = dial.FileName;
                using (var writer = new StreamWriter(path))
                {
                    foreach (var item in Dict)
                    {
                        string line = "";
                        line += item.Key.ToString();
                        line += ' ' + item.Value.ToString(CultureInfo.InvariantCulture);
                        writer.WriteLine(line);
                    }
                }
            }
        }

        private void ButtonSaveRelStatDistr_Click(object sender, EventArgs e)
        {
            var dial = new SaveFileDialog();
            if (dial.ShowDialog() == DialogResult.OK)
            {
                string path = dial.FileName;
                var dict = Tasks.GetIntervalRelStatDistr(Dict);
                using (var writer = new StreamWriter(path))
                {
                    foreach (var item in dict)
                    {
                        string line = "";
                        line += item.Key.ToString();
                        line += ' ' + item.Value.ToString(CultureInfo.InvariantCulture);
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
