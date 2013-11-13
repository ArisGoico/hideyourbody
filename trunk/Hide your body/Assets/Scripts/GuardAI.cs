using UnityEngine;
using System.Collections;

public class GuardAI : MonoBehaviour {
	public Vector3[] waypoints;
	public Vector3 currentWaypoint;	
	public int numCurrentWaypoint;	
	public bool[] watchPoints;
	private NavMeshAgent agent;	
	private bool stop = false;
	private float watchTime = 5.5f;
	private float currentWatchTime = 0.0f;
	private CameraMovement cameraMovement;
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		cameraMovement = this.transform.GetChild(0).GetComponent<CameraMovement>();
		cameraMovement.desactiveCamera();
		if(waypoints.Length > 0)
		{			
			//int newNumCurrentWaypoint;
			//do{newNumCurrentWaypoint = Random.Range(0,waypoints.Length);}while(newNumCurrentWaypoint == numCurrentWaypoint);		
			//numCurrentWaypoint = newNumCurrentWaypoint;
			numCurrentWaypoint++;
			numCurrentWaypoint %= waypoints.Length;
			currentWaypoint = waypoints[numCurrentWaypoint];		
			agent.SetDestination(currentWaypoint);
		}	
		cameraMovement.changeRotationSpeed(50);
		if(waypoints.Length != watchPoints.Length)
			watchPoints = new bool[waypoints.Length];
	}
	
	void FixedUpdate () {
		if(waypoints.Length > 0)
		{			
			if(!stop)
			{
				if(transform.position.x == currentWaypoint.x && transform.position.z == currentWaypoint.z)
				{
					if(watchPoints[numCurrentWaypoint])
					{
						stop = true;
						agent.Stop();
						cameraMovement.activeCamera();					
						currentWatchTime = Time.time;
					}
					else
					{
						numCurrentWaypoint++;
						numCurrentWaypoint %= waypoints.Length;
						currentWaypoint = waypoints[numCurrentWaypoint];		
						agent.SetDestination(currentWaypoint);
					}
					
					
				}
				//agent.SetDestination(waypoints[numCurrentWaypoint]);
				//agent.SetDestination(currentWaypoint);
			}
			else
			{
				if(currentWatchTime + watchTime < Time.time)
				{
					stop = false;
					cameraMovement.centerCamera();
					cameraMovement.desactiveCamera();				
					//int newNumCurrentWaypoint;
					//do{newNumCurrentWaypoint = Random.Range(0,waypoints.Length);}while(newNumCurrentWaypoint == numCurrentWaypoint);					
					//numCurrentWaypoint = newNumCurrentWaypoint;
					//Debug.Log("Pos nº:"+pos+" vector:"+waypoints[pos]);
					numCurrentWaypoint++;
					numCurrentWaypoint %= waypoints.Length;
					currentWaypoint = waypoints[numCurrentWaypoint];		
					agent.SetDestination(currentWaypoint);	
					agent.Resume();
				}
			}
		}
	}
}