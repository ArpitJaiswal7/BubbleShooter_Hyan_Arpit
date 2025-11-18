
 










using com.kshkum.ShootGame.Scripts.CommonUI.Popups;
using UnityEngine;
using UnityEngine.UI;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Reward
{
    public class SpinOpenButton : MonoBehaviour
    {
        [SerializeField]
        private Button spinButton;

        [SerializeField]
        private GameObject freeSpinLabel;
        
        private void OnEnable()
        {
            spinButton.onClick.AddListener(OpenSpin);
            CheckFree();
        }

        private void CheckFree()
        {
            freeSpinLabel.SetActive(PlayerPrefs.GetInt("FreeSpin", 0) == 0);
        }

        private void OpenSpin()
        {
            MenuManager.instance.ShowPopup<LuckySpin>(null, (x) => CheckFree());
        }
    }
}