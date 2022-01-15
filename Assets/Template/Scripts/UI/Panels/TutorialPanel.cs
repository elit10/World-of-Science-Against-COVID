using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class TutorialPanel : UIPanel
{

	public Image cursor;
	public int moveBy = 100;
	public GameObject[] arrows;

	public enum animationType
	{
		up,
		down,
		left,
		right,
		tap
	};
	public animationType curAnimationType;
	private Vector3 startPos;

	private void Awake()
	{
		startPos = cursor.rectTransform.position;
	}


	public void StartTutorial(float duration, animationType type)
	{
		StartCoroutine(ShowTutorial(duration, type));

		OpenImage((int)type);

	}

	IEnumerator ShowTutorial(float duration, animationType type)
	{
		int i = 0;
		while(i < duration/2)
		{
			PlayAnim(type);
			yield return new WaitForSeconds(2);
			i++;
		}
		this.Fade(false, 1);
	}

	public void PlayAnim(animationType type)
	{
		if(type == animationType.down)
		{
			cursor.transform.DOMoveY(cursor.transform.position.y + moveBy, 0f).OnComplete(() => cursor.transform.DOMoveY(cursor.transform.position.y - moveBy, 2f));
		}

		if (type == animationType.up)
		{
			cursor.transform.DOMoveY(cursor.transform.position.y + moveBy, 2f).OnComplete(() => cursor.transform.DOMoveY(cursor.transform.position.y - moveBy, 0f));
		}

		if (type == animationType.left)
		{
			cursor.transform.DOMoveX(cursor.transform.position.x + moveBy, 0).OnComplete(() => cursor.transform.DOMoveX(cursor.transform.position.x - moveBy, 2));
		}

		if (type == animationType.right)
		{
			cursor.transform.DOMoveX(cursor.transform.position.x + moveBy/2, 0.5f).OnComplete(() => cursor.transform.DOMoveX(cursor.transform.position.x - moveBy, 1.5f));
		}

		if (type == animationType.tap)
		{
			cursor.transform.DOScale(2, 1).OnComplete(() => cursor.transform.DOScale(1/2,1));
		}


		ResetCursorPos();
	}

	void ResetCursorPos()
	{
		cursor.rectTransform.position = startPos;
	}


	void OpenImage(int order)
	{
		foreach (GameObject img in arrows)
		{
			if (arrows[order] != null)
			{
				if (img == arrows[order])
				{
					img.SetActive(true);
				}
				else
				{
					img.SetActive(false);
				}
			}

			else
			{
				return;
			}
		}
	}


}