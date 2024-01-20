using BetterCore.Utils;
using System;
using TaleWorlds.MountAndBlade;

namespace BetterHorses.Behaviors {
    class HorseRegen : MissionBehavior {
		private float lastHealthMount;
		private MissionTime nextHealMount = MissionTime.Zero;

		public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

		public override void OnMissionTick(float dt) {
			base.OnMissionTick(dt);

			try {

                if (Mission.Current == null)
                    return;

				if (Mission.Current.MainAgent == null)
					return;

				if (!Mission.Current.MainAgent.HasMount)
					return;

				if (BetterHorses.Settings.MountHealthRegenAmount == 0)
					return;

				if (Mission.Current.MainAgent.MountAgent.Health == Mission.Current.MainAgent.MountAgent.HealthLimit)
					return;
				

				if (this.nextHealMount.IsPast) {

					if (this.lastHealthMount > Mission.Current.MainAgent.MountAgent.Health) {
					
						this.nextHealMount = MissionTime.SecondsFromNow(BetterHorses.Settings.MountRegenDamageDelay);
					} else {
						this.nextHealMount = MissionTime.SecondsFromNow(BetterHorses.Settings.MountHealthRegenInterval);

						Regenerate(Mission.Current.MainAgent.MountAgent, BetterHorses.Settings.MountHealthRegenAmount);

					}
					this.lastHealthMount = Mission.Current.MainAgent.MountAgent.Health;
				}
			} catch (Exception e) {
				NotifyHelper.WriteError(BetterHorses.ModName, "Problem with health regen, cause: " + e);
			}
		}

		private void Regenerate(Agent agent, float amount) {
			if (agent.Health < agent.HealthLimit) {
				float healAmount = HealthHelper.GetMaxHealAmount(amount, agent);

				agent.Health += healAmount;
				//agent.UpdateAgentStats();
			}
		}
	}
}