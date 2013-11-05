using UnityEngine;
using System.Collections;

public class CameraDetection : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 8)		//Player layer
        	Debug.Log("Collider " + other.transform.name + " entered the camera.");
    }
    
    void OnTriggerExit(Collider other) {
    	if (other.gameObject.layer == 8)		//Player layer
        	Debug.Log("Collider " + other.transform.name + " exited the camera.");
    }
}
