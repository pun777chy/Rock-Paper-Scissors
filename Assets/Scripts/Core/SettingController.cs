using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingController : MonoBehaviour
{
    public GameObject settingPanel;
    public Text soundTxt;
    private void Awake()
    {
        SetSettingStats();
    }
    private  void SetSettingStats()
    {
        if (CustomPref.GetPrefs(GameConstants.sound, 1) == 0)
        {
            soundTxt.text = "Off";
        }
        else
        {
            soundTxt.text = "On";
        }
    }
  public void SoundOnOff()
    {
        if(CustomPref.GetPrefs(GameConstants.sound, 1)==0)
        {
            soundTxt.text = "On";
            CustomPref.SetPrefs(GameConstants.sound, 1);
        }
        else
        {
            soundTxt.text = "Off";
            CustomPref.SetPrefs(GameConstants.sound, 0);
        }
        AudioController.Instance.PlayBtnSound();
    }
    public void OpenSettingPanel(bool show)
    {
        settingPanel.SetActive(show);
        AudioController.Instance.PlayBtnSound();
    }

}
