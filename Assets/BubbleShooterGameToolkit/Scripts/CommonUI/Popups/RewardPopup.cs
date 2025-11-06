
 










using BubbleShooterGameToolkit.Scripts.Audio;
using BubbleShooterGameToolkit.Scripts.Data;
using BubbleShooterGameToolkit.Scripts.Settings;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Popups
{
	public class RewardPopup : PopupWithCurrencyLabel {
		public Transform iconPos;
		private int _count;
		private ResourceObject _resource;
		private RewardSettingSpin rewardVisual;

		public override void ShowAnimationSound()
		{
			base.ShowAnimationSound();
			SoundBase.instance.PlaySound(SoundBase.instance.cheers);
		}

		public void SetReward(RewardSettingSpin rewardVisual)
		{
			this.rewardVisual = rewardVisual;
			var rewardObject = Instantiate(rewardVisual.rewardVisualPrefab, iconPos);
			rewardObject.transform.localPosition = Vector3.zero;
			rewardObject.transform.localRotation = Quaternion.identity;
			rewardObject.SetCount(rewardVisual.count);
			_count = rewardVisual.count;
			_resource = rewardVisual.resource;
		}
		
		public override void Close()
		{
			rewardVisual.resource.Add(rewardVisual.count);
			if(_resource.GetType() == typeof(Coins))
				topPanel.AnimateCoins(iconPos.position, "+"+_count, () => base.Close());
			else if(_resource.GetType() == typeof(Life))
				topPanel.AnimateLife(iconPos.position, "", () => base.Close());
			else
				base.Close();
		}

		
	}
}
