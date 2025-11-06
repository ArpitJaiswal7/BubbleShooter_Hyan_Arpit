
 










using BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.FieldObjects
{
    class Wall : ObjectTrigger
    {
        protected override int GetScoreMultiplier(Ball ball)
        {
            return ball.GetScore();
        }

        protected override void BallCollide(Collider2D other)
        {
            Ball ball = other.GetComponent<Ball>();
            if (ball != null && ball.gameObject.layer == LayerMask.NameToLayer("Bubble"))
            {
                ball.gameObject.SetActive(false);
                DestroyBall(ball);
            }
        }
    }
}