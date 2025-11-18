
 










using com.kshkum.ShootGame.Scripts.Ads.AdUnits;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Ads.Networks
{
    [CreateAssetMenu(fileName = "IronsourceAdsHandler", menuName = "com.kshkum.ShootGame/Ads/IronsourceAdsHandler")]
    public class IronsourceAdsHandler : AdsHandlerBase
    {
        private IAdsListener _listener;

        private void Init(string _id)
        {
            #if IRONSOURCE
            IronSource.Agent.setManualLoadRewardedVideo(true);
            IronSource.Agent.validateIntegration();
            IronSource.Agent.init(_id);

            #endif
        }

        private void SetListener(IAdsListener listener)
        {
            _listener = listener;
            Debug.Log(_listener);
            #if IRONSOURCE
            //Add Rewarded Video Events
            IronSourceInterstitialEvents.onAdReadyEvent += OnInterstitialAdReady;
            IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialAdLoadFailedEvent;

            IronSourceRewardedVideoEvents.onAdReadyEvent += OnRewardedVideoAdReady;
            IronSourceRewardedVideoEvents.onAdLoadFailedEvent += RewardedVideoAdShowFailedEvent;
            IronSourceRewardedVideoEvents.onAdRewardedEvent += Rewardeded;

            IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
            #endif
        }

        #if IRONSOURCE

        private void Rewardeded(IronSourcePlacement obj, IronSourceAdInfo ironSourceAdInfo)
        {
            Debug.Log("Ironsource Rewardeded");
            _listener?.OnAdsShowComplete();
        }

        private void SdkInitializationCompletedEvent()
        {
            Debug.Log("Ironsource SdkInitializationCompletedEvent");
            _listener?.OnAdsInitialized();
        }

        private void InterstitialAdLoadFailedEvent(IronSourceError obj)
        {
            Debug.Log("Ironsource InterstitialAdLoadFailedEvent " + obj.getCode() + " " + obj.getDescription());
            _listener?.OnAdsLoadFailed();
        }

        private void RewardedVideoAdShowFailedEvent(IronSourceError obj)
        {
            Debug.Log("1" + obj.getCode());
            Debug.Log("2" + obj.getDescription());
            Debug.Log("Ironsource RewardedVideoAdShowFailedEvent " + obj.getCode() + " " + obj.getDescription());
            Debug.Log(_listener);
            _listener?.OnAdsShowFailed();
        }

        private void OnRewardedVideoAdReady(IronSourceAdInfo obj)
        {
            Debug.Log("Ironsource OnRewardedVideoAdReady");
            _listener?.OnAdsLoaded(obj.instanceId);
        }

        private void OnInterstitialAdReady(IronSourceAdInfo obj)
        {
            Debug.Log("Ironsource OnInterstitialAdReady");
            _listener?.OnAdsLoaded(obj.instanceId);
        }
        #endif

        public override void Init(string _id, bool adSettingTestMode, IAdsListener listener)
        {
            Debug.Log("Ironsource Init");
            Init(_id);
            Debug.Log("Ironsource SetListener");
            SetListener(listener);
        }

        public override void Show(AdUnit adUnit)
        {
            #if IRONSOURCE
            if (adUnit.AdReference.adType == EAdType.Interstitial)
            {
                IronSource.Agent.showInterstitial();
            }
            else if (adUnit.AdReference.adType == EAdType.Rewarded)
            {
                IronSource.Agent.showRewardedVideo();
            }

            _listener?.Show(adUnit);
            #endif
        }

        public override void Load(AdUnit adUnit)
        {
            #if IRONSOURCE
            if (adUnit.AdReference.adType == EAdType.Interstitial)
            {
                IronSource.Agent.loadInterstitial();
            }
            else if (adUnit.AdReference.adType == EAdType.Rewarded)
            {
                IronSource.Agent.loadRewardedVideo();
            }
            #endif
        }

        public override bool IsAvailable(AdUnit adUnit)
        {
            #if IRONSOURCE
            if (adUnit.AdReference.adType == EAdType.Interstitial)
            {
                return IronSource.Agent.isInterstitialReady();
            }

            if (adUnit.AdReference.adType == EAdType.Rewarded)
            {
                return IronSource.Agent.isRewardedVideoAvailable();
            }
            #endif
            return false;
        }
    }
}