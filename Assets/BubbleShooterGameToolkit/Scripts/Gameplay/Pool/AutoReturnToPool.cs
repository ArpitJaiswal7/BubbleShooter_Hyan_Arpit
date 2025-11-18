
 










using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Pool
{
    public class AutoReturnToPool : MonoBehaviour
    {
        private void OnDisable()
        {
            PoolObject.Return(gameObject);
        }
    }
}