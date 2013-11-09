using UnityEngine;
using System.Collections;

public class PressurePlatePlayer : MonoBehaviour, PressurePlateInterface {

	
	void Start() {

	}
	
	public void Activate() {
		Debug.Log("Player " + this.gameObject.name + " received Activate() command from pressure plate.");
	}
	
	public void Deactivate() {
		Debug.Log("Player " + this.gameObject.name + " received Deactivate() command from pressure plate.");
	}
	
	public void Other() {
		Debug.Log("Player " + this.gameObject.name + " received Other() command from pressure plate.");
	}
}
