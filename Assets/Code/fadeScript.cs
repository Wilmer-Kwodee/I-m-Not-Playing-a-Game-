using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeScript : MonoBehaviour
{
    public static fadeScript instance;
    public Animator anime;
    public static string sceneName;
    public GameObject white;
    public GameObject black;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        Invoke("fadeIn", 0.1f);
        //anime.SetTrigger("fadein");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fadeIn()
    {
        if (sceneName != "restat")
        {
            anime.updateMode = AnimatorUpdateMode.Normal;
        }
            //anime.updateMode = AnimatorUpdateMode.Normal;
            anime.SetTrigger("fadein");
    }
    public void fadeOut()
    {
        anime.updateMode = AnimatorUpdateMode.UnscaledTime; 
        anime.SetTrigger("fadeout");
    }
    public void LoadScene()
    {
        if(sceneName != null)
        {
            if(sceneName == "restat")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                sceneName = null;
            }
            else
            {
                SceneManager.LoadScene(sceneName);
                sceneName = null;
            }
        }
    }
}
