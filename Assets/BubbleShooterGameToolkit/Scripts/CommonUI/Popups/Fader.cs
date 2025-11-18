
 










using UnityEngine;
using UnityEngine.UI;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
{
    /// Fader class for fading the screen when a popup is shown
    public class Fader : MonoBehaviour
    {
        private Image fader;
        private bool fadeIn;
        private readonly float fadeTime = .5f;
        private float currentAlpha = 0f;
        public float minValue = 0;
        public float maxValue = .8f;

        private void Awake()
        {
            fader = GetComponent<Image>();
        }

        public bool IsFaded()
        {
            return currentAlpha >= maxValue;
        }

        public void FadeIn()
        {
            return;
            fadeIn = true;
            if (fader != null)
            {
                fader.gameObject.SetActive(true);
            }
        }

        public void FadeOut()
        {
            return;
            fadeIn = false;
        }
        
        void Update() {
            if (fadeIn) {
                currentAlpha += Time.deltaTime / fadeTime;
            } else {
                currentAlpha -= Time.deltaTime / fadeTime;
            }
            currentAlpha = Mathf.Clamp(currentAlpha, minValue, maxValue);
            fader.raycastTarget = currentAlpha > 0;
            fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, currentAlpha);
        }

        public void FadeAfterLoadingScene()
        {
            currentAlpha = 1f;
            FadeOut();
        }
    }
}