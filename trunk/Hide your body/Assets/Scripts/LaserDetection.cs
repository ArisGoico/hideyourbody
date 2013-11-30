using UnityEngine;
using System.Collections;

public class LaserDetection : MonoBehaviour {
	
	private LaserCreation laserCreation;
	// Use this for initialization
	void Start () {
		laserCreation = GetComponent<LaserCreation>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int playerLayer = LayerMask.NameToLayer("Player"); 		
		Ray ray = new Ray(laserCreation.laserStartPoint,laserCreation.laserEndPoint);
		RaycastHit hit;		
		if(Physics.Raycast(ray, out hit, 1000)) 
		{
        	if(hit.collider.gameObject.layer == playerLayer)
			{
				Debug.Log("Player detected by laser");
				GameObject.Find("Player").GetComponent<GlobalLogic>().playerDetected();
			}
        }
	}
}
