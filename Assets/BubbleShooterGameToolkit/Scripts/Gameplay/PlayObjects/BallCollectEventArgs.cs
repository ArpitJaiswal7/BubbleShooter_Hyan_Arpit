
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Targets;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects
{
    public struct BallCollectEventArgs
    {
        public Targetable targetObject { get; }
        public Ball destroyedBy;

        public BallCollectEventArgs(Targetable targetObject, Ball destroyedBy = null)
        {
            this.targetObject = targetObject;
            this.destroyedBy = destroyedBy;
        }
    }
}