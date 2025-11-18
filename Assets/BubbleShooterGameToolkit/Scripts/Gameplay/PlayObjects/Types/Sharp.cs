
 










namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Types
{
    class Sharp : AbsorbingBall
    {
        public override void OnDirectlyTouched(Ball touchedByBall)
        {
            base.OnDirectlyTouched(touchedByBall);
            if (touchedByBall is ColorBall)
            {
                touchedByBall.DestroyBall();
            }
        }
    }
}