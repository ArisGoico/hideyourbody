using UnityEngine;
using System.Collections;

public class PressurePlateGuard : MonoBehaviour, PressurePlateInterface {

	
	void Start() {
		
	}
	
	public void Activate() {
		Debug.Log("Guard " + this.gameObject.name + " received Activate() command from pressure plate.");
	}
	
	public void Deactivate() {
		Debug.Log("Guard " + this.gameObject.name + " received Deactivate() command from pressure plate.");
	}
	
	public void Other() {
		Debug.Log("Guard " + this.gameObject.name + " received Other() command from pressure plate.");
	}
}
