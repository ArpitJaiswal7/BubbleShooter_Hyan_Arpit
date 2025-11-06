
 










using BubbleShooterGameToolkit.Scripts.Settings;
using TMPro;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Daily
{
    public class DayHandle : MonoBehaviour
    {
        [SerializeField]
        private GameObject check;

        [SerializeField]
        private TextMeshProUGUI dayText;

        [SerializeField]
        private TextMeshProUGUI coinsCountText;
        
        [SerializeField]
        private Material lockedFontMaterial;
        
        [SerializeField]
        private GameObject sparklePrefab;
        public EDailyStatus DailyStatus { get; private set; }

        public RewardSetting RewardData { get; set; }

        public void SetDay(int day, RewardSetting rewardSetting)
        {
            dayText.text = "Day " + day.ToString();
            coinsCountText.text = rewardSetting.count.ToString();
            RewardData = rewardSetting;
        }
        
        public void SetStatus(EDailyStatus eDailyStatus)
        {
            DailyStatus = eDailyStatus;
            check.SetActive(eDailyStatus == EDailyStatus.passed);
            if(eDailyStatus == EDailyStatus.locked)
                coinsCountText.fontMaterial = lockedFontMaterial;
            else if(eDailyStatus == EDailyStatus.current)
                Instantiate(sparklePrefab, transform.position, Quaternion.identity, transform);
            coinsCountText.gameObject.SetActive(!check.activeSelf);
            var list = GetComponentsInChildren<DayToggle>();
            foreach (var dayToggle in list)
            {
                dayToggle.SetStatus(eDailyStatus);
            }
        }
    }
}