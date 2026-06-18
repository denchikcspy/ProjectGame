using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Entities.Items;

namespace WindowsFormsApp5.Services
{
    public class WeaponGenerator
    {

        private Random random = new Random();

        private string[] weaponNames =
        {
            "Меч",
            "Кірка",
            "Кинжал",
            "Молоток",
            "Спис",
            "Лук",
            "Арбалет",
            "Булава",
            "Катана",
            "Алебарда"
        };

        public Weapon CreateOne()
        {
            string name = weaponNames[random.Next(weaponNames.Length)];

            int attack = random.Next(5, 31);

            int price = attack * 10;

            return new Weapon(name, price, attack);
        }

        public List<Weapon> CreateMany(int count)
        {
            List<Weapon> weapons = new List<Weapon>();

            for (int i = 0; i < count; i++)
            {
                weapons.Add(CreateOne());
            }

            return weapons;
        }
    }
}
