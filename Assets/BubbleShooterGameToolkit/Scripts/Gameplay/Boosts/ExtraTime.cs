
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Settings;
using BubbleShooterGameToolkit.Scripts.System;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Boosts
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