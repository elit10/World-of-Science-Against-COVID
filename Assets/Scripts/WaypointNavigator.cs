using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WaypointNavigator : MonoBehaviour
{
	NavMeshAgent agent;
	public Waypoint curWaypoint;

	int direction;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}


	private void Start()
	{
		direction = Mathf.RoundToInt(Random.Range(0, 1f));


		agent.SetDestination(curWaypoint.GetPosition());
	}


	private void Update()
	{
		//Debug.Log(Vector3.Distance(agent.transform.position, agent.destination));

		if(Vector3.Distance(agent.transform.position,agent.destination) <= 1.2f)
		{
			if(direction == 0)
			{
				curWaypoint = curWaypoint.nextWaypoint;
			}
			else if(direction ==1)
			{
				curWaypoint = curWaypoint.previousWaypoint;
			}

			
			agent.SetDestination(curWaypoint.GetPosition());
		}

	}



}
