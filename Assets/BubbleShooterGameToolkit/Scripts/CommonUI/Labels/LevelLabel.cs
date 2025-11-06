
 










using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Labels
{
    class LevelLabel : Label
    {
        private void OnEnable()
        {
            label.text = "Level " + PlayerPrefs.GetInt("OpenLevel");
        }
    }
}