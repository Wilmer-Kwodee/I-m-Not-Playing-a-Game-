using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerTwo : MonoBehaviour
{
    public Transform spawnTargetKiri;
    public Transform spawnTargetKanan;
    private int hayoKiriAtoKanan;
    public static bool mayIspawn;

    // Start is called before the first frame update
    void Start()
    {
        mayIspawn = false;
        hayoKiriAtoKanan = Random.Range(0, 2);
        switch (hayoKiriAtoKanan)
        {
            case 0:
                spawnKiri();
                break;
            case 1:
                spawnKanan();
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mayIspawn == true)
        {
            switch (hayoKiriAtoKanan)
            {
                case 0:
                    spawnKiri();
                    break;
                case 1:
                    spawnKanan();
                    break;

            }
        }
    }
    private void spawnKiri()
    {
        mayIspawn = false;
        hayoKiriAtoKanan += 1;
        int randomObstacle = Random.Range(0, 2);
        switch (randomObstacle)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("b", spawnTargetKiri.position, transform.rotation);
                break;
            case 1:
                ObjectPooler.Instance.SpawnFromPool("t", spawnTargetKiri.position, transform.rotation);
                break;
        }
    }
    private void spawnKanan()
    {
        mayIspawn = false;
        hayoKiriAtoKanan -= 1;
        int randomObstacle = Random.Range(0, 2);
        switch (randomObstacle)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("b", spawnTargetKanan.position, transform.rotation);
                break;
            case 1:
                ObjectPooler.Instance.SpawnFromPool("t", spawnTargetKanan.position, transform.rotation);
                break;
        }
    }
}
