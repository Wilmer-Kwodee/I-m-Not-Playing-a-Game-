using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunnerGManager : MonoBehaviour
{
    // biar public voids bisa di akses sama skrip lain
    public static RunnerGManager instance = null; 

    //basic manager logics
    public static int stopcode;
    public static int shieldpicked;
    private int highScore = 0, yourScore = 0;
    private float nextScoreIncrease;
    public Text skorUI;
    public GameObject failPanel;

    // spawn system
    public float spawnRate = 3f;
    private float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        stopcode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)        
            SpawnObstacle();

        UIupdate();
        scorePlusPlus();
        GameOver();
    }

    // private voids
    private void SpawnObstacle()
    {
            if (stopcode == 0)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("delog", transform.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("logsled", transform.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("rock1", transform.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("logjumpsled", transform.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("logsled", transform.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("rock2", transform.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 5);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("delog", transform.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("logsled", transform.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("rock1", transform.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("rock2", transform.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("logjumpsled", transform.position, Quaternion.identity);
                            break;
                    }
                }

            
        }
    }
    private void UIupdate()
    {
        skorUI.text = yourScore.ToString();
    }
    private void scorePlusPlus()
    {
        if (stopcode == 0 && Time.unscaledTime > nextScoreIncrease)
        {
            yourScore += 1;            
            nextScoreIncrease = Time.unscaledTime + 0.01f;
        }
    }
    public void GameOver()
    {
        if(stopcode == 1)
        {
            Time.timeScale = 0;
            failPanel.SetActive(true);
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
}
