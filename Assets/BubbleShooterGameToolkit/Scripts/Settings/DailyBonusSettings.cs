
 










using System;
using BubbleShooterGameToolkit.Scripts.Data;
using UnityEngine;
// using BubbleShooterGameToolkit.Scripts.Settings.Editor;

namespace BubbleShooterGameToolkit.Scripts.Settings
{
    // [EditPrefab("Assets/BubbleShooterGameToolkit/Resources/Popups/DailyBonus.prefab")]
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