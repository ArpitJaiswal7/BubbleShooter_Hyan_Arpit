
 










using UnityEngine;
using UnityEngine.UI;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Daily
{
    public class DayToggle : MonoBehaviour
    {
        [SerializeField]
        public Material grayscaleMaterial;

        [SerializeField]
        private Sprite passed;

        [SerializeField]
        private Sprite current;

        private Material defaultMaterial;
        public Image imageComponent;

        private void Awake()
        {
            imageComponent = GetComponent<Image>();
            defaultMaterial = imageComponent.material; 
        }

        public void SetStatus(EDailyStatus eDailyStatus)
        {
            imageComponent.material = eDailyStatus == EDailyStatus.locked ? grayscaleMaterial : defaultMaterial;var imageComponentSprite = eDailyStatus == EDailyStatus.current ? current : passed;
            if (imageComponentSprite != null)
            {
                imageComponent.sprite = imageComponentSprite;
            }
        }
    }

    public enum EDailyStatus
    {
        locked,
        passed,
        current
    }
}