using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    #region Singleton


    public static CameraManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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




    public void Focus(bool val)
    {
        float target = val ? 40 : 60;

        DOTween.To(() => fov, x => fov = x, target, 1);



    }


}
