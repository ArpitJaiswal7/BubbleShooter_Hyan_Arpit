
 










using System.Linq;
using com.kshkum.ShootGame.Scripts.Settings;
using com.kshkum.ShootGame.Scripts.System;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Boosts
{
    public class BoostManager : Singleton<BoostManager>
    {
        public BoostGUI[] boosts;
        public BoostSettings boostSettings;

        //initializes the boosts array with data from BoostSettings and loads prefs
        public override void Init()
        {
            base.Init();
            boostSettings = Resources.Load<BoostSettings>("Settings/BoostSettings");
            boosts = Object.FindObjectsOfType<BoostGUI>(true).OrderBy(b => b.name).ToArray();
            foreach (var boostGUI in boosts)
            {
                boostGUI.boostParameters = boostSettings.GetBoostParameters(boostGUI.boostResource);
            }
        }
    }
}