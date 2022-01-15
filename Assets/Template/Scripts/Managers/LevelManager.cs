using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using ElephantSDK;


public class LevelManager : MonoBehaviour
{

    public int curLevel;
    private GameObject previousLevel;
    public bool isStarting = false;


    [Header("Level Looping Settings")]

    //Set willLoop = false to disable the Looping system
    public bool willLoop = true;
    public int endOfLoop;
    public int startOfLoop;


    #region Singleton
    public static LevelManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
	#endregion
	private void Start()
	{
        LoadLevel();
	}


    //This loads the specific level that is given
	public void LoadLevel(int val)
	{
        if(previousLevel != null) { Destroy(previousLevel); }
        
        previousLevel = Instantiate(Resources.Load<GameObject>("levels/level-" + val));
    }

    //This method is for loading the curLevel
    public void LoadLevel()
    {
        if (previousLevel != null) { Destroy(previousLevel); }

        previousLevel = Instantiate(Resources.Load<GameObject>("levels/level-" + curLevel));
        isStarting = false;
    }
    


    //StartLevel() gets called when the user presses the screen first time
    //
    public void StartLevel()
	{
        Debug.Log("Level started");

		//Elephant.LevelStarted(curLevel);


        isStarting = false;
    }

    public void Success()
	{
        
        UIManager.instance.IsSuccess(true);
		//Elephant.LevelCompleted(curLevel);
	}
    public void Fail()
	{
        UIManager.instance.IsSuccess(false);
		//Elephant.LevelFailed(curLevel);

	}

    public void NextLevel()
	{
        
        if(willLoop)
		{
            if(curLevel == endOfLoop)
			{
                curLevel = startOfLoop;
                LoadLevel();
                return;
			}
            if(curLevel < endOfLoop)
			{
                curLevel++;
                LoadLevel();
            }
		}
        else
		{
            curLevel++;
            LoadLevel();
        }
    }

    public void RepeatLevel()
	{
        LoadLevel();
	}


}
