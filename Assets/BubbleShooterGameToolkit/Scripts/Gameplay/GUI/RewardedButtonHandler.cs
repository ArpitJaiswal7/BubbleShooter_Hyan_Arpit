
 










using BubbleShooterGameToolkit.Scripts.Ads.AdUnits;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.GUI
{
    public class RewardedButtonHandler : MonoBehaviour
    {
        [SerializeField]
        private AdReference adReference;
        [SerializeField]
        private Button rewardedButton;

        [SerializeField]
        private UnityEvent onRewardedAdComplete;

        private void Awake()
        {
            rewardedButton.onClick.AddListener(ShowRewardedAd);
        }

        private void OnEnable()
        {
            CheckActivation();
        }

        private void CheckActivation()
        {
            rewardedButton.gameObject.SetActive(AdsManager.instance.IsRewardedAvailable(adReference));
        }

        private void ShowRewardedAd()
        {
            AdsManager.instance.ShowAdByType(adReference, _ => onRewardedAdComplete?.Invoke());
            CheckActivation();
        }
    }
}