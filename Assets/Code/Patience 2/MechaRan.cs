using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaRan : MonoBehaviour
{
    public GameObject B;
    public GameObject T;
    public GameObject Z;
    public GameObject B2;
    public GameObject T2;
    public GameObject Z2;

    private float moveSpeed = -1f;
    private float stopcode = 0;
    public static bool jatuhkan;
    private bool kiriAtokanan;
    private bool bangkitKembali;


    // Start is called before the first frame update
    void Start()
    {
        jatuhkan = false;
        bangkitKembali = false;
    }
    void Update()
    {
        if (bangkitKembali == false)
        {
            //Debug.Log("terperiksa!");
            cekPosisi();
            bangkitKembali = true;
        }
        if (stopcode == 0)
        {
            Reverse();
        }
        if (jatuhkan == true)
        {
            JATUHLAH();
        }
    }



    // PRIVATE VOIDS
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

        acakGen();
    }
    public void Reverse()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < -12 && kiriAtokanan == false && gameObject != null)
        {
            gameObject.SetActive(false);
            B.SetActive(false);
            T.SetActive(false);
            Z.SetActive(false);
            B2.SetActive(false);
            T2.SetActive(false);
            Z2.SetActive(false);
            bangkitKembali = false;
            spawnerTwo.mayIspawn = true;
        }
        if (transform.position.x > 16 && kiriAtokanan == true && gameObject != null)
        {
            gameObject.SetActive(false);
            B.SetActive(false);
            T.SetActive(false);
            Z.SetActive(false);
            B2.SetActive(false);
            T2.SetActive(false);
            Z2.SetActive(false);
            bangkitKembali = false;
            spawnerTwo.mayIspawn = true;
        }
    }
    private void JATUHLAH()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 6 * Time.deltaTime, transform.position.z);
        if (transform.position.y < -20 && gameObject != null)
        {
            jatuhkan = false;
            gameObject.SetActive(false);
            bangkitKembali = false;
            spawnerTwo.mayIspawn = true;
            B.SetActive(false);
            T.SetActive(false);
            Z.SetActive(false);
            B2.SetActive(false);
            T2.SetActive(false);
            Z2.SetActive(false);
        }
    }
    private void acakGen()
    {
        // penentuan sang pertama (dari belakang)
        int acakGenerator = Random.Range(1, 4);
        switch (acakGenerator)
        {
            case 1:
                B.SetActive(true);
                break;
            case 2:
                T.SetActive(true);
                break;
            case 3:
                Z.SetActive(true);
                break;
        }

        int acakGenerator2 = Random.Range(1, 4);
        switch (acakGenerator2)
        {
            case 1:
                if (acakGenerator != 1)
                    B2.SetActive(true);
                else
                    T2.SetActive(true);
                break;
            case 2:
                if (acakGenerator != 2)
                    T2.SetActive(true);
                else
                    B2.SetActive(true);
                break;
            case 3:
                if(acakGenerator != 3)
                    Z2.SetActive(true);
                else
                    T2.SetActive(true);
                break;
        }

    }
}
