using WindowsFormsApp5.Battle;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities
{
    public class Enemy : Character
    {
        private int rewardGold;
        private int rewardXP;
        

        public Enemy(
            string name,
            int level,
            ProgressBarValueHelper hp,
            ProgressBarValueHelper mp,
            int endurance,
            int agility,
            int intelligence,
            Weapon currentWeapon,
            Armor currentArmor,
            BattleSprites battleSprites
        )
        : base(
            name,
            level,
            hp,
            mp,
            endurance,
            agility,
            intelligence,
            currentWeapon,
            currentArmor,
            battleSprites
        )
        {
            rewardGold = 50 * level + CustomRandomizer.getRandomNumberInRange(-20, 20);
            rewardXP = 50 * level + CustomRandomizer.getRandomNumberInRange(-10, 20);
        }

        //==========================
        // Нагорода
        //==========================

        public int getRewardGold() => rewardGold;
        public int getRewardXP() => rewardXP;

        public void setRewardGold(int value) => rewardGold = value;
        public void setRewardXP(int value) => rewardXP = value;

        //==========================
        // AI ворога
        //==========================

        public BattleActionResult DecideAction(Player player)
        {
            BattleActionResult result;

            // HP менше 30% -> ремонт
            if ((double)getCurrentHP() / getMaxHP() <= 0.3 && CanRepair())
            {
                result = Repair();
                result.LogText = $"{getName()} ремонтує танк.";
                return result;
            }

            // MP майже закінчилась -> відпочинок
            if (getCurrentMP() < NORMAL_ATTACK_MP_COST)
            {
                result = Rest();
                return result;
            }

            int action = CustomRandomizer.getRandomNumberInRange(1, 100);

            // 45% шанс сильного пострілу
            if (action <= 45 && CanUseStrongAttack())
            {
                result = UseStrongAttack(player);
                return result;
            }

            // 35% шанс кулемета
            if (action <= 80 && CanUseNormalAttack())
            {
                result = UseNormalAttack(player);
                return result;
            }

            // Якщо не може атакувати
            if (CanRepair())
            {
               result = Repair();
               return result;
            }

            result = Rest();
            return result;
        }
    }
}
