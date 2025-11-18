
 










using com.kshkum.ShootGame.Scripts.Data;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Settings;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Boosts
{
    /// Boost class to store the boost data
    public class BoostResource : ResourceObject
    {
        // Get the resource name of the boost
        protected override string ResourceName => "Boost_" + name;
        public override int DefaultValue => Resources.Load<BoostSettings>("Settings/BoostSettings").GetBoostParameters(this).startCount;
        
        public bool makeBoostFree = false;

        public virtual bool Activate(BoostParameters parameters)
        {
            if(!makeBoostFree)
            {
                if (!Consume(1))
                    return false;
            }
            EventManager.GetEvent<BoostResource>(EGameEvent.BoostActivated).Invoke(this);
            return true;
        }
    }
}