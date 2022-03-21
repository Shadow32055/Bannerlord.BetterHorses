using System;
using BetterHorses.Utils;
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


					if (Helper.settings.MountHealthRegenAmount > 0) {
						if (mission.MainAgent.HasMount) {
							if (this.nextHealMount.IsPast) {

								if (tookDamageMount) {
									tookDamageMount = false;
								}

								if (this.lastHealthMount > mission.MainAgent.MountAgent.Health) {
									tookDamageMount = true;
									this.nextHealMount = MissionTime.SecondsFromNow(Helper.settings.MountRegenDamageDelay);
								} else {
									this.nextHealMount = MissionTime.SecondsFromNow(Helper.settings.MountHealthRegenInterval);

									float healAmount = Helper.settings.MountHealthRegenAmount;

								

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
				Helper.WriteToLog("Problem with health regen, cause: " + e);
			}
		}

		private void Regenerate(Agent agent, float amount) {
			if (agent.Health < agent.HealthLimit) {
				float healAmount = GetHealAmount(amount, agent);

				
				agent.Health += healAmount;
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