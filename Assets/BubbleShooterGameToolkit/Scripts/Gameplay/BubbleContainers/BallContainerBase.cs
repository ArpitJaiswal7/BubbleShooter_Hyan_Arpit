
 










using System;
using System.Collections;
using System.Linq;
using com.kshkum.ShootGame.Scripts.Enums;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Types;
using com.kshkum.ShootGame.Scripts.Gameplay.Pool;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.kshkum.ShootGame.Scripts.Gameplay.BubbleContainers
{
    public class BallContainerBase : MonoBehaviour
    {
        protected Ball savedBall;
        
        public static Action<Ball> OnBallLaunched;
        public static Action<Ball> OnBallSwitched;
        protected Coroutine switchCoroutine;

        public Ball BallCharged { get; set; }

        protected virtual void Start() { }

        public void SwitchBall(BallContainerBase ballContainerFrom, BallContainerBase ballContainerDest, Ball newBall, Action<Ball> callback = null)
        {
            if (switchCoroutine != null)
                return;
            switchCoroutine = StartCoroutine(SwitchBallIenumerator(ballContainerFrom, ballContainerDest, newBall, callback));
        }

        private IEnumerator SwitchBallIenumerator(BallContainerBase ballContainerFrom, BallContainerBase ballContainerDest, Ball newBall, Action<Ball> callback = null)
        {
            var trajectoryHeight = 2f;
            float elapsedTime = 0;

            var duration = EventManager.GameStatus == EStatus.Win ? 0.1f : 0.3f;
            
            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                
                Vector3 p1 = ballContainerFrom.transform.position + new Vector3((ballContainerDest.transform.position.x - ballContainerFrom.transform.position.x) / 2, trajectoryHeight, 0);

                // Calculate the Bezier curve's point at time t
                Vector3 m0 = Vector3.Lerp(ballContainerFrom.transform.position, p1, t);
                Vector3 m1 = Vector3.Lerp(p1, ballContainerDest.transform.position, t);
                Vector3 position = Vector3.Lerp(m0, m1, t);

                newBall.transform.position = position;

                elapsedTime += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }
            newBall.transform.SetParent(ballContainerDest.transform);

            newBall.transform.position = ballContainerDest.transform.position;
            switchCoroutine = null;
            callback?.Invoke(newBall);
        }

        protected Ball SpawnBall(string prefabName)
        {
            Ball ball;
            var prefabRef = PrefabReferences.Instance;
            
            if (prefabName.StartsWith("Ball ") && prefabRef != null)
            {
                string colorIndexStr = prefabName.Substring(5);
                if (int.TryParse(colorIndexStr, out int colorIndex) &&
                    prefabRef.coloredBalls != null &&
                    colorIndex >= 0 &&
                    colorIndex < prefabRef.coloredBalls.Length)
                {
                    GameObject ballPrefab = prefabRef.GetColoredBall(colorIndex);
                    if (ballPrefab != null)
                    {
                        ball = PoolObject.GetObject(ballPrefab).GetComponent<Ball>();
                    }
                    else
                    {
                        ball = PoolObject.GetObject(prefabName).GetComponent<Ball>();
                    }
                }
                else
                {
                    ball = PoolObject.GetObject(prefabName).GetComponent<Ball>();
                }
            }
            else
            {
                ball = PoolObject.GetObject(prefabName).GetComponent<Ball>();
            }

            Debug.Log("Ball shot");

            ball.transform.position = transform.position;
            ball.Flags &= ~EBallFlags.Root;
            ball.Flags &= ~EBallFlags.Pinned;
            ball.transform.SetParent(transform);
            ball.gameObject.layer = LayerMask.NameToLayer("LaunchedBubble");
            var componentInChildren = ball.GetComponentInChildren<SpriteRenderer>();
            componentInChildren.sortingOrder = 0;
            componentInChildren.sortingLayerID = 0;
            ball.BallColliderHandler.SetKinematic(ball);
            return ball;
        }

        public void ChangeColor()
        {
            if(BallCharged != null && !BallCharged.GetComponent<BallLaunch>())
            {
                BallCharged.DisableAndReturnToPool();
                
                int colorIndex = ColorManager.instance.GenerateColor();
                Ball newBall;
                
                var prefabRef = PrefabReferences.Instance;
                if (prefabRef != null && prefabRef.coloredBalls != null && 
                    colorIndex >= 0 && colorIndex < prefabRef.coloredBalls.Length)
                {
                    GameObject ballPrefab = prefabRef.GetColoredBall(colorIndex);
                    if (ballPrefab != null)
                    {
                        newBall = SpawnBall($"Ball {colorIndex}");
                    }
                    else
                    {
                        newBall = SpawnBall($"Ball {colorIndex}");
                    }
                }
                else
                {
                    newBall = SpawnBall($"Ball {colorIndex}");
                }
                
                BallCharged = newBall;
            }
        }
        
        public int GetColor()
        {
            if (BallCharged == null || BallCharged is ColorBall == false)
                return -1;
            return ((ColorBall)BallCharged).GetColor();
        }

        public void Spawn(string generateColor)
        {
            BallCharged = SpawnBall(generateColor);
            BallCharged.SetSortingLayer(LayerMask.NameToLayer("Default"));
        }
    }
}