using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FBirdManager : MonoBehaviour
{
    public static FBirdManager Instance;
    public static bool gameStopped;

    public Text deSkore;
    private int theSkore = 0;
    private float jedaWaktu = 1.5f;
    private float waktuTarget = 0;
    private bool bolekah = false;
    public GameObject failUI;
    public Animator FlashBang;

    // spawner component
    public float spawnRate = 3f;
    private float nextSpawn;

    void Start()
    {
        gameStopped = false;
        Instance = this;
        Invoke("dipersilahkan", 1.5f);
        spawnHalangan();
    }
    // Update is called once per frame
    void Update()
    {
        if(bolekah == true && gameStopped == false)
            increaseScore();

        if (Time.time > nextSpawn && gameStopped == false)
            spawnHalangan();
    }

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
    public void gameOver()
    {
        FlashBang.SetBool("Flashed", true);
        failUI.SetActive(true);
        gameStopped = true;
    }

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
