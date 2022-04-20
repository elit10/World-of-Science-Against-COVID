using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = GameManager.instance.maskMaterials[Random.Range(0,GameManager.instance.maskMaterials.Length)];
    }
}
