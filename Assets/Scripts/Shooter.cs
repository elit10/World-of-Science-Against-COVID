using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public ParticleSystem[] sprayParticles;
    public ParticleSystem[] maskParticles;
    public float power;
    public Transform barell;
    public Object maskPrefab;

    #region Singleton
    public static Shooter instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
    #endregion

    public static void Cure(NPC npc,float val)
    {
        npc.curSickness -= val;
        Debug.Log(npc.name);
    }
    public static void Cure(NPC[] npcs, float val)
    {
        for (int i = 0; i < npcs.Length; i++)
        {
            npcs[i].curSickness -= val;
            Debug.Log(npcs[i].name);
        }
    }

    public void ThrowMask()
    {
        GameObject temp = (GameObject)Instantiate(maskPrefab, barell.position, barell.rotation, null);
        temp.AddComponent<MaskBullet>();

        MaskBullet mb = temp.GetComponent<MaskBullet>();


        mb.barell = barell;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // dezenfektan
            PlayAll(sprayParticles);

            Cure(GunCone.instance.inRange.ToArray(),power);

        }
        if (Input.GetMouseButtonDown(1))
        {
            //Maske
            PlayAll(maskParticles);
            ThrowMask();

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
