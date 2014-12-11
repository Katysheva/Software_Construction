namespace Lab_6_Observer
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonYellow = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRed
            // 
            this.buttonRed.Location = new System.Drawing.Point(69, 10);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(78, 25);
            this.buttonRed.TabIndex = 0;
            this.buttonRed.Text = "Red";
            this.buttonRed.UseVisualStyleBackColor = true;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // buttonYellow
            // 
            this.buttonYellow.Location = new System.Drawing.Point(69, 41);
            this.buttonYellow.Name = "buttonYellow";
            this.buttonYellow.Size = new System.Drawing.Size(78, 25);
            this.buttonYellow.TabIndex = 1;
            this.buttonYellow.Text = "Yellow";
            this.buttonYellow.UseVisualStyleBackColor = true;
            this.buttonYellow.Click += new System.EventHandler(this.buttonYellow_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.Location = new System.Drawing.Point(69, 72);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(78, 25);
            this.buttonGreen.TabIndex = 2;
            this.buttonGreen.Text = "Green";
            this.buttonGreen.UseVisualStyleBackColor = true;
            this.buttonGreen.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 217);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGreen);
            this.Controls.Add(this.buttonYellow);
            this.Controls.Add(this.buttonRed);
            this.Name = "FormMain";
            this.Text = "Observer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonYellow;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}

