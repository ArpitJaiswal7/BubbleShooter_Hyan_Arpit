
 










using System;
using BubbleShooterGameToolkit.Scripts.Settings;
using BubbleShooterGameToolkit.Scripts.System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Popups
{
	public class BoostShop : PopupWithCurrencyLabel
	{
		[SerializeField]
		public Button BuyBoostButton;
		
		public Transform icon;
		public TextMeshProUGUI title;
		public TextMeshProUGUI description;
		public TextMeshProUGUI price;
		public TextMeshProUGUI amountText;
		private BoostParameters parameters;
		Action buySuccess;

		private void OnEnable()
		{
			BuyBoostButton.onClick.AddListener(BuyBoost);
		}

		public void SetBoost(BoostParameters param, Action buyCallback = null)
		{
			parameters = param;
			gameObject.SetActive(true);
			title.text = param.title;
			description.text = param.description;
			price.text = param.price.ToString();
			amountText.text = "+" + param.countItems;
			buySuccess = buyCallback;
			var iconBooster = Instantiate(param.iconPrefab, icon.transform);
			var rectTransform = iconBooster.GetComponent<RectTransform>();
			rectTransform.anchorMin = Vector2.zero;
			rectTransform.anchorMax = Vector2.one;
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
		}

		public void BuyBoost()
		{
			var amount = parameters.price;
			if (GameManager.instance.coins.Consume(amount)) {
				ShowCoinsSpendFX(BuyBoostButton.transform.position);
				parameters.boostResource.Add(parameters.countItems);
				Close();
				buySuccess?.Invoke();
			}
		}

	}
}
