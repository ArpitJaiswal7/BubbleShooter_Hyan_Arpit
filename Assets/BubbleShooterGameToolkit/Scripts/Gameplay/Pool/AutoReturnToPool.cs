
 










using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Pool
{
    public class AutoReturnToPool : MonoBehaviour
    {
        private void OnDisable()
        {
            PoolObject.Return(gameObject);
        }
    }
}