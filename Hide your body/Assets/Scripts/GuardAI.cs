using UnityEngine;
using System.Collections;

public class GuardAI : MonoBehaviour {
	
	public Vector3[] wayPoints;
	public Vector3 actualWayPoint;
	private NavMeshAgent agent;	
		
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		if(wayPoints.Length > 0)
		{			
			actualWayPoint = wayPoints[Random.Range(0,wayPoints.Length)];
		}
	}
	
	void FixedUpdate () {
		if(transform.position.x == actualWayPoint.x && transform.position.z == actualWayPoint.z)
		{
			int pos = Random.Range(0,wayPoints.Length);
			//Debug.Log("Pos nº:"+pos+" vector:"+wayPoints[pos]);
			actualWayPoint = wayPoints[pos];
		}
		agent.SetDestination(actualWayPoint);
	}
}
