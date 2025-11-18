
 










using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Labels
{
    class LevelLabel : Label
    {
        private void OnEnable()
        {
            label.text = "Level " + PlayerPrefs.GetInt("OpenLevel");
        }
    }
}