
namespace ПингПонг
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.Score = new System.Windows.Forms.Label();
			this.Spl1 = new System.Windows.Forms.Label();
			this.Spl2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.Game = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.Game)).BeginInit();
			this.SuspendLayout();
			// 
			// Score
			// 
			this.Score.AutoSize = true;
			this.Score.Cursor = System.Windows.Forms.Cursors.UpArrow;
			this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Score.Location = new System.Drawing.Point(371, 9);
			this.Score.Name = "Score";
			this.Score.Size = new System.Drawing.Size(39, 15);
			this.Score.TabIndex = 1;
			this.Score.Text = "Score";
			// 
			// Spl1
			// 
			this.Spl1.AutoSize = true;
			this.Spl1.Location = new System.Drawing.Point(371, 24);
			this.Spl1.Name = "Spl1";
			this.Spl1.Size = new System.Drawing.Size(13, 13);
			this.Spl1.TabIndex = 2;
			this.Spl1.Text = "0";
			// 
			// Spl2
			// 
			this.Spl2.AutoSize = true;
			this.Spl2.Location = new System.Drawing.Point(397, 24);
			this.Spl2.Name = "Spl2";
			this.Spl2.Size = new System.Drawing.Size(13, 13);
			this.Spl2.TabIndex = 3;
			this.Spl2.Text = "0";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(400, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Restart";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(309, 40);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Start";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Game
			// 
			this.Game.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Game.Location = new System.Drawing.Point(1, 65);
			this.Game.Name = "Game";
			this.Game.Size = new System.Drawing.Size(798, 384);
			this.Game.TabIndex = 6;
			this.Game.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Game);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Spl2);
			this.Controls.Add(this.Spl1);
			this.Controls.Add(this.Score);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Shown += new System.EventHandler(this.Form1_Shown);
			((System.ComponentModel.ISupportInitialize)(this.Game)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label Spl1;
        private System.Windows.Forms.Label Spl2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox Game;
    }
}

