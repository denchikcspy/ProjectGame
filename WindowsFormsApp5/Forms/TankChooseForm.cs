using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Battle;
using WindowsFormsApp5.Entities;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Forms
{
    public partial class TankChooseForm : Form
    {
        private TankTemplate tank1;
        private TankTemplate tank2;
        private TankTemplate tank3;
        
        

        public TankChooseForm()
        {
            InitializeComponent();
            CreateTanks();
            ShowTanks();
        }

        private void CreateTanks()
        {
            tank1 = new TankTemplate(
                "Tiger I",
                new ProgressBarValueHelper(450),
                new ProgressBarValueHelper(100),
                new Weapon("88 мм KwK 36", 0, 88, 120, 145, null, "Стандартна гармата Tiger I"),
                new Armor("Лобова броня Tiger I", 0, 100, null, "Базова броня Tiger I"),
                "Tiger1" , 
                new BattleSprites()
                {
                    Idle = Properties.Resources.TigerIdle,
                    NormalAttack = Properties.Resources.TigerNormalAttack,
                    StrongAttack = Properties.Resources.TigerStrongAttack,
                    Repair = Properties.Resources.TigerRepair,
                    Damaged = Properties.Resources.TigerDamaged,
                    Destroyed = Properties.Resources.TigerDestroyed
                }

            );

            tank2 = new TankTemplate(
                "T-34-85",
                new ProgressBarValueHelper(350),
                new ProgressBarValueHelper(100),
                new Weapon("85 мм ЗіС-С-53", 0, 85, 100, 110, null, "Стандартна гармата T-34-85"),
                new Armor("Лобова броня T-34-85", 0, 75, null, "Базова броня T-34-85"),
                "T34-85",
                new BattleSprites()
                {
                    Idle = Properties.Resources.T34_85Idle,
                    NormalAttack = Properties.Resources.T34_85NormalAttack,
                    StrongAttack = Properties.Resources.T34_85StrongAttack,
                    Repair = Properties.Resources.T34_85Repair,
                    Damaged = Properties.Resources.T34_85Damaged,
                    Destroyed = Properties.Resources.T34_85Destroyed
                }

            );

            tank3 = new TankTemplate(
                "Sherman Firefly",
                new ProgressBarValueHelper(385),
                new ProgressBarValueHelper(100),
                new Weapon("76.2 мм QF 17-pounder", 0, 76.2, 105, 135, null, "Стандартна гармата Sherman Firefly"),
                new Armor("Лобова броня Sherman", 0, 60,null, "Базова броня Sherman Firefly"),
                "Sherman" ,
                new BattleSprites()
                {
                    Idle = Properties.Resources.ShermanIdle,
                    NormalAttack = Properties.Resources.ShermanNormalAttack,
                    StrongAttack = Properties.Resources.ShermanStrongAttack,
                    Repair = Properties.Resources.ShermanRepair,
                    Damaged = Properties.Resources.ShermanDamaged,
                    Destroyed = Properties.Resources.ShermanDestroyed
                }

            );
        }

        private void ShowTanks()
        {
            ShowTankInfo(tank1, labelTank1, listBoxTank1, pictureBoxTank1);
            ShowTankInfo(tank2, labelTank2, listBoxTank2, pictureBoxTank2);
            ShowTankInfo(tank3, labelTank3, listBoxTank3, pictureBoxTank3);


            
        }

        private void ShowTankInfo(TankTemplate tank, Label label, ListBox listBox, PictureBox pictureBox)
        {
            label.Text = tank.getName();

            listBox.Items.Clear();
            listBox.Items.Add("Зброя: " + tank.getStartWeapon().getName());
            listBox.Items.Add("Здоров'я " + tank.getHP());
            listBox.Items.Add("Калібр: " + tank.getStartWeapon().getCaliber() + " мм");
            listBox.Items.Add("Урон: " + tank.getStartWeapon().getDamage());
            listBox.Items.Add("Пробиття: " + tank.getStartWeapon().getPenetration() + " мм");
            listBox.Items.Add("Броня: " + tank.getStartArmor().getArmorThickness() + " мм");
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(tank.Image);
            

        }

        private void buttonTank1_Click(object sender, EventArgs e)
        {
            StartGame(tank1);
            
        }
        private void buttonTank2_Click(object sender, EventArgs e)
        {
            StartGame(tank2);
        }

        private void buttonTank3_Click(object sender, EventArgs e)
        {
            StartGame(tank3);
        }

        private void StartGame(TankTemplate tank)
        {
            Player player = new Player(
                tank.getName(),
                1000,
                tank.getHealthBar(),
                tank.getMPBar(),
                tank.getStartWeapon(),
                tank.getStartArmor(),
                tank.getBattleSprites()
                
               
            );
            string Image = tank.Image;


            PlayerInfo playerInfo = new PlayerInfo(player,Image);
            playerInfo.Show();
            this.Hide();
        }
    }
}
