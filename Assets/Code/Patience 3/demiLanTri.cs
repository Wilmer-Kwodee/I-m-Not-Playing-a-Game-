using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demiLanTri : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        BallManagerTri.zonaKematian = true;
    }
}
