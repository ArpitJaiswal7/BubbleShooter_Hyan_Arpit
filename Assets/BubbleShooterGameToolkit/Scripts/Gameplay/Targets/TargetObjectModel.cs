
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using System.Diagnostics;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Targets
{
    public class TargetObjectModel
    {
        private int count;
        private readonly bool countFromField;
        public readonly int targetIndex;
        private LevelManager levelManager;
        public readonly TargetScriptable target;
        public int Count => count;

        public TargetObjectModel(Target targetBind, int _count, int index, LevelManager levelManager)
        {
            this.levelManager = levelManager;
            this.target = targetBind.target;
            this.countFromField = targetBind.target.countFromField;
            this.targetIndex = index;
            this.count = countFromField ? CountFromField() : _count;
        }

        private int CountFromField()
        {
            Debug.WriteLine("countFromField()");
            int totalCount = 0;

            // Assuming levelManager.balls is of type List<List<Ball>>
            foreach (var ballList in levelManager.balls)
            {
                foreach (var ball in ballList)
                {
                    if (ball != null)
                    {
                        if (ball.IsTarget(targetIndex))
                        {
                            totalCount++;
                            Debug.WriteLine("total ball targets: " + totalCount);
                        }
                        
                    }
                }
            }

            return totalCount;
        }
        
        public void OnCount()
        {
            count--;
            if (count < 0)
                count = 0;
        }

        public bool IsDone() => target.IsDone(count);
    }
}