
 










using com.kshkum.ShootGame.Scripts.Audio;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.CommonUI.Popups
{
	public class SoundParticle : MonoBehaviour {

		// Use this for initialization
		void Start () {
	
		}
	
		// Update is called once per frame
		public void Stop () {
			SoundBase.instance.GetComponent<AudioSource>().PlayOneShot( SoundBase.instance.swish[0] );
		}
		public void Hit()
		{
			SoundBase.instance.GetComponent<AudioSource>().PlayOneShot( SoundBase.instance.hit );
		}

	}
}
