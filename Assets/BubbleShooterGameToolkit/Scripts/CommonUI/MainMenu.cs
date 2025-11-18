using com.kshkum.ShootGame.Scripts.Ads.Networks;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace com.kshkum.ShootGame.Scripts.CommonUI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        private void Start()
        {
            playButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            SceneLoader.instance.GoToMap();
        }
    }
}