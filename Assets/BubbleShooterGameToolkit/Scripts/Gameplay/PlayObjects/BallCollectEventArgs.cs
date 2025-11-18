
 










using com.kshkum.ShootGame.Scripts.Gameplay.Targets;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects
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