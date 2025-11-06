
 










using System;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Targets
{
    [CreateAssetMenu(fileName = "target", menuName = "BubbleShooterGameToolkit/Add target", order = 1)]
    public class TargetScriptable : ScriptableObject
    {
        public bool countFromField;
        public string textForMenu;
        public GameObject prefab;
        public GameObject prefabAnimation;
        public Sprite uiIcon;
        public int defaultCount = 10;

        public virtual bool IsDone(int count)
        {
            return count <= 0;
        }
    }

    [Serializable]
    public class Target
    {
        public TargetScriptable target;
        public int count;
    }
 
}