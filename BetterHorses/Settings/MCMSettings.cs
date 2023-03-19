using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterHorses.Settings {
    internal class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettings {

        [SettingPropertyGroup("Horse Rearing")]
        [SettingPropertyBool("Mounts Don't Rear", Order = 0, RequireRestart = false, HintText = "Whether horses rear when hit.")]
        public bool MountsDontRear { get; set; } = false;

        [SettingPropertyGroup("Horse Rearing")]
        [SettingPropertyBool("Only Player?", Order = 0, RequireRestart = false, HintText = "Whether player only horses dont rear when hit.")]
        public bool MountsDontRearPlayerOnly { get; set; } = false;

        [SettingPropertyFloatingInteger("Charge Velocity Multiplier", 0f, 100f, "0.0", Order = 0, RequireRestart = false, HintText = "Causes increased charge damage due to multipling the attacker velocity. No speed adjustments, just multiplies the velocity by the selected amount in the charge damage caluclation. Set to 1 for vanilla, .5 for half charge velocity(damage).")]
        public float ChargeDamage { get; set; } = 1f;

        [SettingPropertyBool("Invulnerable Horse", Order = 0, RequireRestart = false, HintText = "Whether player mount can take damage or not. Only while mounted.")]
        public bool InvulnerableMount { get; set; } = false;

        [SettingPropertyGroup("Horse Commands")]
        [SettingPropertyBool("Horse Commands", Order = 0, IsToggle = true, RequireRestart = false, HintText = "Whether or not to enable horse commands, stay and follow.")]
        public bool CommandableMount { get; set; } = false;

        [SettingPropertyGroup("Horse Commands")]
        [SettingProperty("Command Key", Order = 0, RequireRestart = true, HintText = "What key to use for horse commands. Examples 'Q', 'Numpad0'.")]
        public string CallKey { get; set; } = "Q";

        [SettingPropertyGroup("Regeneration")]
        [SettingPropertyFloatingInteger("Mount Health Regen Amount", 0f, 300f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "Percentage of health restored each regeneration")]
        public float MountHealthRegenAmount { get; set; } = 0;

        [SettingPropertyGroup("Regeneration")]
        [SettingPropertyFloatingInteger("Mount Health Regen Interval", 1f, 120f, "0.0 Seconds", Order = 0, RequireRestart = false, HintText = "Time between each regeneration")]
        public float MountHealthRegenInterval { get; set; } = 1;

        [SettingPropertyGroup("Regeneration")]
        [SettingPropertyFloatingInteger("Mount Regen Damage Delay", 1f, 120f, "0.0 Seconds", Order = 0, RequireRestart = false, HintText = "Time until next heal after damage")]
        public float MountRegenDamageDelay { get; set; } = 1;

        //[SettingPropertyBool("Mount speed based on health", Order = 0, RequireRestart = false, HintText = "Whether mounts slow down based on health. 50% health means horse moves at 50% speed")]
        //public bool MountsSlowDown { get; set; } = false;



        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get; } = "Better Horses";
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}

