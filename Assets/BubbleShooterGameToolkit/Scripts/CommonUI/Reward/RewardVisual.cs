
 










using TMPro;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Reward
{
    public class RewardVisual : MonoBehaviour
    {
        public TextMeshProUGUI countText;
        
        public void SetCount(int count)
        {
            countText.text = count.ToString();
        }
    }
}