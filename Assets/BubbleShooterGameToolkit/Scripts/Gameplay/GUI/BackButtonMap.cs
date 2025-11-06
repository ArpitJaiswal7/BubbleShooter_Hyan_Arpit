
 










using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.GUI
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