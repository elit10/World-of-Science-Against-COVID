using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{

	public TutorialPanel.animationType selectedType;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("player"))
		{
			
			
			UIManager.instance.TutorialScreen(selectedType);
		}
	}
}
