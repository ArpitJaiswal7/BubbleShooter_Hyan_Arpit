// // ©2015 - 2024 Candy Smith
 










using System;
using System.Collections.Generic;

namespace com.kshkum.ShootGame.Scripts.Services
{
    public interface IIAPService
    {
        void InitializePurchasing(IEnumerable<string> products);
        void BuyProduct(string productId);
        decimal GetProductLocalizedPrice(string productId);
        string GetProductLocalizedPriceString(string productId);
    }

}