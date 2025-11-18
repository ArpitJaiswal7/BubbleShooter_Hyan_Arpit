
 










using com.kshkum.ShootGame.Scripts.Enums;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.LevelSystem;
using UnityEngine;
using UnityEngine.Events;

namespace com.kshkum.ShootGame.Scripts.Gameplay
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