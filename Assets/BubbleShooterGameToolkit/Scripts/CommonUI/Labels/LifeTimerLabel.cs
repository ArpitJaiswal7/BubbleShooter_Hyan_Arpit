
 










using BubbleShooterGameToolkit.Scripts.Data;
using BubbleShooterGameToolkit.Scripts.Settings;
using BubbleShooterGameToolkit.Scripts.System;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Labels
{
    public class LifeTimerLabel : Label
    {
        private Life lifeResource;
        private GameSettings gameSettings;

        private void OnEnable()
        {
            lifeResource = GameManager.instance.life;
            gameSettings = GameManager.instance.GameSettings;
            LifeRefillTimer.OnUpdateTime += UpdateLabel;
        }
        
        private void OnDisable()
        {
            LifeRefillTimer.OnUpdateTime -= UpdateLabel;
        }

        private void UpdateLabel(float time)
        {
            var hours = (int) (time / 3600);
            var minutes = (int) ((time - hours * 3600) / 60);
            var seconds = (int) (time - hours * 3600 - minutes * 60);
            label.text = lifeResource.GetResource() >= gameSettings.MaxLife ? "FULL" : $"{minutes:00}:{seconds:00}";
        }
    }
}