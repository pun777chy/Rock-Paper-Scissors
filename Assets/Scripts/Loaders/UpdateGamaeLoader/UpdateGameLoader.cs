using UnityEngine;
using System.Collections;
using System;

public class UpdateGameLoader
{

	private UseableItem _choice;

	public UpdateGameLoader(UseableItem playerChoice)
	{
		_choice = playerChoice;
	}

	public void load()
	{
		int[] UseableItems = (int[])Enum.GetValues(typeof(UseableItem));
		UseableItem opponentHand = (UseableItem) UseableItems[UnityEngine.Random.Range(0, UseableItems.Length)];

		Hashtable mockGameUpdate = new Hashtable();
		mockGameUpdate["resultPlayer"] = _choice;
		mockGameUpdate["resultOpponent"] = opponentHand;
		mockGameUpdate["coinsAmountChange"] = GetCoinsAmount(_choice, opponentHand);
		AudioController.Instance.PlayResultSound(_choice, opponentHand);
		Events.DoOnUpdateLoadedAction(mockGameUpdate);
	}

	private int GetCoinsAmount (UseableItem playerHand, UseableItem opponentHand)
	{
		Result drawResult = ResultAnalyzer.CalculateWinner( playerHand, opponentHand);

		if (drawResult.Equals (Result.Won))
		{
			return 10;
		}
		else if (drawResult.Equals (Result.Lost))
		{
			return -10;
		}
		else
		{
			return 0;
		}

	}
}