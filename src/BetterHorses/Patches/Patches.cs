using HarmonyLib;
using TaleWorlds.Core;
using BetterHorses.Utils;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using static HarmonyLib.AccessTools;

namespace BetterHorses.Patches {

    [HarmonyPatch]
    class Patches {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "DecideMountRearedByBlow")]
        public static void DecideMountRearedByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, ref Blow blow) {

            if (!Helper.settings.MountsDontRear)
                return;

            if(Helper.settings.MountsDontRearPlayerOnly & !victimAgent.IsHuman)
                return;

            blow.BlowFlag = BlowFlags.None;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "ComputeBlowMagnitudeFromHorseCharge")]
        public static void ComputeBlowMagnitudeFromHorseCharge(ref AttackInformation attackInformation, ref AttackCollisionData acd, Vec2 attackerAgentVelocity, Vec2 victimAgentVelocity,
            ref float baseMagnitude, ref float specialMagnitude) {

            specialMagnitude *= Helper.settings.ChargeDamage;
            baseMagnitude *= Helper.settings.ChargeDamage;
        }

        /*static FieldRef<Agent, AgentDrivenProperties> _adp = AccessTools.FieldRefAccess<Agent, AgentDrivenProperties>("_adp");

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Agent), "UpdateAgentProperties")]
        public static bool UpdateAgentProperties(Agent __instance) {
            _adp(__instance).MountSpeed = 100;


            return true;
        }*/
        /*
        [HarmonyPostfix]
        [HarmonyPatch(typeof(CustomBattleAgentStatCalculateModel), "UpdateAgentStats")]
        public static void UpdateAgentStats(Agent agent, ref AgentDrivenProperties agentDrivenProperties) {
            //Helper.DisplayMsg("Called!");
            //if (Helper.settings.MountsSlowDown) {

            if (!agent.IsHuman) {
                float num = agent.Health / agent.HealthLimit;
                agentDrivenProperties.MountSpeed *= num;
                Helper.DisplayMsg(agentDrivenProperties.MountSpeed.ToString());
            }
            //}
        }*/
    }
}
