using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
	public GameObject pedestrianPrefab;

	public int spawnCount;


	private void Start()
	{
		StartCoroutine(Spawn());
	}


	IEnumerator Spawn()
	{
		int count = 0;

		while(count<spawnCount)
		{
			GameObject obj = Instantiate(pedestrianPrefab);
			Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
			obj.GetComponent<WaypointNavigator>().curWaypoint = child.GetComponent<Waypoint>();
			obj.transform.position = child.position;

			yield return new WaitForEndOfFrame();
			count++;
		}


	}

}
