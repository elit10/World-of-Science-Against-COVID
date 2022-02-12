using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Panel : MonoBehaviour
{
	public bool isActive;

	private CanvasGroup group
	{
		get
		{
			return GetComponent<CanvasGroup>();
		}

	}

	public void Activate(bool val)
	{
		isActive = val;

		if (val) { group.alpha = 1; }
		else { group.alpha = 0; }


		gameObject.SetActive(val);
	}

	public void Fade(bool val, float duration)
	{

		isActive = val;

		if (val)
		{
			gameObject.SetActive(true);
			group.DOFade(1, duration);
		}
		else
		{
			group.DOFade(0, duration).OnComplete(() => gameObject.SetActive(false));
		}

	}
}
