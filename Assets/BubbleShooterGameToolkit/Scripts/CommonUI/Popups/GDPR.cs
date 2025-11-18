
 










using com.kshkum.ShootGame.Scripts.System;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
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