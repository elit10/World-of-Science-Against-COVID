using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("player"))
		{
			LevelManager.instance.isStarting = false;
			CustomCharacterController.instance.isListening = false;
			CustomCharacterController.instance.targetYPos = 0;
			AnimationManager.instance.TriggerLimbo(false);
			CustomCharacterController.instance.gameObject.transform.position = new Vector3(CustomCharacterController.instance.gameObject.transform.position.x, 0, CustomCharacterController.instance.currentPos.z);
			LevelManager.instance.Success();
		}
	}

}
