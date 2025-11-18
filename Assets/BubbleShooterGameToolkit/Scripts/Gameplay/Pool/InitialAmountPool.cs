
 










using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Pool
{
    class InitialAmountPool : PoolObject
    {
        [SerializeField] private int initialCapacity;

        public override void Awake()
        {
            base.Awake();
            for (int i = 0; i < initialCapacity; i++)
            {
                var item = Create();
                item.SetActive(false);
                pool.Enqueue(item);
            }
        }
    }
}