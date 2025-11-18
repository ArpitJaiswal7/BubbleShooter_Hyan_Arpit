
 










using System;
using com.kshkum.ShootGame.Scripts.CommonUI.Reward;
using com.kshkum.ShootGame.Scripts.Data;

// using com.kshkum.ShootGame.Scripts.Settings.Editor;

namespace com.kshkum.ShootGame.Scripts.Settings
{
    // [EditPrefab("Assets/com.kshkum.ShootGame/Resources/Popups/LuckySpin.prefab")]
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