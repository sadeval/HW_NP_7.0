namespace HW_NP_7._0
{
    partial class Form1
    {
        // Объявление компонентов
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPlayerTurn;
        private System.Windows.Forms.PictureBox pbDice;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.RadioButton rbHumanVsHuman;
        private System.Windows.Forms.RadioButton rbHumanVsComputer;
        private System.Windows.Forms.Label lblPlayer1Score;
        private System.Windows.Forms.Label lblPlayer2Score;

        // Метод очистки используемых ресурсов.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        // Инициализация компонентов формы
        private void InitializeComponent()
        {
            this.lblPlayerTurn = new System.Windows.Forms.Label();
            this.pbDice = new System.Windows.Forms.PictureBox();
            this.btnRoll = new System.Windows.Forms.Button();
            this.rbHumanVsHuman = new System.Windows.Forms.RadioButton();
            this.rbHumanVsComputer = new System.Windows.Forms.RadioButton();
            this.lblPlayer1Score = new System.Windows.Forms.Label();
            this.lblPlayer2Score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerTurn
            // 
            this.lblPlayerTurn.AutoSize = true;
            this.lblPlayerTurn.Location = new System.Drawing.Point(12, 9);
            this.lblPlayerTurn.Name = "lblPlayerTurn";
            this.lblPlayerTurn.Size = new System.Drawing.Size(89, 16);
            this.lblPlayerTurn.TabIndex = 0;
            this.lblPlayerTurn.Text = "Ход игрока 1";
            // 
            // pbDice
            // 
            this.pbDice.Location = new System.Drawing.Point(15, 35);
            this.pbDice.Name = "pbDice";
            this.pbDice.Size = new System.Drawing.Size(154, 148);
            this.pbDice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDice.TabIndex = 1;
            this.pbDice.TabStop = false;
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(15, 205);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(100, 23);
            this.btnRoll.TabIndex = 2;
            this.btnRoll.Text = "Бросить кость";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // rbHumanVsHuman
            // 
            this.rbHumanVsHuman.AutoSize = true;
            this.rbHumanVsHuman.Checked = true;
            this.rbHumanVsHuman.Location = new System.Drawing.Point(188, 35);
            this.rbHumanVsHuman.Name = "rbHumanVsHuman";
            this.rbHumanVsHuman.Size = new System.Drawing.Size(160, 20);
            this.rbHumanVsHuman.TabIndex = 3;
            this.rbHumanVsHuman.TabStop = true;
            this.rbHumanVsHuman.Text = "Человек vs Человек";
            this.rbHumanVsHuman.UseVisualStyleBackColor = true;
            this.rbHumanVsHuman.CheckedChanged += new System.EventHandler(this.rbHumanVsHuman_CheckedChanged);
            // 
            // rbHumanVsComputer
            // 
            this.rbHumanVsComputer.AutoSize = true;
            this.rbHumanVsComputer.Location = new System.Drawing.Point(188, 61);
            this.rbHumanVsComputer.Name = "rbHumanVsComputer";
            this.rbHumanVsComputer.Size = new System.Drawing.Size(177, 20);
            this.rbHumanVsComputer.TabIndex = 4;
            this.rbHumanVsComputer.Text = "Человек vs Компьютер";
            this.rbHumanVsComputer.UseVisualStyleBackColor = true;
            this.rbHumanVsComputer.CheckedChanged += new System.EventHandler(this.rbHumanVsComputer_CheckedChanged);
            // 
            // lblPlayer1Score
            // 
            this.lblPlayer1Score.AutoSize = true;
            this.lblPlayer1Score.Location = new System.Drawing.Point(185, 97);
            this.lblPlayer1Score.Name = "lblPlayer1Score";
            this.lblPlayer1Score.Size = new System.Drawing.Size(110, 16);
            this.lblPlayer1Score.TabIndex = 5;
            this.lblPlayer1Score.Text = "Счет игрока 1: 0";
            // 
            // lblPlayer2Score
            // 
            this.lblPlayer2Score.AutoSize = true;
            this.lblPlayer2Score.Location = new System.Drawing.Point(185, 130);
            this.lblPlayer2Score.Name = "lblPlayer2Score";
            this.lblPlayer2Score.Size = new System.Drawing.Size(110, 16);
            this.lblPlayer2Score.TabIndex = 6;
            this.lblPlayer2Score.Text = "Счет игрока 2: 0";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(374, 240);
            this.Controls.Add(this.lblPlayer2Score);
            this.Controls.Add(this.lblPlayer1Score);
            this.Controls.Add(this.rbHumanVsComputer);
            this.Controls.Add(this.rbHumanVsHuman);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.pbDice);
            this.Controls.Add(this.lblPlayerTurn);
            this.Name = "Form1";
            this.Text = "Игра в Кости";
            ((System.ComponentModel.ISupportInitialize)(this.pbDice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
