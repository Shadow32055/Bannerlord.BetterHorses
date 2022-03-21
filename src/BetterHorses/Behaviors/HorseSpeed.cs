using BetterHorses.Utils;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterHorses.Behaviors {
    class HorseSpeed : MissionBehavior { 

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnScoreHit(Agent affectedAgent, Agent affectorAgent, WeaponComponentData attackerWeapon, bool isBlocked, float damage, float damagedHp, float movementSpeedDamageModifier, float hitDistance, AgentAttackType attackType, float shotDifficulty, BoneBodyPartType victimHitBodyPart) {
            base.OnScoreHit(affectedAgent, affectorAgent, attackerWeapon, isBlocked, damage, damagedHp, movementSpeedDamageModifier, hitDistance, attackType, shotDifficulty, victimHitBodyPart);

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
