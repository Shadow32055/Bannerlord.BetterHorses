using System;
using TaleWorlds.Core;
using TaleWorlds.Library;
using BetterHorses.Settings;
using TaleWorlds.InputSystem;

namespace BetterHorses.Utils {
    public class Helper {
        public static string modName = "ForgotToSet";
        public static ISettings settings;
        public static InputKey callKey = InputKey.Q;
        public static void SetModName(string name) {
            modName = name;
            DisplayFriendlyMsg(modName + " Loaded.");
        }

        public static void RegisterCallKey() {
            try {
                if (Enum.IsDefined(typeof(InputKey), settings.CallKey)) {
                    callKey = (InputKey)Enum.Parse(typeof(InputKey), settings.CallKey);
                    //DisplayWarningMsg("Key: " + settings.CallKey);
                } else {
                    throw new Exception();
                }
            } catch (Exception e) {
                DisplayWarningMsg("Issue registering call key. '" + settings.CallKey + "' is not a valid key. Using deafult 'Q' key.");
                Helper.WriteToLog("register key exception: " + e);
            }
        }

        public static void DisplayFriendlyMsg(string msg) {
            InformationManager.DisplayMessage(new InformationMessage(msg, Colors.Green));
            WriteToLog(msg);
        }

        public static void DisplayMsg(string msg) {
            InformationManager.DisplayMessage(new InformationMessage(msg));
            WriteToLog(msg);
        }

        public static void DisplayWarningMsg(string msg) {
            InformationManager.DisplayMessage(new InformationMessage(msg, Colors.Red));
            WriteToLog(msg);
        }

        public static void WriteToLog(string text) {
            Debug.Print(modName + ": " + text);
        }
    }
}
