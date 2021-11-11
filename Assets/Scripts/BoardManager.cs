using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
	public GameObject TilePrefab;
	public Camera MainCamera;
	public GameObject PlayerPrefab;
	public int BoardSize;
	GameObject Player;

	private GameObject[,] _tiles;

	private void Awake()
	{
		_tiles = new GameObject[BoardSize, BoardSize];
	}

	public void SetupBoard()
	{
		for (int i = 0; i < BoardSize; i++)
		{
			for (int j = 0; j < BoardSize; j++)
			{
				GameObject tile = Instantiate(TilePrefab, new Vector3(i, j, 0), Quaternion.identity);
				tile.transform.parent = transform;
				tile.GetComponent<TileState>().initializeTile(i, j, this);
				_tiles[i, j] = tile;
				// Debug.Log(tile);
			}
		}
		MainCamera.transform.position = new Vector3(BoardSize / 2 - 0.5f, BoardSize / 2 - 0.5f, -10);

		// Spawning player and setting that tile as occupied
		GameObject player = Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		this.Player = player;
		_tiles[0, 0].GetComponent<TileState>().SetState(TileStates.Filled);
	}

	public void onPlayerClickTile(int x, int y)
	{
		Debug.Log("Clicked on tile: " + x + ", " + y);
		Player.transform.position = new Vector3(x, y, 0);
	}
}
