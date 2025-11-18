
 










using com.kshkum.ShootGame.Scripts.Ads.AdUnits;
using UnityEngine;
using UnityEngine.Advertisements;

namespace com.kshkum.ShootGame.Scripts.Ads
{
    //#if UNITY_ADS
    //[CreateAssetMenu(fileName = "UnityAdsHandler", menuName = "com.kshkum.ShootGame/Ads/UnityAdsHandler")]
    //public class UnityAdsHandler : AdsHandlerBase, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    //{
    //    private bool rewardedLoaded;
    //    private bool initialized;
    //    private IAdsListener listener;

    //    #region IAdsShowable Implementations

    //    public override void Init(string _id, bool adSettingTestMode, IAdsListener listener)
    //    {
    //        Advertisement.Initialize(_id, adSettingTestMode, this);
    //        this.listener = listener;
    //    }

    //    public override void Show(AdUnit adUnit)
    //    {
    //        Advertisement.Show(adUnit.PlacementId, this);
    //        listener.Show(adUnit);
    //    }

    //    public override void Load(AdUnit adUnit)
    //    {
    //        Advertisement.Load(adUnit.PlacementId, this);
    //    }

    //    public override bool IsAvailable(AdUnit adUnit)
    //    {
    //        return false;
    //    }

    //    #endregion

    //    #region Interface Implementations

    //    public void OnInitializationComplete()
    //    {
    //        DebugLog("Init Success");
    //        listener.OnAdsInitialized();
    //    }

    //    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    //    {
    //        DebugLog($"Init Failed: [{error}]: {message}");
    //        listener.OnInitFailed();
    //    }

    //    public void OnUnityAdsAdLoaded(string placementId)
    //    {
    //        DebugLog($"Load Success: {placementId}");
    //        listener.OnAdsLoaded(placementId);
    //    }

    //    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    //    {
    //        DebugLog($"Load Failed: [{error}:{placementId}] {message}");
    //        listener.OnAdsLoadFailed();
    //    }

    //    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    //    {
    //        DebugLog($"OnUnityAdsShowFailure: [{error}]: {message}");
    //        listener.OnAdsShowFailed();
    //    }

    //    public void OnUnityAdsShowStart(string placementId)
    //    {
    //        DebugLog($"OnUnityAdsShowStart: {placementId}");
    //        listener.OnAdsShowStart();
    //    }

    //    public void OnUnityAdsShowClick(string placementId)
    //    {
    //        DebugLog($"OnUnityAdsShowClick: {placementId}");
    //        listener.OnAdsShowClick();
    //    }

    //    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    //    {
    //        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
    //        {
    //            DebugLog($"OnUnityAdsShowComplete: {placementId}");
    //            listener.OnAdsShowComplete();
    //        }
    //    }

    //    //wrapper around debug.log to allow broadcasting log strings to the UI
    //    private void DebugLog(string msg)
    //    {
    //        Debug.Log(msg);
    //    }

    //    #endregion
    //}

    //#endif
}