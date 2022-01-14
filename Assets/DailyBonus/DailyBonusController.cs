using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// DailyBonusController
/// To keep user excited we are giving user a daily reward which he/she will get after the second time he/she would play the game
/// </summary>
public class DailyBonusController : MonoBehaviour {

    private DateTime previous;
    private DateTime today;
    [Header("DailyBonus Panel")]
	public GameObject dailyBonusMenu;
    [Header("List of bonuses")]
    public List<DailyBonus> _dailyBonuses; // List of all daily bonus objects

    // Composing pop up manager in this class because we don't need it in anywhere else 
    //otherwise we would subscribe and fire an  Event to show PopUp. 
    [Header("Pop up Panel")]
    public PopUpManager popUpPanel; 
    [Header("Claim Button")]
    public Button claimButton;
    [Header("Daily bonus Button on Main Screen")]
    public Button dailyBonusMenuBtn;

    [Header("Timers")]
    public float showTimer = 2f;
    public float vanishTimer = 2f;
    
    private int day;

    void Awake()
    {
        SetDefaultState(); // set the buttons and list of bonus to default states
        Invoke("DailyBonusStart", showTimer);
    }

    void DailyBonusStart()
    {
	    today = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
         //If daily bonus has/have been awarded in past
        
            previous = new DateTime(CustomPref.GetPrefs(GameConstants.bonusYear,2017), CustomPref.GetPrefs(GameConstants.bonusMonth,1), CustomPref.GetPrefs(GameConstants.bonusDay,1));
            TimeSpan diff = CompareDates(previous, today);
            if (diff.Days >= 1)
            {
                
				int dailyClaim = CustomPref.GetPrefs(GameConstants.dailyClaim);

                if (diff.Days == 1) // 1st day and consecutive days.
                {
					
					if (dailyClaim >= 7)
					{
						ResetDailyBonus();
						dailyClaim = CustomPref.GetPrefs(GameConstants.dailyClaim);
					}

					else if (dailyClaim >= 2)
					{
						int offset = dailyClaim - 2;
					}
                    ArrangeDailyBonus(dailyClaim + 1);
                    
                }
                else // missed consecutive days. Reset daily bonus from day one
                {
                    ResetDailyBonus();
					dailyClaim = CustomPref.GetPrefs(GameConstants.dailyClaim);
                    ArrangeDailyBonus(dailyClaim + 1);
                }
            }
        
    }
   
    public void ArrangeDailyBonus(int _dailyClaim)
    {
		day = _dailyClaim;
        for (int i = 1; i < _dailyBonuses.Count + 1; i++)
        {
            if (i < _dailyClaim)
            {
                _dailyBonuses[i-1]._claimState = DailyBonus.ClaimState.claimed;
                _dailyBonuses[i-1].StateUpdate();
            }
            else if (i == _dailyClaim)
            {
                _dailyBonuses[i-1]._claimState = DailyBonus.ClaimState.readyToclaim;
                _dailyBonuses[i-1].StateUpdate();
            }
            else
            {
                _dailyBonuses[i-1]._claimState = DailyBonus.ClaimState.notReadyToClaim;
                _dailyBonuses[i-1].StateUpdate();
            }
        }
        dailyBonusMenu.SetActive(true);
        dailyBonusMenuBtn.gameObject.SetActive(true);
        claimButton.interactable = true;
    }

    public TimeSpan CompareDates(DateTime dateOld, DateTime dateNew)
    {
        return dateNew - dateOld;
    }

    /// <summary>
    /// ClaimBonus() is getting called from outside through button
    /// and it is handling multiple responsiblities like,
    /// deactivating buttons, setting preference of current date, 
    /// setting reward, chaning UI states of daily bonus objects 
    /// 
    /// </summary>
    public void ClaimBonus()
    {
        DeActiveButtons();
        CustomPref.SetPrefs(GameConstants.dailyClaim, day);
        Invoke("CloseDailyBonus", vanishTimer);
        AwardDailyBonus(today, 1);
        StateUpdate();
        CustomPref.SetPrefs(GameConstants.coins, _dailyBonuses[day - 1].rewardAmount + CustomPref.GetPrefs(GameConstants.coins));
        //Pop reward panel
        ShowPopUpPanel(_dailyBonuses[day - 1].rewardAmount);
        // Firing Event to set Coins Value in UI Text
        Events.DoOnSetCoins(CustomPref.GetPrefs(GameConstants.coins));
        AudioController.Instance.PlayBtnSound();
    }
    private void ShowPopUpPanel(int amount)
    {
        popUpPanel.ShowPop(amount);
    }
    void StateUpdate()
    {
        _dailyBonuses[day - 1]._claimState = DailyBonus.ClaimState.claimed;
        _dailyBonuses[day - 1].StateUpdate();
    }
    public void ResetDailyBonus()
    {
        CustomPref.SetPrefs(GameConstants.dailyClaim, 0);
    }

    public void ResetPrevious()
    {
        CustomPref.SetPrefs(GameConstants.bonusYear,2000);
        CustomPref.SetPrefs(GameConstants.bonusMonth, 2);
        CustomPref.SetPrefs(GameConstants.bonusDay, 4);
    }
    public void OpenDailyBonus() // calling from out side through buttons
    {
        dailyBonusMenu.SetActive(true);
        AudioController.Instance.PlayBtnSound();
    }
    public void CloseDailyBonus()// calling from out side through buttons
    {
	    dailyBonusMenu.SetActive(false);
        AudioController.Instance.PlayBtnSound();
    }
   
    private void DeActiveButtons()
    {
        claimButton.interactable = false;
        dailyBonusMenuBtn.gameObject.SetActive(false);
    }
    public void AwardDailyBonus(DateTime day, int dayBonus)
    {
        CustomPref.SetPrefs(GameConstants.bonusDay, day.Day);
        CustomPref.SetPrefs(GameConstants.bonusMonth, day.Month);
        CustomPref.SetPrefs(GameConstants.bonusYear, day.Year);
        CustomPref.SavePrefs();
        previous = new DateTime(CustomPref.GetPrefs(GameConstants.bonusYear), CustomPref.GetPrefs(GameConstants.bonusMonth), CustomPref.GetPrefs(GameConstants.bonusDay));
    }

    void SetDefaultState()
    {
        claimButton.interactable = false;
        dailyBonusMenuBtn.gameObject.SetActive(false);
        for (int i = 0; i < _dailyBonuses.Count; i++)
        {
            _dailyBonuses[i].StateUpdate();
        }
    }

}
