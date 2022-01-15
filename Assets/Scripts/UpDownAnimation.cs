using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class UpDownAnimation : MonoBehaviour
{
    private Vector3 target;
	private Vector3 startVec;

	private Vector3[] paths = new Vector3[2];
	
	private void Start()
	{
		target = Vector3.up / 2 + transform.position;
		startVec = transform.position;

		paths[0] = target;
		paths[1] = startVec;

		Jump();
	}

	void Update()
	{
    }


	void Jump()
	{
		if(isActiveAndEnabled)
		{
			transform.DOPath(paths, 3, PathType.CatmullRom).OnComplete(() =>
			{
				Jump();
			});
		}
	}

}
