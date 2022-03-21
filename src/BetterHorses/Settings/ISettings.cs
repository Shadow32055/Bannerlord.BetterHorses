
namespace BetterHorses.Settings {
    public interface ISettings {
        bool InvulnerableMount { get; set; }
        bool CommandableMount { get; set; }
        bool MountsDontRear { get; set; }
        bool MountsDontRearPlayerOnly { get; set; }
        float ChargeDamage { get; set; }
        string CallKey { get; set; }
        float MountHealthRegenAmount { get; set; }
        float MountHealthRegenInterval { get; set; }
        float MountRegenDamageDelay { get; set; }
        //bool MountsSlowDown { get; set; }
    }
}
