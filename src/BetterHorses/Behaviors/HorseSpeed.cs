using BetterHorses.Utils;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterHorses.Behaviors {
    class HorseSpeed : MissionBehavior { 

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, int damage, in MissionWeapon affectorWeapon) {
            base.OnAgentHit(affectedAgent, affectorAgent, damage, affectorWeapon);

            //if (affectedAgent.IsMount) {
            //float num = affectedAgent.Health / affectedAgent.HealthLimit;
            //Helper.DisplayMsg("Setting new speed");
            affectedAgent.SetMaximumSpeedLimit(100, false);
            affectedAgent.SetMinimumSpeed(100);
            affectedAgent.SetAgentDrivenPropertyValueFromConsole(DrivenProperty.MountSpeed, 100);
            affectedAgent.SetAgentDrivenPropertyValueFromConsole(DrivenProperty.CombatMaxSpeedMultiplier, 100);
            affectedAgent.SetAgentDrivenPropertyValueFromConsole(DrivenProperty.MaxSpeedMultiplier, 100);
            affectedAgent.UpdateAgentStats();
            affectedAgent.UpdateAgentProperties();
            affectedAgent.UpdateCustomDrivenProperties();
            //}
        }
    }
}
