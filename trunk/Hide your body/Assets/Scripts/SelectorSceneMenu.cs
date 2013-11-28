using UnityEngine;
using System.Collections;

public class SelectorSceneMenu : MonoBehaviour {

	
	
	void OnGUI() {
		GUI.skin.button.fontSize = 64;
		GUI.skin.button.fontStyle = FontStyle.Italic;
		if (GUI.Button(new Rect(5.0f, 5.0f, Screen.width / 3.0f - 10.0f, Screen.height - 10.0f), "1")) {
			Application.LoadLevel("mainScene");
		}
		if (GUI.Button(new Rect(Screen.width / 3.0f + 5.0f, 5.0f, Screen.width / 3.0f - 10.0f, Screen.height - 10.0f), "2")) {
			Application.LoadLevel("NivelAris");
		}
		if (GUI.Button(new Rect(2 * (Screen.width / 3.0f) + 5.0f, 5.0f, Screen.width / 3.0f - 10.0f, Screen.height - 10.0f), "3")) {
		
		}
	}
}
