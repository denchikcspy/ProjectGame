using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Entities.Items
{
    public class Weapon : Item
    {
        public Weapon(string name, int price, int damage, string description = "")
            : base(name, price, damage, description)
        {

        }

        public int getDamage() => value;
    }
}
