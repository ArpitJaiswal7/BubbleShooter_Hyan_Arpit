
 










using BubbleShooterGameToolkit.Scripts.Audio;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Popups
{
    class PrePlayBanner : Banner
    {
        private void OnEnable()
        {
            GameCamera.instance.MoveToStartingPosition(PlayGame);
        }

        private void PlayGame()
        {
            SoundBase.instance.PlaySound(SoundBase.instance.readyGo[0]);
            SoundBase.instance.PlayDelayed(SoundBase.instance.readyGo[1], 0.8f);
        }
    }
}