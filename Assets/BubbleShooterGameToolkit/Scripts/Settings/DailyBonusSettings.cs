
 










using System;
using com.kshkum.ShootGame.Scripts.Data;
using UnityEngine;
// using com.kshkum.ShootGame.Scripts.Settings.Editor;

namespace com.kshkum.ShootGame.Scripts.Settings
{
    // [EditPrefab("Assets/com.kshkum.ShootGame/Resources/Popups/DailyBonus.prefab")]
    public class DailyBonusSettings : ScriptableObject
    {
        public RewardSetting[] rewards = Array.Empty<RewardSetting>();
    }
    
    [Serializable]
    public class RewardSetting
    {
        public ResourceObject resource;
        public int count;
    }
}