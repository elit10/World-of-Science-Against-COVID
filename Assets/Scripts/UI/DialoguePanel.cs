using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class DialoguePanel : Panel
{
    public string speakerName;
    public Text displayedText;

    public Dialogue curDialogue;
    public GameObject choicePanel;

    public float timer;
    public int order = 0;

    public bool isInDialogue;

    private void Start()
    {
    }

    public void Dialogueloop(Dialogue val,string name)
    {
        isInDialogue = true;

        curDialogue = val;

        speakerName = name;

        ResetValues();
        StartCoroutine("Loop");
    }


    public void ResetValues()
    {
        order = 0;
        timer = 0;

    }

   
    private void Update()
    {
       if(Input.GetButtonDown("Submit"))
        {
            Debug.Log("pressed");
            order++;

        }
    }

    IEnumerator Loop()
    {
        while(order <= curDialogue.dialogues.Length-2)
        {
            timer += Time.deltaTime;
            if (timer >= curDialogue.dialogues[order].Length)
            {
                order++;
                timer = 0;
            }
            displayedText.text = curDialogue.dialogues[order];

            yield return new WaitForEndOfFrame();
        }

        isInDialogue = false;

        DialogueManager.instance.EndDialogue();

    }

}
