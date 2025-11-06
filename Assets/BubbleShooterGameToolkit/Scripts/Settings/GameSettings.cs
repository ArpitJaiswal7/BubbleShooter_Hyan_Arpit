
 










using System;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Settings
{
    public class GameSettings : SettingsBase
    {
        [Header("Default settings")] 
        public int MaxLife;
        public int coins;
        [Header("Life settings")] 
        public int refillLifeCost;
        public int TotalTimeForRestLifeHours;
        public int TotalTimeForRestLifeMin;
        public int TotalTimeForRestLifeSec;
        [Header("Pay to continue game after fail")]
        public int continuePrice; 
        [Header("Add Moves to continue game after fail")]
        public int movesContinue;
        [Header("Add Time to continue game after fail")]
        public int timeContinue = 30;
        [Header("Skip map after win")]
        public GoMapAfter GoMapAfter;
        [Header("Open menu play on map automatically")]
        public bool openMenuPlay = false;
        [Header("Match settings count")]
        public int matchSettingsCount = 3;

        [Header("GDPR settings")]
        public string privacyPolicyUrl;
    }

    [Serializable]
    public class GoMapAfter
    {
        public bool skipMap;
        public int untilLevel = 1;
    }
}