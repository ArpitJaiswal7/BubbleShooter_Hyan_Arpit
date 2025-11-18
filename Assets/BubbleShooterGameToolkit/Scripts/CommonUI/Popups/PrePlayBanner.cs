
 










using com.kshkum.ShootGame.Scripts.Audio;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
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