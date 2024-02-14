using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHole : MonoBehaviour
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
            Debug.Log(hayoKiriAtoKanan);
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
        int randomObstacle = Random.Range(0, 6);
        switch(randomObstacle)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("b", spawnTargetKiri.position, transform.rotation);
                break;
            case 1:
                ObjectPooler.Instance.SpawnFromPool("t", spawnTargetKiri.position, transform.rotation);
                break;
            case 2:
                Vector3 newPosisi0 = new Vector3(spawnTargetKiri.position.x, -20, spawnTargetKiri.position.z);
                ObjectPooler.Instance.SpawnFromPool("z", newPosisi0, transform.rotation);
                break;
            case 3:
                Vector3 newPosisi = new Vector3(spawnTargetKiri.position.x, -20, spawnTargetKiri.position.z);
                ObjectPooler.Instance.SpawnFromPool("kel", newPosisi, transform.rotation);
                break;
            case 4:
                Vector3 newPosisi2 = new Vector3(spawnTargetKiri.position.x, -20, spawnTargetKiri.position.z);
                ObjectPooler.Instance.SpawnFromPool("kelz", newPosisi2, transform.rotation);
                break;
            case 5:
                Vector3 newPosisi3 = new Vector3(spawnTargetKiri.position.x, -20, spawnTargetKiri.position.z);
                ObjectPooler.Instance.SpawnFromPool("kelzbz", newPosisi3, transform.rotation);
                break;
        }
    }
    private void spawnKanan()
    {
        mayIspawn = false;
        hayoKiriAtoKanan -= 1;
        int randomObstacle = Random.Range(0, 6);
        switch (randomObstacle)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("b", spawnTargetKanan.position, transform.rotation);
                break;
            case 1:
                ObjectPooler.Instance.SpawnFromPool("t", spawnTargetKanan.position, transform.rotation);
                break;
            case 2:
                Vector3 newPosisi0 = new Vector3(spawnTargetKanan.position.x, -20, spawnTargetKanan.position.z);
                ObjectPooler.Instance.SpawnFromPool("z", newPosisi0, transform.rotation);
                break;
            case 3:
                Vector3 newPosisi = new Vector3(spawnTargetKanan.position.x, -20, spawnTargetKanan.position.z);
                ObjectPooler.Instance.SpawnFromPool("kel", newPosisi, transform.rotation);
                break;
            case 4:
                Vector3 newPosisi2 = new Vector3(spawnTargetKanan.position.x, -20, spawnTargetKanan.position.z);
                ObjectPooler.Instance.SpawnFromPool("kelz", newPosisi2, transform.rotation);
                break;
            case 5:
                Vector3 newPosisi3 = new Vector3(spawnTargetKanan.position.x, -20, spawnTargetKanan.position.z);
                ObjectPooler.Instance.SpawnFromPool("kelzbz", newPosisi3, transform.rotation);
                break;
        }
    }
}
