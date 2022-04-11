using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    #region Singleton
    public static NPCManager instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public string[] namesM;
    public string[] namesF;
    public string[] surNames;
    public string[] jobs;

    public string countryName;

    public void Start()
    {
        LoadVariables();
    }


    public NPCData RandomData(NPC.Gender curGender)
    {
        NPCData newData = new NPCData();

        string firstName = "";
        string surName = "";

        if(curGender == NPC.Gender.Female)
        {
            firstName = namesF[Random.Range(0, namesF.Length-1)]; 
        }

        if (curGender == NPC.Gender.Male)
        {
            firstName = namesM[Random.Range(0, namesM.Length - 1)];
        }

        surName = surNames[Random.Range(0, surNames.Length - 1)];

        newData.NPCname = firstName + " " + surName;

        newData.NPCage = Random.Range(14, 60).ToString();

        newData.NPCjob = jobs[Random.Range(0, jobs.Length - 1)];

        newData.NPCvaccineCount = Random.Range(0, 3);

        return newData;
    }


    public void LoadVariables()
    {
        namesM = LoadNamesM();
        namesF = LoadNamesF();
        surNames = LoadSurnames();
        jobs = LoadJobs();
    }




    private string[] LoadNamesM()
    {
        TextAsset TA = new TextAsset();

        TA = Resources.Load<TextAsset>("Text/NPC/" +countryName+   "/NamesM");


        return TA.text.Split('|');

    }

    private string[] LoadNamesF()
    {
        TextAsset TA = new TextAsset();

        TA = Resources.Load<TextAsset>("Text/NPC/" + countryName + "/NamesF"); 


        return TA.text.Split('|');

    }


    private string[] LoadSurnames()
    {
        TextAsset TA = new TextAsset();

        TA = Resources.Load<TextAsset>("Text/NPC/" + countryName + "/SurNames"); 


        return TA.text.Split('|');

    }

    private string[] LoadJobs()
    {
        TextAsset TA = new TextAsset();

        TA = Resources.Load<TextAsset>("Text/NPC/Jobs");


        return TA.text.Split('|');

    }




}
