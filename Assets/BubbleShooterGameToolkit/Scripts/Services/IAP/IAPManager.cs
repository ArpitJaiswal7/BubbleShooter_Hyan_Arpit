using System;
using System.Collections.Generic;
using UnityEngine;


namespace com.kshkum.ShootGame.Scripts.Services
{
    public class IAPManager : MonoBehaviour
    {
        public static IAPManager instance;

        private IIAPService iapController;

        public void InitializePurchasing(IEnumerable<string> products)
        {
            #if UNITY_PURCHASING
            iapController = new IAPController();
            iapController.InitializePurchasing(products);
            #else
            iapController = new DummyIAPService();
            #endif
        }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static void SubscribeToPurchaseEvent(Action<string> purchaseHandler)
        {
            #if UNITY_PURCHASING
            IAPController.OnSuccessfulPurchase += purchaseHandler;
            #endif
        }
        
        public static void UnsubscribeFromPurchaseEvent(Action<string> purchaseHandler)
        {
            #if UNITY_PURCHASING
            IAPController.OnSuccessfulPurchase -= purchaseHandler;
            #endif
        }

        public void BuyProduct(string productId)
        {
            iapController.BuyProduct(productId);
        }
        
        public decimal GetProductLocalizedPrice(string productId)
        {
            return iapController.GetProductLocalizedPrice(productId);
        }

        public string GetProductLocalizedPriceString(string productId)
        {
            return iapController.GetProductLocalizedPriceString(productId);
        }
    }

    public class DummyIAPService : IIAPService
    {
        public void InitializePurchasing(IEnumerable<string> products)
        {
            
        }

        public void BuyProduct(string productId)
        {
            
        }

        public decimal GetProductLocalizedPrice(string productId)
        {
            return 0m;
        }

        public string GetProductLocalizedPriceString(string productId)
        {
            return string.Empty;
        }
    }
}