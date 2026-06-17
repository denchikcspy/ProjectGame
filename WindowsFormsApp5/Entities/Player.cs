using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities
{
    public class Player : Character
    {
        private int LevelCup = 1000;
        private int Experience = 0;

        private int Strength = 20;
        private int Endurance = 20;
        private int Agility = 20;
        private int Intelligence = 20;
        private int CriticalChance = 0;

        private int Gold = 0;
        public ProgressBarValueHelper MP;


        public Weapon CurrentWeapon {  get; protected set; }
        public Armor CurrentArmor { get; protected set; }

        public Player(string name) : base(name, 1)
        {
            CriticalChance = (int)Math.Ceiling(Agility * 0.5);
            this.HP = new ProgressBarValueHelper(Endurance * 10);
            this.MP = new ProgressBarValueHelper(Intelligence * 5);

            this.CurrentWeapon = new Weapon("Дерев'яний меч", 10, 2);
            this.CurrentArmor = new Armor("Діряві штани", 1, 2);
        }

        public void setNewWeapon(Weapon newWeapon)
        {
            this.CurrentWeapon = newWeapon;
        }

    }
}
