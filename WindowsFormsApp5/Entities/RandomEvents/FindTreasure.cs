using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities.RandomEvents
{
    public class FindTreasure : Event
    {
        public FindTreasure() : base("Знайдено скарб!", EventType.Positive)
        {
        }

        public override void execute(Player player)
        {
            int money = CustomRandomizer.getRandomNumberInRange(150, 400);

            Description = $"Підбитий танк приховував {money}$.";

            player.addMoney(money);
        }
    }
}
