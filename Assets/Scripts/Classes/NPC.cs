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

	private bool _isCovid;
	public bool isCovid
	{
		get
		{
			return _isCovid;

		}
		set
		{
			if (value)
			{
				stat.ChangeColor(1);
			}

			if (!value)
			{
				stat.ChangeColor(2);
			}

			_isCovid = value;
		}
	}

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

	public NPCStatus stat;

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
		stat = GetComponentInChildren<NPCStatus>();


		if (GetComponentInChildren<Mask>() != null)
		{ mask = GetComponentInChildren<Mask>().gameObject; }

		SpawnMask();
		

		InvokeRepeating("Loop", 0.5f, 1f);
		Invoke("LateStart", 0.3f);
	}


	public void LateStart()
    {
		data = NPCManager.instance.RandomData(NPCGender);
		SpawnCovid();
	}

	public void Loop()
	{
		anim.SetFloat("Speed", agent.speed);

		if (curSickness > resistance)
		{
			isCovid = true;
			//curSickness = resistance + 1;
		}
		if (curSickness < resistance)
		{
			isCovid = false;

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

		curSickness = (rand < GameManager.instance.covidProb) ? resistance+1 : 0;


	}


}
