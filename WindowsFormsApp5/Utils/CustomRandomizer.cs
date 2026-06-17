using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Utils
{
    public class CustomRandomizer
    {
        private static Random random = new Random();

        public static int getRandomNumberInRange(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public static int getRandomNumber(int max)
        {
            return random.Next(max);
        }
    }
}
