
 










using System.Collections;
using com.kshkum.ShootGame.Scripts.Enums;
using com.kshkum.ShootGame.Scripts.Gameplay.BubbleContainers;
using com.kshkum.ShootGame.Scripts.Gameplay.GUI;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.ExtraItems;
using com.kshkum.ShootGame.Scripts.System;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Managers
{
    /// control the moves and time of the game
    public class MovesTimeManager : SingletonBehaviour<MovesTimeManager>
    {
        private int moves;
        public ELevelMode levelLevelMode;

        public void Init(int initialMoves, ELevelMode levelLevelMode)
        {
            moves = initialMoves;
            GameUIManager.instance.UpdateMoves(moves);
            this.levelLevelMode = levelLevelMode;
            if (levelLevelMode == ELevelMode.Time)
            {
                BallContainerBase.OnBallLaunched -= SpendMove;
                EventManager.GetEvent<EStatus>(EGameEvent.Play).Subscribe((x) => StartTimer());
            }
        }

        private void StartTimer()
        {
            if (this != null)
                StartCoroutine(StartTimerCor());
        }

        private void OnEnable()
        {
            BallContainerBase.OnBallLaunched += SpendMove;
        }
        
        private void OnDisable()
        {
            BallContainerBase.OnBallLaunched -= SpendMove;
            if (levelLevelMode == ELevelMode.Time)
            {
                EventManager.GetEvent<EStatus>(EGameEvent.Play).Unsubscribe((x)=>StartTimer());
            }
        }

        private IEnumerator StartTimerCor()
        {
            while (EventManager.GameStatus == EStatus.Play)
            {
                yield return new WaitForSeconds(1);
                SpendMove(null);
            }
        }

        public int GetMoves() => moves;

        public void SpendMove(Ball ball)
        {
            if(ball is BombPowerup)
                return;
            moves--;
            if (moves <= 0)
            {
                moves = 0;
                if(levelLevelMode == ELevelMode.Time && !LevelManager.instance.LevelGridManager.AnyBallsAreGoingToDestroyOrFalling())
                {
                    Debug.Log("Game mode is time mode");
                    LevelManager.instance.CheckMovesAndTargetsAfterDestroy();
                }
            }
            GameUIManager.instance.UpdateMoves(moves);
        }
        
        // debug purpose
        public void SetMoveToOne()
        {
            moves = 1;
            GameUIManager.instance.UpdateMoves(moves);
        }
        public void SetMoves(int i)
        {
            moves = i;
            GameUIManager.instance.UpdateMoves(moves);
        }

        public void AddMoves(int additionalMoves)
        {
            moves += additionalMoves;
            GameUIManager.instance.UpdateMoves(moves);
        }
    }
}