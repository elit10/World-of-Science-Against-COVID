using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(CanvasGroup))]
public abstract class UIPanel : MonoBehaviour
{
	private CanvasGroup group 
	{
		get
		{
			return GetComponent<CanvasGroup>();
		}
	
	}


	public void Activate(bool val)
	{
		if (val) { group.alpha = 1; }
		else { group.alpha = 0; }

		gameObject.SetActive(val);
	}

	public void Fade(bool val, float duration)
	{
		if(val)
		{
			gameObject.SetActive(true);
			group.DOFade(1, duration);
		}
		else
		{
			group.DOFade(0,duration).OnComplete(() => gameObject.SetActive(false)); 
		}
	
	
	}

}
