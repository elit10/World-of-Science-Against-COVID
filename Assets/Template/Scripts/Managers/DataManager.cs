using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	#region Singleton
	public static DataManager instance = null;
	private void Awake()
	{
		if (instance == null) instance = this;
	}
	#endregion

	public int point;

	public int levelData
	{
		get 
		{
			return PlayerPrefs.GetInt("Level");
		}

		set
		{
			PlayerPrefs.SetInt("Level", value);
		}
	}

}
