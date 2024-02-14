using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallManagerTri : MonoBehaviour
{
    public float spawnRate;
    private float nextSpawn;
    public static float POWAAA;
    public static bool isLaunching;
    public static bool controLock;
    public static bool isGameOva = false;
    public Rigidbody BALL;
    public GameObject theBoll;
    public GameObject gameOva;
    public GameObject gameWon;
    public Transform Btarget;
    public Text timeUI;
    public Text ballUI;
    public static int ballcount = 5;
    private float time = 11;

    public GameObject zonkPanel;
    public static bool isZonk;
    public GameObject timePanel;
    public static bool isTime;
    public GameObject ballPanel;
    public static bool isBall;
    public static bool zonaKematian;
    public Transform theLauncher;

    // Start is called before the first frame update
    void Start()
    {
        resetAll();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnHole();
        timeUIupdate();
        ballUIupdate();
        checkLaunch();
        checkGameStatus();
        checkBall();
        checkTime();
        checkWin();
        forZonk();
        forTime();
        forBall();
        BallOutCheck();
    }

    //Private voids
    private void SpawnHole()
    {
        if(Time.time > nextSpawn)
        {
            int whosnext = Random.Range(0, 3);
            switch(whosnext)
            {
                case 0:
                    ObjectPooler.Instance.SpawnFromPool("b", transform.position, transform.rotation);
                    break;
                case 1:
                    ObjectPooler.Instance.SpawnFromPool("t", transform.position, transform.rotation);
                    break;
                case 2:
                    ObjectPooler.Instance.SpawnFromPool("z", transform.position, transform.rotation);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }
    private void timeUIupdate()
    {
        if (time > 0)
        {
            timeUI.text = "Time: " + time.ToString("F0");
            time -= Time.deltaTime;
        }
    }
    private void ballUIupdate()
    {
        ballUI.text = "Ball: " + ballcount;
    }
    private void checkLaunch()
    {
        if (isLaunching == true)
        {
            StartCoroutine(thePendorong());
            BALL.velocity = Vector2.right * POWAAA * -1;
            isLaunching = false;
            POWAAA = 0;
        }
    }
    IEnumerator thePendorong()
    {
        switch (POWAAA)
        {
            case 6:
                #region someSimpleMechanismYeaaa1
                Vector3 oldPosition = theLauncher.position;
                Vector3 newPosisi = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi1 = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi1;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi2 = new Vector3(theLauncher.position.x - 1, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi2;
                yield return new WaitForSeconds(0.1f);
                Vector3 newPosisi7 = new Vector3(theLauncher.position.x + 2f, theLauncher.position.y, theLauncher.position.z);
                yield return new WaitForSeconds(0.05f);
                theLauncher.position = oldPosition;
                #endregion
                break;
            case 8:
                #region someSimpleMechanismYeaaa2
                Vector3 oldPosition1 = theLauncher.position;
                Vector3 newPosisiA = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisiA;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi1A = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi1A;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi2A = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi2A;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi3A = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi3A;
                Vector3 newPosisi4A = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi4A;
                yield return new WaitForSeconds(0.1f);
                Vector3 newPosisi7A = new Vector3(theLauncher.position.x + 2f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi7A;
                yield return new WaitForSeconds(0.05f);
                theLauncher.position = oldPosition1;
                break;
                #endregion
                break;
            case 25:
                #region someSimpleMechanismYeaaa3
                Vector3 oldPosition2 = theLauncher.position;
                Vector3 newPosisiB = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisiB;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi1B = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi1B;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi2B = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi2B;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi3B = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi3B;
                Vector3 newPosisi4B = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi4B;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi5B = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi5B;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi6B = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi6B;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi7B = new Vector3(theLauncher.position.x - 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi7B;
                yield return new WaitForSeconds(0.1f);
                Vector3 newPosisi8B = new Vector3(theLauncher.position.x + 2f, theLauncher.position.y, theLauncher.position.z);
                yield return new WaitForSeconds(0.05f);
                theLauncher.position = oldPosition2;
                break;
                #endregion
        }
    }
    private void spawnBall()
    {
        ballcount -= 1;
        if (ballcount > -1)
        {
            theBoll.transform.position = Btarget.position;
            BALL.velocity = Vector3.zero;
            BALL.angularVelocity = Vector3.zero;
            isLaunching = false;
            Invoke("demiWaktu", 0.3f);
        }
    }
    private void demiWaktu()
    {
        controLock = false;
    }
    private void checkGameStatus()
    {
        if (isGameOva == true)
        {
            Time.timeScale = 0;
            gameOva.SetActive(true);
        }
    }
    private void checkBall()
    {
        if (ballcount < 0)
        {
            ballcount = 0;
            isGameOva = true;
        }
    }
    private void checkTime()
    {
        if (time < 0)
        {
            isGameOva = true;
        }
    }
    private void checkWin()
    {
        if (time > 100)
        {
            gameWon.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void forZonk()
    {
        if (isZonk == true)
        {
            isZonk = false;
            zonkPanel.SetActive(true);
            time -= 20;
            StartCoroutine(zonkTimer());
        }
    }
    IEnumerator zonkTimer()
    {
        spawnBall();
        yield return new WaitForSeconds(1.5f);
        zonkPanel.SetActive(false);

    }
    private void forTime()
    {
        if (isTime == true)
        {
            isTime = false;
            timePanel.SetActive(true);
            time += 30;
            StartCoroutine(timeTimer());
        }
    }
    IEnumerator timeTimer()
    {
        spawnBall();
        yield return new WaitForSeconds(1.5f);
        timePanel.SetActive(false);

    }
    private void forBall()
    {
        if (isBall == true)
        {
            isBall = false;
            ballPanel.SetActive(true);
            ballcount += 2;
            StartCoroutine(ballTimer());
        }
    }
    IEnumerator ballTimer()
    {
        spawnBall();
        yield return new WaitForSeconds(1.5f);
        ballPanel.SetActive(false);

    }
    private void BallOutCheck()
    {
        if (zonaKematian == true)
        {
            zonaKematian = false;
            spawnBall();
            //StartCoroutine(outbTimer());
        }
    }
    IEnumerator outbTimer()
    {
        yield return new WaitForSeconds(1);
        spawnBall();
    }
    private void resetAll()
    {
        Time.timeScale = 1;
        ballcount = 3;
        time = 11;
        isLaunching = false;
        controLock = false;
        isGameOva = false;
        isZonk = false;
        isTime = false;
        isBall = false;
        zonaKematian = false;
    }


    //Public voids
    public void Menu()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "MainMenu";
        fadeScript.instance.fadeOut();
    }
    public void Retry()
    {
        fadeScript.sceneName = "restat";
        fadeScript.instance.fadeOut();
    }
}
