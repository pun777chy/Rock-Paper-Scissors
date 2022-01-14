using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// PopUpManager is specifically to display a pop up panel of reward getting from daily bonus
/// </summary>
public class PopUpManager : MonoBehaviour {
	[Header("Pop Up Panel")]
	public GameObject popUpPanel;
	[Header("Coins Label Text")]
	public Text coinTxt;
	public void ShowPop(int coin)
	{
		popUpPanel.SetActive (true);
		coinTxt.text = coin.ToString()+ " Coins";
		Invoke ("HidePopUP", 2.0f); 
	} 

	public void HidePopUP()
	{
		popUpPanel.SetActive (false);
	}
}
