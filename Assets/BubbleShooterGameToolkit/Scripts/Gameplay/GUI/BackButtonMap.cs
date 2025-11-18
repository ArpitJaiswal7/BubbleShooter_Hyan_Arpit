
 










using com.kshkum.ShootGame.Scripts.System;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.GUI
{
    public class BackButtonMap : CustomButton
    {
        protected override void Start()
        {
            base.Start();
            onClick.RemoveListener(OnButtonClick);
            onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            SceneLoader.instance.GoMain();
        }
    }
}