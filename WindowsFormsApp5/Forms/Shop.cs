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
        private List<Weapon> weapons;
        private List<Armor> armors;
        public Shop( PlayerInfo previosForm, Player player)
        {
            InitializeComponent();
            GenerateShop();
            this.prevForm = previosForm;
            this.player = player;
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.prevForm.Visible = true;

            this.prevForm.RefreshUI();
            this.prevForm.label4.Text = player.getMoney().ToString() + " Грошей";

            this.Close();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Weapon weapon)
            {
                pictureBox1.Image = weapon.getImage();
            }
            else if (listBox1.SelectedItem is Armor armor)
            {
                pictureBox1.Image = armor.getImage();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Оберіть предмет зі списку.");
                return;
            }

            Item selectedItem = shopItems[listBox1.SelectedIndex];

            if (player.getMoney() < selectedItem.getPrice())
            {
                MessageBox.Show("Недостатньо грошей.");
                return;
            }

            bool success = false;

            if (selectedItem is Weapon weapon)
            {
                success = BuyWeapon(weapon);
            }
            else if (selectedItem is Armor armor)
            {
                success = BuyArmor(armor);
            }

            if (success)
            {
                player.setMoney(player.getMoney() - selectedItem.getPrice());
                prevForm.RefreshUI();
            }
        }

        private void GenerateShop()
        {
            bool weaponShop = random.Next(2) == 0;

            listBox1.Items.Clear();
            shopItems.Clear();

            if (weaponShop)
            {
                WeaponGenerator generator = new WeaponGenerator();

                foreach (Weapon weapon in generator.CreateMany(5))
                {
                    shopItems.Add(weapon);
                    listBox1.Items.Add(weapon); // додаємо сам об'єкт
                }
            }
            else
            {
                ArmorGenerator generator = new ArmorGenerator();

                foreach (Armor armor in generator.CreateMany(5))
                {
                    shopItems.Add(armor);
                    listBox1.Items.Add(armor); // додаємо сам об'єкт
                }
            }
        }

        private bool BuyWeapon(Weapon weapon)
        {
            Weapon mainWeapon = player.getCurrentWeapon();

            // Малокаліберна зброя йде як додаткова
            if (weapon.getCaliber() < mainWeapon.getCaliber() && (player.getAdditionalWeapon() == null))
            { 
                player.setAdditionalWeapon(weapon);
                MessageBox.Show("Додаткову зброю встановлено!");
                return true;
            }
            else
            {
                // Вся інша зброя заміняє основну
                player.setCurrentWeapon(weapon);
                MessageBox.Show("Основну зброю замінено!");
                return true;
            }
        }

        private bool BuyArmor(Armor armor)
        {
            Armor mainArmor = player.getCurrentArmor();

            if (mainArmor != null && armor.getArmorThickness() < mainArmor.getArmorThickness())
            {
                if (player.getAdditionalArmor() != null)
                {
                    MessageBox.Show("Додаткова броня вже встановлена!");
                    return false;
                }

                player.setAdditionalArmor(armor);
                MessageBox.Show("Додаткову броню встановлено!");
                return true;
            }
            else
            {
                MessageBox.Show("Цю броню не можна встановити як додаткову.");
                return false;
            }
        }
    }
}
