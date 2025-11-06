
 










using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects
{
    public class BallDestructionOptions
    {
        public bool falling;
        public Ball DestroyedBy { get; set; }
        public GameObject FXPrefab { get; set; }
        public AudioClip DestroySound { get; set; } = null;
        public bool NoScore { get; set; }
        public bool NoFX { get; set; }
        public bool NoSound { get; set; }
        public bool DisableScale { get; set; }
    }
}