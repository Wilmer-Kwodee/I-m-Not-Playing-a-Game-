using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarGManager : MonoBehaviour
{
    public GameObject cameraF;
    public GameObject cameraR;

    [Header("UI Stuffs")]
    public Text speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed.text = VehicleController.speed.ToString("F0");
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
    public void tahanMiror()
    {
        cameraF.SetActive(false);
        cameraR.SetActive(true);
    }
    public void lepasMiror()
    {
        cameraF.SetActive(true);
        cameraR.SetActive(false);
    }
}
