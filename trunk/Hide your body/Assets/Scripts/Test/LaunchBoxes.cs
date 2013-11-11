using UnityEngine;
using System.Collections;

public class LaunchBoxes : MonoBehaviour {
	
	public GameObject box;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("Fire1"))
		{
			/*Transform pos = transform;
			pos.Translate(Vector3.forward,Space.Self);*/
			//Vector3 pos2 = new Vector3(transform.position.x,transform.position.y,transform.position.z);
			GameObject newBox = Instantiate(box,transform.position,transform.rotation) as GameObject;
			newBox.transform.Translate(Vector3.forward,Space.Self);
			
		}
	}
}
