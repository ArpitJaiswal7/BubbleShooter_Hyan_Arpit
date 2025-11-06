
 










using BubbleShooterGameToolkit.Scripts.Audio;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.CommonUI
{
    public class PlaySound : MonoBehaviour
    {
        public AudioClip clip;
        public bool playOnAwake;
        public float delay;

        private void OnEnable()
        {
            if (playOnAwake)
            {
                Invoke(nameof(Play), delay);
            }
        }

        public void Play()
        {
            if (clip == null) return;
            SoundBase.instance.PlaySound(clip);
        }
    }
}