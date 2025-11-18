
 










using com.kshkum.ShootGame.Scripts.Ads.Networks;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Services;
using com.kshkum.ShootGame.Scripts.Settings;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;
namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
{
    public class ItemPurchase : MonoBehaviour
    {
        public Button BuyItemButton;
        public TextMeshProUGUI price;
        public TextMeshProUGUI count;
        public TextMeshProUGUI discountPercent;
        public ShopItemEditor settingsShopItem;

        private void OnEnable()
        {
            if(BuyItemButton != null)
                BuyItemButton.onClick.AddListener(BuyCoins);
            decimal priceValue = IAPManager.instance.GetProductLocalizedPrice(settingsShopItem.productID);
            if (priceValue > 0.01m)
            {
                price.text = IAPManager.instance.GetProductLocalizedPriceString(settingsShopItem.productID);
            }
        }

        private void BuyCoins()
        {
            if (TryGetComponent(out CoinsShop cp))
                cp.BuyCoins(settingsShopItem.productID);

            GetComponentInParent<CoinsShop>().BuyCoins(settingsShopItem.productID);
        }
    }
    
}