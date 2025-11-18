
 










using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects;
using com.kshkum.ShootGame.Scripts.Gameplay.Targets;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Tutorials
{
    [CreateAssetMenu(fileName = "Tutorial", menuName = "com.kshkum.ShootGame/Add Tutorial", order = 1)]
    public class TutorialSetup : ScriptableObject
    {
        public TargetScriptable target;
        public Ball launchBall;
        public string text;
        public bool highlightTarget = true;
    }
}