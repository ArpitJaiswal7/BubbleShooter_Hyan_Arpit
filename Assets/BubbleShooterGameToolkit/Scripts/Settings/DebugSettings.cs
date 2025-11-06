
 










using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Settings
{
    public class DebugSettings : SettingsBase
    {
        [Header("Editor shortcuts")] public bool enableShortcuts = true;
        [Header("press to win")] public KeyCode Win;
        [Header("press to lose")] public KeyCode Lose;
        [Header("set moves to 1")] public KeyCode OneMove;
        [Header("fill power up")] public KeyCode fillPowerUp;
        [Header("restart the level")] public KeyCode Restart;
    }
}