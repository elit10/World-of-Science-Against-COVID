using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPC : MonoBehaviour
{
	public NavMeshAgent agent;
	public Animator anim;

	public NPCData data;

	public enum Gender
	{
		Male,
		Female
	};

	public Gender NPCGender;

	public void Walk(bool val)
    {
		agent.speed = val ? 3.5f : 0;
    }

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		

		InvokeRepeating("Loop", 0, 1f);
		Invoke("LateStart", 0.5f);
	}


	public void LateStart()
    {
		data = NPCManager.instance.RandomData(NPCGender);
	}

	public void Loop()
	{
		anim.SetFloat("Speed", agent.speed);
	}

	public void Walk()
	{
		Debug.Log("is walking");
	}
}
