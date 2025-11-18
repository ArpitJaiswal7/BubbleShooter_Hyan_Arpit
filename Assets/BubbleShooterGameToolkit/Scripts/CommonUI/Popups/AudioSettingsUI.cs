
 










using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
{
	public class AudioSettingsUI : MonoBehaviour
	{
		[SerializeField]
		private Button musicButton;
		[SerializeField]
		private Button soundButton;

		[SerializeField]
		private AudioMixer mixer;
		[SerializeField]
		private string musicParameter = "musicVolume";
		[SerializeField]
		private string soundParameter = "soundVolume";

		[SerializeField]
		private Color enabledColor;
		[SerializeField]
		private Color disabledColor;

		void Start()
		{
			musicButton.onClick.AddListener(ToggleMusic);
			soundButton.onClick.AddListener(ToggleSound);
			OnEnable();
		}

		void OnEnable()
		{
			UpdateButtonState(musicButton, "Music", musicParameter, enabledColor, disabledColor);
			UpdateButtonState(soundButton, "Sound", soundParameter, enabledColor, disabledColor);
		}

		void UpdateButtonState(Button button, string playerPrefKey, string volumeParameter, Color onColor, Color offColor)
		{
			bool enabledState = PlayerPrefs.GetInt(playerPrefKey, 1) != 0f;
			float volumeValue = enabledState ? 0 : -80;

			foreach (Image childImage in button.transform.GetChild(0).GetComponentsInChildren<Image>())
			{
				childImage.color = enabledState ? onColor : offColor;
			}

			mixer.SetFloat(volumeParameter, volumeValue);
		}

		private void ToggleMusic()
		{
			int music = PlayerPrefs.GetInt("Music", 1);
			PlayerPrefs.SetInt("Music", music == 0f ? 1 : 0);
			OnEnable();
		}

		private void ToggleSound()
		{
			int sound = PlayerPrefs.GetInt("Sound", 1);
			PlayerPrefs.SetInt("Sound", sound == 0 ? 1 : 0);
			OnEnable();
		}
	}
}