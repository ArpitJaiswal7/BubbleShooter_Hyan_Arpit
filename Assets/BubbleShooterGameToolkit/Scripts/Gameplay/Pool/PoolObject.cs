
 










using System.Collections.Generic;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects;
using com.kshkum.ShootGame.Scripts.Gameplay.Targets;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Pool
{
    public class PoolObject : MonoBehaviour
    {
        protected static readonly Dictionary<string, PoolObject> pools = new();
        protected static readonly Dictionary<GameObject, PoolObject> prefabPools = new();
        
        public GameObject prefab;
        protected Queue<GameObject> pool = new();
        
        public virtual void Awake()
        {
            if (prefab != null) 
            {
                SetPrefab(prefab);
            }
        }
        
        public void SetPrefab(GameObject newPrefab)
        {
            pools[newPrefab.name] = this;
            prefabPools[newPrefab] = this;
            prefab = newPrefab;
        }
        
        private void OnDestroy()
        {
            pools.Clear();
            prefabPools.Clear();
        }
        
        protected GameObject Create() 
        {
            var item = Instantiate(prefab, transform);
            item.name = prefab.name;
            var targetable = item.GetComponent<Targetable>();
            if (targetable)
            {
                targetable.parent = transform;
            }
            return item;
        }
    
        private GameObject Get()
        {
            var item = pool.Count == 0 ? Create() : pool.Dequeue();
            if (item.activeSelf && pool.Count > 0)
            {
                item = pool.Dequeue();
            }
            Assert.IsFalse(LevelManager.instance.destroyManager != null && LevelManager.instance.destroyManager.ballsToDestroy.Contains(item.GetComponent<Ball>()), "BallCharged in ballsToDestroy");

            item.SetActive(true);
            return item;
        }

        public static void Return(GameObject item)
        {
            if (item == null) return;

            item.SetActive(false);
            if (pools.TryGetValue(item.name, out PoolObject pool))
            {
                pool.pool.Enqueue(item);
            }
        }
        
        public static GameObject GetObject(GameObject prefab)
        {
            if (prefabPools.TryGetValue(prefab, out PoolObject existingPool))
            {
                return existingPool.Get();
            }

            return GetPool(prefab);
        }

        private static GameObject GetPool(GameObject prefab)
        {
            string prefabName = prefab.name;
            if (pools.TryGetValue(prefabName, out PoolObject pool))
            {
                if (!prefabPools.ContainsKey(prefab))
                {
                    prefabPools[prefab] = pool;
                }
                return pool.Get();
            }

            var poolObject = new GameObject(prefabName).AddComponent<PoolObject>();
            poolObject.transform.SetParent(GameObject.Find("Pools").transform);
            poolObject.prefab = prefab;
            pools.Add(prefabName, poolObject);
            prefabPools.Add(prefab, poolObject);
            return poolObject.Get();
        }

        public static GameObject GetObject(string prefabName)
        {
            if (pools.TryGetValue(prefabName, out PoolObject pool))
            {
                return pool.Get();
            }

            var prefabRef = PrefabReferences.Instance;
            if (prefabRef != null)
            {
                GameObject prefab = null;
                
                if (prefabName == "Bouncing" && prefabRef.bouncing != null)
                    prefab = prefabRef.bouncing;
                else if (prefabName == "Carrot" && prefabRef.carrot != null)
                    prefab = prefabRef.carrot;
                else if (prefabName.StartsWith("Ball "))
                {
                    string colorIndexStr = prefabName.Substring(5);
                    if (int.TryParse(colorIndexStr, out int colorIndex))
                    {
                        prefab = prefabRef.GetColoredBall(colorIndex);
                    }
                }
                
                if (prefab != null)
                {
                    return GetObject(prefab);
                }
            }
            
            Debug.LogError($"Pool with name {prefabName} not found");
            return null;
        }
    }
}