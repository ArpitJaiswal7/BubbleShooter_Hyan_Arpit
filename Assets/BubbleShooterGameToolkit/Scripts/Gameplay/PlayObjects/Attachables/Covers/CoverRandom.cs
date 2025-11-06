
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Gameplay.Pool;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects.Attachables.Covers
{
    class CoverRandom : Cover
    {
        private const string BALL_PLACEHOLDER_NAME = "Ball Placeholder";
        
        public override bool DestroyItem(BallDestructionOptions options)
        {
            if (ball != null && ball.name == BALL_PLACEHOLDER_NAME)
            {
                Ball newBall;
                int colorIndex = ColorManager.instance.GenerateColor();
                
                var prefabRef = PrefabReferences.Instance;
                if (prefabRef != null && prefabRef.coloredBalls != null && 
                    colorIndex >= 0 && colorIndex < prefabRef.coloredBalls.Length)
                {
                    GameObject ballPrefab = prefabRef.GetColoredBall(colorIndex);
                    if (ballPrefab != null)
                    {
                        newBall = PoolObject.GetObject(ballPrefab).GetComponent<Ball>();
                    }
                    else
                    {
                        newBall = PoolObject.GetObject($"Ball {colorIndex}").GetComponent<Ball>();
                    }
                }
                else
                {
                    newBall = PoolObject.GetObject($"Ball {colorIndex}").GetComponent<Ball>();
                }
                
                newBall.SetPosition(options.DestroyedBy.position);
                this.ball.DestroyBall();
            }
            return base.DestroyItem(options);
        }
    }
}