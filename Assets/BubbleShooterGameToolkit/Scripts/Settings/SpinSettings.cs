
 










using System;
using BubbleShooterGameToolkit.Scripts.CommonUI.Reward;
using BubbleShooterGameToolkit.Scripts.Data;

// using BubbleShooterGameToolkit.Scripts.Settings.Editor;

namespace BubbleShooterGameToolkit.Scripts.Settings
{
    // [EditPrefab("Assets/BubbleShooterGameToolkit/Resources/Popups/LuckySpin.prefab")]
    public class SpinSettings: SettingsBase
    {
        public int costToSpin = 10;
        public RewardSettingSpin[] rewards = Array.Empty<RewardSettingSpin>();
    }
    
    [Serializable]
    public class RewardSettingSpin
    {
        public ResourceObject resource;
        public RewardVisual rewardVisualPrefab;
        public int count;
    }
}