using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class QuestNpc : NPC
{

	private GameObject player;



	public string ID;


	public Dialogue[] dialogues;

	private void Start()
	{
		player = FirstPersonController.instance.gameObject;

		InvokeRepeating("QuestLoop", 0, 0.2f);

		Invoke("PullDialogue", 0.5f);
	}



	void PullDialogue()
    {
		dialogues = DialogueManager.instance.PullDialogues(ID);




		foreach(Dialogue dg in dialogues)
        {
			Debug.Log(dg.dialogues[0]);
        }
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
