using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfGroup : MonoBehaviour
{
    public bool isZonk;
    public bool isTime;
    public bool isBall;
    private bool SUDAHMASOK;

    void Start()
    {
        SUDAHMASOK = false;
    }
    void Update()
    {
        if(TheRandomizer.jatuhkan == false)
        {
            SUDAHMASOK = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (SUDAHMASOK == false)
        {
            SUDAHMASOK = true;
            TheRandomizer.jatuhkan = true;
            if (isTime == true)
                BallManager.isTime = true;
            if (isZonk == true)
                BallManager.isZonk = true;
            if (isBall == true)
                BallManager.isBall = true;
        }
    }
}
