using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TileStates
{
	Empty,
	Filled
}

public class TileState : MonoBehaviour, IPointerClickHandler
{
	public SpriteRenderer spriteRenderer;
	TileStates state;
	public BoardManager boardManager;
	public int x;
	public int y;

	private void Awake()
	{
		state = TileStates.Empty;
	}

	public void initializeTile(int x, int y, BoardManager manager)
	{
		this.x = x;
		this.y = y;
		this.boardManager = manager;
	}

	private void OnMouseOver()
	{
		if (state.Equals(TileStates.Empty))
		{
			spriteRenderer.color = Color.green;
		} else {
			spriteRenderer.color = Color.red;
		}
	}

	private void OnMouseExit()
	{
		spriteRenderer.color = new Color(0.4f, 0.6f, 1f);
	}

	public void SetState(TileStates state)
	{
		this.state = state;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		boardManager.onPlayerClickTile(x, y);
	}
}
