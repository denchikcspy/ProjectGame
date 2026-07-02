using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities.RandomEvents
{
    public class FindAmmo : Event
    {
        public FindAmmo() : base("Склад боєприпасів", EventType.Positive)
        {
        }

        public override void execute(Player player)
        {
            int mp = CustomRandomizer.getRandomNumberInRange(15, 35);

            Description = $"Ви знайшли склад боєприпасів. MP +{mp}.";

            player.addMP(mp);
        }
    }
}
