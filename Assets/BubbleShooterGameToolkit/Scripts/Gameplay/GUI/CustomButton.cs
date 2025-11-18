
 










using System.Collections;
using com.kshkum.ShootGame.Scripts.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.kshkum.ShootGame.Scripts.Gameplay.GUI
{
    public class CustomButton : Button
    {
        private bool isClicked;
        private readonly float cooldownTime = 2f; // Cooldown time in seconds

        protected override void Awake()
        {
            base.Awake();
            transition = Transition.None;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (isClicked)
            {
                return;
            }

            isClicked = true;
            base.OnPointerClick(eventData);
            SoundBase.instance.PlaySound(SoundBase.instance.click);

            // Start cooldown
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(Cooldown());
            }
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(cooldownTime);
            isClicked = false;
        }
    }
}