using System;
using System.Drawing;
using WindowsFormsApp5.Battle;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities
{
    public class Character
    {
        protected string name;
        protected int level;

        protected ProgressBarValueHelper HP;
        protected ProgressBarValueHelper MP;
        

        protected int Endurance;
        protected int Agility;
        protected int Intelligence;
        protected int CriticalChance;


        protected int mainGunCooldown = 0;

        protected Weapon CurrentWeapon;
        protected Weapon AdditionalWeapon;

        protected Armor CurrentArmor;
        protected Armor AdditionalArmor;

        protected static Random random = new Random();

        protected const int NORMAL_ATTACK_MP_COST = 10;
        protected const int STRONG_ATTACK_MP_COST = 25;
        protected const int REPAIR_MP_COST = 20;
        protected const int REST_MP_RESTORE = 20;

        protected BattleSprites sprites;

        public Character(
            string name,
            int level,
            ProgressBarValueHelper hp,
            ProgressBarValueHelper mp,
            int endurance,
            int agility,
            int intelligence,
            Weapon currentWeapon,
            Armor currentArmor,
            BattleSprites sprites
        )
        {
            this.name = name;
            this.level = level;

            this.HP = hp;
            this.MP = mp;

            this.Endurance = endurance;
            this.Agility = agility;
            this.Intelligence = intelligence;

            this.CriticalChance = (int)Math.Ceiling(agility * 0.5);

            this.CurrentWeapon = currentWeapon;
            this.CurrentArmor = currentArmor;

            this.AdditionalWeapon = null;
            this.AdditionalArmor = null;
            this.sprites = sprites;
        }

        public string getName() => name;
        public int getLevel() => level;

        public int getCurrentHP() => HP.getCurrent();
        public int getMaxHP() => HP.getMax();

        public int getCurrentMP() => MP.getCurrent();
        public int getMaxMP() => MP.getMax();

        public int getEndurance() => Endurance;
        public int getAgility() => Agility;
        public int getIntelligence() => Intelligence;
        public int getCriticalChance() => CriticalChance;

        public int getMainGunCooldown() => mainGunCooldown;

        public Weapon getCurrentWeapon() => CurrentWeapon;
        public Weapon getAdditionalWeapon() => AdditionalWeapon;

        public Armor getCurrentArmor() => CurrentArmor;
        public Armor getAdditionalArmor() => AdditionalArmor;

       
        public void setName(string name) => this.name = name;
        public void setLevel(int level) => this.level = level;

        public void setCurrentHP(int hp) => HP.setCurrent(hp);
        public void removeHP(int value)
        {
            HP.decrease(value);
        }
        public void addHP(int value)
        {
            HP.increase(value);
        }

        public void setCurrentMP(int mp) => MP.setCurrent(mp);
        public void addMP(int value)
        {
            MP.increase(value);
        }
        public void removeMP(int value)
        {
            MP.decrease(value);
        }

        public void setEndurance(int endurance) => Endurance = endurance;
        public void setAgility(int agility) => Agility = agility;
        public void setIntelligence(int intelligence) => Intelligence = intelligence;
        public void setCriticalChance(int criticalChance) => CriticalChance = criticalChance;

        public void setMainGunCooldown(int cooldown) => mainGunCooldown = cooldown;

        public void setCurrentWeapon(Weapon weapon) => CurrentWeapon = weapon;
        public void setAdditionalWeapon(Weapon weapon) => AdditionalWeapon = weapon;

        public void setCurrentArmor(Armor armor) => CurrentArmor = armor;
        public void setAdditionalArmor(Armor armor) => AdditionalArmor = armor;



        public virtual BattleActionResult TakeDamage(int rawDamage, double penetration)
        {
            BattleActionResult result = new BattleActionResult();

            double armor = GetTotalArmor();
            int finalDamage = rawDamage;

            // Броня
            if (penetration < armor)
            {
                finalDamage = (int)(finalDamage * 0.5);
                result.WasBlockedByArmor = true;
            }

            // Ухилення
            int dodgeChance = Agility / 2;

            if (random.Next(100) < dodgeChance)
            {
                finalDamage = (int)(finalDamage * 0.7);
                result.WasDodged = true;
            }

            // Знімаємо HP
            HP.decrease(finalDamage);

            result.DamageDone = finalDamage;

            // Перевіряємо вже ПІСЛЯ удару
            if (HP.getCurrent() <= 0)
            {
                result.TargetDestroyed = true;
                result.ImageState = BattleImageState.Destroyed;
            }
            else
            {
                result.TargetDestroyed = false;
                result.ImageState = BattleImageState.Damaged;
            }

            return result;
        }

        public virtual BattleActionResult UseNormalAttack(Character target)
        {
            BattleActionResult result = new BattleActionResult();

            if (!CanUseNormalAttack())
            {
                result.LogText = "Неможливо виконати звичайну атаку.";
                return result;
            }

            MP.decrease(NORMAL_ATTACK_MP_COST);

            int damage = AdditionalWeapon.getDamage() + Agility / 2;
            double penetration = AdditionalWeapon.getPenetration();

            bool critical = random.Next(100) < CriticalChance;
            if (critical)
            {
                damage = (int)(damage * 1.5);
                result.IsCritical = true;
            }

            BattleActionResult targetResult = target.TakeDamage(damage, penetration);
            result.ImageState = BattleImageState.NormalAttack;
            result.LogText = $"{name} атакував та наніс {targetResult.DamageDone} шкоди.";

            result.DamageDone = targetResult.DamageDone;
            result.TargetDestroyed = targetResult.TargetDestroyed;
            result.WasBlockedByArmor = targetResult.WasBlockedByArmor;
            result.WasDodged = targetResult.WasDodged;
            result.MpSpent = NORMAL_ATTACK_MP_COST;
            result.IsCritical = critical;

            return result;
        }

        public virtual BattleActionResult UseStrongAttack(Character target)
        {
            BattleActionResult result = new BattleActionResult();

            if (!CanUseStrongAttack())
            {
                result.LogText = "Основна гармата ще перезаряджається або не вистачає MP.";
                return result;
            }

            MP.decrease(STRONG_ATTACK_MP_COST);

            int damage = CurrentWeapon.getDamage() + Agility;
            double penetration = CurrentWeapon.getPenetration();

            bool critical = random.Next(100) < (CriticalChance + 10);
            if (critical)
            {
                damage = (int)(damage * 1.5);
                result.IsCritical = true;
            }

            BattleActionResult targetResult = target.TakeDamage(damage, penetration);
            result.ImageState = BattleImageState.StrongAttack;
            result.LogText = $"{name} вистрілив з основної гармати та наніс {targetResult.DamageDone} шкоди.";

            mainGunCooldown = 2;

            result.DamageDone = targetResult.DamageDone;
            if ((double)target.HP.getCurrent() / target.HP.getMax() <= 0.3)
            {
                result.TargetDamaged = true;
            }
            result.TargetDestroyed = targetResult.TargetDestroyed;
            result.WasBlockedByArmor = targetResult.WasBlockedByArmor;
            result.WasDodged = targetResult.WasDodged;
            result.MpSpent = STRONG_ATTACK_MP_COST;
            result.IsCritical = critical;

            return result;
        }
        public int getTotalDamage()
        {
            int damage = 0;

            if (CurrentWeapon != null)
                damage += CurrentWeapon.getDamage();

            if (AdditionalWeapon != null)
                damage += AdditionalWeapon.getDamage();

            return damage;
        }

        public virtual BattleActionResult Repair()
        {
            BattleActionResult result = new BattleActionResult();

            if (!CanRepair())
            {
                result.LogText = "Ремонт неможливий.";
                return result;
            }

            MP.decrease(REPAIR_MP_COST);

            int heal = 20 + Endurance;
            HP.increase(heal);

            result.HealDone = heal;
            result.MpSpent = REPAIR_MP_COST;
            result.ImageState = BattleImageState.Repair;
            result.LogText = $"{name} відремонтував танк на {heal} HP.";

            return result;
        }

        public virtual BattleActionResult Rest()
        {
            BattleActionResult result = new BattleActionResult();

            int restore = REST_MP_RESTORE + Endurance / 2;
            MP.increase(restore);
            result.MpRestored = restore;
            result.ImageState = BattleImageState.Rest;
            result.LogText = $"{name} відновив {restore} MP.";

            return result;
        }

       

        public bool CanUseNormalAttack()
        {
            return AdditionalWeapon != null &&
                   MP.getCurrent() >= NORMAL_ATTACK_MP_COST;
        }

        public bool CanUseStrongAttack()
        {
            return CurrentWeapon != null &&
                   MP.getCurrent() >= STRONG_ATTACK_MP_COST &&
                   mainGunCooldown == 0;
        }

        public bool CanRepair()
        {
            return MP.getCurrent() >= REPAIR_MP_COST &&
                   HP.getCurrent() < HP.getMax();
        }

        public double GetTotalArmor()
        {
            double totalArmor = 0;

            if (CurrentArmor != null)
                totalArmor += CurrentArmor.getArmorThickness();

            if (AdditionalArmor != null)
                totalArmor += AdditionalArmor.getArmorThickness();

            return totalArmor;
        }

        public bool IsDead()
        {
            return HP.getCurrent() <= 0;
        }

        public void StartTurn()
        {
            if (mainGunCooldown > 0)
                mainGunCooldown--;
        }
        public BattleSprites getSprites()
        {
            return sprites;
        }

        
    }
}