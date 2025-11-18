
 










using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Pool
{
    [CreateAssetMenu(fileName = "PrefabReferences", menuName = "Bubble Shooter/Prefab References")]
    public class PrefabReferences : ScriptableObject
    {
        [Header("Game Objects")]
        public GameObject bouncing;

        [Header("Balls")]
        public GameObject[] coloredBalls;
        public GameObject randomBall;
        public GameObject carrot;
        public GameObject emptyBall;
        
        private static PrefabReferences _instance;
        public static PrefabReferences Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<PrefabReferences>("Settings/PrefabReferences");
                    if (_instance == null)
                    {
                        Debug.LogError("PrefabReferences not found in Resources folder!");
                    }
                }
                return _instance;
            }
        }

        public GameObject GetColoredBall(int colorIndex)
        {
            if (coloredBalls == null || colorIndex < 0 || colorIndex >= coloredBalls.Length)
            {
                Debug.LogError($"Invalid color index: {colorIndex}");
                return null;
            }
            return coloredBalls[colorIndex];
        }
    }
}