// // ©2015 - 2024 Candy Smith
 










using System;

namespace BubbleShooterGameToolkit.Scripts.Ads.AdUnits
{
    public class AdUnit
    {
        public Action<string> OnShown;
        public Action<string> OnInitialized;
        public string PlacementId { get; set; } 
        public AdReference AdReference { get; set; }

        public AdsHandlerBase AdsHandler { get; set; }
        public bool Loaded { get; set; }

        public void Complete()
        {
            OnShown?.Invoke(PlacementId);
        }

        public void Initialized()
        {
            OnInitialized?.Invoke(PlacementId);
        }

        public void Load()
        {
            AdsHandler.Load(this);
        }

        public void Show()
        {
            AdsHandler.Show(this);
        }

        public bool IsAvailable()
        {
            return AdsHandler.IsAvailable(this) || Loaded;
        }
    }
}