
 










using BubbleShooterGameToolkit.Scripts.Enums;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.LevelSystem;
using UnityEngine;
using UnityEngine.Events;

namespace BubbleShooterGameToolkit.Scripts.Gameplay
{
    public class ObjectSwitcherGameMode : MonoBehaviour
    {
        public UnityEvent<bool> OnMovesMode;
        public UnityEvent<bool> OnTimeMode;
        private void OnEnable()
        {
            EventManager.GetEvent<Level>(EGameEvent.LevelLoaded).Subscribe(OnLevelLoaded);
        }
        
        private void OnDisable()
        {
            EventManager.GetEvent<Level>(EGameEvent.LevelLoaded).Unsubscribe(OnLevelLoaded);
        }

        private void OnLevelLoaded(Level level)
        {
            OnMovesMode?.Invoke(level.levelMode == ELevelMode.Moves);
            OnTimeMode?.Invoke(level.levelMode != ELevelMode.Moves);
        }
    }
}