﻿using BetterCore.Utils;
using BetterHorses.Behaviors;
using BetterHorses.Settings;
using HarmonyLib;
using System;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;

namespace BetterHorses {
    public class BetterHorses : MBSubModuleBase {

        public static InputKey CallKey { get; private set; }  = InputKey.Q;
        public static InputKey StockKey { get; private set; } = InputKey.F;
        public static MCMSettings Settings { get; private set; } = new MCMSettings();
        public static string ModName { get; private set; } = "BetterHorses";

        private bool isInitialized = false;
        private bool isLoaded = false;

        //FIRST
        protected override void OnSubModuleLoad() {
            try {
                base.OnSubModuleLoad();

                if (isInitialized)
                    return;

                Harmony h = new("Bannerlord.Shadow." + ModName);

                h.PatchAll();

                isInitialized = true;
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnSubModuleLoad threw exception " + e);
            }
        }

        //SECOND
        protected override void OnBeforeInitialModuleScreenSetAsRoot() {
            try {
                base.OnBeforeInitialModuleScreenSetAsRoot();

                if (isLoaded)
                    return;

                ModName = base.GetType().Assembly.GetName().Name;

                Settings = MCMSettings.Instance ?? throw new NullReferenceException("Settings are null");

                NotifyHelper.WriteMessage(ModName + " Loaded.", MsgType.Good);

                RegisterCallKey();
                RegisterStockKey();

                Integrations.BetterHealthLoaded = true;

                isLoaded = true;
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnBeforeInitialModuleScreenSetAsRoot threw exception " + e);
            }
        }

        public override void OnMissionBehaviorInitialize(Mission mission) {
			base.OnMissionBehaviorInitialize(mission);

			if (Settings.CommandableMount) {
				mission.AddMissionBehavior(new HorseCall());
			}

			if (Settings.InvulnerableMount) {
				mission.AddMissionBehavior(new GodHorse());
			}

            if (Settings.AllowRegen) {
                mission.AddMissionBehavior(new HorseRegen());
            }

            if (Settings.AllowResstocking) {
                mission.AddMissionBehavior(new RestockBehavior());
            }
        }

        public static void RegisterCallKey() {
            try {
                if (Enum.IsDefined(typeof(InputKey), Settings.CallKey)) {
                    CallKey = (InputKey)Enum.Parse(typeof(InputKey), Settings.CallKey);
                    //DisplayWarningMsg("Key: " + settings.CallKey);
                } else {
                    throw new Exception();
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "Register call key exception: " + e);
            }
        }

        public static void RegisterStockKey() {
            try {
                if (Enum.IsDefined(typeof(InputKey), Settings.CallKey)) {
                    StockKey = (InputKey)Enum.Parse(typeof(InputKey), Settings.StockKey);
                    //DisplayWarningMsg("Key: " + settings.CallKey);
                } else {
                    throw new Exception();
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "Register stock key exception: " + e);
            }
        }
    }
}