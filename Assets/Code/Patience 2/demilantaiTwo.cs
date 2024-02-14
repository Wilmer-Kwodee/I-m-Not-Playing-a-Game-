using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demilantaiTwo : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        BallManagerTwo.zonaKematian = true;
    }
}
