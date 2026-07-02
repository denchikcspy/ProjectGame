using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Entities;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Entities.RandomEvents;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Forms
{
    public partial class PlayerInfo : Form
    {
         
        Player player;
        List<Event> events = new List<Event>();
        public PlayerInfo(Player player, string image)
        {
            InitializeComponent();


            this.player = player;

            RefreshUI();
            this.label2.Text = "Параметри \nЗброї";
            this.label3.Text = "Параметри \nБроні";
            this.label1.Text = this.player.getName();
            this.label5.Text = ($"У вас {player.getLevel().ToString()} рівень");
            this.label4.Text = "Баланс \n  " + this.player.getMoney().ToString();
            this.pictureBox1.Image =(Image)Properties.Resources.ResourceManager.GetObject(image);

            events.Add(new Ambush());
            events.Add(new FindAmmo());
            events.Add(new FindRepairKit());
            events.Add(new FindTreasure());
            events.Add(new MineField());
            events.Add(new VeteranCrew());
            events.Add(new FuelLeak());

        }
        public PlayerInfo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }
        private void buttonNextEvent_Click(object sender, EventArgs e)
        {
            int percent = CustomRandomizer.getRandomNumberInRange(1, 100);

            // 15% - нічого не сталося
            if (percent <= 15)
            {
                MessageBox.Show("Дорога була спокійною. Нічого не сталося.", "Подія", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 40% - випадкова подія
            else if (percent <= 55)
            {
                Event randomEvent = events[CustomRandomizer.getRandomNumber(events.Count)];

                randomEvent.execute(player);

                MessageBox.Show(
                    randomEvent.Name +
                    "\n\n" +
                    randomEvent.Description,
                    "Подія",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            // 30% - бій
            else if (percent <= 85)
            {
                MessageBox.Show("Попереду помічено ворожий танк Pz.Kpfw. IV! Починається бій.", "Бій", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BattleForm battle = new BattleForm(player, this);

                this.Hide();
                battle.Show();
            }

            // 15% - магазин
            else
            {
                MessageBox.Show("Ви натрапили на польовий магазин.", "Магазин", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Shop shop = new Shop(this, player);

                this.Hide();
                shop.Show();
            }

            RefreshUI();
        }

        public string GetWeaponInfo()
        {
            Weapon weapon = player.getCurrentWeapon();

            return
                "=== ЗБРОЯ ===\r\n" +
                "Назва: " + weapon.getName() + "\r\n" +
                "Калібр: " + weapon.getCaliber() + " мм\r\n" +
                "Урон: " + weapon.getDamage() + "\r\n" +
                "Пробиття: " + weapon.getPenetration() + " мм\r\n";
        }

        public string GetArmorInfo()
        {
            Armor armor = player.getCurrentArmor();

            return
                "=== БРОНЯ ===\r\n" +
                "Назва: " + armor.getName() + "\r\n" +
                "Товщина: " + armor.getArmorThickness() + " мм\r\n";
        }
        public void RefreshUI()
        {
            
            
            label4.Text = player.getMoney().ToString();
            label5.Text = ($"У вас { player.getLevel().ToString()} рівень");
            

            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();

            // =========================
            // ОСНОВНА + ДОДАТКОВА ЗБРОЯ
            // =========================
            richTextBox1.AppendText("=== ЗБРОЯ ===\n\n");

            if (player.getCurrentWeapon() != null)
            {
                richTextBox1.AppendText("Основна зброя:\n");
                richTextBox1.AppendText("Назва: " + player.getCurrentWeapon().getName() + "\n");
                richTextBox1.AppendText("Калібр: " + player.getCurrentWeapon().getCaliber() + " мм\n");
                richTextBox1.AppendText("Урон: " + player.getCurrentWeapon().getDamage() + "\n");
                richTextBox1.AppendText("Пробиття: " + player.getCurrentWeapon().getPenetration() + " мм\n");
                richTextBox1.AppendText("\n");
            }

            if (player.getAdditionalWeapon() != null)
            {
                richTextBox1.AppendText("Додаткова зброя:\n");
                richTextBox1.AppendText("Назва: " + player.getAdditionalWeapon().getName() + "\n");
                richTextBox1.AppendText("Калібр: " + player.getAdditionalWeapon().getCaliber() + " мм\n");
                richTextBox1.AppendText("Урон: " + player.getAdditionalWeapon().getDamage() + "\n");
                richTextBox1.AppendText("Пробиття: " + player.getAdditionalWeapon().getPenetration() + " мм\n");
                richTextBox1.AppendText("\n");
            }
            else
            {
                richTextBox1.AppendText("Додаткова зброя: відсутня\n\n");
            }

            richTextBox1.AppendText("Сумарний урон: " + player.getTotalDamage() + "\n");


            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.DeselectAll(); // Знімаємо синій колір виділення

            // =========================
            // ОСНОВНА + ДОДАТКОВА БРОНЯ
            // =========================
            richTextBox2.AppendText("=== БРОНЯ ===\n\n");

            if (player.getCurrentArmor() != null)
            {
                richTextBox2.AppendText("Основна броня:\n");
                richTextBox2.AppendText("Назва: " + player.getCurrentArmor().getName() + "\n");
                richTextBox2.AppendText("Товщина: " + player.getCurrentArmor().getArmorThickness() + " мм\n");
                richTextBox2.AppendText("\n");
            }

            if (player.getAdditionalArmor() != null)
            {
                richTextBox2.AppendText("Додаткова броня:\n");
                richTextBox2.AppendText("Назва: " + player.getAdditionalArmor().getName() + "\n");
                richTextBox2.AppendText("Товщина: " + player.getAdditionalArmor().getArmorThickness() + " мм\n");
                richTextBox2.AppendText("\n");
            }
            else
            {
                richTextBox2.AppendText("Додаткова броня: відсутня\n\n");
            }

            richTextBox2.AppendText("Сумарна броня: " + player.GetTotalArmor() + " мм\n");
            richTextBox2.SelectAll();
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.DeselectAll(); // Знімаємо синій колір виділення

            // =========================
            // ЗАГАЛЬНА ІНФОРМАЦІЯ ПРО ТАНК
            // =========================
            richTextBox3.AppendText("=== ІНФОРМАЦІЯ ===\n\n");
            richTextBox3.AppendText("Назва танка: " + player.getName() + "\n");
            richTextBox3.AppendText($"Досвід: {player.getExperience()} / {player.getLevelCup()}\n");
           richTextBox3.AppendText("HP: " + player.getCurrentHP() + "/" + player.getMaxHP() + "\n");
            richTextBox3.AppendText("MP: " + player.getCurrentMP() + "/" + player.getMaxMP() + "\n");
            richTextBox3.AppendText("Гроші: " + player.getMoney() + "\n");

            if (player.getCurrentWeapon() != null)
            {
                richTextBox3.AppendText("Основний калібр: " + player.getCurrentWeapon().getCaliber() + " мм\n");
            }

            
            richTextBox3.SelectAll();
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.DeselectAll(); // Знімаємо синій колір виділення


        }
        
        
        
        



        

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PlayerInfo_Load(object sender, EventArgs e)
        {

        }

        
    }
}

