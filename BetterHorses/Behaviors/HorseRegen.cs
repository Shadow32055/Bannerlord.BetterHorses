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
				Mission mission = Mission.Current;
				if (mission != null && mission.MainAgent != null) {


					if (BetterHorses.Settings.MountHealthRegenAmount > 0) {
						if (mission.MainAgent.HasMount) {
							if (this.nextHealMount.IsPast) {

								if (tookDamageMount) {
									tookDamageMount = false;
								}

								if (this.lastHealthMount > mission.MainAgent.MountAgent.Health) {
									tookDamageMount = true;
									this.nextHealMount = MissionTime.SecondsFromNow(BetterHorses.Settings.MountRegenDamageDelay);
								} else {
									this.nextHealMount = MissionTime.SecondsFromNow(BetterHorses.Settings.MountHealthRegenInterval);

									float healAmount = BetterHorses.Settings.MountHealthRegenAmount;

								

									Regenerate(mission.MainAgent.MountAgent, healAmount);

								}
								this.lastHealthMount = mission.MainAgent.MountAgent.Health;
							}
						}
					}

				} else {
					this.nextHealMount = MissionTime.Zero;
				}
			} catch (Exception e) {
				NotifyHelper.ReportError(BetterHorses.ModName, "Problem with health regen, cause: " + e);
			}
		}

		private void Regenerate(Agent agent, float amount) {
			if (agent.Health < agent.HealthLimit) {
				float healAmount = GetHealAmount(amount, agent);

				
				agent.Health += healAmount;
				agent.UpdateAgentStats();
				//agent.SetAgentDrivenPropertyValueFromConsole(TaleWorlds.Core.DrivenProperty.MountSpeed, 10);
			}
		}

		public float GetHealAmount(float healAmount, Agent agent) {
			if ((healAmount + agent.Health) > agent.HealthLimit) {
				return agent.HealthLimit - agent.Health;
			}

			return healAmount;
		}
	}
}