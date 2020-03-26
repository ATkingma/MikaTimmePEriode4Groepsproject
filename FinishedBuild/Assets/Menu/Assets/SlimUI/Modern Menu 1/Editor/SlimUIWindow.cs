using UnityEngine;
using UnityEditor;

public class SlimUIWindow1 : EditorWindow {

	//string myString = "Hello";

	[MenuItem("Window/SlimUI Online Documentation")]
	public static void ShowWindow(){
		Application.OpenURL("https://www.slimui.com/documentation");
	}
}
