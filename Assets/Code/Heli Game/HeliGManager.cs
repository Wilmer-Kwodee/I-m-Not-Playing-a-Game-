using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeliGManager : MonoBehaviour
{
    public static HeliGManager Instance;
    public static bool gameisOva;

    public Text deSkore;
    private int theSkore = 0;
    private float jedaWaktu = 0.1f;
    private float waktuTarget = 0;
    private bool bolekah = false;
    // spawner stuffs
    public float spawnRate;
    private float nextSpawn;
    public GameObject failUI;
    public Rigidbody rb;
    public Transform cameraPos;

    void Start()
    {
        gameisOva = false;
        Time.timeScale = 1;
        Instance = this;
        Time.timeScale = 1;
        spawnHalangan();
        //Invoke("dipersilahkan", 6.5f);
        Invoke("dipersilahkan", 3);
    }
    // Update is called once per frame
    void Update()
    {
        if(gameisOva == false)
        {
            if (bolekah == true)
                increaseScore();
            if (Time.time > nextSpawn)
                spawnHalangan();
        }
    }

    public void Menu()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "MainMenu";
        fadeScript.instance.fadeOut();       
        //SceneManager.LoadScene("MainMenu");
    }
    public void Retry()
    {
        fadeScript.sceneName = "restat";
        fadeScript.instance.fadeOut();
    }
    public void gameOver()
    {
        rb.constraints = RigidbodyConstraints.None;
        gameisOva = true;
        failUI.SetActive(true);
        StartCoroutine(cameraShake());
        //Time.timeScale = 0;
    }
    #region SimpleCameraAlgorithm
    IEnumerator cameraShake()
    {
        Vector3 oldPosition = cameraPos.position;
        Vector3 newPosisi = new Vector3(cameraPos.position.x - 0.5f, cameraPos.position.y - 0.5f, cameraPos.position.z);
        cameraPos.position = newPosisi;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi1 = new Vector3(cameraPos.position.x - 0.5f, cameraPos.position.y - 0.5f, cameraPos.position.z);
        cameraPos.position = newPosisi1;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi2 = new Vector3(cameraPos.position.x - 0.5f, cameraPos.position.y - 0.5f, cameraPos.position.z);
        cameraPos.position = newPosisi2;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi3 = new Vector3(cameraPos.position.x + 0.5f, cameraPos.position.y + 0.5f, cameraPos.position.z);
        cameraPos.position = newPosisi3;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi4 = new Vector3(cameraPos.position.x + 0.5f, cameraPos.position.y + 0.5f, cameraPos.position.z);
        cameraPos.position = newPosisi4;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi5 = new Vector3(cameraPos.position.x + 0.5f, cameraPos.position.y + 0.5f, cameraPos.position.z);
        cameraPos.position = newPosisi5;

        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi6 = new Vector3(cameraPos.position.x - 0.25f, cameraPos.position.y - 0.25f, cameraPos.position.z);
        cameraPos.position = newPosisi6;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi7 = new Vector3(cameraPos.position.x - 0.25f, cameraPos.position.y - 0.25f, cameraPos.position.z);
        cameraPos.position = newPosisi7;
        Vector3 newPosisi8 = new Vector3(cameraPos.position.x + 0.25f, cameraPos.position.y + 0.25f, cameraPos.position.z);
        cameraPos.position = newPosisi8;
        yield return new WaitForSeconds(0.025f);
        Vector3 newPosisi9 = new Vector3(cameraPos.position.x + 0.25f, cameraPos.position.y + 0.25f, cameraPos.position.z);
        cameraPos.position = newPosisi9;
        yield return new WaitForSeconds(0.025f);
        //cameraPos.position = oldPosition;
    }
    #endregion

    private void dipersilahkan()
    {
        bolekah = true;
    }
    private void increaseScore()
    {
        // jadi, pada dasarnya "Time.unscaledTime" itu waktu yang telah berlangsung, misal lu pencet play 10 deik yang lalu, ya Time.unscaledTime-nya juga 10 gitu
        if (Time.unscaledTime > waktuTarget)
        {
            theSkore += 1;
            deSkore.text = theSkore.ToString();
            waktuTarget = Time.unscaledTime + jedaWaktu;
        }
    }
    private void spawnHalangan()
    {
        int randomObstacle = Random.Range(0, 3);
        switch (randomObstacle)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("high", transform.position, Quaternion.identity);
                break;
            case 1:
                ObjectPooler.Instance.SpawnFromPool("normal", transform.position, Quaternion.identity);
                break;
            case 2:
                ObjectPooler.Instance.SpawnFromPool("low", transform.position, Quaternion.identity);
                break;
        }
        nextSpawn = Time.time + spawnRate;
    }
}
