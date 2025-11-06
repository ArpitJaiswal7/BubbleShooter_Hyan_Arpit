
 










using BubbleShooterGameToolkit.Scripts.Audio;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Popups
{
	public class PreWinBanner : Banner {
		private void OnEnable()
		{
			SoundBase.instance.PlaySound(SoundBase.instance.cheers);
		}
	}
}
