
 










using System;

// using BubbleShooterGameToolkit.Scripts.Settings.Editor;

namespace BubbleShooterGameToolkit.Scripts.Settings
{
    // [EditPrefab("Assets/BubbleShooterGameToolkit/Resources/Popups/CoinsShop.prefab")]
    public class ShopSettings : SettingsBase
    {
        public ShopItemEditor[] shopItems;
    }

    [Serializable]
    public class ShopItemEditor
    {
        public string productID;

        public int coins;

        public int discountPercent;
    }
}