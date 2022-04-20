using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public ParticleSystem[] sprayParticles;
    public ParticleSystem[] maskParticles;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // dezenfektan
            PlayAll(sprayParticles);


        }
        if (Input.GetMouseButtonDown(1))
        {
            //Maske
            PlayAll(maskParticles);


        }

    }

    public static void PlayAll(ParticleSystem[] val)
    {
        if (val.Length > 0)
        {
            for (int i = 0; i < val.Length; i++)
            {
                val[i].Play();

            }
        }
        else { return; }
    }


}
