
 










using BubbleShooterGameToolkit.Scripts.Enums;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Popups
{
	public class MenuPause : Popup
	{
		public Button mapButton;
		public Button restartButton;

		private void OnEnable()
		{
			closeButton.onClick.AddListener(Play);
			mapButton.onClick.AddListener(GoToMap);
			restartButton.onClick.AddListener(Restart);
		}

		private void Restart()
		{
			GameManager.instance.RestartLevel();
			Close();
		}

		private void Play()
		{
			EventManager.SetGameStatus(EStatus.Play);
			Close();
		}

		private void GoToMap()
		{
			MenuManager.instance.ShowPopup<Confirmation>(null, ConfirmExit);
		}

		private void ConfirmExit(EPopupResult ePopupResult)
		{
			if (ePopupResult == EPopupResult.Yes)
			{
				SceneLoader.instance.GoToMap();
			}
			else
			{
				// Resume gameplay if user cancels
				EventManager.SetGameStatus(EStatus.Play);
			}
			AfterHideAnimation();
			gameObject.SetActive(false);
		}
	}
}
