using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCone : MonoBehaviour
{
    public static GunCone instance;

    public List<NPC> inRange = new List<NPC>();

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            inRange.Add(other.GetComponent<NPC>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            inRange.Remove(other.GetComponent<NPC>());
        }
    }



}
