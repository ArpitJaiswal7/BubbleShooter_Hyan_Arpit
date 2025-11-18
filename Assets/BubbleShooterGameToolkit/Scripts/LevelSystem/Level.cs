
 










using System;
using System.Collections.Generic;
using System.Linq;
using com.kshkum.ShootGame.Scripts.CommonUI.Tutorials;
using com.kshkum.ShootGame.Scripts.Enums;
using com.kshkum.ShootGame.Scripts.Gameplay.Targets;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.LevelSystem
{
    /// basic level object
    [CreateAssetMenu(fileName = "Level", menuName = "com.kshkum.ShootGame/Level", order = 1)]
    public class Level : ScriptableObject
    {
        // [Header("Moves")] 
        public int moves = 20;

        // [Header("Score amount to reach a star rating")]
        public int[] stars = new int[3] { 1000, 2000, 3000 };
        
        // [Header("Level type")]
        public ELevelTypes levelType = ELevelTypes.Vertical;
        
        public ELevelMode levelMode = ELevelMode.Moves;

        [Header("Level targets to complete the level")]
        public List<Target> targets;

        // [Header("Holes on the ground give extra points")]
        public bool holes = true;

        [HideInInspector] public ELevelTypes levelTypeSave;

        public int sizeX = 10;

        public int sizeY = 20;

        [SerializeField]
        public List<LevelItem> Blocks = new();
        [HideInInspector]
        public List<int> targetsIndeces;
        
        public TutorialSetup tutorial;

        public Sprite background;
        public bool[] randomBallColors = { true, true, true, true, false, false };
        
        public int Number => GetLevelNum();

        public void Clear()
        {
            Blocks.Clear();
            sizeX = 10;
            sizeY = 20;
            for (int i = 0; i < sizeY*sizeX; i++)
            {
                Blocks.Add(new LevelItem());
            }
        }

        public bool IsEmpty() => Blocks.Count == 0 || Blocks[0] == null;

        public int Length => Blocks.Count;

      

        public void Resize(int newSize)
        {
            if (newSize < Blocks.Count)
            {
                Blocks.RemoveRange(newSize, Blocks.Count - newSize);
            }
            else while (Blocks.Count < newSize)
            {
                Blocks.Add(new LevelItem());
            }
            if(sizeX < 10)
                sizeX = 10;
            if(sizeY < 1)
                sizeY = 1;
        }

        private int GetLevelNum()
        {
            string levelName = name;
            string numericPart = new string(levelName.Where(char.IsDigit).ToArray());

            if (int.TryParse(numericPart, out int levelNum))
            {
                return levelNum;
            }
            else
            {
                Debug.LogError("Unable to parse the numeric part from the level name.");
                return -1;
            }
        }

    }
}