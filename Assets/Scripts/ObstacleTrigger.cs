using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("player"))
		{
			AnimationManager.instance.Damage(3);
			GetComponentInChildren<ParticleSystem>().Play();
		}
	}
}
