using TaleWorlds.Core;
using BetterHorses.Utils;
using TaleWorlds.MountAndBlade;

namespace BetterHorses.Behaviors {
    class GodHorse : MissionBehavior {

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnScoreHit(Agent affectedAgent, Agent affectorAgent, WeaponComponentData attackerWeapon, bool isBlocked, float damage, float damagedHp, float movementSpeedDamageModifier, float hitDistance, AgentAttackType attackType, float shotDifficulty, BoneBodyPartType victimHitBodyPart) {
            base.OnScoreHit(affectedAgent, affectorAgent, attackerWeapon, isBlocked, damage, damagedHp, movementSpeedDamageModifier, hitDistance, attackType, shotDifficulty, victimHitBodyPart);

            if (!Helper.settings.InvulnerableMount)
                return;

            if (affectedAgent == Agent.Main.MountAgent) {
                Agent.Main.MountAgent.Health = Agent.Main.MountAgent.HealthLimit;
            }
        }
    }
}
