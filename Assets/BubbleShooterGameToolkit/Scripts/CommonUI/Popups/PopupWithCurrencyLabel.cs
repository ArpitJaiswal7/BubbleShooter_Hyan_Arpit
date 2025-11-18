
 










using com.kshkum.ShootGame.Scripts.Audio;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
{
    public class PopupWithCurrencyLabel : Popup
    {
        [SerializeField]
        private GameObject topPanelPrefab;
        protected TopPanel topPanel;

        protected override void Awake()
        {
            Assert.IsNotNull(topPanelPrefab, "top panel prefab is null");
            topPanel = Instantiate(topPanelPrefab, transform.parent).GetComponent<TopPanel>();
            topPanel.gameObject.SetActive(false);
            base.Awake();
        }

        public override void AfterShowAnimation()
        {
            topPanel.gameObject.SetActive(true);
            base.AfterShowAnimation();
        }

        public override void Close()
        {
            base.Close();
            Destroy(topPanel.gameObject);
        }

        protected void ShowCoinsSpendFX(Vector3 position)
        {
            SoundBase.instance.PlaySound(SoundBase.instance.coinsSpend);
            var fx = Instantiate(Resources.Load<GameObject>("FX/CoinsSpendFX"), position, Quaternion.identity, transform.parent);
            fx.transform.localScale = Vector3.one;
        }
    }
}