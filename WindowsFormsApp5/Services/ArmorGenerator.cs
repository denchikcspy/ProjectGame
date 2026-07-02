using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Entities.Items;

namespace WindowsFormsApp5.Services
{

    public class ArmorGenerator
    {
        private Random random = new Random();

        private Armor[] armorNames =
        {
            new Armor("Навісна лобова броня", 0, 0, Properties.Resources.Навісна_лобова_броня),
            new Armor("Посилені бортові екрани", 0, 0, Properties.Resources.Посилені_бортові_екрани),
            new Armor("Додаткова баштова броня", 0, 0, Properties.Resources.Додаткова_баштова_броня),
            new Armor("Приварена верхня бронеплита", 0, 0, Properties.Resources.Приварена_верхня_бронеплита),
            new Armor("Комплект протикумулятивних екранів", 0, 0, Properties.Resources.Комплект_протикумулятивних_екранів),
            new Armor("Посилена маска гармати", 0, 0, Properties.Resources.Посилена_маска_гармати),
            new Armor("Додатковий бронекорпус", 0, 0, Properties.Resources.Додатковий_бронекорпус),
            new Armor("Броня командирської башточки", 0, 0, Properties.Resources.Броня_командирської_башточки),
            new Armor("Посилений нижній лобовий лист", 0, 0, Properties.Resources.Посилений_нижній_лобовий_лист),
            new Armor("Композитна бортова броня", 0, 0,Properties.Resources.Композитна_бортова_броня)
        };

        public Armor CreateOne()
        {
            Armor armor = armorNames[random.Next(armorNames.Length)];

            string name = armor.getName();

            int defense = random.Next(20, 121); // 20-120 мм

            int price = defense * 15;
            Image image = armor.getImage();

            return new Armor(name, price, defense, image);
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
