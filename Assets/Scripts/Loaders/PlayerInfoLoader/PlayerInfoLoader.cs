using UnityEngine;
using System.Collections;
using System;

public class PlayerInfoLoader
{
	public void load()
	{
		Hashtable mockPlayerData = new Hashtable();
		mockPlayerData["userId"] = 1;
		mockPlayerData["name"] = "Player 1";
		mockPlayerData["coins"] = CustomPref.GetPrefs(GameConstants.coins,50);
        Events.DoOnPlayerInfoLoadedAction(mockPlayerData);
	}
}