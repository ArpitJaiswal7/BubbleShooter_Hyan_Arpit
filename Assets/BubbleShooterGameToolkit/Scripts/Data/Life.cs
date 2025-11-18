
 










using com.kshkum.ShootGame.Scripts.Settings;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Data
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