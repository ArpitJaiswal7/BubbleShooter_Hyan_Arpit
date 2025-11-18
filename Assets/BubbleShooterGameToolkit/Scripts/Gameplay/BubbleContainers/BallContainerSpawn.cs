
 










using com.kshkum.ShootGame.Scripts.Enums;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.BubbleContainers
{
    public class BallContainerSpawn : BallContainerBase
    {
        public BallContainerBase ballContainer;
        float spawnDelay = 0.5f;
        public string nextBallPrefabName;

        private void Update()
        {
            if(EventManager.GameStatus != EStatus.Play && EventManager.GameStatus != EStatus.Win && EventManager.GameStatus != EStatus.Tutorial)
                return;

            if (MovesTimeManager.instance != null && BallCharged == null)
            {
                if (MovesTimeManager.instance.GetMoves() > 1 || MovesTimeManager.instance.GetMoves() == 1 && !ballContainer.BallCharged)
                {
                    if (spawnDelay > 0)
                    {
                        spawnDelay -= Time.deltaTime;
                        return;
                    }
                    spawnDelay = 0.1f;
                    var generateColor = nextBallPrefabName == ""? "Ball " + ColorManager.instance.GenerateColor() : nextBallPrefabName;
                    nextBallPrefabName = "";
                    Spawn(generateColor);
                }
            }
        }

        public void SwitchBalls()
        {
            if (BallCharged != null && ballContainer.BallCharged != null)
            {
                OnBallSwitched?.Invoke(BallCharged);

                var cannonBallCharged = ballContainer.BallCharged;
                SwitchBall(this, ballContainer, BallCharged, (b) => ballContainer.BallCharged = b );
                ballContainer.SwitchBall(ballContainer, this, cannonBallCharged, (b)=> BallCharged = b);
            }
        }
    }
}