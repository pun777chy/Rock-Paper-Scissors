using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
	void ChangeCoinAmount(int amount);
	 int GetUserId();
	string GetName();
	int GetCoins();
}
