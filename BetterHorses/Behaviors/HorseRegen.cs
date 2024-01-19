using BetterCore.Utils;
using System;
using TaleWorlds.MountAndBlade;

namespace BetterHorses.Behaviors {
    class HorseRegen : MissionBehavior {
		private float lastHealthMount;
		private bool tookDamageMount;
		private MissionTime nextHealMount;

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
		
						
				if (this.nextHealMount.IsPast) {

					if (tookDamageMount) {
						tookDamageMount = false;
					}

					if (this.lastHealthMount > Mission.Current.MainAgent.MountAgent.Health) {
						tookDamageMount = true;
						this.nextHealMount = MissionTime.SecondsFromNow(BetterHorses.Settings.MountRegenDamageDelay);
					} else {
						this.nextHealMount = MissionTime.SecondsFromNow(BetterHorses.Settings.MountHealthRegenInterval);

						float healAmount = BetterHorses.Settings.MountHealthRegenAmount;

						Regenerate(Mission.Current.MainAgent.MountAgent, healAmount);

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