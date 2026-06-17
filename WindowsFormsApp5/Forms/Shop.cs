using System;
using System.Windows.Forms;
using WindowsFormsApp5.Entities;
using WindowsFormsApp5.Entities.Items;

namespace WindowsFormsApp5.Forms
{
    public partial class Shop : Form
    {
        private PlayerInfo prevForm;
        private Player player;
        public Shop(string message, PlayerInfo previosForm, Player player)
        {
            InitializeComponent();
            this.label2.Text = message;
            this.prevForm = previosForm;
            this.player = player;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.prevForm.Visible = true;
            this.prevForm.updateWeaponNameLabel();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.player.setNewWeapon(new Weapon("Шипаста булава", 100, 25));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.player.setNewWeapon(new Weapon("Світоносний Ленс", 100, 25));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.player.setNewWeapon(new Weapon("Легендарний бродакс", 100, 25));
        }
    }
}
