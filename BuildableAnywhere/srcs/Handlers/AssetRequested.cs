using StardewModdingAPI.Events;
using BuildableAnywhere.Utilities;

namespace BuildableAnywhere.Handlers
{
    internal static class AssetRequestedHandler
    {
        /// <inheritdoc cref="IContentEvents.AssetRequested"/>
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event data.</param>
        internal static void Apply(object sender, AssetRequestedEventArgs e)
        {
            BuildableAnywhereUtility.MakeAlwaysActive(e);
            MenuUtility.LocalizeBuildableDisplayName(e);
            MapUtility.EditIslandHouseCave(e); 
        
        }
    }
}