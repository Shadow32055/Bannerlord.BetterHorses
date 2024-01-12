using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterHorses.Patches {

    [HarmonyPatch]
    class MissionCombatMechanicsHelperPatch {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), nameof(MissionCombatMechanicsHelper.DecideMountRearedByBlow))]
        public static void DecideMountRearedByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, ref Blow blow, ref bool __result) {

            //If mount rearing is enabled (possible) skip eval
            if (!BetterHorses.Settings.MountsDontRear) {
                //Helper.DisplayFriendlyMsg("mounts dont rear is false");
                return;
            }

            //If no rider exists skip eval
            if (victimAgent.RiderAgent == null) {
                return;
            }

            //If only players pervent rearing and the victim is AI
            if (BetterHorses.Settings.MountsDontRearPlayerOnly && victimAgent.RiderAgent.IsAIControlled) {
                //Helper.DisplayFriendlyMsg("Player only and victimAgent is AI, name = " + victimAgent.Name);
                return;
            }

            //Helper.DisplayFriendlyMsg("W00T");
            __result = false;
        }
    }
}
