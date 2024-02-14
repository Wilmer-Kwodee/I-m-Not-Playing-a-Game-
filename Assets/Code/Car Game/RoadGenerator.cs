using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public bool isStraight;
    public bool isLeft;
    public bool isRight;
    public Transform FrontTarget;

    public static int undian;
    private float selisih;
    private GameObject Playa;
    private bool telahDinonaktifkan = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //checkDistance();
        if(telahDinonaktifkan == false)
            startStuffs();
    }

    private void startStuffs()
    {
        telahDinonaktifkan = true;

        Playa = GameObject.FindWithTag("Player");

        if (isStraight == true)
        {
            ReportStraight2RG();
        }
        if (isLeft == true)
        {
            ReportLeft2RG();
        }
        if (isRight == true)
        {
            ReportRight2RG();
        }

        Invoke("genRoad", 1);
        Invoke("itsTaim2Daii", 10);
    }
    private void cekpattern()
    {
        if (TrackTracker.pattern[0] == "straight" && TrackTracker.pattern[1] == "right" && TrackTracker.pattern[2] == "right")
        {
            if (undian == 3)
            {
                int undianbaru = Random.Range(1, 3);
                undian = undianbaru;
            }
        }
        if (TrackTracker.pattern[0] == "straight" && TrackTracker.pattern[1] == "left" && TrackTracker.pattern[2] == "left")
        {
            if (undian == 2)
            {
                int undianbaru = Random.Range(0, 2);
                if (undianbaru == 0)
                {
                    undianbaru = 1;
                }
                else
                    undianbaru = 3;
                undian = undianbaru;
            }
        }
        if (TrackTracker.pattern[0] == "left" && TrackTracker.pattern[1] == "left" && TrackTracker.pattern[2] == "left")
        {
            undian = 3;
        }
        if (TrackTracker.pattern[0] == "right" && TrackTracker.pattern[1] == "right" && TrackTracker.pattern[2] == "right")
        {
            undian = 2;
        }
        if (TrackTracker.pattern[0] == "left" && TrackTracker.pattern[1] == "left" && TrackTracker.pattern[2] == "straight")
        {
            undian = 3;
        }
        if (TrackTracker.pattern[0] == "right" && TrackTracker.pattern[1] == "right" && TrackTracker.pattern[2] == "straight")
        {
            undian = 2;
        }
    }
    private void genRoad()
    {
        undian = Random.Range(1, 4);
        cekpattern();

        if (undian == 1)
        {           
            if(isStraight == true)
            {
                //Instantiate(straight, FrontTarget.position, transform.rotation);
                ObjectPooler.Instance.SpawnFromPool("lurus", FrontTarget.position, transform.rotation);
            }
            if (isLeft == true)
            {
                //MECHANISM BIAR ROTATIONNYA BENER, JADI DITAMBAH SEKIAN DERAJAT, BUKAN DI "SET"
                Vector3 newEulerAngles = transform.eulerAngles;
                newEulerAngles.y -= 90f;
                //Instantiate(straight, FrontTarget.position, Quaternion.Euler(newEulerAngles));
                ObjectPooler.Instance.SpawnFromPool("lurus", FrontTarget.position, Quaternion.Euler(newEulerAngles));
            }
            if (isRight == true)
            {
                //MECHANISM BIAR ROTATIONNYA BENER, JADI DITAMBAH SEKIAN DERAJAT, BUKAN DI "SET"
                Vector3 newEulerAngles = transform.eulerAngles;
                newEulerAngles.y += 90f;
                //Instantiate(straight, FrontTarget.position, Quaternion.Euler(newEulerAngles));
                ObjectPooler.Instance.SpawnFromPool("lurus", FrontTarget.position, Quaternion.Euler(newEulerAngles));
            }
        }
        if (undian == 2)
        {
            if (isStraight == true)
            {
                //Instantiate(left, FrontTarget.position, transform.rotation);
                ObjectPooler.Instance.SpawnFromPool("kiri", FrontTarget.position, transform.rotation);
            }
            if (isLeft == true)
            {
                //MECHANISM BIAR ROTATIONNYA BENER, JADI DITAMBAH SEKIAN DERAJAT, BUKAN DI "SET"
                Vector3 newEulerAngles = transform.eulerAngles;
                newEulerAngles.y -= 90f;
                //Instantiate(left, FrontTarget.position, Quaternion.Euler(newEulerAngles));
                ObjectPooler.Instance.SpawnFromPool("kiri", FrontTarget.position, Quaternion.Euler(newEulerAngles));
            }
            if (isRight == true)
            {
                //MECHANISM BIAR ROTATIONNYA BENER, JADI DITAMBAH SEKIAN DERAJAT, BUKAN DI "SET"
                Vector3 newEulerAngles = transform.eulerAngles;
                newEulerAngles.y += 90f;
                //Instantiate(left, FrontTarget.position, Quaternion.Euler(newEulerAngles));
                ObjectPooler.Instance.SpawnFromPool("kiri", FrontTarget.position, Quaternion.Euler(newEulerAngles));
            }
        }
        if (undian == 3)
        {
            if (isStraight == true)
            {
                //Instantiate(right, FrontTarget.position, transform.rotation);
                ObjectPooler.Instance.SpawnFromPool("kanan", FrontTarget.position, transform.rotation);
            }
            if (isLeft == true)
            {
                //MECHANISM BIAR ROTATIONNYA BENER, JADI DITAMBAH SEKIAN DERAJAT, BUKAN DI "SET"
                Vector3 newEulerAngles = transform.eulerAngles;
                newEulerAngles.y -= 90f;
                //Instantiate(right, FrontTarget.position, Quaternion.Euler(newEulerAngles));
                ObjectPooler.Instance.SpawnFromPool("kanan", FrontTarget.position, Quaternion.Euler(newEulerAngles));
            }
            if (isRight == true)
            {
                //MECHANISM BIAR ROTATIONNYA BENER, JADI DITAMBAH SEKIAN DERAJAT, BUKAN DI "SET"
                Vector3 newEulerAngles = transform.eulerAngles;
                newEulerAngles.y += 90f;
                //Instantiate(right, FrontTarget.position, Quaternion.Euler(newEulerAngles));
                ObjectPooler.Instance.SpawnFromPool("kanan", FrontTarget.position, Quaternion.Euler(newEulerAngles));
            }
        }
    }
    

    private void checkDistance()
    {
        selisih = transform.position.z - Playa.transform.position.z;

        if(selisih > 10)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
    private void itsTaim2Daii()
    {
        gameObject.SetActive(false);
        telahDinonaktifkan = false;
        //Destroy(gameObject);
    }
    private void ReportStraight2RG()
    {
        // intinya ini buat mekanisme isi slot array mekanisme antrian 3
        int i = 0;
        if (TrackTracker.pattern[i] == null) // periksa yang slot 0, apakah kosong (null) atau tidak, kalo iya isi
        {
            TrackTracker.pattern[i] = "straight";
        }
        else
            i += 1;

        if (TrackTracker.pattern[i] == null) // periksa yang slot 1, apakah kosong (null) atau tidak, kalo iya isi
        {
            TrackTracker.pattern[i] = "straight";
        }
        else
            i += 1;

        if (TrackTracker.pattern[i] == null) // periksa yang slot 2, apakah kosong (null) atau tidak, kalo iya isi
        {
            TrackTracker.pattern[i] = "straight";
        }
        else // jika ngdak kosong, maka geser mundur kebelakang dan buang yang paling belakang, isi di paling depan
        {
            TrackTracker.pattern[0] = TrackTracker.pattern[1];
            TrackTracker.pattern[1] = TrackTracker.pattern[2];
            TrackTracker.pattern[2] = "straight";
        }
    }
    private void ReportLeft2RG()
    {
        int i = 0;
        if (TrackTracker.pattern[i] == null)
        {
            TrackTracker.pattern[i] = "left";
        }
        else
            i += 1;

        if (TrackTracker.pattern[i] == null)
        {
            TrackTracker.pattern[i] = "left";
        }
        else
            i += 1;

        if (TrackTracker.pattern[i] == null)
        {
            TrackTracker.pattern[i] = "left";
        }
        else
        {
            TrackTracker.pattern[0] = TrackTracker.pattern[1];
            TrackTracker.pattern[1] = TrackTracker.pattern[2];
            TrackTracker.pattern[2] = "left";
        }
    }
    private void ReportRight2RG()
    {
        int i = 0;
        if (TrackTracker.pattern[i] == null)
        {
            TrackTracker.pattern[i] = "right";
        }
        else
            i += 1;

        if (TrackTracker.pattern[i] == null)
        {
            TrackTracker.pattern[i] = "right";
        }
        else
            i += 1;

        if (TrackTracker.pattern[i] == null)
        {
            TrackTracker.pattern[i] = "right";
        }
        else
        {
            TrackTracker.pattern[0] = TrackTracker.pattern[1];
            TrackTracker.pattern[1] = TrackTracker.pattern[2];
            TrackTracker.pattern[2] = "right";
        }
    }
}
