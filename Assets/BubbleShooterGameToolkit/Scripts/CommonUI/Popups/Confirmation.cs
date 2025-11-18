
 










using UnityEngine.UI;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
{
    public class Confirmation : Popup
    {
        public Button yesButton;

        private void OnEnable()
        {
            yesButton.onClick.AddListener(Yes);
            closeButton.onClick.AddListener(No);
        }

        private void No()
        {
            result = EPopupResult.No;
            Close();
        }

        private void Yes()
        {
            result = EPopupResult.Yes;
            Close();
        }
    }
}