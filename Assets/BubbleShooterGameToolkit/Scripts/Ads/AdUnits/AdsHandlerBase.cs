// // ©2015 - 2024 Candy Smith
 










using BubbleShooterGameToolkit.Scripts.Ads.AdUnits;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Ads
{
    public abstract class AdsHandlerBase : ScriptableObject
    {
        public abstract void Init(string _id, bool adSettingTestMode, IAdsListener listener);
        public abstract void Show(AdUnit adUnit);
        public abstract void Load(AdUnit adUnit);

        /// set false if adapter doesn't have availability method
        public abstract bool IsAvailable(AdUnit adUnit);
    }
}