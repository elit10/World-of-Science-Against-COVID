using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LimboTrigger : MonoBehaviour
{
	private CapsuleCollider collider;

	private void Start()
	{
		collider = GetComponent<CapsuleCollider>();

	}


	private void OnTriggerEnter(Collider other)
	{
		


		if(other.CompareTag("player"))
		{
			Debug.Log(CustomCharacterController.instance.scaleVal);
			Debug.Log(transform.lossyScale.x * 20 + "  "  + gameObject.name);

			if (CustomCharacterController.instance.scaleVal <= transform.lossyScale.x * 8.4)
			{
				Debug.Log("passed");
				collider.enabled = false;
			}

			else if (CustomCharacterController.instance.scaleVal <= transform.lossyScale.x * 16.8)
			{
				if (AnimationManager.instance.isCrouching || CustomCharacterController.instance.isJumping)
				{
					Debug.Log("passed");
					collider.enabled = false;
				}
				else
				{
					Debug.Log("failed");
					AnimationManager.instance.Damage(0);
					CustomCharacterController.instance.isWalking = false;
					AnimationManager.instance.SetCamera(1);


				}
			}

				

			else
			{
				Debug.Log("failed");
				AnimationManager.instance.Damage(0);
				CustomCharacterController.instance.isWalking = false;
				AnimationManager.instance.SetCamera(1);
			}
		}

	}

}