using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities.RandomEvents
{
    public class FuelLeak : Event
    {
        public FuelLeak() : base("Витік пального", EventType.Negative)
        {
        }

        public override void execute(Player player)
        {
            int mp = CustomRandomizer.getRandomNumberInRange(15, 30);

            Description = $"Через витік пального втрачено {mp} MP.";

            player.removeMP(mp);
        }
    }
}