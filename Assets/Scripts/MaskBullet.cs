using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MaskBullet : MonoBehaviour
{
    public Transform barell;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            other.GetComponent<NPC>().hasMask = true;
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        Invoke(nameof(Destroy), 2.1f);

        transform.DOMove(barell.transform.position + barell.forward * 20, 2f);
    }


    public void Destroy()
    {
        Destroy(gameObject);
    }

}
