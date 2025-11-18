
 










using com.kshkum.ShootGame.Scripts.Audio;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
{
	public class PreWinBanner : Banner {
		private void OnEnable()
		{
			SoundBase.instance.PlaySound(SoundBase.instance.cheers);
		}
	}
}
