using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Properties;

namespace WindowsFormsApp5.Services
{

    public class WeaponGenerator
    {
        private Random random = new Random();

        private List<Weapon> weaponTemplates = new List<Weapon>()
        {
            new Weapon("7.62-мм MG34", 80, 7.62, 10, 8,Properties.Resources.MG34),

            new Weapon("7.92-мм MG42", 110, 7.92, 13, 10,Properties.Resources.MG34),

            new Weapon("12.7-мм Browning M2HB", 170, 12.7, 18, 15,Properties.Resources.M2HBBrowning),

            new Weapon("12.7-мм ДШК", 200, 12.7, 21, 17,Properties.Resources.DHK),

            new Weapon("13.2-мм Hotchkiss M1929", 230, 13.2, 23, 19,Properties.Resources.Hotchkiss_M1929),

            new Weapon("15-мм Besa", 280, 15, 27, 24,Properties.Resources.Besa),

            new Weapon("20-мм KwK 30", 360, 20, 34, 30,Properties.Resources.KwK_30),

            new Weapon("20-мм Oerlikon", 400, 20, 37, 33,Properties.Resources.Oerlikon),

            new Weapon("23-мм ВЯ-23", 470, 23, 43, 38,Properties.Resources.ВЯ23),

            new Weapon("37-мм M6", 620, 37, 56, 50,Properties.Resources.M6),

            new Weapon("40-мм Bofors L/60", 760, 40, 65, 60,Properties.Resources.BoforsL60),

            new Weapon("45-мм 20-К", 900, 45, 74, 70,Properties.Resources._20К),

            new Weapon("50-мм KwK 38", 1050, 50, 85, 82,Properties.Resources.KwK_38)
        };

        public Weapon CreateOne()
        {
            Weapon template = weaponTemplates[random.Next(weaponTemplates.Count)];

            return new Weapon(
                template.getName(),
                template.getPrice(),
                template.getCaliber(),
                template.getDamage(),
                template.getPenetration(),
                template.getImage(),
                template.getDescription()
            );
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
