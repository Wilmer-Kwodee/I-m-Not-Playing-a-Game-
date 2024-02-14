using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheRandomizer : MonoBehaviour
{
    public GameObject B;
    public GameObject T;
    public GameObject Z;
    public Transform l1;
    public Transform l2;
    public Transform l3;
    public Transform r1;
    public Transform r2;
    public Transform r3;

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
        //if (B.transform.position.y < -13.2f | T.transform.position.y < -13.2f | Z.transform.position.y < -13.2f)
        //{
            //JATUHLAH();
        //}
    }



    // PRIVATE VOIDS
    private void cekPosisi()
    {
        if (transform.position.x < -8.4f)
        {
            moveSpeed = 1;
            acakGenRight();
            kiriAtokanan = true;
        }
        else
        {
            moveSpeed = -1;
            kiriAtokanan = false;
            acakGenLeft();
        }        
    }
    public void Reverse()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < -17 && kiriAtokanan == false && gameObject != null)
        {
            gameObject.SetActive(false);
            bangkitKembali = false;
            SpawnerHole.mayIspawn = true;
        }
        if (transform.position.x > 25 && kiriAtokanan == true && gameObject != null)
        {
            gameObject.SetActive(false);
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
            bangkitKembali = false;
            SpawnerHole.mayIspawn = true;
        }
    }
    private void acakGenLeft()
    {
        // penentuan sang pertama (dari belakang)
        int acakGenerator = Random.Range(1, 4);
        switch (acakGenerator)
        {
            case 1:
                B.transform.position = l1.transform.position;
                break;
            case 2:
                B.transform.position = l2.transform.position;
                break;
            case 3:
                B.transform.position = l3.transform.position;
                break;
        }
        // penentuan sang kedua
        int acakGenerator2 = Random.Range(1, 4);
        switch (acakGenerator2)
        {
            case 1:
                if (B.transform.position != l1.transform.position)
                    T.transform.position = l1.transform.position;
                else
                    T.transform.position = l3.transform.position;
                break;
            case 2:
                if (B.transform.position != l2.transform.position)
                    T.transform.position = l2.transform.position;
                else
                    T.transform.position = l1.transform.position;
                break;
            case 3:
                if (B.transform.position != l3.transform.position)
                    T.transform.position = l3.transform.position;
                else
                    T.transform.position = l2.transform.position;
                break;
        }
        // penentuan sang terdepan
        int acakGenerator3 = Random.Range(1, 4);
        switch (acakGenerator3)
        {
            case 1:
                if (B.transform.position != l1.transform.position && T.transform.position != l1.transform.position) 
                    Z.transform.position = l1.transform.position;
                else
                    if(B.transform.position != l2.transform.position && T.transform.position != l2.transform.position)
                        Z.transform.position = l2.transform.position;
                    else
                        Z.transform.position = l3.transform.position;
                break;
            case 2:
                if (B.transform.position != l2.transform.position && T.transform.position != l2.transform.position)
                    Z.transform.position = l2.transform.position;
                else
                    if (B.transform.position != l3.transform.position && T.transform.position != l3.transform.position)
                        Z.transform.position = l3.transform.position;
                    else
                        Z.transform.position = l1.transform.position;
                break;
            case 3:
                if (B.transform.position != l3.transform.position && T.transform.position != l3.transform.position)
                    Z.transform.position = l3.transform.position;
                else
                    if (B.transform.position != l2.transform.position && T.transform.position != l2.transform.position)
                        Z.transform.position = l2.transform.position;
                    else
                        Z.transform.position = l1.transform.position;
                break;
        }

        Vector3 newPosisi = new Vector3(14.57f, -13.111f, 5.2912f);
        transform.position = newPosisi;
    }
    private void acakGenRight()
    {
        // penentuan sang pertama (dari belakang)
        int acakGenerator = Random.Range(1, 4);
        switch (acakGenerator)
        {
            case 1:
                B.transform.position = r1.transform.position;
                break;
            case 2:
                B.transform.position = r2.transform.position;
                break;
            case 3:
                B.transform.position = r3.transform.position;
                break;
        }
        // penentuan sang kedua
        int acakGenerator2 = Random.Range(1, 4);
        switch (acakGenerator2)
        {
            case 1:
                if (B.transform.position != r1.transform.position)
                    T.transform.position = r1.transform.position;
                else
                    T.transform.position = r3.transform.position;
                break;
            case 2:
                if (B.transform.position != r2.transform.position)
                    T.transform.position = r2.transform.position;
                else
                    T.transform.position = r1.transform.position;
                break;
            case 3:
                if (B.transform.position != r3.transform.position)
                    T.transform.position = r3.transform.position;
                else
                    T.transform.position = r2.transform.position;
                break;
        }
        // penentuan sang terdepan
        int acakGenerator3 = Random.Range(1, 4);
        switch (acakGenerator3)
        {
            case 1:
                if (B.transform.position != r1.transform.position && T.transform.position != r1.transform.position)
                    Z.transform.position = r1.transform.position;
                else
                    if (B.transform.position != r2.transform.position && T.transform.position != r2.transform.position)
                    Z.transform.position = r2.transform.position;
                else
                    Z.transform.position = r3.transform.position;
                break;
            case 2:
                if (B.transform.position != r2.transform.position && T.transform.position != r2.transform.position)
                    Z.transform.position = r2.transform.position;
                else
                    if (B.transform.position != r3.transform.position && T.transform.position != r3.transform.position)
                    Z.transform.position = r3.transform.position;
                else
                    Z.transform.position = r1.transform.position;
                break;
            case 3:
                if (B.transform.position != r3.transform.position && T.transform.position != r3.transform.position)
                    Z.transform.position = r3.transform.position;
                else
                    if (B.transform.position != r2.transform.position && T.transform.position != r2.transform.position)
                    Z.transform.position = r2.transform.position;
                else
                    Z.transform.position = r1.transform.position;
                break;
        }

        Vector3 newPosisi = new Vector3(-8.5f, -13.111f, 5.2912f);
        transform.position = newPosisi; 
    }
}
