using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Entities.Items
{
    public class Armor : Item
    {
        public Armor(string name, int price, int defense, string description = "") 
            : base(name, price, defense, description)
        {

        }

        public int getDefence() => value;

        
    }
}
