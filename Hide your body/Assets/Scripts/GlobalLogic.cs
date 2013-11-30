using UnityEngine;
using System.Collections;

public class GlobalLogic : MonoBehaviour {
	
	public Vector3 startPoint;
	private bool alarm;
	
	// Use this for initialization
	void Start () {
		alarm = false;
		transform.position = startPoint;
		GetComponent<CharacterMotor>().canControl = true;			
	}
	
	// Update is called once per frame
	void Update () {
		if(alarm)
		{
			//LUZ AMBIENTAL EN ROJO
			//SONIDO DE ALARMA
			if(Input.GetMouseButtonDown(0))
				resetLevel();
		}
	}
	
	public void levelCompleted()
	{
		Debug.Log("Level completed");
		//CAMBIAR A SIGUIENTE NIVEL
	}
	
	public void playerDetected()
	{
		Debug.Log("Player detected: Game Over. Press mouse left button to restart level.");
		GetComponent<CharacterMotor>().canControl = false;
		alarm = true;		
	}
	
	public void resetLevel()
	{
		alarm = false;
		transform.position = startPoint;
		GetComponent<CharacterMotor>().canControl = true;		
	}
}
