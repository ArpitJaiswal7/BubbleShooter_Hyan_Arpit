
 










using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.BubbleContainers
{
    /// a dot for aim line
    public class AimDot : MonoBehaviour
    {
        private Vector2 startPoint;
        private Vector2 nextPoint;
        public bool animate = true;
        [SerializeField]
        private SpriteRenderer spr;
        private float startTime;
        private float journeyLength;
        private float duration;
        private Vector3 targetScale;
        private float targetTime;
        public bool IsShow => spr.color.a >= 1f;
        private float fadeSpeed = 5f;
        private bool shouldBeVisible = false;

        public void SetColor(Color color)
        {
            spr.color = color;
        }

        public void Hide()
        {
            shouldBeVisible = false;
        }

        public void Show()
        {
            shouldBeVisible = true;
        }

        public void UpdateAnimation(Vector2 startPoint, Vector2 nextPoint)
        {
            this.startPoint = spr.transform.parent.InverseTransformPoint(startPoint);
            this.nextPoint = spr.transform.parent.InverseTransformPoint(nextPoint);
        }

        private void Update()
        {
            UpdateVisibility();

            if (!animate)
                return;
            
            spr.transform.localPosition = Vector2.MoveTowards(spr.transform.localPosition, nextPoint, Time.deltaTime * 5f);
            duration = .5f;
            if (startTime + duration < Time.time)
            {
                ReStartAnimation();
            }
            
            UpdateScaleAnimation();
        }

        private void ReStartAnimation()
        {
            spr.transform.localPosition = startPoint;
            startTime = Time.time;
        }

        public void SetScaleAnimation(Vector3 vector3, float prevScale)
        {
            spr.transform.localScale = new Vector3(prevScale, prevScale, 1);
            targetScale = vector3;
            targetTime = Time.time + duration;
        }
        
        private void UpdateScaleAnimation()
        {
            if (targetTime > Time.time)
            {
                // scale lerp animation in update
                float t = (Time.time - (targetTime - duration)) / duration;
                spr.transform.localScale = Vector3.Lerp(spr.transform.localScale, targetScale, t);
            }
        }
        
        private void UpdateVisibility()
        {
            float targetAlpha = shouldBeVisible ? 1 : 0;
            Color spriteColor = spr.color;
            spriteColor.a = Mathf.MoveTowards(spriteColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
            spr.color = spriteColor;
        }
    }
}