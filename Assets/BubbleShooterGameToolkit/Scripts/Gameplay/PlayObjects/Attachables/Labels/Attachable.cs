
 










using System;
using com.kshkum.ShootGame.Scripts.Audio;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Gameplay.Pool;
using com.kshkum.ShootGame.Scripts.Gameplay.Targets;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Labels
{
    public class Attachable : Targetable
    {
        public virtual Ball ball { get; set; }
        public Action<BallDestructionOptions> OnDestroy;
        protected BallSound ballSoundable;

        public virtual void OnTouched(Ball touchedByBall, Ball thisBall)
        { }

        public virtual bool DestroyItem(BallDestructionOptions options = null)
        {
            options ??= new BallDestructionOptions();
            if(!options.NoFX)
                PlayFX();
            if(!options.NoSound)
                ballSoundable.PlayExplosionSound(audioProperties.destroySound);
            OnDestroy?.Invoke(options);
            RestoreParent();
            EventManager.GetEvent<BallCollectEventArgs>(EGameEvent.ItemDestroyed).Invoke(new BallCollectEventArgs(this, options.DestroyedBy));
            if (!TargetManager.instance.IsTarget(this))
            {
                PoolObject.Return(gameObject);
            }
            return true;
        }

        protected void PlayFX()
        {
            if(fxPrefab)
                PoolObject.GetObject(fxPrefab).transform.position = transform.position;
        }

        public override void OnEnable()
        {
            ball ??= GetComponentInParent<Ball>();
            ballSoundable = new BallSound();
        }

        public virtual void OnDisable()
        { }

        public virtual void SetPosition(Vector3 transformPosition)
        {
            transform.position = transformPosition;
        }
    }
}