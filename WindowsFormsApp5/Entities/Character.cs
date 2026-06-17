using System.Windows.Forms;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Entities
{
    public class Character
    {
        protected string name = "";
        protected int level = 0;
        public ProgressBarValueHelper HP { get; protected set; }

        public Character(string name, int level)
        {
            this.name = name;
            this.level = level;
        }

        public int getLevel() => level;
        public string getName() => name;
    }
}
