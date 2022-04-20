using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    [Header("Difficulty")]
    [Range(0,100)]
    public int maskProb;
    [Range(0, 100)]
    public int covidProb;

    [Header("Mask properties")]
    public Material[] maskMaterials;




}
