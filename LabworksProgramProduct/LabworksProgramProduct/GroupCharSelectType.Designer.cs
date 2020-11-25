namespace LabworksProgramProduct
{
    partial class GroupCharSelectType
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
            this.ButtonSeq = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStatDistr = new System.Windows.Forms.Button();
            this.buttonStatDistrFromFile = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ButtonSeq
            // 
            this.ButtonSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ButtonSeq.Location = new System.Drawing.Point(221, 139);
            this.ButtonSeq.Name = "ButtonSeq";
            this.ButtonSeq.Size = new System.Drawing.Size(340, 42);
            this.ButtonSeq.TabIndex = 24;
            this.ButtonSeq.Text = "Набір послідовних значень";
            this.ButtonSeq.UseVisualStyleBackColor = true;
            this.ButtonSeq.Click += new System.EventHandler(this.ButtonSeq_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(297, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Оберіть тип вводу даних";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(139, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 26);
            this.label1.TabIndex = 22;
            this.label1.Text = "Введіть кількість груп (ознак    ) дослідження";
            // 
            // buttonStatDistr
            // 
            this.buttonStatDistr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonStatDistr.Location = new System.Drawing.Point(221, 200);
            this.buttonStatDistr.Name = "buttonStatDistr";
            this.buttonStatDistr.Size = new System.Drawing.Size(340, 42);
            this.buttonStatDistr.TabIndex = 25;
            this.buttonStatDistr.Text = "Ввід статистичного розподілу";
            this.buttonStatDistr.UseVisualStyleBackColor = true;
            this.buttonStatDistr.Click += new System.EventHandler(this.ButtonStatDistr_Click);
            // 
            // buttonStatDistrFromFile
            // 
            this.buttonStatDistrFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonStatDistrFromFile.Location = new System.Drawing.Point(221, 261);
            this.buttonStatDistrFromFile.Name = "buttonStatDistrFromFile";
            this.buttonStatDistrFromFile.Size = new System.Drawing.Size(340, 42);
            this.buttonStatDistrFromFile.TabIndex = 26;
            this.buttonStatDistrFromFile.Text = "Ввід статистичного розподілу з файлу";
            this.buttonStatDistrFromFile.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(475, 48);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // GroupCharSelectType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonStatDistrFromFile);
            this.Controls.Add(this.buttonStatDistr);
            this.Controls.Add(this.ButtonSeq);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GroupCharSelectType";
            this.Text = "GroupCharSelectType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonSeq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStatDistr;
        private System.Windows.Forms.Button buttonStatDistrFromFile;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}