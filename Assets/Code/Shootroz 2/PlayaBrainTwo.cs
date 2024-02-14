using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayaBrainTwo : MonoBehaviour
{
    private bool firee;
    private bool isReloading;
    public Transform bulTarget;
    public float nextFire = 0f;
    public float fireRate = 15f;
    public static int ammoVar;
    public static int ammoTotal;
    public Animator anime;
    public Transform forReco;

    // Start is called before the first frame update
    void Start()
    {
        //ammoTotal = 900;
        //ammoVar = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        //SEMI AUTO FIRE (HOLDDOWN) (SPRAY) MECHANISM
        if (firee == true) //&& Time.time >= nextFire)
        {
            if (ammoVar > 0)
            {
                if (anime.GetBool("BANGR") == false)
                {
                    anime.SetBool("BANGR", true);
                    //nextFire = Time.time + 1f / fireRate;
                    ObjectPooler.Instance.SpawnFromPool("peluru", bulTarget.position, bulTarget.rotation);
                    ammoVar -= 1;
                }
            }
        }
    }
    public void untukPistolS()
    {
        anime.SetBool("BANGR", false);
    }
    public void untukPistolR()
    {
        anime.SetBool("BULLETR", false);

        int ammoSisa = 30 - ammoVar;
        ammoTotal -= ammoSisa;
        ammoVar = 30;
        if (ammoTotal < 0)
        {
            int ammoSementara = 0 - ammoTotal;
            ammoVar -= ammoSementara;
            ammoTotal = 0;
        }
        isReloading = false;
    }
    public void recoilMechanism()
    {
        Vector3 newEulerAngles = forReco.eulerAngles;
        newEulerAngles.x -= 0.5f;
        forReco.eulerAngles = newEulerAngles;
    }

    public void firehold()
    {
        if (isReloading == false) firee = true;
    }
    public void firelepas()
    {
        firee = false;
    }
    public void relod()
    {
        if (ammoVar < 30 && ammoTotal > 0)
        {
            isReloading = true;
            anime.SetBool("BULLETR", true);
        }
    }
}
