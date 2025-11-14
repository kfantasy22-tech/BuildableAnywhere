using System.Collections.Generic;

namespace BuildableAnywhere.Utilities
{
    internal static class BuildableLocation
    {
        internal static readonly HashSet<string> All = new()
        {
            "Town",
            "Beach",
            "Forest",
            "Mountain",
            "Woods",
            "Desert",
            "IslandWest",
            "Custom_Pasture",
            "Custom_VolcanicSummit"
        };
    }
}