﻿using System;
using TaleWorlds.Engine;
using BetterCore.Utils;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Localization;

namespace BetterHorses.Behaviors
{
    class HorseCall : MissionBehavior {

        private Agent? horseAgent;

        private WorldPosition stayPosition;

        MissionTime positionUpdate;

        private bool horseStay = true;

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnAgentDismount(Agent agent) {
            base.OnAgentDismount(agent);
            if (agent != Mission.Current.MainAgent)
                return;

            if (horseAgent == null)
                return;

            stayPosition = horseAgent.GetWorldPosition();
        }

        public override void OnDeploymentFinished() {
            base.OnDeploymentFinished();

            if (Mission.Current.MainAgent.HasMount)
                horseAgent = Mission.Current.MainAgent.MountAgent;
        }

        public override void OnMissionTick(float dt) {
            base.OnMissionTick(dt);
            try {
                if (Mission.Current == null)
                    return;

                if (horseAgent == null)
                    return;

                if (horseStay) {
                    if (positionUpdate.IsPast) {
                        MoveHorse(stayPosition);
                        positionUpdate = MissionTime.SecondsFromNow(5);
                    }
                } else {
                    if (positionUpdate.IsPast) {
                        MoveHorse(Mission.Current.MainAgent.GetWorldPosition());
                        positionUpdate = MissionTime.SecondsFromNow(5);
                    }
                }

                if (Input.IsKeyPressed(BetterHorses.CallKey)) {
                    horseStay = !horseStay;

                    if (!horseStay) {
                        NotifyHelper.WriteMessage(new TextObject(Strings.FollowText).ToString(), MsgType.Good);
                        MoveHorse(Mission.Current.MainAgent.GetWorldPosition());
                    } else {
                        NotifyHelper.WriteMessage(new TextObject(Strings.StayText).ToString(), MsgType.Good);
                        stayPosition = horseAgent.GetWorldPosition();

                    }
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterHorses.ModName, "Problem with horse call, cause: " + e);
            }
        }

        private void MoveHorse(WorldPosition pos) {
            if (horseAgent == null)
                return;

            horseAgent.SetScriptedPosition(ref pos,true);
        }
    }
}
