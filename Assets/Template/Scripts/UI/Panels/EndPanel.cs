using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EndPanel : UIPanel
{
	public GameObject successImg;
	public GameObject failImg;



	public void IsSuccess(bool val)
	{
		successImg.SetActive(val);
		failImg.SetActive(!val);

		
	}


	public void OnPressContinue()
	{
		Debug.Log("basýldý");
		if(!LevelManager.instance.isStarting)
		{
			CustomCharacterController.instance.ResetLevel();
			
			if (successImg.activeSelf) { LevelManager.instance.NextLevel(); }
			else { LevelManager.instance.RepeatLevel(); }
			LevelManager.instance.isStarting = true;
			AnimationManager.instance.SetCamera(0);
			UIManager.instance.startPanel.Activate(true);


			this.Fade(false, 1);

			
		}


		

	}


}
