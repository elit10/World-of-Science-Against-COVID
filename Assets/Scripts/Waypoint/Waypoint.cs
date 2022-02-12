using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	public Waypoint previousWaypoint;
	public Waypoint nextWaypoint;

	[Range(0,30f)]
	public float width = 1f;

	public Vector3 GetPosition()
	{
		Vector3 min = transform.position + transform.right * width / 2;
		Vector3 max = transform.position - transform.right * width / 2;

		return Vector3.Lerp(min, max, Random.Range(0, 1f));



	}
}
