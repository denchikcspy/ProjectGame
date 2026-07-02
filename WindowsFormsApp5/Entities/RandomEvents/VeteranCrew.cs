using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Entities.RandomEvents
{
    public class VeteranCrew : Event
    {
        public VeteranCrew() : base("Досвідчений екіпаж", EventType.Positive)
        {
        }

        public override void execute(Player player)
        {
            Description = "Екіпаж став більш досвідченим. +40 XP.";

            player.addExperience(40);
        }
    }
}
