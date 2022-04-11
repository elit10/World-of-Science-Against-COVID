using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPC : MonoBehaviour
{
	public NavMeshAgent agent;

	public Animator anim;

	private bool _hasMask;

	public bool hasMask
	{
		get
		{
			return _hasMask;
		}
		set
		{
			_hasMask = value;

			//activate mask object
			if (mask != null) { mask.SetActive(value); }
		}
	}

	public bool isCovid;

	public NPCData data;

	public int resistance
	{
		get
		{
			int maskval = hasMask ? 100 : 0;

			return data.NPCvaccineCount * 10 + maskval;
		}

	}

	public GameObject mask;

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

		if (GetComponentInChildren<Mask>() != null)
		{ mask = GetComponentInChildren<Mask>().gameObject; }

		SpawnMask();

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


	public void SpawnMask()
	{
		int rand = Random.Range(0, 101);

		hasMask = (rand < GameManager.instance.maskProb);


	}

}
