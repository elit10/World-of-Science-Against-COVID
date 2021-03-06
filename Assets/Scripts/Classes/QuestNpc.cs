using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNpc : NPC
{

	private GameObject player;

	public int dialogueOrder = 0;

	public string ID;

	public Quiz curQuiz;

	public Dialogue[] dialogues;

	private void Start()
	{
		player = GameObject.FindWithTag("Player");

		InvokeRepeating("QuestLoop", 0, 0.2f);

		Invoke("PullDialogue", 0.5f);


		
	}



	void PullDialogue()
    {
		dialogues = DialogueManager.instance.PullDialogues(ID);

		curQuiz = QuizManager.instance.NewQuiz(5);


		foreach (Dialogue dg in dialogues)
        {
			//Debug.Log(dg.dialogues[0]);
        }
    }


	void QuestLoop()
	{
		if (isCloseEnough() && !UIManager.instance.dialoguePanel.isInDialogue)
		{
			if (dialogueOrder < dialogues.Length)
			{
				DialogueManager.instance.EnterDialogue(dialogues[dialogueOrder], data.NPCname, this);
			}
			else
			{
				//QU?ZLER? BURASI A?IYOR

				QuizManager.instance.OpenUpQuiz(curQuiz);
			}
		}
	}



	public bool isCloseEnough()
	{
		bool val = false;
	
		val = (Vector3.Distance(gameObject.transform.position, player.transform.position) < 5);

		return val;

	}




}
