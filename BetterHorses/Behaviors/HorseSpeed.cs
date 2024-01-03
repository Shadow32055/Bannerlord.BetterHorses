using TaleWorlds.MountAndBlade;

namespace BetterHorses.Behaviors {
    class HorseSpeed : MissionBehavior { 

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        /*public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, in MissionWeapon affectorWeapon, in Blow blow, in AttackCollisionData attackCollisionData) {
            base.OnAgentHit(affectedAgent, affectorAgent, affectorWeapon, blow, attackCollisionData);

            if (affectedAgent.IsMount) {
                affectedAgent.AgentDrivenProperties.MaxSpeedMultiplier = 100f;
                affectedAgent.AgentDrivenProperties.MountSpeed = 100f;
                affectedAgent.SetMaximumSpeedLimit(100f, true);
                //float num = affectedAgent.Health / affectedAgent.HealthLimit;
                Helper.DisplayMsg("Setting new speed");
                //affectedAgent.MountAgent.SetMinimumSpeed(100f);
                //affectedAgent.MountAgent.SetMaximumSpeedLimit(100f, false);
                //affectedAgent.SetMaximumSpeedLimit(100, false);
                //affectedAgent.SetMinimumSpeed(100);
                //affectedAgent.SetAgentDrivenPropertyValueFromConsole(DrivenProperty.MountSpeed, 100);
                //affectedAgent.SetAgentDrivenPropertyValueFromConsole(DrivenProperty.CombatMaxSpeedMultiplier, 100);
                //affectedAgent.SetAgentDrivenPropertyValueFromConsole(DrivenProperty.MaxSpeedMultiplier, 100);
                affectedAgent.UpdateAgentProperties();
                affectedAgent.UpdateAgentStats();
                //affectedAgent.UpdateCustomDrivenProperties();
            }
        }*/

        public override void OnMissionTick(float dt) {
            base.OnMissionTick(dt);

            //foreach ( Agent agent in Mission.Agents) {
                //if (agent.IsMount) {

            //Agent.Main.AgentDrivenProperties.MaxSpeedMultiplier = 100f;
            //Agent.Main.AgentDrivenProperties.MountSpeed = 100f;
            Agent.Main.SetMaximumSpeedLimit(100f, true);
            //float num = affectedAgent.Health / affectedAgent.HealthLimit;
            //Helper.DisplayMsg("Setting new speed");
            //affectedAgent.MountAgent.SetMinimumSpeed(100f);
            //affectedAgent.MountAgent.SetMaximumSpeedLimit(100f, false);
            //affectedAgent.SetMaximumSpeedLimit(100, false);
            //affectedAgent.SetMinimumSpeed(100);
            //affectedAgent.SetAgentDrivenPropertyValueFromConsole(DrivenProperty.MountSpeed, 100);
            //affectedAgent.SetAgentDrivenPropertyValueFromConsole(DrivenProperty.CombatMaxSpeedMultiplier, 100);
            //affectedAgent.SetAgentDrivenPropertyValueFromConsole(DrivenProperty.MaxSpeedMultiplier, 100);
            Agent.Main.UpdateAgentProperties();
            Agent.Main.UpdateAgentStats();
                    //affectedAgent.UpdateCustomDrivenProperties();
                //}
           // }
        }
    }
}
