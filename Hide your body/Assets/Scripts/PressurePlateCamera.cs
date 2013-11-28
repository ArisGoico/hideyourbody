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
		/*
		MAFIN - aqui puedes aplicar los efectos que quieras para que la camara se muestre como activada esteticamente.
		*/
		this.GetComponentInChildren<Light>().enabled = true;
	}
	
	public void Deactivate() {
		detection.detecting = false;
		movement.moving = false;
		/*
		MAFIN - aqui puedes aplicar los efectos que quieras para que la camara se muestre como desactivada esteticamente.
		*/
		this.GetComponentInChildren<Light>().enabled = false;
	}
	
	public void Other() {
	
	}
}
