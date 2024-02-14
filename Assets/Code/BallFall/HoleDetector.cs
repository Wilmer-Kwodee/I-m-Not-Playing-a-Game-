using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDetector : MonoBehaviour
{
    public bool common;
    public bool uncommon;
    public bool prejackpot;
    public bool jackpot;

    void OnCollisionEnter(Collision collision)
    {
        if (common)
            BallFManager.instance.common();
        if (uncommon)
            BallFManager.instance.uncommon();
        if (prejackpot)
            BallFManager.instance.prejack();
        if (jackpot)
            BallFManager.instance.jackpot();
    }
}
