using com.kshkum.ShootGame.Scripts.Ads.AdUnits;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Ads
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