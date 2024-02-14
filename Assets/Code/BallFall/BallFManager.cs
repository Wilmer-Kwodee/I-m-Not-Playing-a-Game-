using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallFManager : MonoBehaviour
{
    public static BallFManager instance = null;
    public Rigidbody[] ball;
    public GameObject[] bAll;
    public static int POWAAA;
    public Transform ballTarget;
    public static bool LAUNCH;
    public static bool dipersilahkan;
    public static bool SPAWN;
    private int bolake = 0;

    public GameObject failUI;
    public GameObject winUI;
    public Text ballText;
    private int ballCount = 10;
    public Text pointsText;
    public int PointCount = 0;
    public Transform theLauncher;
    public GameObject commonUI;
    public GameObject uncommonUI;
    public GameObject prejackUI;
    public GameObject jackpotUI;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        dipersilahkan = true;
        POWAAA = 0;
        LAUNCH = false;
        SPAWN = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(LAUNCH == true)
        {
            if(dipersilahkan == true) Launche();
        }
        if (SPAWN == true)
        {
            reSpawne();
        }
        updateUIs();
        checkLose();
        checkwin();
    }




    // private voids
    private void Launche()
    {
        StartCoroutine(thePendorong());
        ballCount -= 1;
        LAUNCH = false;
        ball[bolake].velocity = Vector2.right * POWAAA;
        POWAAA = 0;
        dipersilahkan = false;
    }
    IEnumerator thePendorong()
    {
        switch (POWAAA)
        {
            case 5:
                #region someSimpleMechanismYeaaa0
                Vector3 oldPositionx = theLauncher.position;
                Vector3 newPosisix = new Vector3(theLauncher.position.x + 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisix;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi1x = new Vector3(theLauncher.position.x + 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi1x;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi7x = new Vector3(theLauncher.position.x - 1f, theLauncher.position.y, theLauncher.position.z);
                yield return new WaitForSeconds(0.05f);
                theLauncher.position = oldPositionx;
                #endregion
                break;
            case 25:
                #region someSimpleMechanismYeaaa1
                Vector3 oldPosition = theLauncher.position;
                Vector3 newPosisi = new Vector3(theLauncher.position.x + 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi1 = new Vector3(theLauncher.position.x + 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi1;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi2 = new Vector3(theLauncher.position.x + 1, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi2;
                yield return new WaitForSeconds(0.1f);
                Vector3 newPosisi7 = new Vector3(theLauncher.position.x - 2f, theLauncher.position.y, theLauncher.position.z);
                yield return new WaitForSeconds(0.05f);
                theLauncher.position = oldPosition;
                #endregion
                break;
            case 75:
                #region someSimpleMechanismYeaaa2
                Vector3 oldPosition1 = theLauncher.position;
                Vector3 newPosisiA = new Vector3(theLauncher.position.x + 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisiA;
                yield return new WaitForSeconds(0.025f);
                Vector3 newPosisi1A = new Vector3(theLauncher.position.x + 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi1A;
                yield return new WaitForSeconds(0.025f);
                Vector3 newPosisi2A = new Vector3(theLauncher.position.x + 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi2A;
                yield return new WaitForSeconds(0.025f);
                Vector3 newPosisi3A = new Vector3(theLauncher.position.x + 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi3A;
                yield return new WaitForSeconds(0.025f);
                Vector3 newPosisi4A = new Vector3(theLauncher.position.x + 0.5f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi4A;
                yield return new WaitForSeconds(0.05f);
                Vector3 newPosisi7A = new Vector3(theLauncher.position.x - 2f, theLauncher.position.y, theLauncher.position.z);
                theLauncher.position = newPosisi7A;
                yield return new WaitForSeconds(0.05f);
                theLauncher.position = oldPosition1;
                break;
                #endregion
        }
    }
    private void reSpawne()
    {
        //ball.velocity = Vector3.zero;
        //ball.angularVelocity = Vector3.zero;
        if (ballCount > 0)
        {
            dipersilahkan = true;
            SPAWN = false;
            bolake += 1;
            bAll[bolake].SetActive(true);
            //bAll[bolake].transform.position = ballTarget.transform.position;
        }
    }
    private void updateUIs()
    {
        ballText.text = ballCount.ToString();
        pointsText.text = PointCount.ToString();
    }
    private void checkLose()
    {
        if(PointCount < 100)
        {
            int dedcount = 0;
            foreach (GameObject go in bAll)
            {
                if (!go.activeSelf)
                {
                    dedcount += 1;
                }
            }
            if (dedcount == 10 && bolake == 9) failUI.SetActive(true);
        }
    }
    private void checkwin()
    {
        if (PointCount >= 100)
        {
            PointCount = 100;
            winUI.SetActive(true);
        }
    }





    //Public voids
    public void Menu()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "MainMenu";
        fadeScript.instance.fadeOut();
    }
    public void common()
    {
        PointCount += 10;
        StartCoroutine(common2());
    }
    IEnumerator common2()
    {
        commonUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        commonUI.SetActive(false);
    }
    public void uncommon()
    {
        PointCount += 20;
        StartCoroutine(uncommon2());
    }
    IEnumerator uncommon2()
    {
        uncommonUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        uncommonUI.SetActive(false);
    }
    public void prejack()
    {
        PointCount += 50;
        StartCoroutine(prejack2());
    }
    IEnumerator prejack2()
    {
        prejackUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        prejackUI.SetActive(false);
    }
    public void jackpot()
    {
        PointCount += 100;
        StartCoroutine(jackpot2());
    }
    IEnumerator jackpot2()
    {
        jackpotUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        jackpotUI.SetActive(false);
    }
}
