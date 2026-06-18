using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Entities.Items;

namespace WindowsFormsApp5.Services
{
    public class ArmorGenerator
    {
        private Random random = new Random();

        private string[] armorNames =
        {
            "Шолом",
            "Нагрудник",
            "Щит",
            "Ботинки",
            "Рукавиці",
            "Кольчуга",
            "Кулаки з шипами",
            "Плащ",
            "Браслет",
            "Наплечник"
        };

        public Armor CreateOne()
        {
            string name = armorNames[random.Next(armorNames.Length)];

            int defense = random.Next(5, 31); 

            int price = defense * 10;

            return new Armor(name, defense, price);

        }

        public List<Armor> CreateMany(int count)
        {
            List<Armor> armors = new List<Armor>();

            for (int i = 0; i < count; i++)
            {
                armors.Add(CreateOne());
            }

            return armors;

        }    
    }
}
