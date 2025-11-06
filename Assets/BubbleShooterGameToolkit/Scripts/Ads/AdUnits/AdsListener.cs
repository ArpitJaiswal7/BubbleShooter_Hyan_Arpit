// // ©2015 - 2024 Candy Smith
 










using System.Collections.Generic;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Ads.AdUnits
{
    public class AdsListener : IAdsListener
    {
        private readonly List<AdUnit> adUnits;
        private bool available;
        private AdUnit _adUnit;

        public AdsListener(List<AdUnit> adUnits)
        {
            this.adUnits = adUnits;
        }

        public void Show(AdUnit adUnit)
        {
            Debug.Log("Show ad " + adUnit.PlacementId);
            _adUnit = adUnit;
        }

        public void OnAdsInitialized()
        {
            Debug.Log("Ads initialized");
            foreach (var adUnit in adUnits)
            {
                adUnit.Initialized();
            }
        }

        public void OnAdsLoaded(string placementId)
        {
            foreach (var adUnit in adUnits)
            {
                if (adUnit.PlacementId == placementId)
                {
                    adUnit.Loaded = true;
                }
            }
        }

        public void OnInitFailed()
        {
            Debug.Log("Ads init failed, check assigned ad handler");
        }

        public void OnAdsLoadFailed()
        {
        }

        public void OnAdsShowFailed()
        {
            if (_adUnit != null)
            {
                _adUnit.Loaded = false;
            }

            _adUnit = null;
        }

        public void OnAdsShowStart()
        {
        }

        public void OnAdsShowClick()
        {
        }

        public void OnAdsShowComplete()
        {
            _adUnit.Complete();
            _adUnit = null;
        }
    }
}