using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


	#region Singleton
	public static GameManager instance = null;
	private void Awake()
	{
		if (instance == null) instance = this;
	}
	#endregion


	public enum gameState
	{
		win,
		lose,
		running,
		start
	};

	public gameState currentState;



}
