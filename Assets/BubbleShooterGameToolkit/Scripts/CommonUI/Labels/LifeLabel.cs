
 










using BubbleShooterGameToolkit.Scripts.System;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Labels
{
    public class LifeLabel : Label
    {
        private void OnEnable()
        {
            GameManager.instance.life.OnResourceUpdate += UpdateLabel;
            UpdateLabel(GameManager.instance.life.GetResource());
        }
        
        private void OnDisable()
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.life.OnResourceUpdate -= UpdateLabel;
            }
        }

        private void UpdateLabel(int count)
        {
            if (label != null)
            {
                label.text = "" + GameManager.instance.life.GetResource();
            }
        }
    }
}