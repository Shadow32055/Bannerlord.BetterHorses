using HarmonyLib;
using TaleWorlds.Core;
using BetterHorses.Utils;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
//using static HarmonyLib.AccessTools;

namespace BetterHorses.Patches {

    [HarmonyPatch]
    class Patches {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "DecideMountRearedByBlow")]
        public static void DecideMountRearedByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, ref Blow blow, ref bool __result) {

            //If mount rearing is enabled (possible) skip eval
            if (!Helper.settings.MountsDontRear) {
                //Helper.DisplayFriendlyMsg("mounts dont rear is false");
                return;
            }

            //If no rider exists skip eval
            if (victimAgent.RiderAgent == null) {
                return;
            }

            //If only players pervent rearing and the victim is AI
            if (Helper.settings.MountsDontRearPlayerOnly && victimAgent.RiderAgent.IsAIControlled) {
                //Helper.DisplayFriendlyMsg("Player only and victimAgent is AI, name = " + victimAgent.Name);
                return;
            }

            //Helper.DisplayFriendlyMsg("W00T");
            __result = false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "ComputeBlowMagnitudeFromHorseCharge")]
        public static bool ComputeBlowMagnitudeFromHorseCharge(ref AttackInformation attackInformation, ref AttackCollisionData acd, Vec2 attackerAgentVelocity, Vec2 victimAgentVelocity,
            ref float baseMagnitude, ref float specialMagnitude) {

            attackerAgentVelocity = attackerAgentVelocity * Helper.settings.ChargeDamage;

            Vec2 attackerAgentMovementDirection = attackInformation.AttackerAgentMovementDirection;
            Vec2 v = attackerAgentMovementDirection * Vec2.DotProduct(victimAgentVelocity, attackerAgentMovementDirection);
            Vec2 vec = attackerAgentVelocity - v;
            AttackCollisionData attackCollisionData = acd;
            Vec3 collisionGlobalPosition = attackCollisionData.CollisionGlobalPosition;
            float num = ChargeDamageDotProduct(attackInformation.VictimAgentPosition, attackerAgentMovementDirection, collisionGlobalPosition);
            float num2 = vec.Length * num;
            baseMagnitude = num2 * num2 * num * attackInformation.AttackerAgentMountChargeDamageProperty;
            specialMagnitude = baseMagnitude;

            return false;
        }

        private static float ChargeDamageDotProduct(in Vec3 victimPosition, in Vec2 chargerMovementDirection, in Vec3 collisionPoint) {
            Vec3 vec = victimPosition;
            Vec2 asVec = vec.AsVec2;
            vec = collisionPoint;
            float b = Vec2.DotProduct((asVec - vec.AsVec2).Normalized(), chargerMovementDirection);
            return MathF.Max(0f, b);
        }

        /*
        
        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "ComputeBlowMagnitudeFromHorseCharge")]
        public static void ComputeBlowMagnitudeFromHorseCharge(ref AttackInformation attackInformation, ref AttackCollisionData acd, Vec2 attackerAgentVelocity, Vec2 victimAgentVelocity,
            ref float baseMagnitude, ref float specialMagnitude) {

            specialMagnitude *= Helper.settings.ChargeDamage;
            baseMagnitude *= Helper.settings.ChargeDamage;
        }
        
        */
        /*

        static FieldRef<Agent, AgentDrivenProperties> _adp = AccessTools.FieldRefAccess<Agent, AgentDrivenProperties>("_adp");

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Agent), "UpdateAgentProperties")]
        public static bool UpdateAgentProperties(Agent __instance) {
            _adp(__instance).MountSpeed = 100;


            return true;
        }
        
        */
        /*
        
        [HarmonyPostfix]
        [HarmonyPatch(typeof(CustomBattleAgentStatCalculateModel), "UpdateAgentStats")]
        public static void UpdateAgentStats(Agent agent, ref AgentDrivenProperties agentDrivenProperties) {
            Helper.DisplayMsg("Called!");
            if (Helper.settings.MountsSlowDown) {

                if (!agent.IsHuman) {
                    float num = agent.Health / agent.HealthLimit;
                    agentDrivenProperties.MountSpeed *= num;
                    Helper.DisplayMsg(agentDrivenProperties.MountSpeed.ToString());
                }
            }
        }

        */
        /*

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Mission), "OnTick")]
        public static void OnTick(float dt, float realDt, bool updateCamera, bool doAsyncAITick) {
            Agent.Main.SetMaximumSpeedLimit(100f, true);
        }

        */
    }
}
