
 










using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Targets
{
    public class ExtraItemAnimation : AnimatedTargetBase
    {
        protected override float time => 1;

        public override void Init(Vector3 startPosition, Vector3 targetPosition)
        {
            base.Init(startPosition, targetPosition);
            transform.GetChild(0).gameObject.SetActive(true);
            animator.Rebind();
            animator.SetTrigger("Count");
        }

        private void Update()
        {
            // for every child of the game object
            foreach(Transform child in transform)
            {
                Vector3 direction = targetPosition - child.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; // assuming the sprite is facing up at 0 degrees
                Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
                child.rotation = targetRotation;
            }
        }
        
        public override void OnCompleted()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            Invoke(nameof(base.OnCompleted), 1);
        }
    }
}