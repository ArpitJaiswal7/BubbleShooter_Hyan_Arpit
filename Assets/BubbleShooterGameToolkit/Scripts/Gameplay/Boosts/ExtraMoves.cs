
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Settings;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Boosts
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