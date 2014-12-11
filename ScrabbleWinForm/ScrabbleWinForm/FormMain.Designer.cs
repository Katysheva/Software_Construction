namespace ScrabbleWinForm
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.labelPlayerInfo = new System.Windows.Forms.Label();
            this.pictureBoxLetters = new System.Windows.Forms.PictureBox();
            this.buttonNextPlayer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLetters)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(368, 10);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(630, 630);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            // 
            // labelPlayerInfo
            // 
            this.labelPlayerInfo.AutoSize = true;
            this.labelPlayerInfo.Location = new System.Drawing.Point(152, 10);
            this.labelPlayerInfo.Name = "labelPlayerInfo";
            this.labelPlayerInfo.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerInfo.TabIndex = 1;
            this.labelPlayerInfo.Text = "label1";
            // 
            // pictureBoxLetters
            // 
            this.pictureBoxLetters.Location = new System.Drawing.Point(368, 646);
            this.pictureBoxLetters.Name = "pictureBoxLetters";
            this.pictureBoxLetters.Size = new System.Drawing.Size(630, 50);
            this.pictureBoxLetters.TabIndex = 2;
            this.pictureBoxLetters.TabStop = false;
            this.pictureBoxLetters.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLetters_MouseDown);
            // 
            // buttonNextPlayer
            // 
            this.buttonNextPlayer.Location = new System.Drawing.Point(1114, 662);
            this.buttonNextPlayer.Name = "buttonNextPlayer";
            this.buttonNextPlayer.Size = new System.Drawing.Size(148, 34);
            this.buttonNextPlayer.TabIndex = 3;
            this.buttonNextPlayer.Text = "Next player";
            this.buttonNextPlayer.UseVisualStyleBackColor = true;
            this.buttonNextPlayer.Click += new System.EventHandler(this.buttonNextPlayer_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.buttonNextPlayer);
            this.Controls.Add(this.pictureBoxLetters);
            this.Controls.Add(this.labelPlayerInfo);
            this.Controls.Add(this.canvas);
            this.Name = "FormMain";
            this.Text = "Scrabble";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLetters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label labelPlayerInfo;
        private System.Windows.Forms.PictureBox pictureBoxLetters;
        private System.Windows.Forms.Button buttonNextPlayer;
    }
}

