
 










using BubbleShooterGameToolkit.Scripts.LevelSystem;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects.Attachables.Labels
{
    class ExtraItem : LabelItem
    {
        protected override void ChangeAttributes(Level obj)
        {
            base.ChangeAttributes(obj);
            if (ball.cover != null)
            {
                ball.cover.OnDestroy += DestroyThisItem;
            }
        }

        private void DestroyThisItem(BallDestructionOptions options)
        {
            DestroyItem(options);
        }

        public override bool DestroyItem(BallDestructionOptions options = null)
        {
            if (ball?.cover != null)
                ball.cover.OnDestroy -= DestroyThisItem;
            return base.DestroyItem(options);
        }

        public override void SetPosition(Vector3 transformPosition)
        {
            transform.position = ball.transform.position + new UnityEngine.Vector3(.2f, .2f, 0);
            transform.localRotation = UnityEngine.Quaternion.Euler(0, 0, 30);
        }
    }
}