
 










using System.Collections.Generic;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects;
using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Targets
{
    public class TargetManager : SingletonBehaviour<TargetManager>
    {
        public List<TargetObjectController> _targetObjectControllers = new List<TargetObjectController>();

        void Start()
        {
            SetupEventListeners();
        }

        private void OnDisable()
        {
            RemoveEventListeners();
        }

        void SetupEventListeners()
        {
            EventManager.GetEvent<BallCollectEventArgs>(EGameEvent.ItemDestroyed).Subscribe(OnCount);
            EventManager.GetEvent<BallCollectEventArgs>(EGameEvent.Uncover).Subscribe(OnCount);
            EventManager.GetEvent<BallCollectEventArgs>(EGameEvent.Fall).Subscribe(OnCount);
            EventManager.GetEvent<BallCollectEventArgs>(EGameEvent.StarActivated).Subscribe(OnCount);
        }

        void RemoveEventListeners()
        {
            EventManager.GetEvent<BallCollectEventArgs>(EGameEvent.ItemDestroyed).Unsubscribe(OnCount);
            EventManager.GetEvent<BallCollectEventArgs>(EGameEvent.Uncover).Unsubscribe(OnCount);
            EventManager.GetEvent<BallCollectEventArgs>(EGameEvent.Fall).Unsubscribe(OnCount);
            EventManager.GetEvent<BallCollectEventArgs>(EGameEvent.StarActivated).Unsubscribe(OnCount);
        }
        
        private void OnCount(BallCollectEventArgs collectEventArgs)
        {
            foreach (var targetObject in _targetObjectControllers)
            {
                targetObject.OnCount(collectEventArgs);
            }
        }

        public bool IsTarget(Targetable ball)
        {
            bool isTarget = false;
            foreach (var targetObject in _targetObjectControllers)
            {
                if (targetObject.IsTarget(ball))
                {
                    isTarget = true;
                    break;
                }
            }
            return isTarget;
        }

        public bool IsTargetsDone()
        {
            Debug.Log("Checking if target is achieved ot not");
            // Check if all targets are done
            foreach (var targetObject in _targetObjectControllers)
            {
                if (!targetObject.IsDone())
                {
                    Debug.Log("targetObject is not done");
                    return false;
                }
                if (targetObject.GetModel().target.name == "Stars")
                {
                    Debug.Log("model name != stars");
                    if (_targetObjectControllers.Count == 1 && targetObject.IsDone() && MovesTimeManager.instance.GetMoves() > 0 && LevelManager.instance.LevelGridManager.AnyBallExists())
                    {
                        Debug.Log("Target is not completed");
                        return false;
                    }
                }
            }
            Debug.Log("target Done");
            return true;
        }

        public int GetTargetCount(string targetName)
        {
            int count = 0;
            foreach (var targetObject in _targetObjectControllers)
            {
                if (targetObject.GetModel().target.name == targetName)
                {
                    count = targetObject.GetModel().Count;
                    break;
                }
            }
            return count;
        }
    }
}