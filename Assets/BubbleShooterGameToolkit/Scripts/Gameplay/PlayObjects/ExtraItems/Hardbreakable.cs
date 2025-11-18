
 










using com.kshkum.ShootGame.Scripts.Audio;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Covers;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.ExtraItems
{
    // hard breakable cover, can be empty inside
    public class Hardbreakable : Cover
    {
        private int hp;
        public Sprite[] sprites;

        public override Ball ball
        {
            get => base.ball;
            set
            {
                base.ball = value;
                if(value is BallPlaceholder)
                {
                    RestoreParent();
                    value.transform.GetComponentInChildren<SpriteRenderer>().color = Color.clear;
                }
            }
        }

        public override void OnEnable()
        {
            hp = sprites.Length;
            GetComponentInChildren<SpriteRenderer>().sprite = sprites[hp - 1];
            base.OnEnable();
        }

        public override bool DestroyItem(BallDestructionOptions options)
        {
            hp--;
            if (hp > 0 && !ball.Flags.HasFlag(EBallFlags.Falling))
            {
                GetComponentInChildren<SpriteRenderer>().sprite = sprites[hp - 1];
                if(!options.NoFX)
                    PlayFX();
                ballSoundable.PlayExplosionSound(audioProperties.destroySound);
                return false;
            }

            return base.DestroyItem(options);
        }
    }
}