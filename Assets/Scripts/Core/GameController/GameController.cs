using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour
{

    private IPlayer _player;

    private void OnEnable()
    {
        Events.OnPlayerInfoLoadedAction += OnPlayerInfoLoaded;
        Events.OnUpdateLoadedAction += OnGameUpdated;

    }
    void Start()
    {
        PlayerInfoLoader playerInfoLoader = new PlayerInfoLoader();
        playerInfoLoader.load();
        UpdateHud();
    }

    public void OnPlayerInfoLoaded(Hashtable playerData)
    {
        _player = new Player(playerData);
    }

    public void UpdateHud()
    {
        Events.DoOnSetPlayerNameAndCoins(_player.GetName(), _player.GetCoins());
    }

    public void HandlePlayerInput(int item)
    {
        UseableItem playerChoice = (UseableItem)item;
        UpdateGame(playerChoice);
        AudioController.Instance.PlayBtnSound();
    }

    private void UpdateGame(UseableItem playerChoice)
    {
        UpdateGameLoader updateGameLoader = new UpdateGameLoader(playerChoice);
        updateGameLoader.load();
        UpdateHud();
    }

    public void OnGameUpdated(Hashtable gameUpdateData)
    {
        Events.DoOnSetPlayersHands(DisplayResultAsText((UseableItem)gameUpdateData["resultPlayer"]), DisplayResultAsText((UseableItem)gameUpdateData["resultOpponent"]));
        Events.DoOnChangePlayersHands((int)gameUpdateData["resultPlayer"], (int)gameUpdateData["resultOpponent"]);
        _player.ChangeCoinAmount((int)gameUpdateData["coinsAmountChange"]);
    }

    private string DisplayResultAsText(UseableItem result)
    {
        return result.ToString();
    }

    private void OnDisable()
    {
        Events.OnPlayerInfoLoadedAction -= OnPlayerInfoLoaded;
        Events.OnUpdateLoadedAction -= OnGameUpdated;
    }
}