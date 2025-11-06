
 










using DG.Tweening;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Targets
{
    public class AnimatedTarget : AnimatedTargetBase
    {
        [SerializeField] private float delay = 1f;
        [SerializeField] private bool rotate = true;

        public override void Init(Vector3 startPosition, Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
            transform.position = startPosition;
            var a1 = transform.DOScale(Vector3.one * 2, .2f);
            var a2 = transform.DOMove(targetPosition, time).SetEase(Ease.InOutBack).OnComplete(OnCompleted);
            var a3 = transform.DOScale(Vector3.one, .5f);
            if(rotate)
                transform.DORotate(Vector3.back * 1000, time * 2);
            var sequence = DOTween.Sequence();
            //delay before animation
            sequence.Append(a1);
            sequence.AppendInterval(delay);
            sequence.Append(a2);
            sequence.Append(a3);
            sequence.Play();
        }
    }
}