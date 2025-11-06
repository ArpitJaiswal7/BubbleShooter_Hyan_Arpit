// // ©2015 - 2022 Candy Smith
 


// 


// // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE





using System;
using UnityEngine;

namespace BubbleShooterGameToolkit.TutorialInfo.Scripts
{
	public class Readme : ScriptableObject
	{
		public Texture2D icon;
		public string title;
		public Section[] sections;
		public bool loadedLayout;

		[Serializable]
		public class Section
		{
			public string heading, text, linkText, url;
		}
	}
}
