using BetterCore.Utils;
using HarmonyLib;
using System.Reflection;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.GauntletUI.Mission;
using TaleWorlds.MountAndBlade.ViewModelCollection;

namespace BetterHorses.Behaviors {
    internal class RestockBehavior : MissionBehavior {
        Agent horseAgent;
        Agent userAgent;
        bool hasFocus = false;
        AgentInteractionInterfaceVM intInterface;
        int timesStocked = 0;
        int restockTimes = 0;
        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnDeploymentFinished() {
            base.OnDeploymentFinished();
            userAgent = Mission.Current.MainAgent;

            if (Mission.Current.MainAgent.MountAgent != null) {
                horseAgent = userAgent.MountAgent;
            }

            restockTimes = BetterHorses.Settings.StockTimes;

            MissionGauntletAgentStatus missionBehavior = base.Mission.GetMissionBehavior<MissionGauntletAgentStatus>();
            FieldInfo fieldInfo = AccessTools.Field(typeof(MissionGauntletAgentStatus), "_dataSource");
            FieldInfo fieldInfo2 = AccessTools.Field(typeof(MissionAgentStatusVM), "_interactionInterface");
            intInterface = (AgentInteractionInterfaceVM)fieldInfo2.GetValue(fieldInfo.GetValue(missionBehavior));
        }

        public override void OnFocusGained(Agent agent, IFocusable focusableObject, bool isInteractable) {
            base.OnFocusGained(agent, focusableObject, isInteractable);

            if (focusableObject == horseAgent) {
                hasFocus = true;
                if (timesStocked <= restockTimes) {
                    intInterface.SecondaryInteractionMessage = new TextObject((restockTimes - timesStocked) + " ammo restocks avaiable").ToString();
                } else {
                    intInterface.SecondaryInteractionMessage = new TextObject("No more ammo restocks avaiable").ToString();
                }
                intInterface.IsActive = true;
            }
        }

        public override void OnFocusLost(Agent agent, IFocusable focusableObject) {
            base.OnFocusLost(agent, focusableObject);

            if (focusableObject == horseAgent) {  
                hasFocus = false;
            }
        }

        public override void OnMissionTick(float dt) {
            base.OnMissionTick(dt);

            if (hasFocus && Input.IsKeyPressed(BetterHorses.StockKey) && timesStocked <= restockTimes) {
                for (EquipmentIndex equipmentIndex = EquipmentIndex.WeaponItemBeginSlot; equipmentIndex < EquipmentIndex.NumAllWeaponSlots; equipmentIndex++) {
                    if (!userAgent.Equipment[equipmentIndex].IsEmpty && (userAgent.Equipment[equipmentIndex].CurrentUsageItem.WeaponClass == WeaponClass.Arrow || userAgent.Equipment[equipmentIndex].CurrentUsageItem.WeaponClass == WeaponClass.Bolt) && userAgent.Equipment[equipmentIndex].Amount < userAgent.Equipment[equipmentIndex].ModifiedMaxAmount) {
                        userAgent.SetWeaponAmountInSlot(equipmentIndex, userAgent.Equipment[equipmentIndex].ModifiedMaxAmount, true);
                        NotifyHelper.ChatMessage("Ammo restocked!", MsgType.Good);
                        timesStocked++;
                    }
                }
            }
        }
    }
}
