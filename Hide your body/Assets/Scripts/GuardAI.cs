using UnityEngine;
using System.Collections;

public class GuardAI : MonoBehaviour {
	
	public Vector3[] waypoints;
	public int numCurrentWaypoint;
	public Vector3 currentWaypoint;	
	private NavMeshAgent agent;	
		
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		if(waypoints.Length > 0)
		{			
			currentWaypoint = waypoints[Random.Range(0,waypoints.Length)];
		}
	}
	
	void FixedUpdate () {
		if(waypoints.Length > 0)
		{			
			if(transform.position.x == currentWaypoint.x && transform.position.z == currentWaypoint.z)
			{
				numCurrentWaypoint = Random.Range(0,waypoints.Length);
				//Debug.Log("Pos nº:"+pos+" vector:"+waypoints[pos]);
				currentWaypoint = waypoints[numCurrentWaypoint];
			}
			agent.SetDestination(waypoints[numCurrentWaypoint]);
			//agent.SetDestination(currentWaypoint);
		}
	}
}