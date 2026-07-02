using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities.RandomEvents
{
    public class MineField : Event
    {
        public MineField() : base("Мінне поле", EventType.Negative)
        {
        }

        public override void execute(Player player)
        {
            int damage = CustomRandomizer.getRandomNumberInRange(20, 45);

            Description = $"Танк підірвався на міні. HP -{damage}.";

            player.removeHP(damage);
        }
    }
}
