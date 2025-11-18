
 










using System;
using System.Linq;
using com.kshkum.ShootGame.Scripts.CommonUI.Popups;
using com.kshkum.ShootGame.Scripts.Settings;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Daily
{
    public class DailyBonus : PopupWithCurrencyLabel
    {
        
        // Array of handles representing each day
        [SerializeField]
        public DayHandle[] dayHandles;
        // Instance of the custom scriptable object that stores daily bonus settings
        private DailyBonusSettings settings;
        private int rewardStreak;

        // This method is automatically called when the script becomes enabled
        public void OnEnable()
        {
            return;
            // Load daily bonus settings
            settings = LoadSettings("Settings/DailyBonusSettings");

            // Update the reward streak count and store it
            rewardStreak = UpdateRewardStreak();

            // Update each day handle based on the current reward streak
            UpdateDayHandles(rewardStreak);
        }

        // Loads and returns daily bonus settings stored at the specified path
        public DailyBonusSettings LoadSettings(string path)
        {
            return Resources.Load<DailyBonusSettings>(path);
        }

        // Checks the last reward date and the current date 
        // to determine and update the reward streak
        public int UpdateRewardStreak()
        {
            DateTime today = DateTime.Today;
            DateTime lastRewardDate = DateTime.Parse(PlayerPrefs.GetString("DailyBonusDay", today.Subtract(TimeSpan.FromDays(1)).ToString()));

            if (today > lastRewardDate)
            {
                int rewardStreak = GetRewardStreak() + 1;
                PlayerPrefs.SetString("DailyBonusDay", today.ToString());
                PlayerPrefs.SetInt("RewardStreak", rewardStreak = (int)Mathf.Repeat(rewardStreak, dayHandles.Length));
                return rewardStreak;
            }

            return GetRewardStreak();
        }

        // Updates the status of each day handle in the scene 
        // according to the current reward streak
        public void UpdateDayHandles(int rewardStreak)
        {
            for (var i = 0; i < dayHandles.Length; i++)
            {
                var dayHandle = dayHandles[i];
                var coinsCount = settings.rewards[i].count;
                dayHandle.SetDay(i + 1, settings.rewards[i]);

                var status = i < rewardStreak ? EDailyStatus.passed : i == rewardStreak ? EDailyStatus.current : EDailyStatus.locked;
                dayHandle.SetStatus(status);
            }
        }

        // Gets and returns the reward streak count from player preferences 
        public int GetRewardStreak()
        {
            return PlayerPrefs.GetInt("RewardStreak", -1);
        }

        public override void Close()
        {
            dayHandles[rewardStreak].RewardData.resource.Add(dayHandles[rewardStreak].RewardData.count);
            var dayHandle = dayHandles.First(i=>i.DailyStatus == EDailyStatus.current);
            topPanel.AnimateCoins(dayHandle.transform.position,"+"+ dayHandle.RewardData.count, () => base.Close());
        }
    }
}