
 










using BubbleShooterGameToolkit.Scripts.Audio;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects
{
    public interface IBallSoundable
    {
        void PlayExplosionSound(AudioClip _destroySound);
    }
    
    public class BallSound : IBallSoundable
    {
        public void PlayExplosionSound(AudioClip _destroySound)
        {
            if (_destroySound != null)
                SoundBase.instance.PlayLimitSound(_destroySound);
        }
    }
    
    public class BallSoundBomb : IBallSoundable
    {
        public void PlayExplosionSound(AudioClip _destroySound)
        {
            if (_destroySound != null)
                SoundBase.instance.PlaySound(_destroySound);
        }
    }

}