using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
	public ParticleSystem[] scaleUpParticles;
	public ParticleSystem[] scaleDownParticles;

	public ParticleSystem[] winParticles;

	#region Singleton
	public static ParticleController instance = null;
	private void Awake()
	{
		if (instance == null) instance = this;
	}
	#endregion

	public void PlayParticle(ParticleSystem[] particles,bool val)
	{
		if(val)
		{
			foreach (ParticleSystem ps in particles)
			{
				ps.Play();
			}
		}
		else
		{
			foreach (ParticleSystem ps in particles)
			{
				ps.Stop();
			}
		}
	}

	public void PlayParticle(ParticleSystem particle)
	{
		particle.Play();
	}

	public void ScaleUp()
	{
		PlayParticle(scaleUpParticles,true);
	}

	public void ScaleDown()
	{
		PlayParticle(scaleDownParticles, true);
	}



	public void WinParticle()
	{
		PlayParticle(winParticles, true);
	}

}
