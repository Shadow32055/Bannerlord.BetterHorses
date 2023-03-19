
namespace BetterHorses.Settings {
    public class DefaultSettings : ISettings {
        public bool InvulnerableMount { get; set; } = false;
        public bool CommandableMount { get; set; } = false;
        public bool MountsDontRear { get; set; } = false;
        public bool MountsDontRearPlayerOnly { get; set; } = false;
        public float ChargeDamage { get; set; } = 1f;
        public string CallKey { get; set; } = "Q";
        public float MountHealthRegenAmount { get; set; } = 0;
        public float MountHealthRegenInterval { get; set; } = 1;
        public float MountRegenDamageDelay { get; set; } = 1;
        //public bool MountsSlowDown { get; set; } = false;
    }
}
