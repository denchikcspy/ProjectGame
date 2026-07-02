using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities.RandomEvents
{
    public class FindRepairKit : Event
    {
        public FindRepairKit() : base("Ремонтний комплект", EventType.Positive)
        {
        }

        public override void execute(Player player)
        {
            int hp = CustomRandomizer.getRandomNumberInRange(20, 45);

            Description = $"Екіпаж полагодив танк. HP +{hp}.";

            player.addHP(hp);

        }
    }
}
