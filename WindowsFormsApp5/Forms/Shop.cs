using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp5.Entities;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Services;


namespace WindowsFormsApp5.Forms
{
    public partial class Shop : Form
    {
        private PlayerInfo prevForm;
        private Player player;
        private List<Item> shopItems = new List<Item>();
        private Random random = new Random();
        public Shop(string message, PlayerInfo previosForm, Player player)
        {
            InitializeComponent();
            GenerateShop();
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
            if (listBox1.SelectedIndex == -1)
                return;

            Item selectedItem = shopItems[listBox1.SelectedIndex];

            if (player.getMoney() >= selectedItem.getPrice())
            {
                player.setMoney(player.getMoney() - selectedItem.getPrice());

                if (selectedItem is Weapon)
                {
                    player.setNewWeapon((Weapon)selectedItem);
                    prevForm.updateWeaponNameLabel();
                }
                else if (selectedItem is Armor)
                {
                    player.setNewArmor((Armor)selectedItem);
                    prevForm.updateArmorNameLabel();
                }

                MessageBox.Show("Предмет куплено!");
            }
            else
            {
                MessageBox.Show("Недостатньо грошей!");
            }
        }

        private void GenerateShop()
        {
            bool weaponShop = random.Next(2) == 0;

            if (weaponShop)
            {
                WeaponGenerator generator = new WeaponGenerator();

                foreach (Weapon weapon in generator.CreateMany(5))
                {
                    shopItems.Add(weapon);
                    listBox1.Items.Add(weapon.getName());
                }
            }
            else
            {
                ArmorGenerator generator = new ArmorGenerator();

                foreach (Armor armor in generator.CreateMany(5))
                {
                    shopItems.Add(armor);
                    listBox1.Items.Add(armor.getName());
                }
            }
        }


    }
}
