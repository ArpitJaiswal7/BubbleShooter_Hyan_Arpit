
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.LevelSystem;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects.Attachables.Labels
{
    public class LabelItem : Attachable
    {
        public override void OnEnable()
        {
            base.OnEnable();
            EventManager.GetEvent<Level>(EGameEvent.LevelLoaded).Subscribe(ChangeAttributes);
        }
        
        public override void OnDisable()
        {
            base.OnDisable();
            EventManager.GetEvent<Level>(EGameEvent.LevelLoaded).Unsubscribe(ChangeAttributes);
        }

        protected virtual void ChangeAttributes(Level obj)
        {
        }

        public override void OnTouched(Ball touchedByBall, Ball thisBall)
        {
            base.OnTouched(touchedByBall, thisBall);
            DestroyItem();
        }

        public override bool DestroyItem(BallDestructionOptions options = null)
        {
            ball.label = null;
            return base.DestroyItem(options);
        }
    }
}