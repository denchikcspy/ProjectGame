using System;
using WindowsFormsApp5.Utils;


namespace WindowsFormsApp5.Entities
{
    public class Enemy : Character
    {
        private int rewardGold;
        private int rewardXP;

        private int damage;
        private int defence;

        public Enemy(string name, int level) : base(name, level)
        {
            this.rewardGold = 50 * level + CustomRandomizer.getRandomNumberInRange(-20, 20);
            this.rewardXP = 50 * level + CustomRandomizer.getRandomNumberInRange(-10, 20);
            this.damage = 20 * level + CustomRandomizer.getRandomNumberInRange(-5, 30);
            this.defence = 20 * level + CustomRandomizer.getRandomNumberInRange(-5, 30);
            this.HP = new ProgressBarValueHelper(400 * level + CustomRandomizer.getRandomNumberInRange(-50, 100));
        }

        public int getRewardGold() => this.rewardGold;
        public int getRewardXP() => this.rewardXP;
        public int getDamage() => this.damage;
        public int getDefence() => this.defence;
    }
}
