using System;
using System.Windows.Forms;
using WindowsFormsApp5.Entities;

namespace WindowsFormsApp5.Forms
{
    public partial class PlayerInfo : Form
    {
        Player player;
        public PlayerInfo()
        {
            InitializeComponent();
            player = new Player("Ростислав");
            this.label2.Text = player.CurrentWeapon.getName();
            this.label1.Text = player.getName();
        }

        public void updateWeaponNameLabel()
        {
            this.label2.Text = player.CurrentWeapon.getName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shop shopForm = new Shop("Якейсь повідомлення!", this, player);
            this.Visible = false;

            shopForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
