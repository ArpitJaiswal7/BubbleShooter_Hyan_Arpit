
 










using System;
using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.LevelSystem
{
    public class LevelLoader : Singleton<LevelLoader>
    {
        public static Action OnLevelLoaded;

        // Current loaded level
        public Level CurrentLevel { get; private set; }
        public Level LoadLevel(int num)
        {
            CurrentLevel = Resources.Load<Level>("Levels/Level_" + num);
            return CurrentLevel;
        }
        
        public void LoadLevel(Level levelToLoad = null)
        {
            CurrentLevel = levelToLoad;
            if (CurrentLevel != null)
                return;
            var levelName = PlayerPrefs.GetString("OpenLevelName");
            if (!string.IsNullOrEmpty(levelName))
            {
                CurrentLevel = Resources.Load<Level>("Levels/"+levelName);
                PlayerPrefs.DeleteKey("OpenLevelName");
            }
            else
            {
                var levelNumber = PlayerPrefs.GetInt("OpenLevel", 1);
                CurrentLevel = LoadLevel(levelNumber);
            }
            OnLevelLoaded?.Invoke();
        }
    }
}