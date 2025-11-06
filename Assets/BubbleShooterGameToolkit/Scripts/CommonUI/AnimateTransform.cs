
 










using System;
using DG.Tweening;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.CommonUI
{
    [RequireComponent(typeof(RectTransform))]
    public class AnimateTransform : MonoBehaviour
    {
        public Move position;
        public Rotate rotation;
        public Scale scale;
        public Size sizeDelta;
        
        private RectTransform rectTransform;

        void OnEnable()
        {
            rectTransform = GetComponent<RectTransform>();

            if(position.targetValue != Vector3.zero)
            {
                rectTransform.anchoredPosition = position.startValue;
                position.Animate(rectTransform);
            }
            if(rotation.targetValue != Vector3.zero)
            {
                rectTransform.eulerAngles = rotation.startValue;
                rotation.Animate(rectTransform);
            }
            if(scale.targetValue != Vector3.zero)
            {
                rectTransform.localScale = scale.startValue;
                scale.Animate(rectTransform);
            }
            if(sizeDelta.targetValue != Vector3.zero)
            {
                rectTransform.sizeDelta = sizeDelta.startValue;
                sizeDelta.Animate(rectTransform);
            }
        }

        private void OnDisable()
        {
            rectTransform.DOKill();
        }
    }
    
    [Serializable]
    public abstract class TweenAnimationParameters
    {
        public Vector3 startValue;
        public Vector3 targetValue;
        public float duration = 0f;
        public float delay = 0f;
        public Ease easeType = Ease.Linear;
        public bool loop = false;
        public LoopType loopType;

        public void Animate(RectTransform rectTransform)
        {
            GetTween(rectTransform).SetEase(easeType).SetDelay(delay).SetLoops(loop? -1: 1, loopType);
        }

        protected abstract Tweener GetTween(RectTransform rectTransform);
    }
    
    [Serializable]
    public class Move: TweenAnimationParameters
    {
        protected override Tweener GetTween(RectTransform rectTransform) => rectTransform.DOLocalMove(targetValue, duration);
    }
    
    [Serializable]
    public class Rotate: TweenAnimationParameters
    {
        protected override Tweener GetTween(RectTransform rectTransform) => rectTransform.DOLocalRotate(targetValue, duration);
    }
    
    [Serializable]
    public class Scale: TweenAnimationParameters
    {
        protected override Tweener GetTween(RectTransform rectTransform) => rectTransform.DOScale(targetValue, duration);
    }
    
    [Serializable]
    public class Size: TweenAnimationParameters
    {
        protected override Tweener GetTween(RectTransform rectTransform) => rectTransform.DOSizeDelta(targetValue, duration);
    }
}