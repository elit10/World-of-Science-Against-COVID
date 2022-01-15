using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillTrigger : MonoBehaviour
{

	public enum pills
	{
		blue,
		red
	};

	public pills curPill;


	private void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("player"))
		{
			if(curPill == pills.blue)
			{
				CustomCharacterController.instance.scaleVal = -0.25f;
				ParticleController.instance.ScaleDown();
				Debug.Log("blue");
			}
			if (curPill == pills.red)
			{
				CustomCharacterController.instance.scaleVal = 0.25f;
				ParticleController.instance.ScaleUp();
				Debug.Log("red");
			}

			Destroy(gameObject);
		}

	}
}
