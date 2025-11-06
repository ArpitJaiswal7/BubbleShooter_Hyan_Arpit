
 










using BubbleShooterGameToolkit.Scripts.Data;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Settings;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Boosts
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