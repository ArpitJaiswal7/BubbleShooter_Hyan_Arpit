
 










using BubbleShooterGameToolkit.Scripts.Settings;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Data
{
    public class Life : ResourceObject
    {
        protected override string ResourceName => "Life";
        public override int DefaultValue => Resources.Load<GameSettings>("Settings/GameSettings").MaxLife;

        public void RestoreLifes()
        {
            Set(DefaultValue);
        }
    }
}