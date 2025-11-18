
 










using System.Collections;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
{
    public class Banner : Popup
    {
        public override void AfterShowAnimation()
        {
            base.AfterShowAnimation();
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.8f);
            Close();
        }
    }
}