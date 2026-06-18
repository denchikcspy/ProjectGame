namespace WindowsFormsApp5
{
    partial class Form1
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
            this.PlayerName = new System.Windows.Forms.Label();
            this.Health = new System.Windows.Forms.Label();
            this.Level = new System.Windows.Forms.Label();
            this.Weapon = new System.Windows.Forms.Label();
            this.Armor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayerName
            // 
            this.PlayerName.AutoSize = true;
            this.PlayerName.Location = new System.Drawing.Point(53, 60);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Size = new System.Drawing.Size(35, 13);
            this.PlayerName.TabIndex = 0;
            this.PlayerName.Text = "label1";
            // 
            // Health
            // 
            this.Health.AutoSize = true;
            this.Health.Location = new System.Drawing.Point(53, 89);
            this.Health.Name = "Health";
            this.Health.Size = new System.Drawing.Size(35, 13);
            this.Health.TabIndex = 1;
            this.Health.Text = "label2";
            // 
            // Level
            // 
            this.Level.AutoSize = true;
            this.Level.Location = new System.Drawing.Point(53, 114);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(35, 13);
            this.Level.TabIndex = 2;
            this.Level.Text = "label3";
            // 
            // Weapon
            // 
            this.Weapon.AutoSize = true;
            this.Weapon.Location = new System.Drawing.Point(53, 141);
            this.Weapon.Name = "Weapon";
            this.Weapon.Size = new System.Drawing.Size(35, 13);
            this.Weapon.TabIndex = 3;
            this.Weapon.Text = "label4";
            // 
            // Armor
            // 
            this.Armor.AutoSize = true;
            this.Armor.Location = new System.Drawing.Point(53, 164);
            this.Armor.Name = "Armor";
            this.Armor.Size = new System.Drawing.Size(35, 13);
            this.Armor.TabIndex = 4;
            this.Armor.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Armor);
            this.Controls.Add(this.Weapon);
            this.Controls.Add(this.Level);
            this.Controls.Add(this.Health);
            this.Controls.Add(this.PlayerName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayerName;
        private System.Windows.Forms.Label Health;
        private System.Windows.Forms.Label Level;
        private System.Windows.Forms.Label Weapon;
        private System.Windows.Forms.Label Armor;
    }
}

