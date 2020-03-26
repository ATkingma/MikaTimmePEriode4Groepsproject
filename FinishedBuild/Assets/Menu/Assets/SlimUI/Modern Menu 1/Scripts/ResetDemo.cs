using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimUI.ModernMenu{
	public class ResetDemo1 : MonoBehaviour {

		void Update () {
			if(Input.GetKeyDown("r")){
				SceneManager.LoadScene(0);
			}
		}
	}
}