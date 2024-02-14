using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float spidnpowa;
    private bool dipersilahkan;

    void Update()
    {
        if (FBirdManager.gameStopped == false)
        {
            if (HeliGManager.gameisOva == false)
            {
                dipersilahkan = true;
            }
            else
                dipersilahkan = false;
        }
        if (HeliGManager.gameisOva == false)
        {
            if (FBirdManager.gameStopped == false)
            {
                dipersilahkan = true;
            }
            else
                dipersilahkan = false;
        }

        if (dipersilahkan == true)
        {
            transform.position = new Vector3(transform.position.x + spidnpowa * Time.deltaTime, transform.position.y, transform.position.z);

            Vector3 teleportPos = new Vector3(11.7f, 0.79f, transform.position.z);

            if (transform.position.x < -11.82f)
            {
                transform.position = teleportPos;
            }
        }
    }
}
