
 










#region

using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects;
using BubbleShooterGameToolkit.Scripts.Settings;
using UnityEngine;

#endregion

namespace BubbleShooterGameToolkit.Scripts.Gameplay.FieldObjects
{
    public class Hole : ObjectTrigger
    {
        public int score;

        protected override void OnEnable()
        {
            base.OnEnable();
            score = Resources.Load<GameplaySettings>("Settings/GameplaySettings").holesScore[int.Parse(name.Substring(name.Length - 1))];
        }

        protected override int GetScoreMultiplier(Ball ball)
        {
            return score + ball.GetScore();
        }

        protected override void BallCollide(Collider2D other)
        {
            Ball ball = other.GetComponent<Ball>();
            if (ball != null && (ball.Flags & EBallFlags.Destroying) == 0)
            {
                ball.gameObject.SetActive(false);
                DestroyBall(ball);
            }
        }

        protected override void DestroyBall(Ball ball)
        {
            ScoreManager.instance.AddScore(GetScoreMultiplier(ball), transform.position, false);
            var ballDestructionOptions = new BallDestructionOptions();
            ballDestructionOptions.NoScore = true;
            ballDestructionOptions.NoFX = true;
            ball.DestroyBall(ballDestructionOptions);
        }
    }

}