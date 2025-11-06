using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using BubbleShooterGameToolkit.Scripts.CommonUI.Popups;
//using com.unity3d.mediation;

namespace BubbleShooterGameToolkit.Scripts.Ads.Networks
{
    public class AdMobManager : MonoBehaviour
    {
        public static AdMobManager instance;

        private BannerView bannerView;
        private InterstitialAd interstitialAd;
        private RewardedAd rewardedAd;

        [Header("AdMob Ad Unit IDs")]
        private string bannerAdUnitId;
        private string interstitialAdUnitId;
        private string rewardedAdUnitId;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }


#if UNITY_ANDROID
            bannerAdUnitId = "ca-app-pub-2871748425405224/5344015302";
            interstitialAdUnitId = "ca-app-pub-2871748425405224/9482570869";
            rewardedAdUnitId = "ca-app-pub-2871748425405224/9091688624";

            //bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
            //interstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";
            //rewardedAdUnitId = "ca-app-pub-3940256099942544/5224354917";

#elif UNITY_IOS
            bannerAdUnitId = "ca-app-pub-2871748425405224/9002174811";
            interstitialAdUnitId = "ca-app-pub-2871748425405224/1123684790";
            rewardedAdUnitId = "ca-app-pub-2871748425405224/6764407175";

            //bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
            //interstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";
            //rewardedAdUnitId = "ca-app-pub-3940256099942544/5224354917";
#endif
            MobileAds.Initialize(initStatus =>
            {
                Debug.Log("✅ AdMob Initialized.");
                RequestBanner();
                RequestInterstitial();
                RequestRewardedAd();
            });
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "map")
            {
                if (UnityEngine.Random.Range(0, 20) % 3 == 0)
                {
                    Debug.Log("🎯 Showing Interstitial Ad in Map Scene");
                    ShowInterstitial();
                }
            }
        }

        #region Banner Ad

        private void RequestBanner()
        {
            bannerView?.Destroy();

            bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);
            AdRequest adRequest = new AdRequest.Builder().Build();

            bannerView.LoadAd(adRequest);
            Debug.Log("Showing banner ad");
        }

        public void ShowBanner() => bannerView?.Show();
        public void HideBanner() => bannerView?.Hide();

        #endregion

        #region Interstitial Ad

        private void RequestInterstitial()
        {
            AdRequest adRequest = new AdRequest.Builder().Build();

            interstitialAd = new InterstitialAd(interstitialAdUnitId);
            interstitialAd.OnAdClosed += (sender, args) => {
                Debug.Log("🔁 Interstitial Closed, Reloading...");
                RequestInterstitial();
            };
            interstitialAd.OnAdFailedToLoad += (sender, args) => {
                Debug.LogError("❌ Interstitial failed to load: " + args.LoadAdError);
            };
            interstitialAd.LoadAd(adRequest);

            interstitialAd.OnAdClosed += (sender, reward) =>
            {
                Debug.Log("Interstitial Ad Closed & loading again");
                RequestInterstitial();
            };
        }

        public void ShowInterstitial()
        {
            if (interstitialAd != null && interstitialAd.IsLoaded())
            {
                interstitialAd.Show();
                Debug.Log("Showing interstitial ad");
            }
            else
            {
                Debug.Log("⚠️ Interstitial not ready");
            }
        }

        #endregion

        #region Rewarded Ad

        private void RequestRewardedAd()
        {
            rewardedAd = new RewardedAd(rewardedAdUnitId);
            AdRequest adRequest = new AdRequest.Builder().Build();

            rewardedAd.OnAdClosed += (sender, args) =>
            {
                Debug.Log("🔁 Rewarded Ad Closed, Reloading...");
                GetComponentInParent<CoinsShop>()?.BuyCoins("product_1");
                RequestRewardedAd();
            };

            rewardedAd.OnAdFailedToLoad += (sender, args) =>
            {
                Debug.LogError("❌ Rewarded ad failed to load: " + args.LoadAdError);
                RequestRewardedAd();
            };

            rewardedAd.OnUserEarnedReward += (sender, reward) =>
            {
                Debug.Log($"🏆 User earned reward: {reward.Type} - {reward.Amount}");

            };

            rewardedAd.LoadAd(adRequest);
        }

        public void ShowRewardedAd()
        {
            if (rewardedAd != null && rewardedAd.IsLoaded())
            {
                rewardedAd.Show();
                Debug.Log("Showing rewarded ad");
            }
            else
            {
                Debug.Log("⚠️ Rewarded ad not ready");
                RequestRewardedAd();
            }
        }

        #endregion

        private void OnDestroy()
        {
            bannerView?.Destroy();
            interstitialAd?.Destroy();
            // RewardedAd has no Destroy in v7.3.0
        }
    }
}