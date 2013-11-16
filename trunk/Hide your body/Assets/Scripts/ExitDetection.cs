using UnityEngine;
using System.Collections;

public class ExitDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void OnTriggerEnter(Collider other) 
	{
		int playerLayer = LayerMask.NameToLayer("Player"); 
		if (playerLayer == other.gameObject.layer) 
		{
			other.gameObject.GetComponent<GlobalLogic>().levelCompleted();
		}
	}
}
