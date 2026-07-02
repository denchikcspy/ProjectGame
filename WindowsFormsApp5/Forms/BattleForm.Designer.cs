namespace WindowsFormsApp5.Forms
{
    partial class BattleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleForm));
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.progressBarPlayerMP = new System.Windows.Forms.ProgressBar();
            this.labelCooldown = new System.Windows.Forms.Label();
            this.progressBarPlayerHP = new System.Windows.Forms.ProgressBar();
            this.lblPlayerHP = new System.Windows.Forms.Label();
            this.lblPlayerMP = new System.Windows.Forms.Label();
            this.lblEnemyHP = new System.Windows.Forms.Label();
            this.progressBarEnemyHP = new System.Windows.Forms.ProgressBar();
            this.lblEnemyName = new System.Windows.Forms.Label();
            this.lblEnemyLevel = new System.Windows.Forms.Label();
            this.richTextBoxBattleLog = new System.Windows.Forms.RichTextBox();
            this.pictureBoxPlayer = new System.Windows.Forms.PictureBox();
            this.pictureBoxEnemy = new System.Windows.Forms.PictureBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.btnStrongAttack = new System.Windows.Forms.Button();
            this.btnRepair = new System.Windows.Forms.Button();
            this.btnRest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(57, 33);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(35, 13);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "label1";
            // 
            // progressBarPlayerMP
            // 
            this.progressBarPlayerMP.Location = new System.Drawing.Point(87, 389);
            this.progressBarPlayerMP.Name = "progressBarPlayerMP";
            this.progressBarPlayerMP.Size = new System.Drawing.Size(100, 23);
            this.progressBarPlayerMP.TabIndex = 1;
            // 
            // labelCooldown
            // 
            this.labelCooldown.AutoSize = true;
            this.labelCooldown.Location = new System.Drawing.Point(184, 33);
            this.labelCooldown.Name = "labelCooldown";
            this.labelCooldown.Size = new System.Drawing.Size(35, 13);
            this.labelCooldown.TabIndex = 2;
            this.labelCooldown.Text = "label2";
            // 
            // progressBarPlayerHP
            // 
            this.progressBarPlayerHP.Location = new System.Drawing.Point(51, 313);
            this.progressBarPlayerHP.Name = "progressBarPlayerHP";
            this.progressBarPlayerHP.Size = new System.Drawing.Size(190, 23);
            this.progressBarPlayerHP.TabIndex = 3;
            // 
            // lblPlayerHP
            // 
            this.lblPlayerHP.AutoSize = true;
            this.lblPlayerHP.Location = new System.Drawing.Point(123, 286);
            this.lblPlayerHP.Name = "lblPlayerHP";
            this.lblPlayerHP.Size = new System.Drawing.Size(35, 13);
            this.lblPlayerHP.TabIndex = 4;
            this.lblPlayerHP.Text = "label3";
            // 
            // lblPlayerMP
            // 
            this.lblPlayerMP.AutoSize = true;
            this.lblPlayerMP.Location = new System.Drawing.Point(123, 361);
            this.lblPlayerMP.Name = "lblPlayerMP";
            this.lblPlayerMP.Size = new System.Drawing.Size(35, 13);
            this.lblPlayerMP.TabIndex = 5;
            this.lblPlayerMP.Text = "label4";
            // 
            // lblEnemyHP
            // 
            this.lblEnemyHP.AutoSize = true;
            this.lblEnemyHP.Location = new System.Drawing.Point(700, 313);
            this.lblEnemyHP.Name = "lblEnemyHP";
            this.lblEnemyHP.Size = new System.Drawing.Size(35, 13);
            this.lblEnemyHP.TabIndex = 10;
            this.lblEnemyHP.Text = "label6";
            // 
            // progressBarEnemyHP
            // 
            this.progressBarEnemyHP.Location = new System.Drawing.Point(609, 352);
            this.progressBarEnemyHP.Name = "progressBarEnemyHP";
            this.progressBarEnemyHP.Size = new System.Drawing.Size(215, 60);
            this.progressBarEnemyHP.TabIndex = 9;
            // 
            // lblEnemyName
            // 
            this.lblEnemyName.AutoSize = true;
            this.lblEnemyName.Location = new System.Drawing.Point(774, 33);
            this.lblEnemyName.Name = "lblEnemyName";
            this.lblEnemyName.Size = new System.Drawing.Size(35, 13);
            this.lblEnemyName.TabIndex = 8;
            this.lblEnemyName.Text = "label7";
            // 
            // lblEnemyLevel
            // 
            this.lblEnemyLevel.AutoSize = true;
            this.lblEnemyLevel.Location = new System.Drawing.Point(631, 33);
            this.lblEnemyLevel.Name = "lblEnemyLevel";
            this.lblEnemyLevel.Size = new System.Drawing.Size(35, 13);
            this.lblEnemyLevel.TabIndex = 6;
            this.lblEnemyLevel.Text = "label8";
            // 
            // richTextBoxBattleLog
            // 
            this.richTextBoxBattleLog.Location = new System.Drawing.Point(350, 33);
            this.richTextBoxBattleLog.Name = "richTextBoxBattleLog";
            this.richTextBoxBattleLog.ReadOnly = true;
            this.richTextBoxBattleLog.Size = new System.Drawing.Size(179, 332);
            this.richTextBoxBattleLog.TabIndex = 11;
            this.richTextBoxBattleLog.Text = "";
            // 
            // pictureBoxPlayer
            // 
            this.pictureBoxPlayer.InitialImage = null;
            this.pictureBoxPlayer.Location = new System.Drawing.Point(51, 78);
            this.pictureBoxPlayer.Name = "pictureBoxPlayer";
            this.pictureBoxPlayer.Size = new System.Drawing.Size(181, 188);
            this.pictureBoxPlayer.TabIndex = 12;
            this.pictureBoxPlayer.TabStop = false;
            // 
            // pictureBoxEnemy
            // 
            this.pictureBoxEnemy.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxEnemy.InitialImage")));
            this.pictureBoxEnemy.Location = new System.Drawing.Point(628, 78);
            this.pictureBoxEnemy.Name = "pictureBoxEnemy";
            this.pictureBoxEnemy.Size = new System.Drawing.Size(181, 188);
            this.pictureBoxEnemy.TabIndex = 13;
            this.pictureBoxEnemy.TabStop = false;
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(82, 464);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(105, 36);
            this.btnAttack.TabIndex = 14;
            this.btnAttack.Text = "Атака";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // btnStrongAttack
            // 
            this.btnStrongAttack.Location = new System.Drawing.Point(193, 464);
            this.btnStrongAttack.Name = "btnStrongAttack";
            this.btnStrongAttack.Size = new System.Drawing.Size(105, 36);
            this.btnStrongAttack.TabIndex = 15;
            this.btnStrongAttack.Text = "Сильна атака";
            this.btnStrongAttack.UseVisualStyleBackColor = true;
            this.btnStrongAttack.Click += new System.EventHandler(this.btnStrongAttack_Click);
            // 
            // btnRepair
            // 
            this.btnRepair.Location = new System.Drawing.Point(304, 464);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(105, 36);
            this.btnRepair.TabIndex = 16;
            this.btnRepair.Text = "Ремонт";
            this.btnRepair.UseVisualStyleBackColor = true;
            this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(415, 464);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(105, 36);
            this.btnRest.TabIndex = 17;
            this.btnRest.Text = "Відпочинок";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // BattleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 529);
            this.Controls.Add(this.btnRest);
            this.Controls.Add(this.btnRepair);
            this.Controls.Add(this.btnStrongAttack);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.pictureBoxEnemy);
            this.Controls.Add(this.pictureBoxPlayer);
            this.Controls.Add(this.richTextBoxBattleLog);
            this.Controls.Add(this.lblEnemyHP);
            this.Controls.Add(this.progressBarEnemyHP);
            this.Controls.Add(this.lblEnemyName);
            this.Controls.Add(this.lblEnemyLevel);
            this.Controls.Add(this.lblPlayerMP);
            this.Controls.Add(this.lblPlayerHP);
            this.Controls.Add(this.progressBarPlayerHP);
            this.Controls.Add(this.labelCooldown);
            this.Controls.Add(this.progressBarPlayerMP);
            this.Controls.Add(this.lblPlayerName);
            this.Name = "BattleForm";
            this.Text = "BattleForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.ProgressBar progressBarPlayerMP;
        private System.Windows.Forms.Label labelCooldown;
        private System.Windows.Forms.ProgressBar progressBarPlayerHP;
        private System.Windows.Forms.Label lblPlayerHP;
        private System.Windows.Forms.Label lblPlayerMP;
        private System.Windows.Forms.Label lblEnemyHP;
        private System.Windows.Forms.ProgressBar progressBarEnemyHP;
        private System.Windows.Forms.Label lblEnemyName;
        private System.Windows.Forms.Label lblEnemyLevel;
        private System.Windows.Forms.RichTextBox richTextBoxBattleLog;
        private System.Windows.Forms.PictureBox pictureBoxPlayer;
        private System.Windows.Forms.PictureBox pictureBoxEnemy;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Button btnStrongAttack;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.Button btnRest;
    }
}