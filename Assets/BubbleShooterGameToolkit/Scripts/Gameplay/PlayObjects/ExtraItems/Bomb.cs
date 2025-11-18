
 










using com.kshkum.ShootGame.Scripts.Gameplay.Animations;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Types;
using com.kshkum.ShootGame.Scripts.LevelSystem;
using DG.Tweening;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.ExtraItems
{
    public class Bomb : ExplosiveBall
    {
        public override Ball[] GetAffectedBalls()
        {
            return LevelUtils.GetNeighbours<Ball>(this, ball => ball != null && ball.DestroyProperties.destroyByExplosion && ball != this);
        }

        protected override void Activate()
        {
            var sequence = DOTween.Sequence();
            sequence.AppendInterval(0.1f); // Pause for 0.05 seconds
            var balls = GetAffectedBalls();
            ScoreManager.instance.CheckMultiplier(balls);
            WaveEffectProcessor.instance.AnimateWaveEffect(this, transform.position+ Vector3.up * 0.5f, 5, 0.3f, 0.1f, .01f, .1f);
            foreach (var ball in balls)
            {
                if (ball != null)
                {
                    var ballDestructionOptions = new BallDestructionOptions();
                    ballDestructionOptions.DestroyedBy = this;
                    if (ball is ColorBall)
                        sequence.AppendCallback(() =>
                        {
                            ballDestructionOptions.NoSound = true;
                            ballDestructionOptions.FXPrefab = explosionFXBubble;
                            ball.DestroyBall(ballDestructionOptions);
                        });
                    else
                        sequence.AppendCallback(() => ball.DestroyBall(ballDestructionOptions));
                    sequence.AppendInterval(0.05f); // Pause for 0.05 seconds
                }
            }
            sequence.AppendCallback(OnFinished);
        }

        public override bool DestroyBall(BallDestructionOptions options = null)
        {
            options ??= new BallDestructionOptions();
            return base.DestroyBall(options);
        }
    }
}