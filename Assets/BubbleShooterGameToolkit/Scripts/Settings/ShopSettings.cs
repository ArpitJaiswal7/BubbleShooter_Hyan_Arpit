
 










using System;

// using com.kshkum.ShootGame.Scripts.Settings.Editor;

namespace com.kshkum.ShootGame.Scripts.Settings
{
    // [EditPrefab("Assets/com.kshkum.ShootGame/Resources/Popups/CoinsShop.prefab")]
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