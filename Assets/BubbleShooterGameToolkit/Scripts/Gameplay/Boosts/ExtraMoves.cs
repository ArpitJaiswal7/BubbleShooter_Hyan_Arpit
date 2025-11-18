
 










using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Settings;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Boosts
{
    public class ExtraMoves : BoostResource
    {
        public override bool Activate(BoostParameters parameters)
        {
            if (!base.Activate(parameters)) return false;

            MovesTimeManager.instance.AddMoves(parameters.countItems);
            EventManager.GetEvent<BoostResource>(EGameEvent.BoostDeactivated).Invoke(this);
            return true;

        }
    }
}