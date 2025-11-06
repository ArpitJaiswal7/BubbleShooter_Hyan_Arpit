
 










using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleShooterGameToolkit.Scripts.CommonUI.Labels
{
	public class Label : MonoBehaviour
	{
		public Image icon;
		public TextMeshProUGUI label;
		void Awake()
		{
			if(label == null)
				label = GetComponent<TextMeshProUGUI>();
		}
	}
}
