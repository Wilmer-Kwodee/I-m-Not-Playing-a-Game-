using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetScript : MonoBehaviour
{
    public bool close;
    public bool medium;
    public bool far;
    public float moveSpeed = -5f;
    private bool bolehjatuh = false;
    private bool sudahterpanggil = false;
    private bool udhDariKiri = false;
    private bool udhDariKanan = false;
    //private bool 

    // Start is called before the first frame update
    void Start()
    {
        //POSITIANCEKKHE();
    }

    void OnCollisionEnter(Collision collisioninfo)
    {
        if(sudahterpanggil == false)
        {
            sudahterpanggil = true;
            if (close == true)
            {
                if(SceneManager.GetActiveScene().name == "Shootroz 1") ShootingManager.dipersilahkanDekat = true;
                else ShootingGManagerTwo.dipersilahkanDekat = true;
            }
            if (medium == true)
            {
                if (SceneManager.GetActiveScene().name == "Shootroz 1") ShootingManager.dipersilahkanSedang = true;
                else ShootingGManagerTwo.dipersilahkanSedang = true;
            }
            if (far == true)
            {
                if (SceneManager.GetActiveScene().name == "Shootroz 1") ShootingManager.dipersilahkanJauh = true;
                else ShootingGManagerTwo.dipersilahkanJauh = true;
            }
            bolehjatuh = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bergerak();
        JATUHLAH();
    }


    private void POSITIANCEKKHE()
    {
        if(transform.position.x == -5)
        {
            float balikarah = moveSpeed * -1;
            moveSpeed = balikarah;
        }
    }
    private void bergerak()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < -5.5f && gameObject != null && udhDariKiri == false)
        {
            udhDariKiri = true;
            udhDariKanan = false;
            float balikarah = moveSpeed * - 1;
            moveSpeed = balikarah;
        }
        if (transform.position.x > 6.4f && gameObject != null && udhDariKanan == false)
        {
            udhDariKanan = true;
            udhDariKiri = false;
            float balikarah = moveSpeed * -1;
            moveSpeed = balikarah;
        }
    }
    private void JATUHLAH()
    {
        if(bolehjatuh == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 4 * Time.deltaTime, transform.position.z);
            if (transform.position.y < -1 && gameObject != null)
            {
                sudahterpanggil = false;
                bolehjatuh = false;
                gameObject.SetActive(false);
            }
        }
    }
}
