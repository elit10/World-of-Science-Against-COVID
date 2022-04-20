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

	public float curSickness;

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
		SpawnCovid();

		InvokeRepeating("Loop", 0.5f, 1f);
		Invoke("LateStart", 0.3f);
	}


	public void LateStart()
    {
		data = NPCManager.instance.RandomData(NPCGender);
	}

	public void Loop()
	{
		anim.SetFloat("Speed", agent.speed);

		if (curSickness > resistance)
		{
			isCovid = true;
			curSickness = 0;
		}
		if (isCovid)
		{
			float distance = hasMask ? 5 : 10;

			NPC[] curClosest = Closest(this, distance);
            for (int i = 0; i < curClosest.Length; i++)
            {
				curClosest[i].curSickness++;
            }
		}
		
	}
	
	public static NPC[] Closest(NPC self, float ratio)
	{
		NPC[] npcs = FindObjectsOfType<NPC>();
		List<NPC> temp = new List<NPC>();

		for (int i = 0; i < npcs.Length; i++)
        {
			if (Vector3.Distance(npcs[i].transform.position, self.transform.position) < ratio)
			{
				temp.Add(npcs[i]);
			}
		}
		return temp.ToArray();

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

	public void SpawnCovid()
	{
		int rand = Random.Range(0, 101);

		isCovid = (rand < GameManager.instance.maskProb);


	}


}
