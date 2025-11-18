
 










using System.Linq;
using com.kshkum.ShootGame.Scripts.Enums;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects;
using com.kshkum.ShootGame.Scripts.Utils;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Rendering;

namespace com.kshkum.ShootGame.Scripts.Gameplay.BubbleContainers
{
    /// Throws balls
    public class LaunchContainer : BallContainerBase
    {
        public BallContainerSpawn ballContainerSpawn;
        private Ball ballAnimated;
        private Vector2Int newBallPos;

        private void Update()
        {
            if (EventManager.GameStatus != EStatus.Play && EventManager.GameStatus != EStatus.Win && EventManager.GameStatus != EStatus.Tutorial)
                return;

            if (BallCharged == null)
            {
                if(savedBall != null)
                {
                    BallCharged = savedBall;
                    var sortingGroup = BallCharged.gameObject.AddComponentIfNotExists<SortingGroup>();
                    sortingGroup.sortingOrder = 0;
                    savedBall = null;
                }
                else
                {
                    if (ballContainerSpawn.BallCharged != null)
                    {
                        ballAnimated = ballContainerSpawn.BallCharged;
                        SwitchBall(ballContainerSpawn, this, ballAnimated);
                        BallCharged = ballAnimated;
                        ballContainerSpawn.BallCharged = null;
                    }
                }
            }
        }

        public void SaveBall()
        {
            // save ball for next move
            if (BallCharged != null)
            {
                savedBall = BallCharged;
            }
        }

        public void LaunchBall(RaycastData raycastData)
        {
            Debug.Log("Ball shot new");
            if (BallCharged == null || switchCoroutine != null)
                return;
            if (MovesTimeManager.instance.GetMoves() == 0 && EventManager.GameStatus != EStatus.Win)
                return;

            var ballMovement = BallCharged.gameObject.AddComponentIfNotExists<BallLaunch>();
            if (ballMovement.launched)
                return;

            ballMovement.ball = BallCharged;
            ballMovement.Launch(raycastData);

            OnBallLaunched?.Invoke(BallCharged);
            BallCharged = null;
        }
    }
}