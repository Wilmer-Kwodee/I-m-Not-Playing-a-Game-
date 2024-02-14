using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPSGManager : MonoBehaviour
{
    public Transform inventorySelect;
    public Transform inventoryPos1;
    public Transform inventoryPos2;
    public Transform inventoryPos3;
    private float inventoryVar;
    public Text ammo;
    public Text sprintPowa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inventoryVar = PlayerScript.inventoryVar;
        inventoryCheck();
        mainUI();
    }

    public void Menu()
    {
        fadeScript.instance.white.SetActive(true);
        fadeScript.instance.black.SetActive(false);
        fadeScript.sceneName = "MainMenu";
        fadeScript.instance.fadeOut();
    }
    private void inventoryCheck()
    {
        if (inventoryVar == 0)
        {
            inventorySelect.position = Vector3.Lerp(inventorySelect.position, inventoryPos1.position, 0.15f);
        }
        if (inventoryVar == 1)
        {
            inventorySelect.position = Vector3.Lerp(inventorySelect.position, inventoryPos2.position, 0.15f);
        }
    }
    private void mainUI()
    {
        ammo.text = "Ammo : " + PlayerScript.ammoVar + " / " + PlayerScript.ammoTotal;
        sprintPowa.text = "Energy : " + PlayerScript.sprintEnergy.ToString("F0");
    }
}
