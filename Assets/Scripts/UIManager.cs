using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    #region Singleton
    public static UIManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion


    public InfoPanel NPCInfo;
    public DialoguePanel dialoguePanel;
    public QuizPanel quizPanel;
    public Panel[] panels;

    public void OpenUpPanel(Panel panel)
    {
        foreach(Panel p in panels)
        {
            if(panel == p)
            {
                p.Activate(true);
            }
            else
            {
                p.Activate(false);
            }
        }
    }

    public void CloseAllPanels()
    {
        foreach(Panel p in panels)
        {
            p.Activate(false);
        }
    }




}
