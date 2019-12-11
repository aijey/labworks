namespace LabworksProgramProduct
{
    partial class SelectNumberOfIntervalsForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxMVal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxRVal = new System.Windows.Forms.TextBox();
            this.TextBoxNVal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(90, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введіть кількість інтервалів";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "m = ";
            // 
            // TextBoxMVal
            // 
            this.TextBoxMVal.Location = new System.Drawing.Point(195, 58);
            this.TextBoxMVal.Name = "TextBoxMVal";
            this.TextBoxMVal.Size = new System.Drawing.Size(55, 20);
            this.TextBoxMVal.TabIndex = 2;
            this.TextBoxMVal.TextChanged += new System.EventHandler(this.TextBoxMVal_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "R - розмах =";
            // 
            // TextBoxRVal
            // 
            this.TextBoxRVal.Location = new System.Drawing.Point(127, 115);
            this.TextBoxRVal.Name = "TextBoxRVal";
            this.TextBoxRVal.ReadOnly = true;
            this.TextBoxRVal.Size = new System.Drawing.Size(55, 20);
            this.TextBoxRVal.TabIndex = 4;
            // 
            // TextBoxNVal
            // 
            this.TextBoxNVal.Location = new System.Drawing.Point(306, 115);
            this.TextBoxNVal.Name = "TextBoxNVal";
            this.TextBoxNVal.ReadOnly = true;
            this.TextBoxNVal.Size = new System.Drawing.Size(55, 20);
            this.TextBoxNVal.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "n - об\'єм сук. =";
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(151, 181);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(101, 30);
            this.ButtonNext.TabIndex = 7;
            this.ButtonNext.Text = "Далі";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // SelectNumberOfIntervalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 252);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.TextBoxNVal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxRVal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxMVal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SelectNumberOfIntervalsForm";
            this.Text = "SelectNumberOfIntervalsForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxMVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxRVal;
        private System.Windows.Forms.TextBox TextBoxNVal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button ButtonNext;
    }
}