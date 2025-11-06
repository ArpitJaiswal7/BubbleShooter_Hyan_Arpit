
 










using BubbleShooterGameToolkit.Scripts.Enums;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.BubbleContainers
{
    [RequireComponent(typeof(BallContainerBase))]
    public class ColorUpdate : MonoBehaviour
    {
        private BallContainerBase ballContainer;

        private void OnEnable()
        {
            ballContainer = GetComponent<BallContainerBase>();
            // Subscribe to the event
            EventManager.GetEvent<int>(EGameEvent.ColorRemoved).Subscribe(OnColorRemoved);
        }

        private void OnDisable()
        {
            // Unsubscribe from the event
            EventManager.GetEvent<int>(EGameEvent.ColorRemoved).Unsubscribe(OnColorRemoved);
        }

        private void OnColorRemoved(int color)
        {
            if (EventManager.GameStatus != EStatus.Win && LevelManager.instance.LevelGridManager.AnyBallExists())
            {
                if (ballContainer.GetColor() == color)
                {
                    ballContainer.ChangeColor();
                }
            }
        }
    }
}