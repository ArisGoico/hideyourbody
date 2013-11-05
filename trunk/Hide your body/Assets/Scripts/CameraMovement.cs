using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	
	public float maxRotationLeft		= 0.0f;
	public float maxRotationRight		= 0.0f;
	public float rotationSpeed			= 1.0f;
	
	private bool rotatingLeft			= false;
	private Quaternion rotationLeft;
	private Quaternion rotationRight;
	
	void Start() {
		float angleTemp = 0.0f;
		Vector3 axisTemp = Vector3.zero;
		this.transform.rotation.ToAngleAxis(out angleTemp, out axisTemp);
		rotationLeft =  Quaternion.AngleAxis(angleTemp + maxRotationLeft, axisTemp + Vector3.up);
		rotationRight = Quaternion.AngleAxis(angleTemp + maxRotationRight, axisTemp + Vector3.up);
		if (Quaternion.Angle(rotationLeft, rotationRight) < 0.5f)
			Debug.LogError("The 2 angles cannot be so similar in CameraMovement script!");
	}
	
	void Update () {
		if (rotatingLeft) {		//Rotating left
			this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotationLeft, rotationSpeed * Time.deltaTime);
		}
		else {
			this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotationRight, rotationSpeed * Time.deltaTime);
		}
		
		if (Quaternion.Angle(this.transform.rotation, rotationLeft) < 0.5f && rotatingLeft)
			rotatingLeft = false;
		if (Quaternion.Angle(this.transform.rotation, rotationRight) < 0.5f && !rotatingLeft)
			rotatingLeft = true;
	}
}
