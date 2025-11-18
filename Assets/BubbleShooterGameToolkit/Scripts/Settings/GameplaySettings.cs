
 










using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms.Impl;

namespace com.kshkum.ShootGame.Scripts.Settings
{
    public class GameplaySettings : SettingsBase
    {
        [Header("Ball speed")]
        public float ballSpeed = 25;
        [Header("Ball default size, for adjusting screen for a level")]
        public float ballWidth;
        public float ballHeight;
        public float cameraSize = 14.8f;
        public bool showScorePopup = true;
        public AnimationCurve ScoreMultiplierCurve;
        [Header("Popup text like 'Good!', 'Great!', 'Fantastic!'")]
        public PopupTextElement[] popupTextElements;
        public int warningTimeThreshold = 10;
        public int warningMovesThreshold = 5;
        [SerializeField]
        public int bouncingCount = 4;

        [Header("Colors for aim line and editor")]
        public Color[] ballColors = {
            Color.red,
            Color.yellow,
            Color.blue,
            Color.green,
            new Color(0.5f, 0, 1),
            new Color(1, 0.5f, 0),
        };

        [Header("Hole score")]
        public int[] holesScore = { 50, 100, 200, 100, 50 };

    }
    
    [Serializable]
    public class PopupTextElement
    {
        public int MinValue;
        public int MaxValue;
        public GameObject popupTextPrefab;
    }
}