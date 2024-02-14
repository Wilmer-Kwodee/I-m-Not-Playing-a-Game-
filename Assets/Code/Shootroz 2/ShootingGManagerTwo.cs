using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShootingGManagerTwo : MonoBehaviour
{
    public Text ammo;
    public Text score;
    public Text time;
    private int skor = 0;
    private int taim = 61;
    private float nextTime = 0;
    public GameObject failUI;
    public GameObject winUI;
    public GameObject targetDekat;
    public GameObject targetSedang;
    public GameObject targetJauh;
    public Transform posisiDekatL;
    public Transform posisiSedangL;
    public Transform posisiJauhL;
    public Transform posisiDekatR;
    public Transform posisiSedangR;
    public Transform posisiJauhR;
    public static bool dipersilahkanDekat;
    public static bool dipersilahkanSedang;
    public static bool dipersilahkanJauh;
    private bool alreadyOver;

    // Start is called before the first frame update
    void Start()
    {
        PlayaBrainTwo.ammoTotal = 90;
        PlayaBrainTwo.ammoVar = 30;

        alreadyOver = false;
        dipersilahkanDekat = false;
        dipersilahkanSedang = false;
        dipersilahkanJauh = false;


        int randomGen = Random.Range(0, 2);
        if (randomGen == 0)
            ObjectPooler.Instance.SpawnFromPool("dekat", posisiDekatL.position, posisiDekatL.rotation);
        if (randomGen == 1)
            ObjectPooler.Instance.SpawnFromPool("dekat", posisiDekatR.position, posisiDekatR.rotation);

        int randomGen1 = Random.Range(0, 2);
        if (randomGen1 == 0)
            ObjectPooler.Instance.SpawnFromPool("sedang", posisiSedangL.position, posisiSedangL.rotation);
        if (randomGen1 == 1)
            ObjectPooler.Instance.SpawnFromPool("sedang", posisiSedangR.position, posisiSedangR.rotation);

        int randomGen2 = Random.Range(0, 2);
        if (randomGen2 == 0)
            ObjectPooler.Instance.SpawnFromPool("jauh", posisiJauhL.position, posisiJauhL.rotation);
        if (randomGen2 == 1)
            ObjectPooler.Instance.SpawnFromPool("jauh", posisiJauhR.position, posisiJauhR.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (alreadyOver == false)
        {
            mainUI();
            spawnDekat();
            spawnSedang();
            spawnJauh();
            checkGameState();
        }
    }

    private void spawnDekat()
    {
        if (dipersilahkanDekat == true)
        {
            dipersilahkanDekat = false;
            skor += 1;
            int randomGen = Random.Range(0, 2);
            if (randomGen == 0)
                ObjectPooler.Instance.SpawnFromPool("dekat", posisiDekatL.position, posisiDekatL.rotation);
            if (randomGen == 1)
                ObjectPooler.Instance.SpawnFromPool("dekat", posisiDekatR.position, posisiDekatR.rotation);
        }
    }
    private void spawnSedang()
    {
        if (dipersilahkanSedang == true)
        {
            dipersilahkanSedang = false;
            skor += 2;
            int randomGen = Random.Range(0, 2);
            if (randomGen == 0)
                ObjectPooler.Instance.SpawnFromPool("sedang", posisiSedangL.position, posisiSedangL.rotation);
            if (randomGen == 1)
                ObjectPooler.Instance.SpawnFromPool("sedang", posisiSedangR.position, posisiSedangR.rotation);
        }
    }
    private void spawnJauh()
    {
        if (dipersilahkanJauh == true)
        {
            dipersilahkanJauh = false;
            skor += 3;
            int randomGen = Random.Range(0, 2);
            if (randomGen == 0)
                ObjectPooler.Instance.SpawnFromPool("jauh", posisiJauhL.position, posisiJauhL.rotation);
            if (randomGen == 1)
                ObjectPooler.Instance.SpawnFromPool("jauh", posisiJauhR.position, posisiJauhR.rotation);
        }
    }
    private void mainUI()
    {
        if (Time.time > nextTime)
        {
            taim -= 1;
            nextTime = Time.time + 1;
        }

        ammo.text = "Ammo : " + PlayaBrainTwo.ammoVar + " / " + PlayaBrainTwo.ammoTotal;
        score.text = "Score : " + skor;
        time.text = "Time : " + taim;
    }
    private void checkGameState()
    {
        if (taim == 0 | PlayaBrainTwo.ammoTotal == 0)
        {
            failUI.SetActive(true);
            alreadyOver = true;
        }
        if (skor > 100)
        {
            skor = 100;
            winUI.SetActive(true);
            alreadyOver = true;
        }
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
}
