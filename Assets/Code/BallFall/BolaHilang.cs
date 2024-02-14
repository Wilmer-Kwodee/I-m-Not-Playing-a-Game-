using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaHilang : MonoBehaviour
{
    private GameObject vvvhis;

    void Start()
    {
        vvvhis = gameObject;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Finish") vvvhis.SetActive(false);
    }
}
