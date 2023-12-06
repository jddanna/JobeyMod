using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using JobeyMod.Patches;

namespace JobeyMod
{
    [BepInPlugin(modGuid, modName, modVersion)]
    public class JobeyMod : BaseUnityPlugin
    {
        private const string modGuid = "JobeyMod.Plugin";
        private const string modName = "Jobey Mod";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new(modGuid);

        private static JobeyMod Instance;

        internal ManualLogSource logSource;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            logSource = BepInEx.Logging.Logger.CreateLogSource(modGuid);

            logSource.LogInfo("mod awake");

            harmony.PatchAll(typeof(JobeyMod));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
