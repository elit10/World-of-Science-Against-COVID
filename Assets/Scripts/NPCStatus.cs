using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStatus : MonoBehaviour
{
    public MeshRenderer mr {
        get
        {
            return GetComponent<MeshRenderer>();

        }

    }

    public void ChangeColor(int index)
    {
        mr.material = GameManager.instance.statusMats[index];
    }


}
