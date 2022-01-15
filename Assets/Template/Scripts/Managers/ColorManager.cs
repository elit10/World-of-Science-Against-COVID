using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public SkyColor[] colors;
    public Material skybox;

    #region Singleton
    public static ColorManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void ChangeColor(int val)
	{
        skybox.SetColor("_Color", colors[val].up);
        skybox.SetColor("_Color2", colors[val].down);
    }
    
}



