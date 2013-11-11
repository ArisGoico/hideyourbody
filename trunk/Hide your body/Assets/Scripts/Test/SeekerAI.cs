using UnityEngine;
using System.Collections;

public class SeekerAI : MonoBehaviour {
	
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<NavMeshAgent>().SetDestination(target.position);
	}
}
