
 










using BubbleShooterGameToolkit.Scripts.Audio;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Popups
{
    public class MenuFail : Popup
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;
        
        [SerializeField]
        public Button againButton;

        private void OnEnable()
        {
            closeButton.onClick.AddListener(GoMap);
            againButton.onClick.AddListener(Again);
            scoreText.text = $"Score: <color=#FFFFFF>{ScoreManager.instance.GetScore() }</color>";
        }

        public override void ShowAnimationSound()
        {
            base.ShowAnimationSound();
            SoundBase.instance.PlayDelayed(SoundBase.instance.failed,.2f);
        }

        private void GoMap()
        {
            OnCloseAction =(_)=> SceneLoader.instance.GoToMap();
            Close();
        }

        void KeepPlaying()
        {
            if (GameManager.instance.coins.Consume(GameManager.instance.GameSettings.continuePrice))
            {
                Continue();
            }
        }

        public void Continue()
        {
            //ShowCoinsSpendFX(continueButton.transform.position);
            result = EPopupResult.Continue;
            Close();
        }

        private void Again()
        {
            OnCloseAction = (_) => GameManager.instance.RestartLevel();
            Close();
        }
    }
}