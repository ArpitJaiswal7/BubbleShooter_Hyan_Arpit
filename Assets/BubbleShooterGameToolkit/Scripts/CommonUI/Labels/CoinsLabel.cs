
 










using BubbleShooterGameToolkit.Scripts.CommonUI.Popups;
using BubbleShooterGameToolkit.Scripts.System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Labels
{
    public class CoinsLabel : Label
    {
        public Button buyButton;
        private Tweener doPunchScale;

        [SerializeField]
        private TextMeshProUGUI coisTextPrefab;

        private void OnEnable()
        {
            UpdateLabel(GameManager.instance.coins.GetResource());
            GameManager.instance.coins.OnResourceUpdate += UpdateLabel;
            buyButton?.onClick.AddListener(Buy);
        }

        private void OnDisable()
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.coins.OnResourceUpdate -= UpdateLabel;
            }
        }

        private void UpdateLabel(int count)
        {
            label.text = count.ToString();
        }

        public void Buy()
        {
            var coinsShop = MenuManager.instance.ShowPopup<CoinsShop>();
            // coinsShop.OnAfterCloseAction += () => buyButton.interactable = true;
        }

        
    }
}