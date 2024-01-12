using BetterCore.Utils;
using HarmonyLib;
using SandBox.GameComponents;
using System;
using TaleWorlds.MountAndBlade;

namespace BetterHorses.Patches {
    [HarmonyPatch(typeof(SandboxAgentStatCalculateModel))]
    class SandboxAgentStatCalculateModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), nameof(SandboxAgentStatCalculateModel.UpdateAgentStats))]
        public static void UpdateAgentStats(Agent agent, AgentDrivenProperties agentDrivenProperties) {
            try {
               if (agent is null)
                   return;

                if (agent.IsMount) {
                    if (agent.RiderAgent != null) {
                        if ((agent.RiderAgent.IsPlayerUnit && BetterHorses.Settings.AdjustmentsPlayerOnly) || !BetterHorses.Settings.AdjustmentsPlayerOnly) {

                            agentDrivenProperties.MountSpeed *= BetterHorses.Settings.Speed;
                            agentDrivenProperties.MountManeuver *= BetterHorses.Settings.Maneuver;
                            agentDrivenProperties.MountDashAccelerationMultiplier *= BetterHorses.Settings.Acceleration;
                            agentDrivenProperties.MountChargeDamage *= BetterHorses.Settings.ChargeDamage;
                        }
                    }

                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterHorses.ModName, "SandboxAgentStatCalculateModel.UpdateAgentStats threw exception: " + e);
            }
        }
    }
}
