
 










using com.kshkum.ShootGame.Scripts.Audio;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.ExtraItems
{
    public abstract class ExplosiveBall : Ball
    {
        [SerializeField]
        protected GameObject explosionFXBubble;
        [SerializeField]
        protected AudioClip explosionBubbleSound; 
        [SerializeField]
        protected AudioClip activateSound;

        private bool activated;

        public abstract Ball[] GetAffectedBalls();
        protected abstract void Activate();

        public override void OnEnable()
        {
            base.OnEnable();
            activated = false;
            ballSoundable = new BallSoundBomb();
        }
        
        public override bool DestroyBall(BallDestructionOptions options = null)
        {
            
            if (ballDestruction.CanDestroyNow())
            {
                options ??= new BallDestructionOptions();
                if (!activated)
                {
                    ballSoundable.PlayExplosionSound(activateSound);
                    Debug.Log("Destroying ball and can destroy now");
                    activated = true;
                    Activate();
                }
            }

            return base.DestroyBall(options);
        }

        public void OnFinished()
        {
            EventManager.GetEvent(EGameEvent.CheckSeparatedBalls).Invoke();
        }
    }
}