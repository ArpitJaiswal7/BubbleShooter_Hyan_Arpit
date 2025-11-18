
 










namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects
{
    class BallPlaceholder : Ball
    {
        public override void Uncover()
        {
            base.Uncover();
            DestroyBall();
        }
    }
}