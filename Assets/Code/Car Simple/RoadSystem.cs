using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSystem : MonoBehaviour
{
    public Transform carTargetLeft;
    public Transform carTargetMid;
    public Transform carTargetRight;
    private int epicSmolLogik;
    private bool telahDiNonaktifkan;
    public GameObject[] lampu;


    // Start is called before the first frame update
    void Start()
    {
        int theKode = CarSimpleManager.bombTimer;
        if (theKode == 15)
        {
            for (int i = 0; i < lampu.Length; i++)
            {
                lampu[i].SetActive(false);
            }
        }   
        //spawnTraffic();
        //spawnTraffic();
        //spawnTraffic();
        Invoke("selfDestruction", theKode);
    }

    // Update is called once per frame
    void Update()
    {
        checkLampDie();
        if (telahDiNonaktifkan == false)
        {
            telahDiNonaktifkan = true;
            for(int i = 0; i < 3; i++)
            {
                spawnTraffic();
            }
        }
    }

    #region PrivateVoids
    private void selfDestruction()
    {
        gameObject.SetActive(false);
        telahDiNonaktifkan = false;
    }
    private void checkLampDie()
    {
        if (CarSimpleManager.lampujalananMATILAH == true)
        {
            for (int i = 0; i < lampu.Length; i++)
            {
                lampu[i].SetActive(false);
            }
        }
    }
    private void spawnTraffic()
    {
        //if (Time.time > when2Spawn)
        //{
            int undianPermata = Random.Range(0, 3);
            switch (undianPermata)
            {
                case 0:
                    spawnLeft();
                    break;

                case 1:
                    spawnMid();
                    break;

                case 2:
                    spawnRight();
                    break;
            }
            //when2Spawn = Time.time + spawnRate;

            Vector3 newPosisi1 = new Vector3(carTargetLeft.position.x, carTargetLeft.position.y, carTargetLeft.position.z - 33);
            carTargetLeft.position = newPosisi1;
            Vector3 newPosisi2 = new Vector3(carTargetMid.position.x, carTargetMid.position.y, carTargetMid.position.z - 33);
            carTargetMid.position = newPosisi2;
            Vector3 newPosisi3 = new Vector3(carTargetRight.position.x, carTargetRight.position.y, carTargetRight.position.z - 33);
            carTargetRight.position = newPosisi3;
        //}
    }
    private void spawnLeft()
    {
        int undianKedau = Random.Range(0, 3);
        switch (undianKedau)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("car1", carTargetLeft.position, Quaternion.identity);
                break;

            case 1:
                ObjectPooler.Instance.SpawnFromPool("car2", carTargetLeft.position, Quaternion.identity);
                break;

            case 2:
                ObjectPooler.Instance.SpawnFromPool("car3", carTargetLeft.position, Quaternion.identity);
                break;
        }
    }
    private void spawnMid()
    {
        int undianKedau = Random.Range(0, 3);
        switch (undianKedau)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("car1", carTargetMid.position, Quaternion.identity);
                break;

            case 1:
                ObjectPooler.Instance.SpawnFromPool("car2", carTargetMid.position, Quaternion.identity);
                break;

            case 2:
                ObjectPooler.Instance.SpawnFromPool("car3", carTargetMid.position, Quaternion.identity);
                break;
        }

    }
    private void spawnRight()
    {
        int undianKedau = Random.Range(0, 3);
        switch (undianKedau)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("car1", carTargetRight.position, Quaternion.identity);
                break;

            case 1:
                ObjectPooler.Instance.SpawnFromPool("car2", carTargetRight.position, Quaternion.identity);
                break;

            case 2:
                ObjectPooler.Instance.SpawnFromPool("car3", carTargetRight.position, Quaternion.identity);
                break;
        }
    }
    #endregion
}
