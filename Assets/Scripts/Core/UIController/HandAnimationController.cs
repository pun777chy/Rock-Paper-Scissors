using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandAnimationController : MonoBehaviour
{
    public Animator playerAnim;
    public Animator opponentAnim;

    public Image playerParentHand;
    public Image opponentParentHand;

    private string animationName = "Shake";
    public void OnEnable()
    {
        ActiveParentImage();
    }
    public void PlayAnimation()
    {
        playerAnim.SetTrigger(animationName);
        opponentAnim.SetTrigger(animationName);
    }

    public void DeActiveParentImage()
    {
        playerParentHand.enabled = false;
        opponentParentHand.enabled = false;
    }
    public void ActiveParentImage()
    {
        playerParentHand.enabled = true;
        opponentParentHand.enabled = true;
    }
}
