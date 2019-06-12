namespace LabworksProgramProduct
{
    partial class TasksForm1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxIntervalCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.TextBoxKValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(508, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Побудувати варіаційний ряд";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 137);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(245, 54);
            this.button2.TabIndex = 1;
            this.button2.Text = "Побудувати статистичний розподіл частот";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(31, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(245, 54);
            this.button3.TabIndex = 2;
            this.button3.Text = "Побудувати статистичний розподіл відносних частот";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(31, 257);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(245, 54);
            this.button4.TabIndex = 3;
            this.button4.Text = "Побудувати статистичний розподіл накопичуваних частот";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(31, 317);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(245, 54);
            this.button5.TabIndex = 4;
            this.button5.Text = "Побудувати статистичний розподіл відносних накопичувальних частот";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(294, 137);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(245, 54);
            this.button6.TabIndex = 5;
            this.button6.Text = "Побудувати полігон частот";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(294, 197);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(245, 54);
            this.button7.TabIndex = 6;
            this.button7.Text = "Побудувати полігон відносних частот";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(294, 257);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(245, 54);
            this.button8.TabIndex = 7;
            this.button8.Text = "Знайти моду та медіану";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(294, 317);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(245, 54);
            this.button9.TabIndex = 8;
            this.button9.Text = "Побудувати емпіричну функції розподілу";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(366, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Оберіть одну з заданих опцій";
            // 
            // TextBoxIntervalCount
            // 
            this.TextBoxIntervalCount.Location = new System.Drawing.Point(850, 108);
            this.TextBoxIntervalCount.Name = "TextBoxIntervalCount";
            this.TextBoxIntervalCount.Size = new System.Drawing.Size(98, 20);
            this.TextBoxIntervalCount.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(820, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Введіть к-сть інтервалів";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(820, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "m =";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(619, 146);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(245, 54);
            this.button10.TabIndex = 13;
            this.button10.Text = "Побудувати інтервальний розподіл частот";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(870, 146);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(245, 54);
            this.button11.TabIndex = 14;
            this.button11.Text = "Побудувати гістограму частот";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(870, 217);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(245, 54);
            this.button12.TabIndex = 15;
            this.button12.Text = "Побудувати гістограму відносних частот";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(619, 217);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(245, 54);
            this.button13.TabIndex = 16;
            this.button13.Text = "Побудувати емпіричну функцію інтервального розподілу";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(619, 287);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(496, 54);
            this.button14.TabIndex = 17;
            this.button14.Text = "Знайти моду та медіану";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(31, 509);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(508, 54);
            this.button15.TabIndex = 18;
            this.button15.Text = "Знайти числові характеристики вибірки";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Button15_Click);
            // 
            // TextBoxKValue
            // 
            this.TextBoxKValue.Location = new System.Drawing.Point(223, 483);
            this.TextBoxKValue.Name = "TextBoxKValue";
            this.TextBoxKValue.Size = new System.Drawing.Size(126, 20);
            this.TextBoxKValue.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 467);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Введіть порядок емпіричного моменту";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "k =";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(619, 467);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(496, 70);
            this.button16.TabIndex = 23;
            this.button16.Text = "Знайти числові характеристики згрупованих даних";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.Button16_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TasksForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 603);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxKValue);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.TextBoxIntervalCount);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Name = "TasksForm1";
            this.Text = "Оберіть завдання";
            this.Load += new System.EventHandler(this.TasksForm1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxIntervalCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TextBox TextBoxKValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}