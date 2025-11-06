
 










using BubbleShooterGameToolkit.Scripts.CommonUI.Popups;
using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Labels
{
    public class LifeTimerHandler : MonoBehaviour
    {
        public Button buyLifeButton;
        private int gameSettingsMaxLife;

        private void OnEnable()
        {
            buyLifeButton?.onClick.AddListener(BuyLife);
            gameSettingsMaxLife = GameManager.instance.GameSettings.MaxLife;
            GameManager.instance.life.OnResourceUpdate += UpdateButton;
            UpdateButton(GameManager.instance.life.GetResource());
        }
        
        private void OnDisable()
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.life.OnResourceUpdate -= UpdateButton;
            }
        }

        private void UpdateButton(int count)
        {
            if (buyLifeButton != null)
            {
                buyLifeButton.interactable = !GameManager.instance.life.IsEnough(gameSettingsMaxLife);
            }
        }

        public void BuyLife()
        {
            if(GameManager.instance.life.IsEnough(gameSettingsMaxLife))
                return;
            MenuManager.instance.ShowPopup<LifeShop>();
        }
    }
}