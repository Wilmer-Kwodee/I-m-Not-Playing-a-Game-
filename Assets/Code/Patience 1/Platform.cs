using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float moveSpeed = -1f;
    private float stopcode = 0;
    public bool isZonk;
    public bool isTime;
    public bool isBall;
    private bool SUDAHMASOK;
    private bool jatuhkan;
    private bool kiriAtokanan;
    private bool bangkitKembali;

    void Start()
    {
        SUDAHMASOK = false;
        jatuhkan = false;
        bangkitKembali = false;
    }
    void Update()
    {       
        if(bangkitKembali == false)
        {
            //Debug.Log("terperiksa!");
            cekPosisi();
            bangkitKembali = true;
        }
        if (stopcode == 0)
        {
            Reverse();
        }
        if(jatuhkan == true)
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
                    BallManager.isTime = true;
                if (isZonk == true)
                    BallManager.isZonk = true;
                if (isBall == true)
                    BallManager.isBall = true;
        }
    }

    public void Reverse()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < -8 && kiriAtokanan == false && gameObject != null)
        {
            gameObject.SetActive(false);
            SUDAHMASOK = false;
            bangkitKembali = false;
            SpawnerHole.mayIspawn = true;
        }
        if (transform.position.x > 14.5f && kiriAtokanan == true && gameObject != null)
        {
            gameObject.SetActive(false);
            SUDAHMASOK = false;
            bangkitKembali = false;
            SpawnerHole.mayIspawn = true;
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
             SpawnerHole.mayIspawn = true;
        }
        
    }
    private void cekPosisi()
    {
        if (transform.position.x < -8.4f)
        {
            moveSpeed = 1;
            kiriAtokanan = true;
        }
        else
        {
            moveSpeed = -1;
            kiriAtokanan = false;
        }           
    }
}
