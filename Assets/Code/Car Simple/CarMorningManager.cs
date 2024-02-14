using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarMorningManager : MonoBehaviour
{
    public bool ezOne;
    public bool nightOne;
    public static int bombTimer;

    public GameObject loserPanel;

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
            if (Time.timeScale != 0)
            {
                score -= 0.01f;
                nextSekor = Time.time + nextSekorTarget;
            }
        }
    }

    private void checkGameOver()
    {
        if(alreadyOver != true)
        {
            if (isOver == true)
            {
                alreadyOver = true;
                StartCoroutine(camPos());
                StartCoroutine(carPos());
                StartCoroutine(carRotat());
            }
        }
    }
    #region sederhanaSaja
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
    IEnumerator carPos()
    {
        Vector3 newPosisi = theCar.position;
        newPosisi.z += 0.2f;
        theCar.position = newPosisi;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi2 = theCar.position;
        newPosisi2.z += 0.2f;
        theCar.position = newPosisi2;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi3 = theCar.position;
        newPosisi3.z += 0.2f;
        theCar.position = newPosisi3;
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
        loserPanel.SetActive(true);
        Time.timeScale = 0;
    }
    #endregion

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
}
