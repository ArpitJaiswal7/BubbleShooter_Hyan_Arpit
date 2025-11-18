
 










using System;
using com.kshkum.ShootGame.Scripts.Data;
using com.kshkum.ShootGame.Scripts.Gameplay;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Settings
{
    [Serializable]
    public class BoostParameters
    {
        [Header("Boost name")]
        public string title;
        public ResourceObject boostResource;
        [Header("Cost of the boost")]
        public int price = 10;
        [Header("Number of purchased boosters")]
        public int purchasingAmount = 10;
        [Header("Start number of boost for free")]
        public int startCount = 3;
        [Header("Number of boosters that will appear on the game field")]
        public int countItems = 3;
        [Header("The level at which the booster will be available")]
        public int openLevel = 1;
        public string description;
        [Header("Boost icon for the shop and the game field")]
        public GameObject iconPrefab;
        [Header("Ball prefab to convert a ball into a booster")]
        public Ball ballPrefab;

    }
}