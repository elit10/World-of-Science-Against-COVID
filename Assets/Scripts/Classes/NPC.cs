using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPC : MonoBehaviour
{
	public NavMeshAgent agent;
	public Animator anim;

	public string NPCname;
	public string NPCjob;
	public string NPCage;
	public string NPCvaccineCount;


	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();


		InvokeRepeating("Loop", 0, 1f);
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
