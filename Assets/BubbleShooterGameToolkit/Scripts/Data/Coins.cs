using com.kshkum.ShootGame.Scripts.CommonUI;
using com.kshkum.ShootGame.Scripts.CommonUI.Popups;
using com.kshkum.ShootGame.Scripts.Settings;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Data
{
    public class Coins : ResourceObject
    {
        protected override string ResourceName => "Coins";
        public override int DefaultValue => Resources.Load<GameSettings>("Settings/GameSettings").coins;

        public override bool Consume(int amount)
        {
            if(!base.Consume(amount))
            {
                MenuManager.instance.ShowPopup<CoinsShop>();
                return false;
            }
            return true; 
        }
    }
}