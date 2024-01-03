using System;
using TaleWorlds.Engine;
using BetterCore.Utils;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;

namespace BetterHorses.Behaviors {
    class HorseCall : MissionBehavior {

        private Agent? horseAgent;

        private WorldPosition pos;

        MissionTime positionUpdate;

        private bool horseStay = false;

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnMissionTick(float dt) {
            base.OnMissionTick(dt);
            try {
                Mission mission = Mission.Current;

                if (mission != null && mission.MainAgent != null) {
                    if (mission.MainAgent.HasMount) {
                        horseAgent = mission.MainAgent.MountAgent;
                    }

                    if (!mission.MainAgent.HasMount) {
                        if (horseAgent != null) {

                            if (horseStay) {
                                if (positionUpdate.IsPast) {
                                    MoveHorse(pos);
                                    positionUpdate = MissionTime.SecondsFromNow(5);
                                }
                            } else {
                                if (positionUpdate.IsPast) {
                                    MoveHorse(mission.MainAgent.GetWorldPosition());
                                    positionUpdate = MissionTime.SecondsFromNow(5);
                                }
                            }

                            if (Input.IsKeyPressed(SubModule.callKey)) {
                                horseStay = !horseStay;

                                if (!horseStay) {
                                    Logger.SendMessage("Horse will follow you.", Severity.Good);
                                    MoveHorse(mission.MainAgent.GetWorldPosition());
                                } else {
                                    Logger.SendMessage("Horse will stay put.", Severity.Good);
                                    pos = horseAgent.GetWorldPosition();

                                }
                            }
                        }
                    }
                } else {
                    positionUpdate = MissionTime.Zero;
                }
            } catch (Exception e) {
                Logger.SendMessage("Problem with horse call, cause: " + e, Severity.High);
            }
        }

        private void MoveHorse(WorldPosition pos) {
            horseAgent.SetScriptedPosition(ref pos,true);
        }
    }
}
