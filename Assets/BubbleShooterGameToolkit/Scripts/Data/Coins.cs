
 










using BubbleShooterGameToolkit.Scripts.CommonUI;
using BubbleShooterGameToolkit.Scripts.CommonUI.Popups;
using BubbleShooterGameToolkit.Scripts.Settings;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Data
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