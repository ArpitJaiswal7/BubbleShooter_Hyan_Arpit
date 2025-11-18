
 










using System;
using System.Collections.Generic;
using com.kshkum.ShootGame.Scripts.Enums;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects;
using com.kshkum.ShootGame.Scripts.System;

namespace com.kshkum.ShootGame.Scripts.Settings
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