using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	public GameObject boardObject;
	BoardManager boardManager;

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				// _instance = GameObject.FindObjectOfType<GameManager> ();
				Debug.LogError("GameManager is null");
			}
			return _instance;
		}
	}

	private void Awake()
	{
		_instance = this;
		boardManager = boardObject.GetComponent<BoardManager>();
		Setup();
	}

	void Setup()
	{
		boardManager.SetupBoard();
	}
}
