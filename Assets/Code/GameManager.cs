using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainmen;
    public GameObject selectgem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start()
    {
        mainmen.SetActive(false);
        selectgem.SetActive(true);
    }
    public void back()
    {
        mainmen.SetActive(true);
        selectgem.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void car()
    {
        SceneManager.LoadScene("Car Game");
    }
    public void fps()
    {
        SceneManager.LoadScene("FPS Game");
    }
    public void quit()
    {
        Application.Quit();
    }
}
