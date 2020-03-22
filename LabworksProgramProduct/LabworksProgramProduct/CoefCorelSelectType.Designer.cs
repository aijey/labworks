namespace LabworksProgramProduct
{
    partial class CoefCorelSelectType
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
            this.ButtonInputMatrixFromFile = new System.Windows.Forms.Button();
            this.ButtonInputMatrix = new System.Windows.Forms.Button();
            this.ButtonInputPairs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonInputMatrixFromFile
            // 
            this.ButtonInputMatrixFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ButtonInputMatrixFromFile.Location = new System.Drawing.Point(218, 260);
            this.ButtonInputMatrixFromFile.Name = "ButtonInputMatrixFromFile";
            this.ButtonInputMatrixFromFile.Size = new System.Drawing.Size(340, 42);
            this.ButtonInputMatrixFromFile.TabIndex = 23;
            this.ButtonInputMatrixFromFile.Text = "Ввід матриці з файлу";
            this.ButtonInputMatrixFromFile.UseVisualStyleBackColor = true;
            this.ButtonInputMatrixFromFile.Click += new System.EventHandler(this.ButtonInputMatrixFromFile_Click);
            // 
            // ButtonInputMatrix
            // 
            this.ButtonInputMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ButtonInputMatrix.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonInputMatrix.Location = new System.Drawing.Point(218, 200);
            this.ButtonInputMatrix.Name = "ButtonInputMatrix";
            this.ButtonInputMatrix.Size = new System.Drawing.Size(340, 42);
            this.ButtonInputMatrix.TabIndex = 22;
            this.ButtonInputMatrix.Text = "Ввід матриці значень\r\n";
            this.ButtonInputMatrix.UseVisualStyleBackColor = true;
            this.ButtonInputMatrix.Click += new System.EventHandler(this.ButtonInputMatrix_Click);
            // 
            // ButtonInputPairs
            // 
            this.ButtonInputPairs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ButtonInputPairs.Location = new System.Drawing.Point(218, 140);
            this.ButtonInputPairs.Name = "ButtonInputPairs";
            this.ButtonInputPairs.Size = new System.Drawing.Size(340, 42);
            this.ButtonInputPairs.TabIndex = 21;
            this.ButtonInputPairs.Text = "Набір пар значень виду (Xi, Yi)\r\n";
            this.ButtonInputPairs.UseVisualStyleBackColor = true;
            this.ButtonInputPairs.Click += new System.EventHandler(this.ButtonInputPairs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(286, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Оберіть тип вводу даних";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(73, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(666, 26);
            this.label1.TabIndex = 19;
            this.label1.Text = "Введіть матрицю сумісної появи значень ознак для X та Y";
            // 
            // CoefCorelSelectType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 352);
            this.Controls.Add(this.ButtonInputMatrixFromFile);
            this.Controls.Add(this.ButtonInputMatrix);
            this.Controls.Add(this.ButtonInputPairs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CoefCorelSelectType";
            this.Text = "√";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonInputMatrixFromFile;
        private System.Windows.Forms.Button ButtonInputMatrix;
        private System.Windows.Forms.Button ButtonInputPairs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}