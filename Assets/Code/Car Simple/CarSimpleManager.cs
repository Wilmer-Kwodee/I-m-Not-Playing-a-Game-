using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSimpleManager : MonoBehaviour
{
    public bool ezOne;
    public bool nightOne;
    public static int bombTimer;

    public Animator UIAnime;
    public GameObject loserPanel;
    public GameObject mirrorL;
    public GameObject mirrorR;
    public GameObject CameraF;
    public GameObject CameraB;
    public GameObject ScaryCar;
    public GameObject ScaryCar2;
    public Transform scaryTarget;
    public static bool lampujalananMATILAH;
    private bool spionCannot = false;

    public Text scoreDistance;
    private float score;
    private float nextSekor;
    public float nextSekorTarget;

    public static bool isOver;
    private bool alreadyOver;

    private bool playaHasEntered;

    public Transform theCar;
    public Transform theCarCam;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        playaHasEntered = false;
        isOver = false;
        score = 100.00f;
        lampujalananMATILAH = false;

        if (ezOne == true)
        {
            bombTimer = 15;
        }
        if (nightOne == true)
        {
            bombTimer = 7;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        selisihJarak();
        spawnRoad();
        checkGameOver();
        scoring();
        PEMAKSAAN();
    }

    private void selisihJarak()
    {
        float jarak = transform.position.z - theCar.position.z;
        if (jarak > -140f)
            playaHasEntered = true;
    }
    private void spawnRoad()
    {
        if (playaHasEntered == true)//Time.time > when2SpawnRoad)
        {
            playaHasEntered = false;
            ObjectPooler.Instance.SpawnFromPool("road", transform.position, Quaternion.identity);
            Vector3 newPosisi = new Vector3(transform.position.x, transform.position.y, transform.position.z - 100);
            transform.position = newPosisi;
        }
        
    }
    private void scoring()
    {
        scoreDistance.text = score.ToString("F2");
        if (Time.time > nextSekor)
        {
            if (score > 87)
            {
                score -= 0.01f;                
                nextSekor = Time.time + nextSekorTarget;
            }
            else
            {
                StartCoroutine(scoreError());
                Invoke("lampuMATILAH", 2);
                if (score < 87 && score > 86)
                {
                    ScaryCar.SetActive(true);
                    Vector3 thepos = new Vector3(19.2f, 6, scaryTarget.transform.position.z);
                    ScaryCar.transform.position = thepos;
                    Invoke("spawnScary2", 8);
                }                   
            }              
        }
    }

    private void checkGameOver()
    {
        if(score > 87)
        {
            if (alreadyOver != true)
            {
                if (isOver == true)
                {
                    alreadyOver = true;
                    StartCoroutine(camRotat());
                    StartCoroutine(camPos());
                    StartCoroutine(carRotat());
                    StartCoroutine(carPos());
                }
            }
        }
    }
    #region someSimpleTimeMechanism
    IEnumerator camRotat()
    {
        Vector3 newEulerAngles = theCarCam.eulerAngles;
        newEulerAngles.x += 9f;
        theCarCam.eulerAngles = newEulerAngles;
        yield return new WaitForSeconds(0.025f);
        Vector3 newEulerAngles2 = theCarCam.eulerAngles;
        newEulerAngles2.x += 9f;
        theCarCam.eulerAngles = newEulerAngles2;
        yield return new WaitForSeconds(0.025f);
        Vector3 newEulerAngles3 = theCarCam.eulerAngles;
        newEulerAngles3.x += 9f;
        theCarCam.eulerAngles = newEulerAngles3;
        yield return new WaitForSeconds(0.025f);
        Vector3 newEulerAngles4 = theCarCam.eulerAngles;
        newEulerAngles4.x += 9f;
        theCarCam.eulerAngles = newEulerAngles4;
        yield return new WaitForSeconds(0.025f);
        Vector3 newEulerAngles5 = theCarCam.eulerAngles;
        newEulerAngles5.x += 9f;
        theCarCam.eulerAngles = newEulerAngles5;
    }
    IEnumerator camPos()
    {
        Vector3 oldPosition = theCarCam.position;
        Vector3 newPosisi = new Vector3(theCarCam.position.x - 0.5f, theCarCam.position.y - 0.5f, theCarCam.position.z);
        theCarCam.position = newPosisi;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi1 = new Vector3(theCarCam.position.x - 0.5f, theCarCam.position.y - 0.5f, theCarCam.position.z);
        theCarCam.position = newPosisi1;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi2 = new Vector3(theCarCam.position.x - 0.5f, theCarCam.position.y - 0.5f, theCarCam.position.z);
        theCarCam.position = newPosisi2;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi3 = new Vector3(theCarCam.position.x + 0.5f, theCarCam.position.y + 0.5f, theCarCam.position.z);
        theCarCam.position = newPosisi3;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi4 = new Vector3(theCarCam.position.x + 0.5f, theCarCam.position.y + 0.5f, theCarCam.position.z);
        theCarCam.position = newPosisi4;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi5 = new Vector3(theCarCam.position.x + 0.5f, theCarCam.position.y + 0.5f, theCarCam.position.z);
        theCarCam.position = newPosisi5;

        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi6 = new Vector3(theCarCam.position.x - 0.25f, theCarCam.position.y - 0.25f, theCarCam.position.z);
        theCarCam.position = newPosisi6;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi7 = new Vector3(theCarCam.position.x - 0.25f, theCarCam.position.y - 0.25f, theCarCam.position.z);
        theCarCam.position = newPosisi7;
        Vector3 newPosisi8 = new Vector3(theCarCam.position.x + 0.25f, theCarCam.position.y + 0.25f, theCarCam.position.z);
        theCarCam.position = newPosisi8;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi9 = new Vector3(theCarCam.position.x + 0.25f, theCarCam.position.y + 0.25f, theCarCam.position.z);
        theCarCam.position = newPosisi9;
        yield return new WaitForSeconds(0.025f);
    }
    IEnumerator carRotat()
    {
        Vector3 newEulerAngles = theCar.eulerAngles;
        newEulerAngles.x += 15f;
        theCar.eulerAngles = newEulerAngles;
        yield return new WaitForSeconds(0.025f);
        Vector3 newEulerAngles2 = theCar.eulerAngles;
        newEulerAngles2.x += 15f;
        theCar.eulerAngles = newEulerAngles2;
        yield return new WaitForSeconds(0.025f);
        Vector3 newEulerAngles3 = theCar.eulerAngles;
        newEulerAngles3.x += 15f;
        theCar.eulerAngles = newEulerAngles3;
        yield return new WaitForSeconds(0.025f);
        Vector3 newEulerAngles4 = theCar.eulerAngles;
        newEulerAngles4.x += 15f;
        theCar.eulerAngles = newEulerAngles4;
        yield return new WaitForSeconds(0.025f);
        Vector3 newEulerAngles5 = theCar.eulerAngles;
        newEulerAngles5.x += 15f;
        theCar.eulerAngles = newEulerAngles5;
    }
    IEnumerator carPos()
    {
        Vector3 newPosisi = theCar.position;
        newPosisi.y += 0.3f;
        newPosisi.z += 0.8f;
        theCar.position = newPosisi;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi2 = theCar.position;
        newPosisi2.y += 0.3f;
        newPosisi2.z += 0.8f;
        theCar.position = newPosisi2;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi3 = theCar.position;
        newPosisi3.y += 0.3f;
        newPosisi3.z += 0.8f;
        theCar.position = newPosisi3;
        yield return new WaitForSeconds(0.05f);
        loserPanel.SetActive(true);
        Time.timeScale = 0;
    }
    #endregion

    private void enableMirror()
    {
        mirrorL.SetActive(true);
        mirrorR.SetActive(true);
    }
    private void lampuMATILAH()
    {
        lampujalananMATILAH = true;
        Invoke("enableMirror", 4);
    }
    private void spawnScary2()
    {
        Invoke("disableMirrar", 2);
        Invoke("andddItsTheEnd", 3);
        ScaryCar2.SetActive(true);
        Vector3 newPosisi = new Vector3(19.2f, 6, transform.position.z - 100);
        ScaryCar2.transform.position = newPosisi;
    }
    private void andddItsTheEnd()
    {
        Time.timeScale = 0;
        UIAnime.SetTrigger("gameFinished");
    }
    private void disableMirrar()
    {
        spionCannot = true;
    }
    private void PEMAKSAAN()
    {
        if (spionCannot == true)
        {
            CameraB.SetActive(false);
            CameraF.SetActive(true);
        }
    }



    public void Menu()
    {
        fadeScript.sceneName = "MainMenu";
        fadeScript.instance.fadeOut();
    }
    public void Retry()
    {
        fadeScript.sceneName = "restat";
        fadeScript.instance.fadeOut();
    }
    public void sementaraRestat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MirrorDown()
    {
        if(spionCannot == false)
        {
            CameraB.SetActive(true);
            CameraF.SetActive(false);
        }
    }
    public void MirrorUp()
    {
        CameraB.SetActive(false);
        CameraF.SetActive(true);
    }

    IEnumerator scoreError()
    {
        score -= 0.1f;
        yield return new WaitForSeconds(0.5f);
        score += 0.1f;
        yield return new WaitForSeconds(0.5f);
        score -= 0.1f;
        yield return new WaitForSeconds(0.5f);
        score += 0.1f;
        yield return new WaitForSeconds(0.5f);
        score -= 0.1f;
        yield return new WaitForSeconds(0.5f);
        score += 0.1f;
        yield return new WaitForSeconds(0.5f);
        score -= 0.1f;
        yield return new WaitForSeconds(0.5f);
        score += 0.1f;
        yield return new WaitForSeconds(0.5f);
        score -= 0.1f;
        yield return new WaitForSeconds(0.5f);
        score += 0.1f;
        yield return new WaitForSeconds(0.5f);
    }
}
