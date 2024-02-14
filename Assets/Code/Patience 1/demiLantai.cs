using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demiLantai : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        BallManager.zonaKematian = true;
    }
}
