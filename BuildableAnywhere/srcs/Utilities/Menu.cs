using StardewModdingAPI.Events;
using StardewValley.GameData.Locations;

namespace BuildableAnywhere.Utilities
{
    internal class MenuUtility
    {
        public static void LocalizeBuildableDisplayName(AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale.IsEquivalentTo("Data/Locations"))
            {
                e.Edit(asset =>
                {
                    var data = asset.AsDictionary<string, LocationData>().Data;

                    foreach (string locationName in BuildableLocation.All)
                    {
                        if (data.TryGetValue(locationName, out var loc) && loc is not null)
                        {
                            string translated = ModEntry.Helper.Translation.Get($"Menu.{locationName}.DisplayName");

                            if (!string.IsNullOrWhiteSpace(translated))
                            loc.DisplayName = translated;
                        }
                    }
                });
            }
        }
    }
}