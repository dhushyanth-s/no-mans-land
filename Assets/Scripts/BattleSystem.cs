using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
	public BattleState state;
	public Text dialogueText;
	void Start()
	{
		state = BattleState.START;
	}

	public void OnSkipButton()
	{
		if (state == BattleState.PLAYERTURN)
		{
			dialogueText.text = "Enemy Turn";
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		yield return new WaitForSeconds(2f);
		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	void PlayerTurn()
	{
		dialogueText.text = "Player Turn";
	}
}
