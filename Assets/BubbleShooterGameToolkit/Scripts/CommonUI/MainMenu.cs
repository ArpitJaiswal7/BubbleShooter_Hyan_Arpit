
 










using BubbleShooterGameToolkit.Scripts.Ads.Networks;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.CommonUI
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