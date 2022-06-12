using TaleWorlds.Core;
using BetterHorses.Utils;
using TaleWorlds.MountAndBlade;

namespace BetterHorses.Behaviors {
    class GodHorse : MissionBehavior {

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, int damage, in MissionWeapon affectorWeapon) {
            base.OnAgentHit(affectedAgent, affectorAgent, damage, affectorWeapon);

            if (!Helper.settings.InvulnerableMount)
                return;

            if (affectedAgent == Agent.Main.MountAgent) {
                Agent.Main.MountAgent.Health = Agent.Main.MountAgent.HealthLimit;
            }
        }
    }
}
