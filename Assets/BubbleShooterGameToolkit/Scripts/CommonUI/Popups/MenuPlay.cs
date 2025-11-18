
 










using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.LevelSystem;
using com.kshkum.ShootGame.Scripts.System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
{
    public class MenuPlay : Popup
    {
        private int num;
        
        [SerializeField]
        private Button playButton;

        private void OnEnable()
        {
            playButton.onClick.AddListener(StartGame);
            num = PlayerPrefs.GetInt("OpenLevel");
            var level = LevelLoader.instance.LoadLevel(num);
            EventManager.GetEvent<Level>(EGameEvent.LevelLoaded).Invoke(level);
        }

        public void StartGame()
        {

            //if (!GameManager.instance.life.IsEnough(1))
            {
                //MenuManager.instance.ShowPopup<LifeShop>();
            }
            //else
            //{
            OnCloseAction = (x) => { SceneLoader.instance.StartGameScene(); };
            result = EPopupResult.Continue;
            Close();
            //}
        }
    }
}