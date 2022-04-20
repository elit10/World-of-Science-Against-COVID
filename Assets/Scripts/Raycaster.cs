using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{

	RaycastHit hit;




	private void Update()
	{
		

		if(Physics.Raycast(gameObject.transform.position,gameObject.transform.forward,out hit,100f))
		{
			if (UIManager.instance.NPCInfo == null) { return; }


			if(hit.collider.GetComponent<NPC>() != null)
			{
				if(!UIManager.instance.NPCInfo.isActive)
				{
					UIManager.instance.NPCInfo.Activate(true);
					
				}
				UIManager.instance.NPCInfo.FillValues(hit.collider.GetComponent<NPC>().data);
			}

			else
			{
				if(UIManager.instance.NPCInfo.isActive)
				{
					UIManager.instance.NPCInfo.Activate(false);
				}
			}
		}
	}
}
