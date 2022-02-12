using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class QuestNpc : NPC
{

	private GameObject player;



	private void Start()
	{
		player = FirstPersonController.instance.gameObject;

		InvokeRepeating("QuestLoop", 0, 0.2f);
	}


	void QuestLoop()
	{
		if(isCloseEnough())
		{
			Debug.Log("Quest");
		}
	}


	public bool isCloseEnough()
	{
		bool val = false;
	
		val = (Vector3.Distance(gameObject.transform.position, player.transform.position) < 5);

		return val;

	}




}
