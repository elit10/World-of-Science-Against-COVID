using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoPanel : Panel
{


    public void FillValues(NPCData data)
    {
        if (data == null) { return; }
        npcName.text = data.NPCname;
        npcJob.text = data.NPCjob;
        npcAge.text = data.NPCage;
        npcVaccineCount.text = data.NPCvaccineCount.ToString();
    }

    public Text npcName;
	public Text npcJob;
	public Text npcAge;
	public Text npcVaccineCount;



}
