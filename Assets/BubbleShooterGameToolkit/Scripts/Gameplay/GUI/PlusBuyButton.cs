
 










using TMPro;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.GUI
{
    public class PlusBuyButton : CustomButton
    {
        public TextMeshProUGUI plusIcon;

        protected override void OnEnable()
        {
            base.OnEnable();
            plusIcon = GetComponentInChildren<TextMeshProUGUI>();
        }

        public override bool IsInteractable()
        {
            var isInteractable = base.IsInteractable();
            if (plusIcon != null)
            {
                plusIcon.color = isInteractable ? new Color(59f / 255f, 53f / 255f, 63f / 255f) : new Color(135f / 255f, 133f / 255f, 136f / 255f);
            }

            return isInteractable;
        }
    }
}