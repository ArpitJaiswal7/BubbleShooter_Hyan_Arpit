
 










using BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects.Properties;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Targets
{
    public abstract class Targetable: MonoBehaviour
    {
        private int targetIndex; // index of target for this ball

        [SerializeField]
        public AudioProperties audioProperties;

        [Header("Will be taken from pool")]
        [SerializeField]
        public GameObject fxPrefab;

        [HideInInspector] public Transform parent; // saved parent for returning after launch, made to move ball with camera

        public int GetTargetIndex()
        {
            if (targetIndex == 0)
                targetIndex = name.GetHashCode();
            return targetIndex;
        }

        public virtual void OnEnable()
        {
        }

        public void RestoreParent()
        {
            transform.SetParent(parent);
        }
    }
}