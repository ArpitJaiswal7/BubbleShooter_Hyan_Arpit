
 










using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Targets
{
    public class TargetObjectUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countUI;
        [SerializeField] private GameObject check;
        [SerializeField] private GameObject fail;
        public Image image;

        public void UpdateTarget(int count, bool isDone, int getMoves)
        {
            if (countUI != null)
            {
                countUI.text = count.ToString();
            }

            if (check != null)
            {
                check.SetActive(isDone);
                if (fail != null)
                {
                    fail.SetActive(!isDone && getMoves <= 0);
                }
                countUI.gameObject.SetActive(!isDone && getMoves > 0 || !check.activeSelf);
            }
        }
    }
}