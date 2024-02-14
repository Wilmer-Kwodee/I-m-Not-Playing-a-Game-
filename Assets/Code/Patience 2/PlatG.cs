using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatG : MonoBehaviour
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
        if (MechaRan.jatuhkan == false)
        {
            SUDAHMASOK = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (SUDAHMASOK == false)
        {
            SUDAHMASOK = true;
            MechaRan.jatuhkan = true;
            if (isTime == true)
                BallManagerTwo.isTime = true;
            if (isZonk == true)
                BallManagerTwo.isZonk = true;
            if (isBall == true)
                BallManagerTwo.isBall = true;
        }
    }
}
