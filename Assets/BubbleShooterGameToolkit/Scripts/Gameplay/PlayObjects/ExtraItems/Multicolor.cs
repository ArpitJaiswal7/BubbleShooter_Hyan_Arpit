
 










using BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects.Types;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects.ExtraItems
{
    public class Multicolor : ColorBall
    {
        private int targetColor;

        public override void OnTouched(Ball touchedByBall)
        {
            base.OnTouched(touchedByBall);

            if (touchedByBall is ColorBall colorBall)
            {
                targetColor = colorBall.GetColor();
            }
        }
        
        public override bool CompareColor(int color)
        {
            return true;
        }

        public override int GetColor(ColorBall neighborBall)
        {
            if (neighborBall != null)
            {
                targetColor = neighborBall.GetColor();
            }

            return targetColor;
        }

        public override bool DestroyBall(BallDestructionOptions options = null)
        {
            Destroy(GetComponent<Rigidbody2D>());
            return base.DestroyBall(options);
        }
    }
}