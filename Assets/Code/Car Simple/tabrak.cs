using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabrak : MonoBehaviour
{
    public Transform[] spinnycircle;
    public float rotatSped;

    void Update()
    {
        for(int i = 0; i < spinnycircle.Length; i++)
        {
            Vector3 newEulerAngles = spinnycircle[i].eulerAngles;
            newEulerAngles.z -= rotatSped;
            spinnycircle[i].transform.eulerAngles = newEulerAngles;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {            
            if (GameObject.Find("CarSimpleManager") != null)
                CarSimpleManager.isOver = true;
            else
                CarMorningManager.isOver = true;
        }
    }
}
