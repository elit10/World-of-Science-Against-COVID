using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{

	RaycastHit hit;

	private void Update()
	{


		if(Physics.Raycast(gameObject.transform.position,gameObject.transform.forward,out hit,100f))
		{
			if(hit.collider.CompareTag("NPC"))
			{
				UIManager.instance.NPCInfo.gameObject.SetActive(true);
			}
			else { UIManager.instance.NPCInfo.gameObject.SetActive(false); }
		}
	}
}
