using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  static partial class Events
{
    public static event Action<string, int> OnSetPlayerNameAndCoins;
    public static void DoOnSetPlayerNameAndCoins(string name, int coins) => OnSetPlayerNameAndCoins?.Invoke(name,coins);

    public static event Action<int> OnSetCoins;
    public static void DoOnSetCoins(int coins) => OnSetCoins?.Invoke(coins);

    public static event Action<string, string> OnSetPlayersHands;
    public static void DoOnSetPlayersHands(string playerHand, string enemyHand) => OnSetPlayersHands?.Invoke(playerHand, enemyHand);

    public static event Action<int, int> OnChangePlayersHands;
    public static void DoOnChangePlayersHands(int playerHand, int enemyHand) => OnChangePlayersHands?.Invoke(playerHand, enemyHand);
}
