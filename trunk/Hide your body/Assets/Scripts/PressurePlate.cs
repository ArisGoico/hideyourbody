using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	public LayerMask mask 		= -1;
	public bool detecting		= true;
	
	public GameObject triggers;
	
	public enum Actions {Deactivate = 0, Activate = 1, Other = 2};
	public Actions actionIn		= Actions.Deactivate;
	public Actions actionOut 	= Actions.Activate;
	
	void Start() {
		if (triggers != null) {
			if (triggers.tag == "Camera") {
				//Its a camera
				if (triggers.GetComponentInChildren<PressurePlateCamera>() == null) {
					Debug.LogWarning("The pressure plate triggered Camera \"" + triggers.name + "\" has no PressurePlateCamera script. Turning off pressure plate.");
				}
				else {
					//Do something with the camera to initialize
				}
			}
			else if (triggers.tag == "Player") {
				//Its the player
				if (triggers.GetComponentInChildren<PressurePlatePlayer>() == null) {
					Debug.LogWarning("The pressure plate triggered Player \"" + triggers.name + "\" has no PressurePlatePlayer script. Turning off pressure plate.");
				}
				else {
					//Do something with the player to initialize
				}
			}
			else if (triggers.tag == "Guard") {
				//Its a camera
				if (triggers.GetComponentInChildren<PressurePlateGuard>() == null) {
					Debug.LogWarning("The pressure plate triggered Guard \"" + triggers.name + "\" has no PressurePlateGuard script. Turning off pressure plate.");
				}
				else {
					//Do something with the guard to initialize
				}
			}
		}
		else {
			detecting = false;
			Debug.LogWarning("The pressure plate " + this.gameObject.name + " has no trigger to activate. Turning off pressure plate.");
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (!detecting)
			return;
		int otherLayer = 1 << other.gameObject.layer; 
		if ((otherLayer & mask.value) > 0) {		//Detection in the correct layer
        	PressurePlateInterface script = null;
        	if (triggers.tag == "Camera") {
				//Its a camera
				script = triggers.GetComponentInChildren<PressurePlateCamera>();				
			}
			else if (triggers.tag == "Player") {
				//Its the player
				script = triggers.GetComponentInChildren<PressurePlatePlayer>();
			}
			else if (triggers.tag == "Guard") {
				//Its a camera
				script = triggers.GetComponentInChildren<PressurePlateGuard>();
			}
			
			if (script != null) {
				/*
				MAFIN - aqui estamos seguros de que se activa y que lo que le han puesto encima pasa por el filtro.
				*/
				switch (actionIn) {
					case Actions.Deactivate: 
						script.Deactivate();
						break;
					case Actions.Activate: 
						script.Activate();
						break;
					case Actions.Other:
						script.Other();
						break;
				}
			}        	
        }
    }
    
    void OnTriggerExit(Collider other) {
    	if (!detecting)
			return;
		int otherLayer = 1 << other.gameObject.layer; 
		if ((otherLayer & mask.value) > 0) {		//Detection in the correct layer
        	PressurePlateInterface script = null;
        	if (triggers.tag == "Camera") {
				//Its a camera
				script = triggers.GetComponentInChildren<PressurePlateCamera>();				
			}
			else if (triggers.tag == "Player") {
				//Its the player
				script = triggers.GetComponentInChildren<PressurePlatePlayer>();
			}
			else if (triggers.tag == "Guard") {
				//Its a camera
				script = triggers.GetComponentInChildren<PressurePlateGuard>();
			}
			
			if (script != null) {
				/*
				MAFIN - aqui estamos seguros de que se desactiva y que lo que le han puesto encima pasa por el filtro.
				*/
				switch (actionOut) {
					case Actions.Deactivate: 
						script.Deactivate();
						break;
					case Actions.Activate: 
						script.Activate();
						break;
					case Actions.Other:
						script.Other();
						break;
				}
			}        	
        }
    }
}
