using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator UIAnime;
    public GameObject fadeSystem;

    void Awake()
    {
        Time.timeScale = 1;
        FBirdManager.gameStopped = false;
        HeliGManager.gameisOva = false;

        if (GameObject.Find("FadeSystem(Clone)") == null)
            Instantiate(fadeSystem, transform.position, transform.rotation);

    }
    public void play()
    {
        Invoke("triggerLevel", 0.15f);
    }
    public void back()
    {
        Invoke("triggerMenu", 0.15f);
    }

    public void car()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Car Game";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Car Game");
    }
    public void carMornin()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Car Mornin Game";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Car Mornin Game");
    }
    public void carNight()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Car Night Game";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Car Night Game");
    }
    public void fps()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "FPS Game";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("FPS Game");
    }
    public void tap1()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "TAP 1";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("FBird Game");
    }
    public void tap2()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "TAP 2";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("FBird Game");
    }
    public void tap3()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "TAP 3";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("FBird Game");
    }
    public void heli1()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Heli Game 1";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Heli Game");
    }
    public void heli2()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Heli Game 2";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Heli Game");
    }
    public void heli3()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Heli Game 3";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Heli Game");
    }
    public void Patience1()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Patience 1";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Ball Game");
    }
    public void Patience2()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Patience 2";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Ball Game");
    }
    public void Patience3()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Patience 3";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Ball Game");
    }
    public void ballfall()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "BallFall G";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("BallFall G");
    }
    public void shooting1()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Shootroz 1";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Shooting Game");
    }
    public void shooting2()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Shootroz 2";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Shooting Game");
    }
    public void runner()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Runner Game";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Runner Game");
    }
    public void ventura()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "Ventura";
        fadeScript.instance.fadeOut();
        //SceneManager.LoadScene("Runner Game");
    }
    public void quit()
    {
        fadeScript.instance.white.SetActive(false);
        fadeScript.instance.black.SetActive(true);
        fadeScript.instance.fadeOut();
        Invoke("quitapp", 0.5f);
    }
    private void quitapp()
    {
        Application.Quit();
    }
    private void triggerLevel()
    {
        UIAnime.SetTrigger("isLevel");
        UIAnime.ResetTrigger("isMenu");
    }
    private void triggerMenu()
    {
        UIAnime.SetTrigger("isMenu");
        UIAnime.ResetTrigger("isLevel");
    }
}
