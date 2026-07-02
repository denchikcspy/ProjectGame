
namespace WindowsFormsApp5.Battle
{
    public class BattleActionResult
    {
        public string LogText { get; set; } = "";

        public int DamageDone { get; set; } = 0;
        public int HealDone { get; set; } = 0;
        public int MpSpent { get; set; } = 0;
        public int MpRestored { get; set; } = 0;

        public bool IsCritical { get; set; } = false;
        public bool WasDodged { get; set; } = false;
        public bool WasBlockedByArmor { get; set; } = false;
        public bool TargetDamaged { get; set; } = false;
        public bool TargetDestroyed { get; set; } = false;

        public BattleImageState ImageState { get; set; } = BattleImageState.None;
    }
}