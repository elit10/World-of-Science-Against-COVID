using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

using UnityStandardAssets.Characters.FirstPerson;

public class CameraManager : MonoBehaviour
{
    #region Singleton

    public static RigidbodyFirstPersonController controller;

    public static CameraManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            controller = FindObjectOfType<RigidbodyFirstPersonController>();
        }
    }
    #endregion


    public Camera mainCamera;

    public float fov
    {
        get
        {
            return mainCamera.fieldOfView;
        }

        set
        {
            mainCamera.fieldOfView = value;
        }
    }

    

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    public void LockOnTarget(Vector3 position)
    {
        transform.parent.transform.LookAt(position);
    }

    public void LockOnTarget(bool val)
    {
        if(val)
        {
            return;
        }
        transform.rotation = Quaternion.Euler(Vector3.zero);

    }


    public static void EnableControls(bool val)
    {
        controller.enabled = val;
    }

    public static void CamLock(bool val)
    {
        Cursor.lockState = val ? CursorLockMode.Locked : CursorLockMode.None;

        Cursor.visible = !val;
    }

    public void Focus(bool val)
    {
        float target = val ? 40 : 60;

        DOTween.To(() => fov, x => fov = x, target, 1);



    }


}
