
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects;
using BubbleShooterGameToolkit.Scripts.Settings;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Boosts
{
    public class MulticolorBallBoostResource : BoostResource
    {
        public override bool Activate(BoostParameters parameters)
        {
            if (!base.Activate(parameters)) return false;
            EventManager.GetEvent<(Ball,Ball)>(EGameEvent.BallStopped).Subscribe(OnBallStopped);

            return true;
        }

        private void OnBallStopped((Ball, Ball) valueTuple)
        {   
            EventManager.GetEvent<(Ball,Ball)>(EGameEvent.BallStopped).Unsubscribe(OnBallStopped);
            EventManager.GetEvent<BoostResource>(EGameEvent.BoostDeactivated).Invoke(this);
        }
    }
}