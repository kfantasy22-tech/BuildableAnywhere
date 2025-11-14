namespace BuildableAnywhere.Utilities
{
    public sealed class ModConfig
    {
        public bool AllowBuildingInSlimeArea = false;
    }

    internal class GMCMUtility
    {
        internal static void Initialize()
        {
            ReadConfig();
            Register();
        }

        private static void ReadConfig()
        {
            ModEntry.Config = ModEntry.Helper.ReadConfig<ModConfig>();
        }

        private static void Register()
        {
            GenericModConfigMenu.IGenericModConfigMenuApi gmcm = ModEntry.Helper.ModRegistry.GetApi<GenericModConfigMenu.IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (gmcm is null)
                return;

            gmcm.Register(
                mod: ModEntry.ModManifest,
                reset: () => ModEntry.Config = new ModConfig(),
                save: () => ModEntry.Helper.WriteConfig(ModEntry.Config)
            );

            gmcm.AddBoolOption(
                mod: ModEntry.ModManifest,
                name: () => ModEntry.Helper.Translation.Get("GMCM.AllowBuildingInSlimeArea.Title"),
                tooltip: () => ModEntry.Helper.Translation.Get("GMCM.AllowBuildingInSlimeArea.Tooltip"),
                getValue: () => ModEntry.Config.AllowBuildingInSlimeArea,
                setValue: value =>
                {
                    ModEntry.Config.AllowBuildingInSlimeArea = value;
                    BuildableAnywhereUtility.UpdateSlimeArea();
                }
            );
        }
    }
}