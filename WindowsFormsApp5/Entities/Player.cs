using System;
using System.Windows.Forms;
using WindowsFormsApp5.Battle;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities
{
    public class Player : Character
    {
        private int LevelCup = 25;
        private int Experience;
        private int Money;
        
        


        public Player(
    string name,
    int money,
    ProgressBarValueHelper health,
    ProgressBarValueHelper mp,
    Weapon startWeapon,
    Armor startArmor,
    BattleSprites battleSprites


) : base(name, 1, health, mp, 20, 15, 20, startWeapon, startArmor, battleSprites)
        {
            this.Money = money;
            this.HP = health;          // поле з Character
            this.MP = mp;              // поле MP гравця
            this.CurrentWeapon = startWeapon;
            this.CurrentArmor = startArmor;

            this.AdditionalWeapon = null;
            this.AdditionalArmor = null;
            

            // базові характеристики
            this.Endurance = 20;
            this.Agility = 15;
            this.Intelligence = 20;
            this.CriticalChance = (int)Math.Ceiling(Agility * 0.5);
        }


        public int getMoney() => Money;
        public int getExperience() => Experience;
        public int getLevelCup() => LevelCup;

        
        public void setMoney(int money) => Money = money;
        public void setExperience(int experience) => Experience = experience;
        public void setLevelCup(int levelCup) => LevelCup = levelCup;

        
        public void addMoney(int value)
        {
            Money += value;
        }




        public void addExperience(int value)
        {
            Experience += value;
            LevelUp();
        }
        public void LevelUp()
        {
            
            while (this.Experience > this.LevelCup)
            {
                Experience -= LevelCup;

                level++;

                LevelCup = (int)(LevelCup * 1.3);

                Endurance += 3;
                Agility += 2;
                Intelligence += 2;

                CriticalChance = (int)Math.Ceiling(Agility * 0.5);

                HP = new ProgressBarValueHelper(HP.getMax() + 30);
                MP = new ProgressBarValueHelper(MP.getMax() + 15);

                MessageBox.Show($"Нічого собі!!\nУ вас тепер {level} рівень! Вітаємо!", "Новий рівень", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void FullRepair()
        {
            HP.setCurrent(HP.getMax());
        }
        public void RestoreMP()
        {
            MP.setCurrent(MP.getMax());
        }
        public void DamagePlayer(int damage)
        {
            HP.decrease(damage);
        }
        public void HealPlayer(int heal)
        {
            HP.increase(heal);
        }

        public void AddRandomWeapon(Weapon weapon)
        {
            EquipWeaponFromShop(weapon);
        }

        public void AddRandomArmor(Armor armor)
        {
            CurrentArmor = armor;
        }

        public void IncreaseStat(int endurance, int agility, int intelligence)
        {
            Endurance += endurance;
            Agility += agility;
            Intelligence += intelligence;
        }

        public void LoseMoney(int value)
        {
            Money -= value;

            if (Money < 0) {

                Money = 0;

            }
               
        }


        public void setNewWeapon(Weapon weapon)
        {
            CurrentWeapon = weapon;
        }

        public void setNewArmor(Armor armor)
        {
            CurrentArmor = armor;
        }

        
        public void EquipWeaponFromShop(Weapon weapon)
        {
            if (weapon == null)
                return;

            
            if (weapon.getCaliber() <= 30)
            {
                AdditionalWeapon = weapon;
            }
            else
            {
                CurrentWeapon = weapon;
            }
        }
        


    }
    }
