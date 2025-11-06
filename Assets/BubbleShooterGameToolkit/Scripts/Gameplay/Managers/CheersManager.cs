
 










using System.Linq;
using BubbleShooterGameToolkit.Scripts.Gameplay.Pool;
using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Managers
{
    public class CheersManager : MonoBehaviour
    {
        private float lastCheersTime;
        private readonly int cheersCooldown = 10;

        private void OnEnable()
        {
            EventManager.GetEvent<int>(EGameEvent.BallsDestroyed).Subscribe(ShowCheers);
        }

        private void OnDisable()
        {
            EventManager.GetEvent<int>(EGameEvent.BallsDestroyed).Unsubscribe(ShowCheers);
        }

        private void Update()
        {
            lastCheersTime -= Time.deltaTime;
        }

        private void ShowCheers(int countToDestroy)
        {
            return;
            if (lastCheersTime > 0)
            {
                return;
            }
            
            lastCheersTime = cheersCooldown;
            
            //iterate in random order through all cheers
            foreach (var cheer in GameManager.instance.GameplaySettings.popupTextElements.OrderBy(x => Random.value))
            {
                if (cheer.MinValue <= countToDestroy && cheer.MaxValue >= countToDestroy)
                {
                    PoolObject.GetObject(cheer.popupTextPrefab.name);
                    break;
                }
            }
        }
    }
}