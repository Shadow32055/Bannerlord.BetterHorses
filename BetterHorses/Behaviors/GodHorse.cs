using TaleWorlds.MountAndBlade;

namespace BetterHorses.Behaviors {
    class GodHorse : MissionBehavior {

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, in MissionWeapon affectorWeapon, in Blow blow, in AttackCollisionData attackCollisionData) {
            base.OnAgentHit(affectedAgent, affectorAgent, affectorWeapon, blow, attackCollisionData);

            if (!BetterHorses.Settings.InvulnerableMount)
                return;

            if (affectedAgent == Agent.Main.MountAgent) {
                Agent.Main.MountAgent.Health = Agent.Main.MountAgent.HealthLimit;
            }
        }
    }
}
