
 










using System.Collections.Generic;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Gameplay.Pool;
using BubbleShooterGameToolkit.Scripts.System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.FieldObjects
{
    public class BouncingManager : SingletonBehaviour<BouncingManager> 
    {
        readonly List<Bouncing> bouncings = new();
        public void AddBouncing()
        {
            var maxCount = GameManager.instance.GameplaySettings.bouncingCount;
            if (bouncings.Count >= maxCount) return;
            
            Bouncing bouncing;
            var prefabRef = PrefabReferences.Instance;
            if (prefabRef != null && prefabRef.bouncing != null)
            {
                bouncing = PoolObject.GetObject(prefabRef.bouncing).GetComponent<Bouncing>();
            }
            else
            {
                bouncing = PoolObject.GetObject("Bouncing").GetComponent<Bouncing>();
            }
            
            bouncings.Add(bouncing);
            float startingX = Random.Range(0, 2) == 0 ? -10f : 10f;
            float startingY = Random.Range(-6f, -3f);
            bouncing.transform.SetParent(GameCamera.instance.transform);
            bouncing.transform.localPosition = new Vector3(startingX, startingY, 0);
            bouncing.Begin();
        }
        
        public void RemoveBouncing()
        {
            if (bouncings.Count > 0)
            {
                var index = UnityEngine.Random.Range(0, bouncings.Count);
                var bouncing = bouncings[index];
                bouncings.RemoveAt(index);
                bouncing.Remove();
            }
        }
    }
}