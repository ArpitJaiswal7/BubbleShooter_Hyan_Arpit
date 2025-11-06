
 










using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BubbleShooterGameToolkit.Scripts.Enums;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects;
using BubbleShooterGameToolkit.Scripts.LevelSystem;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Animations
{
    /// Checks all balls to determine if they're connected. If not, triggers them to drop down.
    public class SeparatingBallManager : MonoBehaviour
    {
        private List<List<Ball>> balls;
        private Level level;

        public void Init(List<List<Ball>> balls, Level level)
        {
            this.balls = balls;
            this.level = level;
        }

        public Coroutine CheckSeparatedBalls()
        {
            return StartCoroutine(CheckSeparatedBallsCor(balls, level));
        }

        private IEnumerator CheckSeparatedBallsCor(List<List<Ball>> balls, Level level)
        {
            for (int i = 0; i < 5; i++)
            {
                //separate connected from the rest balls
                List<Ball> ballsToFall = Prepare(balls, level);

                ballsToFall = ballsToFall.OrderByDescending(ball => ball.position.y).ToList();
                foreach (var ball in ballsToFall)
                {
                    ball.Fall();
                    //yield return new WaitForSeconds(Random.Range(0.01f, 0.03f));
                }

                GameCamera.instance.CheckLowestBall();

                yield return new WaitUntil(() => ballsToFall.All(ball => !ball.gameObject.activeSelf)); // wait for all balls to fall

                yield return new WaitForEndOfFrame();
            }
        }

        public List<Ball> Prepare(List<List<Ball>> balls, Level level, EBallFlags filterFlags = EBallFlags.None)
        {
            LevelUtils.ClearMarks(balls);

            // find connected balls
            var ballsWithNeighbours = LevelUtils.GetConnectedBalls(level, filterFlags);

            List<Ball> ballsToFall = new List<Ball>();
            var ballsCount = balls.SelectMany(list => list).Count(ball => ball != null);
            if (ballsCount > ballsWithNeighbours.Count)
            {
                for (int y = balls.Count - 1; y >= 0; y--)
                {
                    for (int x = 0; x < balls[y].Count; x++)
                    {
                        var ball = balls[y][x];
                        if (ball == null)
                            continue;

                        var verticalCondition = level.levelType != ELevelTypes.Vertical || ball.position.y > 0; // don't fall balls on the top of the level in vertical mode
                        if ((ball.Flags & EBallFlags.Pinned) != 0 && verticalCondition && !ballsWithNeighbours.Contains(ball) && (ball.Flags & EBallFlags.MarkedForDestroy) == 0 && (ball.Flags & EBallFlags.Destroying) == 0)
                        {
                            ball.TryToFall();
                            ballsToFall.Add(ball);
                        }
                    }
                }
            }

            return ballsToFall;
        }
    }
}