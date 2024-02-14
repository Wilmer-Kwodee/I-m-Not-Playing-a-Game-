using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayaBrain : MonoBehaviour
{
    private bool firee;
    private bool isReloading;
    public Transform bulTarget;
    public float nextFire = 0f;
    public float fireRate = 15f;
    public static int ammoVar;
    public static int ammoTotal;
    public Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        //ammoTotal = 120;
        //ammoVar = 12;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        //SEMI AUTO FIRE (HOLDDOWN) (SPRAY) MECHANISM
        if (firee == true && Time.time >= nextFire)
        {
            if (ammoVar > 0)
            {
                if (anime.GetBool("BANG") == false)
                {
                    firee = false;
                    anime.SetBool("BANG", true);
                    nextFire = Time.time + 1f / fireRate;
                    ObjectPooler.Instance.SpawnFromPool("peluru", bulTarget.position, bulTarget.rotation);
                    ammoVar -= 1;
                }
            }
        }
    }
    public void untukPistolS()
    {
        anime.SetBool("BANG", false);
    }
    public void untukPistolR()
    {
        anime.SetBool("BULLET", false);

        int ammoSisa = 12 - ammoVar;
        ammoTotal -= ammoSisa;
        ammoVar = 12;
        if (ammoTotal < 0)
        {
            int ammoSementara = 0 - ammoTotal;
            ammoVar -= ammoSementara;
            ammoTotal = 0;
        }
        isReloading = false;
    }

    public void firehold()
    {
        if(isReloading == false) firee = true;
    }
    public void firelepas()
    {
        firee = false;
    }
    public void relod()
    {
        if (ammoVar < 12 && ammoTotal > 0)
        {
            isReloading = true;
            anime.SetBool("BULLET", true);
        }
    }
}
