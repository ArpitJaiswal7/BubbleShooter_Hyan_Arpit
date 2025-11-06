
 










using BubbleShooterGameToolkit.Scripts.Audio;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.FieldObjects
{
    public class WallBounceTrigger : MonoBehaviour
    {
        [SerializeField] private AudioClip wallBounceSound;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                SoundBase.instance.PlayLimitSound(wallBounceSound);
            }
        }
    }
}