using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [Header("- Main Components -")]
    private JoyStick jStick;
    private bool shiftt;
    private bool ctrl;
    private bool firee;
    private float nextEner;
    public CharacterController cc;
    public float speed = 12f;
    private float gravity = -19.62f;
    private Vector3 velocity; //For Jumping
    public GameObject melee;
    public Animator meleeAnime;
    public GameObject gun;
    public static float inventoryVar;

    [Header("- Mouse LookRotat Stuffs -")]
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    [Header("- UI Elements -")]
    //public Text ammo;
    public static int ammoVar;
    public static int ammoTotal;
    //public Text sprintPowa;
    public static float sprintEnergy;
    public static bool isRecharging;

    [Header("- GroundCheck Stuffs -")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    [Header("- Shooting Stuffs -")]
    public GameObject bullet;
    public Transform bulTarget;
    public float nextFire = 0f;
    public float fireRate = 15f;

    void Start()
    {
        sprintEnergy = 100;
        ammoTotal = 900;
        ammoVar = 30;
        inventoryVar = 0;
        isRecharging = false;
        jStick = GameObject.Find("StaticPic").GetComponent<JoyStick>();
        //Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

            Gravity();
            GroundCheck();
            Move();
            Shoot();
            Reload();
            regenateSprint();
            updateUI();
            inventorySystem();
            crouch();
            //MouseLook();

    }


    private void Gravity()
    {

            velocity.y += gravity * Time.deltaTime;
            cc.Move(velocity * Time.deltaTime);
        
    }
    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
    private void Move()
    {

            //float x = Input.GetAxis("Horizontal");
            //float z = Input.GetAxis("Vertical");
            float x = jStick.inputHorizontal();
            float z = jStick.inputVertical();
            Vector3 move = transform.right * x + transform.forward * z;
            cc.Move(move * speed * Time.deltaTime);

            if (shiftt == true && sprintEnergy > 0 && x != 0 | z != 0)
            {
                speed = 12f;
                sprintEnergy -= 0.5f;
            }
            else
                speed = 6f;

            if (Input.GetKey("space") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(1.5f * -2 * gravity);
            }
        
    }
    private void Shoot()
    {
        //SEMI AUTO FIRE (HOLDDOWN) (SPRAY) MECHANISM
        if (inventoryVar == 1 && firee == true && Time.time >= nextFire)
        {
            if (ammoVar > 0)
            {
                nextFire = Time.time + 1f / fireRate;
                Instantiate(bullet, bulTarget.position, bulTarget.rotation);
                ammoVar -= 1;
            }
        }
        if (inventoryVar == 0 && firee == true)
        {
            meleeAnime.SetBool("attack", true);
        }
        if (inventoryVar == 0 && firee == false)
        {
            meleeAnime.SetBool("attack", false);
        }
    }
    private void Reload()
    {
        if (Input.GetKey("r"))
        {
            if (ammoVar < 30 && ammoTotal > 0)
            {
                int ammoSisa = 30 - ammoVar;
                ammoTotal -= ammoSisa;
                ammoVar = 30;
                if (ammoTotal < 0)
                {
                    int ammoSementara = 0 - ammoTotal;
                    ammoVar -= ammoSementara;
                    ammoTotal = 0;
                }
            }

        }
    }
    private void updateUI()
    {
        //ammo.text = "Ammo : " + ammoVar + " / " + ammoTotal;
        // sprintPowa.text = "Energy : " + sprintEnergy.ToString("F0");
    }
    private void regenateSprint()
    {
        if (sprintEnergy < 100 && isRecharging == false)
        {
            regStamina();
        }
        if (sprintEnergy > 100)
        {
            sprintEnergy -= 1;
        }
    }
    private void regStamina()
    {
        float x = jStick.inputHorizontal();
        float y = jStick.inputVertical();

        if (x > 0 || x < 0 || y < 0 || y > 0)
        {
            if(Time.time > nextEner)
            {
                sprintEnergy += 1;
                nextEner += 0.35f;
            }
        }
        else
        {
            if (Time.time > nextEner)
            {
                sprintEnergy += 1;
                nextEner += 0.1f;
            }
        }
        isRecharging = false;
    }
    
    private void inventorySystem()
    {
        if (Input.GetKeyDown("q"))
        {
            inventoryVar += 1;
        }
        if (inventoryVar == 0)
        {
            melee.SetActive(true);
            gun.SetActive(false);
        }
        if (inventoryVar == 1)
        {
            melee.SetActive(false);
            gun.SetActive(true);
        }
        if (inventoryVar > 1)
        {
            inventoryVar = 0;
        }
    }
    private void crouch()
    {
        if(ctrl == true)
            transform.localScale = new Vector3(0.6f, 0.3f, 0.6f);
        else
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }


    // TOUCH SCREEN MOBILE EXPERIMEN BUTTON STUFFS
    public void q()
    {
        inventoryVar += 1;
    }
    public void space()
    {
        if(isGrounded)
            velocity.y = Mathf.Sqrt(1.5f * -2 * gravity);
    }
    public void shifthold()
    {
        shiftt = true;
    }
    public void shiftlepas()
    {
        shiftt = false;
    }
    public void ctrlhold()
    {
        ctrl = true;
    }
    public void ctrllepas()
    {
        ctrl = false;
    }
    public void r()
    {
        if (ammoVar < 30 && ammoTotal > 0)
        {
            int ammoSisa = 30 - ammoVar;
            ammoTotal -= ammoSisa;
            ammoVar = 30;
            if (ammoTotal < 0)
            {
                int ammoSementara = 0 - ammoTotal;
                ammoVar -= ammoSementara;
                ammoTotal = 0;
            }
        }
    }
    public void firehold()
    {
        firee = true;
    }
    public void firelepas()
    {
        firee = false;
    }
}
