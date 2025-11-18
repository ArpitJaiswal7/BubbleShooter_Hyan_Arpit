
 










using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Labels;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Properties;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Covers
{
    ///script for objects that appears above a ball
    public class Cover : Attachable
    {
        [Header("Protect ball from destroying"), Tooltip("if true, ball will not be destroyed, cover will be destroyed instead")]
        public bool isProtectingBall = true;

        [Space(10)]
        public DestroyProperties destroyProperties;

        public override bool DestroyItem(BallDestructionOptions options)
        {
            base.DestroyItem(options);
            if (isProtectingBall)
            {
                ball.cover = null;
                ball.Uncover();
                return false;
            }

            return true;
        }
        
        public void AdjustSortingOrder(int y)
        {
            var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

            for (var i = 0; i < spriteRenderers.Length; i++)
            {
                var spriteRenderer = spriteRenderers[i];
                spriteRenderer.sortingOrder = y + i;
            }
        }
    }
}