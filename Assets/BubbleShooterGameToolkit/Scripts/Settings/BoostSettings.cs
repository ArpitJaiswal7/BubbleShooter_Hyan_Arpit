
 










using System;
using com.kshkum.ShootGame.Scripts.Gameplay.Boosts;

namespace com.kshkum.ShootGame.Scripts.Settings
{
    public class BoostSettings : SettingsBase
    {
        public BoostParameters[] boosts;

        public BoostParameters GetBoostParameters(BoostResource boostType)
        {
            foreach (var boost in boosts)
            {
                if (boost.boostResource == boostType)
                {
                    return boost;
                }
            }

            throw new Exception("Boost not found");
        }
    }
}