using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	#region Singleton
	public static DialogueManager instance;
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}

		else { return; }
	}
	#endregion

	[HideInInspector]
	public Dialogue nullDialogue;

	public TextAsset[] texts;

	public GameObject dialoguesGO;

	private QuestNpc curNPC;


	private void Start()
	{
		CreateNullDialogue();

		texts = Resources.LoadAll<TextAsset>("Text/Dialogues/");
		FormDialogue();


		Debug.Log(nullDialogue.dialogues[0]);
	}



	public void CreateNullDialogue()
	{
		Dialogue newDialogue = new Dialogue();

		newDialogue.dialogues = new string[]
		{
			"I think we have talked enough"
		};

		newDialogue.nextDialogue = newDialogue;


		nullDialogue = newDialogue;



	}

	public void FormDialogue()
	{
		
	
	}


	public TextAsset TargetText(string name)
	{
		TextAsset toReturn = new TextAsset();



		foreach(TextAsset TA in texts)
		{
			if(TA.name == name)
			{
				toReturn = TA;
			}
		}
		return toReturn;	
	}

	public Dialogue[] PullDialogues(string name)
    {
		List<Dialogue> dialogues = new List<Dialogue>();

		int order = 1;
		Dialogue curDialogue = CreateDialogue(TargetText(name + order));
		dialogues.Add(curDialogue);
		while(curDialogue.dialogues[curDialogue.dialogues.Length-1] != "end")
        {
			order++;
			curDialogue = CreateDialogue(TargetText(name + order));
			dialogues.Add(curDialogue);
		}

		curDialogue.nextDialogue = nullDialogue;

		return dialogues.ToArray();
    }

	public Dialogue CreateDialogue(TextAsset val)
	{


		Dialogue newDialogue = dialoguesGO.AddComponent<Dialogue>();

		string[] source = val.text.Split('|');

		string[] texts = new string[source.Length];

		for (int i = 0; i < source.Length; i++)
		{
			texts[i] = source[i].Trim();
		}



		newDialogue.dialogues = texts;

		return newDialogue;
		
	}



	public void EnterDialogue(Dialogue val,string name,QuestNpc self)
    {
		curNPC = self;
		curNPC.transform.LookAt(GameObject.FindWithTag("Player").transform.position);
		curNPC.Walk(false);

		CameraManager.instance.Focus(true);
		CameraManager.instance.LockOnTarget(curNPC.gameObject.transform.position);

		SlowDownTime(true);
		Debug.Log("entered dialogue");
		
		UIManager.instance.OpenUpPanel(UIManager.instance.dialoguePanel);

		UIManager.instance.dialoguePanel.Dialogueloop(val, name);




		//open up dialogue screen


	}





	public void EndDialogue()
    {
		CameraManager.instance.Focus(false);
		CameraManager.instance.LockOnTarget(false);
		curNPC.Walk(true);

		curNPC.dialogueOrder++;
		SlowDownTime(false);
		UIManager.instance.CloseAllPanels();
		


    }



	public void SlowDownTime(bool val)
	{
		Time.timeScale = val ? 0.2f : 1;
	}



}
