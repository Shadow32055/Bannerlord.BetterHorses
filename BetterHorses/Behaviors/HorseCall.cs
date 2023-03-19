using System;
using TaleWorlds.Engine;
using BetterHorses.Utils;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;

namespace BetterHorses.Behaviors {
    class HorseCall : MissionBehavior {

        private Agent horseAgent;

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

                            if (Input.IsKeyPressed(Helper.callKey)) {
                                horseStay = !horseStay;

                                if (!horseStay) {
                                    Helper.DisplayFriendlyMsg("Horse will follow you.");
                                    MoveHorse(mission.MainAgent.GetWorldPosition());
                                } else {
                                    Helper.DisplayFriendlyMsg("Horse will stay put.");
                                    pos = mission.MainAgent.GetWorldPosition();
                                }
                            }
                        }
                    }
                } else {
                    positionUpdate = MissionTime.Zero;
                }
            } catch (Exception e) {
                Helper.WriteToLog("Problem with horse call, cause: " + e);
            }
        }

        private void MoveHorse(WorldPosition pos) {
            float num = pos.GetGroundVec3().Distance(this.horseAgent.Position);
            if (num > 20f) {
                horseAgent.SetScriptedPositionAndDirection(ref pos, 0f, true, Agent.AIScriptedFrameFlags.None);
            } else if (num > 10f) {
                horseAgent.SetScriptedPositionAndDirection(ref pos, 0f, true, Agent.AIScriptedFrameFlags.DoNotRun);
            }
        }
    }
}
