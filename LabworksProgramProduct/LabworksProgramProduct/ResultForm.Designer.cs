namespace LabworksProgramProduct
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSaveVariantRow = new System.Windows.Forms.Button();
            this.dataGridVariantRow = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSaveStaticDistr = new System.Windows.Forms.Button();
            this.dataGridStaticDistrRow = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridStaticRelDistr = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridStaticIncDistr = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridStaticRelIncDistr = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.FreqPolygon = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.RelFreqPolygon = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.labelModa = new System.Windows.Forms.Label();
            this.labelMedian = new System.Windows.Forms.Label();
            this.textBoxModa = new System.Windows.Forms.TextBox();
            this.textBoxMedian = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVariantRow)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStaticDistrRow)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStaticRelDistr)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStaticIncDistr)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStaticRelIncDistr)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FreqPolygon)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RelFreqPolygon)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.buttonSaveVariantRow);
            this.panel1.Controls.Add(this.dataGridVariantRow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 153);
            this.panel1.TabIndex = 0;
            // 
            // buttonSaveVariantRow
            // 
            this.buttonSaveVariantRow.Location = new System.Drawing.Point(254, 107);
            this.buttonSaveVariantRow.Name = "buttonSaveVariantRow";
            this.buttonSaveVariantRow.Size = new System.Drawing.Size(239, 33);
            this.buttonSaveVariantRow.TabIndex = 2;
            this.buttonSaveVariantRow.Text = "Зберегти в файл";
            this.buttonSaveVariantRow.UseVisualStyleBackColor = true;
            this.buttonSaveVariantRow.Click += new System.EventHandler(this.ButtonSaveVariantRow_Click);
            // 
            // dataGridVariantRow
            // 
            this.dataGridVariantRow.AllowUserToAddRows = false;
            this.dataGridVariantRow.AllowUserToDeleteRows = false;
            this.dataGridVariantRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVariantRow.Location = new System.Drawing.Point(17, 52);
            this.dataGridVariantRow.Name = "dataGridVariantRow";
            this.dataGridVariantRow.ReadOnly = true;
            this.dataGridVariantRow.Size = new System.Drawing.Size(745, 38);
            this.dataGridVariantRow.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(250, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Статистичний варіаційний ряд";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.buttonSaveStaticDistr);
            this.panel2.Controls.Add(this.dataGridStaticDistrRow);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 194);
            this.panel2.TabIndex = 3;
            // 
            // buttonSaveStaticDistr
            // 
            this.buttonSaveStaticDistr.Location = new System.Drawing.Point(254, 145);
            this.buttonSaveStaticDistr.Name = "buttonSaveStaticDistr";
            this.buttonSaveStaticDistr.Size = new System.Drawing.Size(239, 33);
            this.buttonSaveStaticDistr.TabIndex = 2;
            this.buttonSaveStaticDistr.Text = "Зберегти в файл";
            this.buttonSaveStaticDistr.UseVisualStyleBackColor = true;
            this.buttonSaveStaticDistr.Click += new System.EventHandler(this.ButtonSaveStaticDistr_Click);
            // 
            // dataGridStaticDistrRow
            // 
            this.dataGridStaticDistrRow.AllowUserToAddRows = false;
            this.dataGridStaticDistrRow.AllowUserToDeleteRows = false;
            this.dataGridStaticDistrRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStaticDistrRow.Location = new System.Drawing.Point(17, 52);
            this.dataGridStaticDistrRow.Name = "dataGridStaticDistrRow";
            this.dataGridStaticDistrRow.ReadOnly = true;
            this.dataGridStaticDistrRow.Size = new System.Drawing.Size(745, 71);
            this.dataGridStaticDistrRow.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(250, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Статистичний розподіл частот";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.dataGridStaticRelDistr);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 371);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 139);
            this.panel3.TabIndex = 4;
            // 
            // dataGridStaticRelDistr
            // 
            this.dataGridStaticRelDistr.AllowUserToAddRows = false;
            this.dataGridStaticRelDistr.AllowUserToDeleteRows = false;
            this.dataGridStaticRelDistr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStaticRelDistr.Location = new System.Drawing.Point(17, 52);
            this.dataGridStaticRelDistr.Name = "dataGridStaticRelDistr";
            this.dataGridStaticRelDistr.ReadOnly = true;
            this.dataGridStaticRelDistr.Size = new System.Drawing.Size(745, 71);
            this.dataGridStaticRelDistr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(214, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Статистичний розподіл відносних частот";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.dataGridStaticIncDistr);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(12, 516);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(776, 139);
            this.panel4.TabIndex = 5;
            // 
            // dataGridStaticIncDistr
            // 
            this.dataGridStaticIncDistr.AllowUserToAddRows = false;
            this.dataGridStaticIncDistr.AllowUserToDeleteRows = false;
            this.dataGridStaticIncDistr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStaticIncDistr.Location = new System.Drawing.Point(17, 52);
            this.dataGridStaticIncDistr.Name = "dataGridStaticIncDistr";
            this.dataGridStaticIncDistr.ReadOnly = true;
            this.dataGridStaticIncDistr.Size = new System.Drawing.Size(745, 71);
            this.dataGridStaticIncDistr.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(188, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(397, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Статистичний розподіл накопичуваних частот";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.Controls.Add(this.dataGridStaticRelIncDistr);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(12, 661);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(776, 139);
            this.panel5.TabIndex = 6;
            // 
            // dataGridStaticRelIncDistr
            // 
            this.dataGridStaticRelIncDistr.AllowUserToAddRows = false;
            this.dataGridStaticRelIncDistr.AllowUserToDeleteRows = false;
            this.dataGridStaticRelIncDistr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStaticRelIncDistr.Location = new System.Drawing.Point(17, 52);
            this.dataGridStaticRelIncDistr.Name = "dataGridStaticRelIncDistr";
            this.dataGridStaticRelIncDistr.ReadOnly = true;
            this.dataGridStaticRelIncDistr.Size = new System.Drawing.Size(745, 71);
            this.dataGridStaticRelIncDistr.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.Location = new System.Drawing.Point(149, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(485, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Статистичний розподіл відносних накопичуваних частот";
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel6.Controls.Add(this.FreqPolygon);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(12, 806);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(776, 406);
            this.panel6.TabIndex = 7;
            // 
            // FreqPolygon
            // 
            chartArea1.Name = "ChartArea1";
            this.FreqPolygon.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.FreqPolygon.Legends.Add(legend1);
            this.FreqPolygon.Location = new System.Drawing.Point(17, 64);
            this.FreqPolygon.Name = "FreqPolygon";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.FreqPolygon.Series.Add(series1);
            this.FreqPolygon.Size = new System.Drawing.Size(745, 300);
            this.FreqPolygon.TabIndex = 1;
            this.FreqPolygon.Text = "chart1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label6.Location = new System.Drawing.Point(305, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Полігон частот";
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel7.Controls.Add(this.RelFreqPolygon);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(12, 1218);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(776, 362);
            this.panel7.TabIndex = 8;
            // 
            // RelFreqPolygon
            // 
            chartArea2.Name = "ChartArea1";
            this.RelFreqPolygon.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.RelFreqPolygon.Legends.Add(legend2);
            this.RelFreqPolygon.Location = new System.Drawing.Point(17, 59);
            this.RelFreqPolygon.Name = "RelFreqPolygon";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.RelFreqPolygon.Series.Add(series2);
            this.RelFreqPolygon.Size = new System.Drawing.Size(745, 300);
            this.RelFreqPolygon.TabIndex = 1;
            this.RelFreqPolygon.Text = "chart1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label7.Location = new System.Drawing.Point(271, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(222, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Полігон відносних частот";
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel8.Controls.Add(this.textBoxMedian);
            this.panel8.Controls.Add(this.textBoxModa);
            this.panel8.Controls.Add(this.labelMedian);
            this.panel8.Controls.Add(this.labelModa);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(12, 1586);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(776, 115);
            this.panel8.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label8.Location = new System.Drawing.Point(318, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Мода і медіана";
            // 
            // labelModa
            // 
            this.labelModa.AutoSize = true;
            this.labelModa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelModa.Location = new System.Drawing.Point(119, 54);
            this.labelModa.Name = "labelModa";
            this.labelModa.Size = new System.Drawing.Size(51, 17);
            this.labelModa.TabIndex = 1;
            this.labelModa.Text = "Мода: ";
            // 
            // labelMedian
            // 
            this.labelMedian.AutoSize = true;
            this.labelMedian.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelMedian.Location = new System.Drawing.Point(119, 89);
            this.labelMedian.Name = "labelMedian";
            this.labelMedian.Size = new System.Drawing.Size(70, 17);
            this.labelMedian.TabIndex = 2;
            this.labelMedian.Text = "Медіана: ";
            // 
            // textBoxModa
            // 
            this.textBoxModa.Location = new System.Drawing.Point(232, 51);
            this.textBoxModa.Name = "textBoxModa";
            this.textBoxModa.ReadOnly = true;
            this.textBoxModa.Size = new System.Drawing.Size(100, 20);
            this.textBoxModa.TabIndex = 3;
            // 
            // textBoxMedian
            // 
            this.textBoxMedian.Location = new System.Drawing.Point(232, 86);
            this.textBoxMedian.Name = "textBoxMedian";
            this.textBoxMedian.ReadOnly = true;
            this.textBoxMedian.Size = new System.Drawing.Size(100, 20);
            this.textBoxMedian.TabIndex = 4;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(830, 573);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ResultForm";
            this.Text = "Результат";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVariantRow)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStaticDistrRow)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStaticRelDistr)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStaticIncDistr)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStaticRelIncDistr)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FreqPolygon)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RelFreqPolygon)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSaveVariantRow;
        private System.Windows.Forms.DataGridView dataGridVariantRow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSaveStaticDistr;
        private System.Windows.Forms.DataGridView dataGridStaticDistrRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridStaticRelDistr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridStaticIncDistr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridStaticRelIncDistr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart FreqPolygon;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataVisualization.Charting.Chart RelFreqPolygon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxMedian;
        private System.Windows.Forms.TextBox textBoxModa;
        private System.Windows.Forms.Label labelMedian;
        private System.Windows.Forms.Label labelModa;
    }
}