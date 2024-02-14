using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatTri : MonoBehaviour
{
    public float moveSpeed = -1f;
    private float stopcode = 0;
    public bool isZonk;
    public bool isTime;
    public bool isBall;
    private bool SUDAHMASOK;
    private bool jatuhkan;
    private bool bangkitKembali;

    void Update()
    {
        if (stopcode == 0)
        {
            Reverse();
        }
        if (jatuhkan == true)
        {
            JATUHLAH();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (SUDAHMASOK == false)
        {
            SUDAHMASOK = true;
            jatuhkan = true;
            if (isTime == true)
                BallManagerTri.isTime = true;
            if (isZonk == true)
                BallManagerTri.isZonk = true;
            if (isBall == true)
                BallManagerTri.isBall = true;
        }
    }

    public void Reverse()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < -8 && gameObject != null)
        {
            gameObject.SetActive(false);
            SUDAHMASOK = false;
            bangkitKembali = false;
        }
    }

    private void JATUHLAH()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 6 * Time.deltaTime, transform.position.z);
        if (transform.position.y < -20 && gameObject != null)
        {
            jatuhkan = false;
            gameObject.SetActive(false);
            SUDAHMASOK = false;
            bangkitKembali = false;
        }
    }
}
