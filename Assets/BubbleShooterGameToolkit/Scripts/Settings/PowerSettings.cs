
 










using System;
using System.Collections.Generic;
using BubbleShooterGameToolkit.Scripts.Enums;
using BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects;
using BubbleShooterGameToolkit.Scripts.System;

namespace BubbleShooterGameToolkit.Scripts.Settings
{
    public class PowerSettings : SingletonScriptableSettings<PowerSettings>
    {
        public List<PowerSetting> powerColorSettings;
        public float powerStep = .1f;

        [Serializable]
        public class PowerSetting
        {
            public EPower power;
            public Ball powerBallPrefab;
        }
    }
}