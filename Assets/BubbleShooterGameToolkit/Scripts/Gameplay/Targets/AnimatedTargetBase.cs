
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Gameplay.Pool;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Targets
{
    public class AnimatedTargetBase : MonoBehaviour
    {
        protected Animator animator;
        protected Vector3 targetPosition;
        protected virtual float time => .5f;

        public virtual void Init(Vector3 startPosition, Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
            animator = GetComponent<Animator>();
            transform.position = startPosition;
            GroupAnimationManager.instance.Animate(
                transform,
                time,
                GetTargetPosition(),
                Quaternion.identity,
                true,
                OnCompleted);
        }
        
        public virtual Vector3 GetTargetPosition()
        {
            return transform.parent.InverseTransformPoint(targetPosition);
        }

        public virtual void OnCompleted()
        {
            ReturnToPool();
        }

        protected void ReturnToPool()
        {
            PoolObject.Return(gameObject);
        }
    }
}