using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Battle;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp5.Entities
{
    public class TankTemplate
    {
        private string name;
        private ProgressBarValueHelper health;
        private ProgressBarValueHelper MP;
        private BattleSprites battleSprites;

        private Weapon startWeapon;
        private Armor startArmor;
        public string Image;

        public TankTemplate(string name, ProgressBarValueHelper health, ProgressBarValueHelper MP, Weapon startWeapon, Armor startArmor, string image, BattleSprites sprites)
        {
            this.name = name;
            this.health = health;
            this.MP = MP;
            this.startWeapon = startWeapon;
            this.startArmor = startArmor;
            this.Image = image;
            this.battleSprites = sprites;
        }

        public string getName() => name;
        public int getHP() => health.getMax();
        public int getMinHP() => health.getMin();
        public int getMaxHP() => health.getMax();

        public int getMaxMP() => MP.getMax();

        public Weapon getStartWeapon() => startWeapon;
        public Armor getStartArmor() => startArmor;

        public ProgressBarValueHelper getHealthBar()
        {
            return new ProgressBarValueHelper(health.getMax(), health.getMin());
        }

        public ProgressBarValueHelper getMPBar()
        {
            return new ProgressBarValueHelper(MP.getMax(), MP.getMin());
        }
        public BattleSprites getBattleSprites()
        {
            return battleSprites;
        }

    }
}
