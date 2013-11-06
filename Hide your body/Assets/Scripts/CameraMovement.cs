using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	
	public float maxRotationLeft		= 0.0f;
	public float maxRotationRight		= 0.0f;
	public float rotationSpeed			= 1.0f;
	
	public bool moving					= true;
	
	private bool rotatingLeft			= false;
	private Quaternion rotationLeft;
	private Quaternion rotationRight;
	
	void Start() {
		rotationLeft = transform.localRotation * Quaternion.Euler(0,maxRotationLeft,0);
		rotationRight = transform.localRotation * Quaternion.Euler(0,maxRotationRight,0);
	}
	
	void Update () {
		if (!moving)
			return;
		if (rotatingLeft) {		//Rotating left
			this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, rotationLeft, rotationSpeed * Time.deltaTime);
		}
		else {
			this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, rotationRight, rotationSpeed * Time.deltaTime);
		}
		
		if (Quaternion.Angle(this.transform.localRotation, rotationLeft) < 0.5f && rotatingLeft)
			rotatingLeft = false;
		if (Quaternion.Angle(this.transform.localRotation, rotationRight) < 0.5f && !rotatingLeft)
			rotatingLeft = true;
	}
}
