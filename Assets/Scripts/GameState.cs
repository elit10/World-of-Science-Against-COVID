using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    #region Singleton
    public static GameState instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public enum gameState
    {
        running,
        inDialogue,
        inQuiz
    };



    public gameState curState;
}
