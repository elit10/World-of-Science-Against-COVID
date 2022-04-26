using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    [Header("Difficulty")]
    [Range(0, 100)]
    public static int maskProb;
    [Range(0, 100)]
    public static int covidProb;

    [Header("Mask properties")]
    public Material[] maskMaterials;

    [Header("NPC Status")]
    public Material[] statusMats;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;


    }

}
