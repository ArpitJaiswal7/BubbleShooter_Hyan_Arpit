
 










namespace BubbleShooterGameToolkit.Scripts.Gameplay.Targets
{
    class StarsTargetScriptable : TargetScriptable
    {
        public override bool IsDone(int count)
        {
            return count <= 0;
        }
    }
}