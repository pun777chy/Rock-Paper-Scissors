using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Hands Aniamtion Controller")]
    // Composing Animation Controller
    public HandAnimationController parentsHandAnimationController;
    [Header("Player And Opponent Choices Texts")]
    public Text playerHand;
	public Text enemyHand;
    [Header("Player Data Texts")]
    public Text _nameLabel;
	public Text _moneyLabel;
    [Header("Hand Gesture Images")]
    public GameObject[] playerHands;
    public GameObject[] opponentHands;

    private void OnEnable()
    {
        Events.OnSetPlayerNameAndCoins += Events_OnSetPlayerNameAndCoins;
        Events.OnSetCoins += Events_OnSetCoins;
        Events.OnSetPlayersHands += Events_OnSetPlayersHands;
        Events.OnChangePlayersHands += Events_OnChangePlayersHands;
       
    }
    private void Start()
    {
        SwitchOffHands();
    }
    private void Events_OnSetCoins(int coins)
    {
        _moneyLabel.text = "Money: $" + coins.ToString();
    }

    private void SwitchOffHands()
    {
        for (int i = 0; i < playerHands.Length; i++)
        {
            playerHands[i].SetActive(false);
        }
        for (int i = 0; i < opponentHands.Length; i++)
        {
            opponentHands[i].SetActive(false);
        }
    }
    private void Events_OnChangePlayersHands(int playerHand, int opponentHand)
    {
        SwitchOffHands();
        parentsHandAnimationController.DeActiveParentImage();
        parentsHandAnimationController.PlayAnimation();
        playerHands[playerHand].SetActive(true);
        opponentHands[opponentHand].SetActive(true);
    }

    private void Events_OnSetPlayerNameAndCoins(string name, int coins)
    {
        _nameLabel.text = "Name: " + name;
        _moneyLabel.text = "Money: $" + coins.ToString();
    }
    private void Events_OnSetPlayersHands(string pHand, string eHand)
    {
        playerHand.text = pHand;
        enemyHand.text = eHand;
    }
    private void OnDisable()
    {
        Events.OnSetPlayerNameAndCoins -= Events_OnSetPlayerNameAndCoins;
        Events.OnSetCoins -= Events_OnSetCoins;
        Events.OnSetPlayersHands -= Events_OnSetPlayersHands;
        Events.OnChangePlayersHands -= Events_OnChangePlayersHands;
    }

}
