using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities.RandomEvents
{
    public class Ambush : Event
    {
        public Ambush() : base("Засідка", EventType.Negative)
        {
        }

        public override void execute(Player player)
        {
            int damage = CustomRandomizer.getRandomNumberInRange(15, 30);
            int money = CustomRandomizer.getRandomNumberInRange(40, 120);

            Description = $"Колона потрапила в засідку. HP -{damage}, втрачено {money}$.";

            player.removeHP(damage);
            player.LoseMoney(money);
        }
    }
}
