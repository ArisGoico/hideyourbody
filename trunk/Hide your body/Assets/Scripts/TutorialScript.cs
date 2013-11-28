using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {
	
	public Texture2D splashImage;
	private Rect splashPos;
	
	public Texture2D[] tutorial;
	private Rect[] tutorialPos;
	
	private Texture2D tutorialSplash;
	private Rect tutorialSplashPos;
	
	public float splashTime			= 0.0f;
	private float splashTimeReal;
	
	private bool showSplash			= false;
	
	void Start () {
		float left = Screen.width / 2.0f - splashImage.width / 2.0f;
		float up = Screen.height / 2.0f - splashImage.height / 2.0f;
		splashPos = new Rect(left, up, splashImage.width, splashImage.height);
		
		if (tutorial.Length > 0) {
			tutorialPos = new Rect[tutorial.Length];
			
			for (int i = 0; i < tutorial.Length; i++) {
				left = Screen.width / 2.0f - tutorial[i].width / 2.0f;
				up = Screen.height / 2.0f - tutorial[i].height / 2.0f;
				tutorialPos[i] = new Rect(left, up, tutorial[i].width, tutorial[i].height);
			}
		}
		showSplash = true;
		splashTimeReal = Time.time + splashTime;
		tutorialSplash = splashImage;
		tutorialSplashPos = splashPos;
		turnPauseOn();
	}
	
	void Update () {
		if (Time.realtimeSinceStartup >= splashTimeReal) {
			showSplash = false;
			turnPauseOff();
		}
		if (Input.anyKey) {
			splashTimeReal = Time.realtimeSinceStartup;
		}
	}
	
	void OnGUI() {
		if (showSplash) {
			splashGUI();
		}
	}
	
	private void splashGUI() {
		GUI.Label(tutorialSplashPos, tutorialSplash);
	}
	
	private void turnPauseOn() {
		Time.timeScale = 0.0f;
		(GameObject.FindGameObjectWithTag("Player")).GetComponent<MouseLook>().enabled = false;
		BloomAndLensFlares script = Camera.main.GetComponent<BloomAndLensFlares>();
		script.bloomThreshhold = 0.0f;
		script.bloomIntensity = 4.5f;
	}
	
	private void turnPauseOff() {
		(GameObject.FindGameObjectWithTag("Player")).GetComponent<MouseLook>().enabled = true;
		BloomAndLensFlares script = Camera.main.GetComponent<BloomAndLensFlares>();
		script.bloomThreshhold = 0.3f;
		script.bloomIntensity = 1.0f;
		Time.timeScale = 1.0f;
	}
	
	public void launchTutorial(int tutScreen, float time = 10.0f) {
		if (tutScreen < tutorial.Length && tutScreen >= 0) {
			tutorialSplash = tutorial[tutScreen];
			tutorialSplashPos = tutorialPos[tutScreen];
			splashTimeReal = Time.realtimeSinceStartup + time;
			showSplash = true;
		}
	}
}
