using UnityEngine;
using System.Collections;

public class LaserCreation : MonoBehaviour {

	// Use this for initialization
	public Vector3 laserStartPoint;
	public Vector3 laserEndPoint;
	
	void Start () {
		
		Ray ray = new Ray(transform.parent.position,transform.parent.TransformDirection(Vector3.forward));
		RaycastHit hit;		
		if(Physics.Raycast(ray, out hit, 1000)) 
		{
        	laserStartPoint = transform.parent.position;
			GetComponent<LineRenderer>().SetPosition(0,transform.InverseTransformPoint(laserStartPoint));
			laserEndPoint = hit.point;
			GetComponent<LineRenderer>().SetPosition(1,transform.InverseTransformPoint(laserEndPoint));
        }				
		else
		{
			GetComponent<LineRenderer>().SetVertexCount(0);
		}		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
