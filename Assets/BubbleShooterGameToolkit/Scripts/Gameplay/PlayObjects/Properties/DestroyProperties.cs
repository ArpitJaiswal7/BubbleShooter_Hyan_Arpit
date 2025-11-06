
 










using System;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects.Properties
{
    [Serializable]
    public class DestroyProperties
    {
        [Header("Destroy by neighbour explosions")]
        public bool destroyByExplosion = true;

        [Header("Destroy by touch of launching ball")]
        public bool destroyByTouch;
        
        [Header("Destroy instead of falling")]
        public bool destroyOnFall;
    }
}