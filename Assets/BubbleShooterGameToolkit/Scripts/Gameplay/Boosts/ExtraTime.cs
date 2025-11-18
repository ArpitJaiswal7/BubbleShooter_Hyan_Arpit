
 










using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Settings;
using com.kshkum.ShootGame.Scripts.System;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Boosts
{
    public class ExtraTime : BoostResource
    {
        public override bool Activate(BoostParameters parameters)
        {
            if (!base.Activate(parameters)) return false;
            MovesTimeManager.instance.AddMoves(GameManager.instance.GameSettings.timeContinue);
            EventManager.GetEvent<BoostResource>(EGameEvent.BoostDeactivated).Invoke(this);
            return true;
        }
    }
}