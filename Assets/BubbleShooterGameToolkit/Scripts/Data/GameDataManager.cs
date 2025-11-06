
 










using System;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Data
{
    public class GameDataManager : SingletonBehaviour<GameDataManager>
    {
        [HideInInspector]
        public int Level;

        private void OnEnable()
        {
            UpdateLevel();
            EventManager.GetEvent(EGameEvent.Map).Subscribe(UpdateLevel);
        }
        
        private void OnDisable()
        {
            EventManager.GetEvent(EGameEvent.Map).UnSubscribe(UpdateLevel);
        }

        private void UpdateLevel()
        {
            Level = PlayerPrefs.GetInt("Level", 1);
        }

        public void SaveLevel(int levelNumber, int score)
        {
            Level = levelNumber + 1;
            var levellast = PlayerPrefs.GetInt("Level", 1);
            if (levellast < Level)
                PlayerPrefs.SetInt("Level", Math.Max(levellast, Level));
            if (PlayerPrefs.GetInt("LevelScore" + levelNumber, 0) < score)
                PlayerPrefs.SetInt("LevelScore" + levelNumber, score);
            PlayerPrefs.Save();
            
        }
    }
}