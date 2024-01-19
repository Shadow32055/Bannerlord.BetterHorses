using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterHorses.Settings
{
    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {

        [SettingPropertyGroup(Strings.RearingText)]
        [SettingPropertyBool(Strings.MountRearText, Order = 0, RequireRestart = false, HintText = Strings.MountRearHint)]
        public bool MountsDontRear { get; set; } = false;

        [SettingPropertyGroup(Strings.RearingText)]
        [SettingPropertyBool(Strings.PlayerText, Order = 0, RequireRestart = false, HintText = Strings.PlayerHint)]
        public bool MountsDontRearPlayerOnly { get; set; } = false;

        [SettingPropertyGroup(Strings.AdjText)]
        [SettingPropertyFloatingInteger(Strings.ChargeText, 0f, 100f, "0.0", Order = 0, RequireRestart = false, HintText = Strings.ChargeHint)]
        public float ChargeDamage { get; set; } = 1f;

        [SettingPropertyGroup(Strings.AdjText)]
        [SettingPropertyFloatingInteger(Strings.SpeedText, 0f, 100f, "0.0", Order = 0, RequireRestart = false, HintText = Strings.SpeedHint)]
        public float Speed { get; set; } = 1f;

        [SettingPropertyGroup(Strings.AdjText)]
        [SettingPropertyFloatingInteger(Strings.ManeuverText, 0f, 4f, "0.0", Order = 0, RequireRestart = false, HintText = Strings.ManeuverHint)]
        public float Maneuver { get; set; } = 1f;

        [SettingPropertyGroup(Strings.AdjText)]
        [SettingPropertyFloatingInteger(Strings.AccelText, 0f, 100f, "0.0", Order = 0, RequireRestart = false, HintText = Strings.AccelHint)]
        public float Acceleration { get; set; } = 1f;

        [SettingPropertyGroup(Strings.AdjText)]
        [SettingPropertyBool(Strings.PlayerText, Order = 0, RequireRestart = false, HintText = Strings.PlayerHint)]
        public bool AdjustmentsPlayerOnly { get; set; } = false;

        [SettingPropertyGroup(Strings.GodMountText)]
        [SettingPropertyBool(Strings.InvulnerableText, IsToggle = true, Order = 0, RequireRestart = false, HintText = Strings.InvulnerableHint)]
        public bool InvulnerableMount { get; set; } = false;

        [SettingPropertyGroup(Strings.CommandText)]
        [SettingPropertyBool(Strings.MountCommandsText, Order = 0, IsToggle = true, RequireRestart = false, HintText = Strings.MountCommandsHint)]
        public bool CommandableMount { get; set; } = false;

        [SettingPropertyGroup(Strings.CommandText)]
        [SettingProperty(Strings.KeyText, Order = 0, RequireRestart = true, HintText = Strings.KeyHint)]
        public string CallKey { get; set; } = "Q";

        [SettingPropertyGroup(Strings.RegenText)]
        [SettingPropertyBool(Strings.AllowRegenText, Order = 0, IsToggle = true, RequireRestart = false, HintText = Strings.AllowRegenHint)]
        public bool AllowRegen { get; set; } = false;

        [SettingPropertyGroup(Strings.RegenText)]
        [SettingPropertyFloatingInteger(Strings.RegenAmountText, 0f, 300f, "0.0 HP", Order = 0, RequireRestart = false, HintText = Strings.RegenAmountHint)]
        public float MountHealthRegenAmount { get; set; } = 0;

        [SettingPropertyGroup(Strings.RegenText)]
        [SettingPropertyFloatingInteger(Strings.RegenIntervalText, 1f, 120f, "0.0 Seconds", Order = 0, RequireRestart = false, HintText = Strings.RegenIntervalHint)]
        public float MountHealthRegenInterval { get; set; } = 1;

        [SettingPropertyGroup(Strings.RegenText)]
        [SettingPropertyFloatingInteger(Strings.RegenDelayText, 1f, 120f, "0.0 Seconds", Order = 0, RequireRestart = false, HintText = Strings.RegenDelayHint)]
        public float MountRegenDamageDelay { get; set; } = 1;

        [SettingPropertyGroup(Strings.RestockText)]
        [SettingPropertyBool(Strings.AllowRestockText, Order = 0, IsToggle = true, RequireRestart = false, HintText = Strings.AllowRestockHint)]
        public bool AllowResstocking { get; set; } = false;

        [SettingPropertyGroup(Strings.RestockText)]
        [SettingPropertyInteger(Strings.RestockTimesText, 1, 100, "0", Order = 0, RequireRestart = false, HintText = Strings.RestockTimesHint)]
        public int StockTimes { get; set; } = 3;

        [SettingPropertyGroup(Strings.RestockText)]
        [SettingProperty(Strings.KeyText, Order = 0, RequireRestart = true, HintText = Strings.KeyHint)]
        public string StockKey { get; set; } = "E";

        //[SettingPropertyBool("Mount speed based on health", Order = 0, RequireRestart = false, HintText = "Whether mounts slow down based on health. 50% health means horse moves at 50% speed")]
        //public bool MountsSlowDown { get; set; } = false;



        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}

