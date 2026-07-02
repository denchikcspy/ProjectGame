using System;
using System.Windows.Forms;
using WindowsFormsApp5.Forms;
using WindowsFormsApp5.Entities;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Utils;
using WindowsFormsApp5.Battle;

namespace WindowsFormsApp5
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ProgressBarValueHelper hp = new ProgressBarValueHelper(100);
            ProgressBarValueHelper mp = new ProgressBarValueHelper(100);
            Weapon Stweapon = new Weapon("Якась зброя", 0, 45, 50, 60,null);
            Armor Starmor = new Armor("Якась броня", 0, 50,null);
            Player player = new Player("Denys", 1000, hp, mp,Stweapon,Starmor,new BattleSprites());
            Application.Run(new TankChooseForm());
        }
    }
}
