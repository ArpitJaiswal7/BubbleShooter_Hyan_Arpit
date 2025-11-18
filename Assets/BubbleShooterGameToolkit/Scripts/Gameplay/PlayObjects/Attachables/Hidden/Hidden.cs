
 










using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Labels;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Hidden
{
    public class Hidden : Attachable
    {
        public override bool DestroyItem(BallDestructionOptions options)
        {
            base.DestroyItem(options);
            ball.hidden = null;
            return true;
        }
    }
}