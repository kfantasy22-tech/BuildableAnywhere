using System;
using HarmonyLib;
using StardewModdingAPI;
using BuildableAnywhere.Handlers;
using BuildableAnywhere.Patches;
using BuildableAnywhere.Utilities;

namespace BuildableAnywhere
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        // Instance tunggal
        internal static new IModHelper	Helper { get; private set; }
		internal static new IMonitor	Monitor { get; private set; }
		internal static new IManifest	ModManifest { get; private set; }


        public static ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            Helper = base.Helper;
			Monitor = base.Monitor;
			ModManifest = base.ModManifest;


            try
            {
                Harmony harmony = new(ModManifest.UniqueID);

                // Apply Harmony patches
                AnimalQueryMenuPatch.Apply(harmony);
                CarpenterMenuPatch.Apply(harmony);
                PurchaseAnimalsMenuPatch.Apply(harmony);
                GameLocationPatch.Apply(harmony);
                IslandWestPatch.Apply(harmony);
                FarmAnimalPatch.Apply(harmony);
                JunimoHutPatch.Apply(harmony);
            }
            catch (Exception e)
            {
                Monitor.Log($"Issue with Harmony patching: {e}", LogLevel.Error);
                return;
            }

            // Events
            Helper.Events.GameLoop.GameLaunched += GameLaunchedHandler.Apply;
            Helper.Events.Content.AssetRequested += AssetRequestedHandler.Apply;
        }
    }
}
