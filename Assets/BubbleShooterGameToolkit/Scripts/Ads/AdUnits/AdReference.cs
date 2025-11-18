
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Ads.AdUnits
{
    [CreateAssetMenu(fileName = "AdReference", menuName = "com.kshkum.ShootGame/Ads/AdReference")]
    public class AdReference : ScriptableObject
    {
        public EAdType adType;
    }
}