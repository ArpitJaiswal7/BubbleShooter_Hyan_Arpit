
 










using com.kshkum.ShootGame.Scripts.CommonUI;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Services.GDPR
{
    public class GDPRPopupManager : MonoBehaviour
    {
        private void Awake()
        {
            Invoke(nameof(ShowGDPR), 2);
        }

        private void ShowGDPR()
        {
            if (PlayerPrefs.GetInt("npa", -1) == -1)
            {
                MenuManager.instance.ShowPopup<CommonUI.Popups.GDPR>();
            }
        }
    }
}