using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AnimationManager : MonoBehaviour
{
    public Animator anim;
    public bool isCrouching = false;

    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera finishCam;

    #region Singleton
    public static AnimationManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
        }
    }
    #endregion

    

    public void TriggerLimbo(bool val)
	{
        anim.SetBool("LimboBool",val);
        isCrouching = val;


    }

    public void SetCamera(int val)
	{
        if(val == 0)
		{
            mainCam.Priority = 2;
            finishCam.Priority = 1;
		}

        if(val == 1)
		{
            mainCam.Priority = 1;
            finishCam.Priority = 2;
		}
	}


    public void JumpAnim()
	{
        anim.Play("Jump");
	}


    public void Dance()
	{
        SetCamera(1);
        anim.Play("Dance");
        ParticleController.instance.WinParticle();
        CustomCharacterController.instance.targetYPos = 0;
	}

    public void Damage(float val)
	{
        anim.Play("Hit");
        CustomCharacterController.instance.StartCoroutine("Damage",val);
	}



}
