using UnityEngine;
using System.Collections;

public enum Result
{
	Won,
	Lost,
	Draw
}

public static class ResultAnalyzer
{
	//public static Result GetResultState(UseableItem playerHand, UseableItem enemyHand)
	//{
	//	if (isStronger(playerHand, enemyHand))
	//	{
	//		return Result.Won;
	//	}
	//	else if (isStronger(enemyHand, playerHand))
	//	{
	//		return Result.Lost;
	//	}
	//	else
	//	{
	//		return Result.Draw;
	//	}
	//}

	//private static bool isStronger (UseableItem firstHand, UseableItem secondHand)
	//{
	//	switch (firstHand)
	//	{
	//		case UseableItem.Rock:
	//		{
	//			switch (secondHand)
	//			{
	//				case UseableItem.Scissors:
	//					return true;
	//				case UseableItem.Paper:
	//					return false;
	//			}
	//			break;
	//		}
	//		case UseableItem.Paper:
	//		{
	//			switch (secondHand)
	//			{
	//				case UseableItem.Rock:
	//					return true;
	//				case UseableItem.Scissors:
	//					return false;
	//			}
	//			break;
	//		}
	//		case UseableItem.Scissors:
	//		{
	//			switch (secondHand)
	//			{
	//				case UseableItem.Paper:
	//					return true;
	//				case UseableItem.Rock:
	//					return false;
	//			}
	//			break;
	//		}
	//	}

	//	return false;
	//}
	public static Result CalculateWinner(UseableItem player1Item, UseableItem player2Item)
	{
		int player1 = (int)player1Item;
		int player2 = (int)player2Item;
		int result =  (Mathf.Abs(player1 - player2) % 2);
		if (player1 == player2)
			return Result.Draw;
		switch (result)
		{
			case 0:
				 
					if(player1<player2)
                    {
						return Result.Won;
                    }
					else
                    {
						return Result.Lost;
					}
				 
			 break;
			case 1:
				if (player1 > player2)
				{
					return Result.Won;
				}
				else
				{
					return Result.Lost;
				}


		}
		return Result.Draw;
	}

}