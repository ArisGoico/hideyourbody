using UnityEngine;
using System.Collections;

public class CameraDetection : MonoBehaviour {
	
	public LayerMask mask 	= -1;
	public bool detecting	= true;
	
	void OnTriggerEnter(Collider other) {
		if (!detecting)
			return;
		int otherLayer = 1 << other.gameObject.layer; 
		if ((otherLayer & mask.value) > 0) {		//Player layer
        	Vector3 otherCenter = other.bounds.center;
        	Ray ray = new Ray(this.transform.position, (otherCenter - this.transform.position).normalized);
        	RaycastHit hitInfo;
        	if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity)) {
        		if (hitInfo.collider == other)
        			Debug.Log("Collider " + other.transform.name + " hit by the camera on enter.");
        	}
        	
        }
    }
    
    void OnTriggerExit(Collider other) {
    	if (!detecting)
			return;
    	int otherLayer = 1 << other.gameObject.layer; 
		if ((otherLayer & mask.value) > 0) {		//Player layer
        	Vector3 otherCenter = other.bounds.center;
        	Ray ray = new Ray(this.transform.position, (otherCenter - this.transform.position).normalized);
        	RaycastHit hitInfo;
        	if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity)) {
        		if (hitInfo.collider == other)
        			Debug.Log("Collider " + other.transform.name + " hit by the camera on exit.");
        	}        	
        }
    }
}
