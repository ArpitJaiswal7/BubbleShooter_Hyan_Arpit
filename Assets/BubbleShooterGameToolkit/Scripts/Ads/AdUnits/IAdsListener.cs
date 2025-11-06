// // ©2015 - 2024 Candy Smith
 










namespace BubbleShooterGameToolkit.Scripts.Ads.AdUnits
{
    public interface IAdsListener
    {
        void Show(AdUnit adUnit);
        void OnAdsInitialized();
        void OnAdsLoaded(string placementId);
        void OnAdsLoadFailed();
        void OnAdsShowFailed();
        void OnAdsShowStart();
        void OnAdsShowClick();
        void OnAdsShowComplete();
        void OnInitFailed();
    }
}