
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects.Types
{
    public class ColorBall : Ball
    {
        [SerializeField]
        protected int color;

        private Sprite sprite;
        private Color colorForAim;

        public override void OnEnable()
        {
            base.OnEnable();
            colorForAim = GameManager.instance.GameplaySettings.ballColors[color];
        }

        public override void SetPosition(Vector2Int pos)
        {
            base.SetPosition(pos);
            ColorManager.instance.AddColor(color);
        }

        public override Color GetColorForAim()
        {
            return colorForAim;
        }

        public virtual int GetColor(ColorBall neighborBall = null)
        {
            return color;
        }
        
        public virtual bool CompareColor(int color)
        {
            return this.color == color;
        }

        public override void Fall()
        {
            base.Fall();
            ColorManager.instance.RemoveColor(color);
        }

        public override bool DestroyBall(BallDestructionOptions options = null)
        {
            bool falling = Flags.HasFlag(EBallFlags.Falling);
            var destroyBall = base.DestroyBall(options);
            if(destroyBall && !falling)
                ColorManager.instance.RemoveColor(color);
            return destroyBall;
        }
    }
}