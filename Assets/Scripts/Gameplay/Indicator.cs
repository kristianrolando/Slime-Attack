using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public PlayerAttack player;

    public Animator animIndicatorRight;
    public Animator animIndicatorLeft;

    void Update()
    {
        if (player.statEnimiesRight)
            animIndicatorRight.SetBool("detected", true);
        else
            animIndicatorRight.SetBool("detected", false);

        if (player.statEnimiesLeft)
            animIndicatorLeft.SetBool("detected", true);
        else
            animIndicatorLeft.SetBool("detected", false);
    }
}
