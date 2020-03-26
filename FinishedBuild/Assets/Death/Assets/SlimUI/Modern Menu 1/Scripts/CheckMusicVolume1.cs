using UnityEngine;
using System.Collections;

namespace SlimUI.ModernMenu{
	public class CheckMusicVolume1 : MonoBehaviour {
		public void  Start (){
			// remember volume level from last time
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
		}

		public void UpdateVolume (){
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
		}
	}
}