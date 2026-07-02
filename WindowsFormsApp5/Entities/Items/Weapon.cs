using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Entities.Items
{
    public class Weapon : Item
    {
        private double caliber;
        private int damage;
        private double penetration;
        private Image image;

        public Weapon(string name, int price, double caliber, int damage, double penetration, Image Image, string description = "")
            : base(name, price, description)
        {
            this.caliber = caliber;
            this.damage = damage;
            this.penetration = penetration;
            image = Image;
        }

        public double getCaliber() => caliber;
        public int getDamage() => damage;
        public double getPenetration() => penetration;
        public Image getImage() => image;
        public override string ToString()
        {
            return $"Назва: {getName()} | Урон: {getDamage()} | Пробиття: {getPenetration()} | Ціна: {getPrice()}";
        }
    }
}
