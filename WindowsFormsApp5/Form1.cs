using System;
using System.Windows.Forms;
using WindowsFormsApp5.Entities;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Player Player = new Player("Воїн Рицарь");

            PlayerName.Text = "Ім'я: " + Player.getName();
            Health.Text = "Здоров'я: " + Player.HP.getCurrent() + " / " + Player.HP.getMax();
            Level.Text = "Рівень: " + Player.getLevel();
            Weapon.Text = "Зброя: " + Player.CurrentWeapon.getName();
            Armor.Text = "Броня: " + Player.CurrentArmor.getName();
        }
    }
}
