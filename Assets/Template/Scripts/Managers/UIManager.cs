using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public EndPanel endPanel;
    public StartPanel startPanel;
    public TutorialPanel tutorialPanel;
    
    
    #region Singleton
    public static UIManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
	#endregion


    public void TutorialScreen(TutorialPanel.animationType type)
	{
        tutorialPanel.Activate(true);
        tutorialPanel.StartTutorial(2, type);

        endPanel.Activate(false);
        startPanel.Activate(false);
    }


	private void Start()
	{
        tutorialPanel.Activate(true);
        endPanel.Activate(false);
        startPanel.Activate(true);

        tutorialPanel.StartTutorial(2, tutorialPanel.curAnimationType);
    }

    public void IsSuccess(bool val)
	{
        endPanel.Activate(true);
        endPanel.IsSuccess(val);
    }

}
