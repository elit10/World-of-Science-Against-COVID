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
	public List<Dialogue> dialogues;
	[HideInInspector]
	public Dialogue nullDialogue;
	[HideInInspector]
	public TextAsset[] texts;

	public GameObject dialoguesGO;

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
		CreateDialogue(TargetText("example1"));
	
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




	public Dialogue CreateDialogue(TextAsset val)
	{

		Debug.Log(val.text);


		Dialogue newDialogue = dialoguesGO.AddComponent<Dialogue>();

		string[] source = val.text.Split('|');

		string[] texts = new string[source.Length];

		for (int i = 0; i < source.Length; i++)
		{
			texts[i] = source[i].Trim();
		}


		if(texts[texts.Length-1] == "end")
		{
			Debug.Log("dialogue ended");
			newDialogue.nextDialogue = nullDialogue;
		}
		else
		{
			Debug.Log("The next dialogue is " + texts[texts.Length - 1]);
			newDialogue.nextDialogue = CreateDialogue(TargetText(texts[texts.Length - 1]));
		}

		newDialogue.dialogues = texts;

		dialogues.Add(newDialogue);

		return newDialogue;
		
	}




}
