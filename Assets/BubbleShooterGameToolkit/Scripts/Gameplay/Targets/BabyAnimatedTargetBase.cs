
 










using BubbleShooterGameToolkit.Scripts.Audio;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Targets
{
    public class BabyAnimatedTargetBase : AnimatedTargetBase
    {
        protected override float time => 3;
        
        [SerializeField]
        private AudioClip[] landingSounds;

        public override Vector3 GetTargetPosition()
        {
            var rectTransform = LevelManager.instance.landingRect;
    
            // corners of the RectTransform
            Vector3[] corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);
    
            var bottomLeft = corners[0];
            var topRight = corners[2];
    
            // total width of the area
            float totalWidth = topRight.x - bottomLeft.x;

            // index of the current baby
            int index = CurrentBabyCount();

            // x position of the current baby
            float x = bottomLeft.x + 1 * index;
            
            x = Mathf.PingPong(x, totalWidth) + bottomLeft.x;

            float y = UnityEngine.Random.Range(bottomLeft.y, topRight.y);

            var vector3 = new Vector3(x, y, 0);
            var targetPositionLocal = transform.parent.InverseTransformPoint(vector3);
            
            SoundBase.instance.PlayDelayed(landingSounds[UnityEngine.Random.Range(0, landingSounds.Length)],0.5f);

            return targetPositionLocal;
        }

        private static int CurrentBabyCount()
        {
            return TargetManager.instance.GetTargetCount("Babies");
        }

        public override void OnCompleted()
        {
            animator.SetTrigger("Landing");
        }
    }
}