
 










using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Popups
{
    public class GDPR : Popup
    {
        public void OnUserClickAccept()
        {
            PlayerPrefs.SetInt("npa", 0);
            Close();
        }

        public void OnUserClickCancel()
        {
            PlayerPrefs.SetInt("npa", 1);
            Close();
        }

        public void OnUserClickPrivacyPolicy()
        {
            Application.OpenURL(GameManager.instance.GameSettings.privacyPolicyUrl);
        }
    }
}