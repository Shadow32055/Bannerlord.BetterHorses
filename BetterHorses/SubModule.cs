using BetterCore.Utils;
using BetterHorses.Behaviors;
using BetterHorses.Settings;
using HarmonyLib;
using System;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;

namespace BetterHorses {
    public class SubModule : MBSubModuleBase {

        public static MCMSettings _settings;
        public static InputKey callKey = InputKey.Q;

        protected override void OnSubModuleLoad() {
            base.OnSubModuleLoad();

            Harmony h = new("Bannerlord.Shadow.BetterHorses");

            h.PatchAll();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot() {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            string modName = base.GetType().Assembly.GetName().Name;

            Helper.SetModName(modName);
            if (MCMSettings.Instance is not null) {
                _settings = MCMSettings.Instance;
            } else {
                Logger.SendMessage("Failed to find settings instance!", Severity.High);
            }
        }

		public override void OnMissionBehaviorInitialize(Mission mission) {
			base.OnMissionBehaviorInitialize(mission);

			if (_settings.CommandableMount) {
				mission.AddMissionBehavior(new HorseCall());
			}

			if (_settings.InvulnerableMount) {
				mission.AddMissionBehavior(new GodHorse());
			}

			//mission.AddMissionBehavior(new HorseSpeed());
			mission.AddMissionBehavior(new HorseRegen());
        }

        public static void RegisterCallKey() {
            try {
                if (Enum.IsDefined(typeof(InputKey), _settings.CallKey)) {
                    callKey = (InputKey)Enum.Parse(typeof(InputKey), _settings.CallKey);
                    //DisplayWarningMsg("Key: " + settings.CallKey);
                } else {
                    throw new Exception();
                }
            } catch (Exception e) {
                Logger.SendMessage("Issue registering call key. '" + _settings.CallKey + "' is not a valid key. Using deafult 'Q' key.", Severity.High);
                Logger.PrintToLog("register key exception: " + e);
            }
        }
    }
}