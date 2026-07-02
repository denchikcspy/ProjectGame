using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Entities.Items
{
    public class Item
    {
        int id;
        static int autoInc = 1;
        protected string name;
        protected int price;
        protected string description;

        public Item(string name, int price, string description = "")
        {
            this.id = autoInc++;
            this.name = name;
            this.price = price;
            this.description = description;
        }

        public int getId() => id;
        public string getName() => name;
        public string getDescription() => description;
        public int getPrice() => price;
    }
}
