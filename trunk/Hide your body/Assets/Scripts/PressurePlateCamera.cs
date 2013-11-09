using UnityEngine;
using System.Collections;

public class PressurePlateCamera : MonoBehaviour, PressurePlateInterface {
	
	private CameraDetection detection;
	private CameraMovement movement;
	
	void Start() {
		detection = this.GetComponentInChildren<CameraDetection>();
		movement = this.GetComponentInChildren<CameraMovement>();
	}
	
	public void Activate() {
		detection.detecting = true;
		movement.moving = true;
	}
	
	public void Deactivate() {
		detection.detecting = false;
		movement.moving = false;
	}
	
	public void Other() {
	
	}
}
