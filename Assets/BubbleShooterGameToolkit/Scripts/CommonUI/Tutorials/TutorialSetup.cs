
 










using BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects;
using BubbleShooterGameToolkit.Scripts.Gameplay.Targets;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Tutorials
{
    [CreateAssetMenu(fileName = "Tutorial", menuName = "BubbleShooterGameToolkit/Add Tutorial", order = 1)]
    public class TutorialSetup : ScriptableObject
    {
        public TargetScriptable target;
        public Ball launchBall;
        public string text;
        public bool highlightTarget = true;
    }
}