using BetterHorses.Localizations;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterHorses.Settings {
    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {

        [SettingPropertyGroup(RefValues.RearingText)]
        [SettingPropertyBool(RefValues.MountRearText, Order = 0, RequireRestart = false, HintText = RefValues.MountRearHint)]
        public bool MountsDontRear { get; set; } = false;

        [SettingPropertyGroup(RefValues.RearingText)]
        [SettingPropertyBool(RefValues.PlayerText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerHint)]
        public bool MountsDontRearPlayerOnly { get; set; } = false;

        [SettingPropertyGroup(RefValues.AdjText)]
        [SettingPropertyFloatingInteger(RefValues.ChargeText, 0f, 100f, "0.0", Order = 0, RequireRestart = false, HintText = RefValues.ChargeHint)]
        public float ChargeDamage { get; set; } = 1f;

        [SettingPropertyGroup(RefValues.AdjText)]
        [SettingPropertyFloatingInteger(RefValues.SpeedText, 0f, 100f, "0.0", Order = 0, RequireRestart = false, HintText = RefValues.SpeedHint)]
        public float Speed { get; set; } = 1f;

        [SettingPropertyGroup(RefValues.AdjText)]
        [SettingPropertyFloatingInteger(RefValues.ManeuverText, 0f, 4f, "0.0", Order = 0, RequireRestart = false, HintText = RefValues.ManeuverHint)]
        public float Maneuver { get; set; } = 1f;

        [SettingPropertyGroup(RefValues.AdjText)]
        [SettingPropertyFloatingInteger(RefValues.AccelText, 0f, 100f, "0.0", Order = 0, RequireRestart = false, HintText = RefValues.AccelHint)]
        public float Acceleration { get; set; } = 1f;

        [SettingPropertyGroup(RefValues.AdjText)]
        [SettingPropertyBool(RefValues.PlayerText, Order = 0, RequireRestart = false, HintText = RefValues.PlayerHint)]
        public bool AdjustmentsPlayerOnly { get; set; } = false;

        [SettingPropertyGroup(RefValues.GodMountText)]
        [SettingPropertyBool(RefValues.InvulnerableText, IsToggle = true, Order = 0, RequireRestart = false, HintText = RefValues.InvulnerableHint)]
        public bool InvulnerableMount { get; set; } = false;

        [SettingPropertyGroup(RefValues.CommandText)]
        [SettingPropertyBool(RefValues.MountCommandsText, Order = 0, IsToggle = true, RequireRestart = false, HintText = RefValues.MountCommandsHint)]
        public bool CommandableMount { get; set; } = false;

        [SettingPropertyGroup(RefValues.CommandText)]
        [SettingProperty(RefValues.KeyText, Order = 0, RequireRestart = true, HintText = RefValues.KeyHint)]
        public string CallKey { get; set; } = "Q";

        [SettingPropertyGroup(RefValues.RegenText)]
        [SettingPropertyBool(RefValues.AllowRegenText, Order = 0, IsToggle = true, RequireRestart = false, HintText = RefValues.AllowRegenHint)]
        public bool AllowRegen { get; set; } = false;

        [SettingPropertyGroup(RefValues.RegenText)]
        [SettingPropertyFloatingInteger(RefValues.RegenAmountText, 0f, 300f, "0.0 HP", Order = 0, RequireRestart = false, HintText = RefValues.RegenAmountHint)]
        public float MountHealthRegenAmount { get; set; } = 0;

        [SettingPropertyGroup(RefValues.RegenText)]
        [SettingPropertyFloatingInteger(RefValues.RegenIntervalText, 1f, 120f, "0.0 Seconds", Order = 0, RequireRestart = false, HintText = RefValues.RegenIntervalHint)]
        public float MountHealthRegenInterval { get; set; } = 1;

        [SettingPropertyGroup(RefValues.RegenText)]
        [SettingPropertyFloatingInteger(RefValues.RegenDelayText, 1f, 120f, "0.0 Seconds", Order = 0, RequireRestart = false, HintText = RefValues.RegenDelayHint)]
        public float MountRegenDamageDelay { get; set; } = 1;

        [SettingPropertyGroup(RefValues.RestockText)]
        [SettingPropertyBool(RefValues.AllowRestockText, Order = 0, IsToggle = true, RequireRestart = false, HintText = RefValues.AllowRestockHint)]
        public bool AllowResstocking { get; set; } = false;

        [SettingPropertyGroup(RefValues.RestockText)]
        [SettingPropertyInteger(RefValues.RestockTimesText, 1, 100, "0", Order = 0, RequireRestart = false, HintText = RefValues.RestockTimesHint)]
        public int StockTimes { get; set; } = 3;

        [SettingPropertyGroup(RefValues.RestockText)]
        [SettingProperty(RefValues.KeyText, Order = 0, RequireRestart = true, HintText = RefValues.KeyHint)]
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

