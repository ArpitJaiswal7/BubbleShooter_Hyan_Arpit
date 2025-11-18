
 










using System.Collections.Generic;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Pool
{
    class BabyTargetPool : PoolObject
    {
        public override void Awake()
        {
            base.Awake();
            InvokeRepeating("OrderBaby", 0.5f, 0.5f);
        }

        /// <summary>
        /// Order baby in transform hierarchy by Y position
        /// </summary>
        private void OrderBaby()
        {
            if (transform.childCount == 0)
                return;
            var children = new List<Transform>();
            foreach (Transform child in transform)
            {
                children.Add(child);
            }

            children.Sort((t1, t2) => t2.position.y.CompareTo(t1.position.y));
            for (int i = 0; i < children.Count; i++)
            {
                children[i].SetSiblingIndex(i);
            }
        }
    }
}