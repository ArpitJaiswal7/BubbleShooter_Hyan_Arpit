
 










using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.FieldObjects
{
    class BottomWalForRotate : Wall
    {
        protected override void BallCollide(Collider2D other)
        {
            base.BallCollide(other);
            
            // increase collider size if launched ball is colliding with bottom wall to looks better in holes
            BallLaunch ball = other.gameObject.GetComponent<BallLaunch>();
            if (ball != null && ball.direction.y < 0)
            {
                ball.ball.BallColliderHandler.SetKinematic(ball.ball, false);
            }
        }
    }
}