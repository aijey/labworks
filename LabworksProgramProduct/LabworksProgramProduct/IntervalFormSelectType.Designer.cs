namespace LabworksProgramProduct
{
    partial class IntervalFormSelectType
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
            this.ButtonIntervalDistr = new System.Windows.Forms.Button();
            this.ButtonStatisticFromFile = new System.Windows.Forms.Button();
            this.ButtonStatisticDistr = new System.Windows.Forms.Button();
            this.ButtonVariantRow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonIntervalFromFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonIntervalDistr
            // 
            this.ButtonIntervalDistr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ButtonIntervalDistr.Location = new System.Drawing.Point(226, 250);
            this.ButtonIntervalDistr.Name = "ButtonIntervalDistr";
            this.ButtonIntervalDistr.Size = new System.Drawing.Size(340, 42);
            this.ButtonIntervalDistr.TabIndex = 11;
            this.ButtonIntervalDistr.Text = "Ввід інтервального розподілу\r\n";
            this.ButtonIntervalDistr.UseVisualStyleBackColor = true;
            this.ButtonIntervalDistr.Click += new System.EventHandler(this.ButtonIntervalDistr_Click);
            // 
            // ButtonStatisticFromFile
            // 
            this.ButtonStatisticFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ButtonStatisticFromFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonStatisticFromFile.Location = new System.Drawing.Point(226, 310);
            this.ButtonStatisticFromFile.Name = "ButtonStatisticFromFile";
            this.ButtonStatisticFromFile.Size = new System.Drawing.Size(340, 42);
            this.ButtonStatisticFromFile.TabIndex = 10;
            this.ButtonStatisticFromFile.Text = "Ввід статистичного розподілу з файлу";
            this.ButtonStatisticFromFile.UseVisualStyleBackColor = true;
            this.ButtonStatisticFromFile.Click += new System.EventHandler(this.ButtonStatisticFromFile_Click);
            // 
            // ButtonStatisticDistr
            // 
            this.ButtonStatisticDistr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ButtonStatisticDistr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonStatisticDistr.Location = new System.Drawing.Point(226, 190);
            this.ButtonStatisticDistr.Name = "ButtonStatisticDistr";
            this.ButtonStatisticDistr.Size = new System.Drawing.Size(340, 42);
            this.ButtonStatisticDistr.TabIndex = 9;
            this.ButtonStatisticDistr.Text = "Ввід статистичного розподілу";
            this.ButtonStatisticDistr.UseVisualStyleBackColor = true;
            this.ButtonStatisticDistr.Click += new System.EventHandler(this.ButtonStatisticDistr_Click);
            // 
            // ButtonVariantRow
            // 
            this.ButtonVariantRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ButtonVariantRow.Location = new System.Drawing.Point(226, 130);
            this.ButtonVariantRow.Name = "ButtonVariantRow";
            this.ButtonVariantRow.Size = new System.Drawing.Size(340, 42);
            this.ButtonVariantRow.TabIndex = 8;
            this.ButtonVariantRow.Text = "Набір послідовних значень";
            this.ButtonVariantRow.UseVisualStyleBackColor = true;
            this.ButtonVariantRow.Click += new System.EventHandler(this.ButtonVariantRow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(291, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Оберіть тип вводу даних";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(166, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введення значень ознаки, яку досліджуєте";
            // 
            // ButtonIntervalFromFile
            // 
            this.ButtonIntervalFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ButtonIntervalFromFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonIntervalFromFile.Location = new System.Drawing.Point(226, 370);
            this.ButtonIntervalFromFile.Name = "ButtonIntervalFromFile";
            this.ButtonIntervalFromFile.Size = new System.Drawing.Size(340, 42);
            this.ButtonIntervalFromFile.TabIndex = 12;
            this.ButtonIntervalFromFile.Text = "Ввід інтервального розподілу з файлу";
            this.ButtonIntervalFromFile.UseVisualStyleBackColor = true;
            // 
            // IntervalFormSelectType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.ButtonIntervalFromFile);
            this.Controls.Add(this.ButtonIntervalDistr);
            this.Controls.Add(this.ButtonStatisticFromFile);
            this.Controls.Add(this.ButtonStatisticDistr);
            this.Controls.Add(this.ButtonVariantRow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IntervalFormSelectType";
            this.Text = "IntervalFormSelectType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonIntervalDistr;
        private System.Windows.Forms.Button ButtonStatisticFromFile;
        private System.Windows.Forms.Button ButtonStatisticDistr;
        private System.Windows.Forms.Button ButtonVariantRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonIntervalFromFile;
    }
}