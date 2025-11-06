
 










using BubbleShooterGameToolkit.Scripts.LevelSystem;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.GUI
{
    public class BackgroundManager : MonoBehaviour
    {
        [SerializeField]
        private Image backround;

        private void Start()
        {
            if (LevelLoader.instance.CurrentLevel != null)
            {
                if (LevelLoader.instance.CurrentLevel.background != null)
                    backround.sprite = LevelLoader.instance.CurrentLevel.background;
            }
            else
            {
                LevelLoader.OnLevelLoaded += OnLevelLoaded;
            }
        }

        private void OnLevelLoaded()
        {
            if (LevelLoader.instance.CurrentLevel.background != null)
                    backround.sprite = LevelLoader.instance.CurrentLevel.background;
            LevelLoader.OnLevelLoaded -= OnLevelLoaded;
        }
    }
}