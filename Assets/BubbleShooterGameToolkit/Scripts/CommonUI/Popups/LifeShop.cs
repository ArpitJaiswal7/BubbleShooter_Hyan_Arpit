
 










using BubbleShooterGameToolkit.Scripts.System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Popups
{
    public class LifeShop : PopupWithCurrencyLabel
    {
        public Button buyLifeButton;
        
        [SerializeField] private Transform iconPos;

        private void OnEnable()
        {
            buyLifeButton.onClick.AddListener(BuyLife);
            buyLifeButton.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.instance.GameSettings.refillLifeCost.ToString();
        }

        private void BuyLife()
        {
            if(GameManager.instance.coins.Consume(GameManager.instance.GameSettings.refillLifeCost))
            {
                ShowCoinsSpendFX(buyLifeButton.transform.position);
                GetLife();
            }
        }

        public void GetLife()
        {
            var lifeDefaultValue = GameManager.instance.life.GetResource();
            DOVirtual.DelayedCall(0.5f, () => AnimLife(lifeDefaultValue));
            GameManager.instance.life.RestoreLifes();
            result = EPopupResult.Continue;
        }

        private void AnimLife(int value)
        {
            topPanel.AnimateLife(iconPos.position, "", () => base.Close());
        }
    }
}