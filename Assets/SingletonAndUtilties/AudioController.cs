using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AudioController is basic singleton class which is controlling sound effects on buttons and results
/// </summary>
public class AudioController : GenericSingleton<AudioController>
{
    public AudioSource source;
    /// <summary>
    /// Since we have a limited sounds so I am having references of audio clips.
    /// </summary>
    public AudioClip btnSound;
    public AudioClip winSound;
    public AudioClip lossSound;
    public AudioClip drawSound;

    public void PlayBtnSound()
    {
        source.clip = btnSound;
        if(CustomPref.GetPrefs(GameConstants.sound,1)==1)
        source.Play();
    }
    public void PlayWinSound()
    {
        source.clip = winSound;
        if (CustomPref.GetPrefs(GameConstants.sound,1) == 1)
            source.Play();
    }
    public void PlayLossSound()
    {
        source.clip = lossSound;
        if (CustomPref.GetPrefs(GameConstants.sound,1) == 1)
            source.Play();
    }
    public void PlayDrawSound()
    {
        source.clip = drawSound;
        if (CustomPref.GetPrefs(GameConstants.sound,1) == 1)
            source.Play();
    }
    public void PlayResultSound(UseableItem playerHand, UseableItem opponentHand)
    {
        Result drawResult = ResultAnalyzer.CalculateWinner( playerHand,  opponentHand);

        if (drawResult.Equals(Result.Won))
        {
           Invoke("PlayWinSound",0.2f); // Adding a delay so button click sound can be played before this one
        }
        else if (drawResult.Equals(Result.Lost))
        {
            Invoke("PlayLossSound", 0.2f); // Adding a delay so button click sound can be played before this one
        }
        else
        {
            Invoke("PlayDrawSound", 0.2f);  // Adding a delay so button click sound can be played before this one
        }

    }

}
