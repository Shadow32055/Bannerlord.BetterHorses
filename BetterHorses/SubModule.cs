using HarmonyLib;
using TaleWorlds.Core;
using BetterHorses.Utils;
using BetterHorses.Settings;
using BetterHorses.Behaviors;
using TaleWorlds.MountAndBlade;

namespace BetterHorses {
    public class SubModule : MBSubModuleBase {

		protected override void OnBeforeInitialModuleScreenSetAsRoot() {
			base.OnBeforeInitialModuleScreenSetAsRoot();

			string modName = base.GetType().Assembly.GetName().Name;

			Helper.SetModName(modName);
			Helper.settings = SettingsManager.Instance;
			Helper.RegisterCallKey();
		}

		protected override void OnGameStart(Game g, IGameStarter ig) {
			base.OnGameStart(g, ig);

			new Harmony("Bannerlord.Shadow.BetterHorses").PatchAll();
		}

		public override void OnMissionBehaviorInitialize(Mission mission) {
			base.OnMissionBehaviorInitialize(mission);

			if (Helper.settings.CommandableMount) {
				mission.AddMissionBehavior(new HorseCall());
			}

			if (Helper.settings.InvulnerableMount) {
				mission.AddMissionBehavior(new GodHorse());
			}

			//mission.AddMissionBehavior(new HorseSpeed());
			mission.AddMissionBehavior(new HorseRegen());
		}
	}
}