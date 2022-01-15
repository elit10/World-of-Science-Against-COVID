using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour
{
    
    [HideInInspector]
    public Camera cam 
    {
		get
		{
            return gameObject.GetComponent<Camera>();
		}
    }


    public Transform followedObject;
    public bool isFollowing;
    public float lookOffset;
    public Vector3 followOffset;

    public void ChangeFov(float level)
    {
        StartCoroutine(ChangeFOVRoutine(level));
    }


    IEnumerator ChangeFOVRoutine(float level)
    {
        if (cam.fieldOfView < level)
        {
            while (cam.fieldOfView < level)
            {
                cam.fieldOfView++;
                yield return null;
            }
        }
        else
        {
            while (cam.fieldOfView >= level)
            {
                cam.fieldOfView--;
                yield return null;
            }
        }
    }


    private void Update()
    {
        if (followedObject == null) return;

        if (isFollowing)
        {

            Vector3 _pos = followedObject.position + (followedObject.forward * -followOffset.z) + (followedObject.up * followOffset.y);
            Vector3 _look = (followedObject.position + new Vector3(0, lookOffset, 0)) - transform.position;


            transform.position = Vector3.Slerp(transform.position, _pos, Time.deltaTime * (_pos - transform.position).magnitude);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_look), Time.deltaTime * (_pos - transform.position).magnitude * 3);

        }
    }

    #region Singleton
    public static CameraManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
