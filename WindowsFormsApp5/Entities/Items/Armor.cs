using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Entities.Items
{
    public class Armor : Item
    {
        private int armorThickness;
        private Image image;


        public Armor(string name, int price, int armorThickness,Image Image, string description = "")
            : base(name, price, description)
        {
            this.armorThickness = armorThickness;
            this.image = Image;
        }

        public double getArmorThickness() => armorThickness;
        public Image getImage() => image;
        public override string ToString()
        {
            return $"Назва: {getName()} | Товщина: {getArmorThickness()} мм | Ціна: {getPrice()}";
        }
        
    }
}
