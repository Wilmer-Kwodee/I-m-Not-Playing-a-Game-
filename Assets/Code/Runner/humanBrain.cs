using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanBrain : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource LoncatSFX;
    private float jumPowaa = 4.8f;
    public Animator animator;
    private bool roll = false;
    public static bool nobutton;
    public static int airTime = 0;
    public GameObject charac;
    private int stopcode;
    public Transform target;
    public SkinnedMeshRenderer renderer;
    private bool noDetek;
    private bool isFloor;

    void Start()
    {
        nobutton = true;
        rb.isKinematic = false;
        noDetek = true;
        animator.SetBool("ded", false);
        animator.SetFloat("gamestarted", 1);
        rb.AddForce(3500, 0, 0);
        renderer.enabled = true;
        Invoke("tEst", 1.3f);
    }
    private void tEst()
    {
        nobutton = false;
    }
    IEnumerator Respawned()
    {
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
    }
    public void jumplul()
    {
        if (nobutton == false && transform.position.y < 1.7)
        {
                if (transform.position.y < 0.6)
                {
                    LoncatSFX.Play();
                    rb.velocity = Vector2.up * jumPowaa;
                    roll = false;
                    animator.SetBool("sleded", false);
                }
                if (isFloor == true)
                {
                    LoncatSFX.Play();
                    rb.velocity = Vector2.up * jumPowaa;
                    roll = false;
                    animator.SetBool("sleded", false);
                }
        }
        if (isFloor == true)
        {
            LoncatSFX.Play();
            rb.velocity = Vector2.up * jumPowaa;
            roll = false;
            animator.SetBool("sleded", false);
        }
    }
    public void oldJumpMethod()
    {
        if (nobutton == false)
        {
            //rb.velocity = new Vector3 (0, jumPowaa, 0);
            rb.AddForce(0, 2400, 0);
            roll = false;
            animator.SetBool("sleded", false);
            //Loncat.Play(); 
        }
    }
    public void nunduklul()
    {
        if (transform.position.y < 1.2 && nobutton == false) //0.9
        {
            animator.SetBool("sleded", true);
        }
        if (transform.position.y > 0.5 && nobutton == false) //0.7
        {
            roll = true;
            rb.AddForce(0, -3000, 0);
        }
    }
    public void nonunduk()
    {
        if (transform.position.y < 1.2) //0.501f
        {
            animator.SetBool("sleded", false);
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (stopcode == 0)
        {
            if (collisionInfo.collider.tag == "Obstacle")
            {
                if (RunnerGManager.shieldpicked == 0)
                {
                    RunnerGManager.stopcode = 1;
                    animator.SetBool("ded", true);
                    Handheld.Vibrate();
                }
                if (RunnerGManager.shieldpicked == 2)
                {
                    RunnerGManager.shieldpicked = 0;
                    RunnerGManager.stopcode = 3;
                    Invoke("shieldyo", 0.1f);
                    Handheld.Vibrate();
                }
            }
            if (collisionInfo.collider.tag == "Floor")
            {
                isFloor = true;
            }
            else
                isFloor = false;
        }
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        if (isFloor == true)
        {
            isFloor = false;
        }
    }
    private void shieldyo() // buat shield nabrak
    {
        RunnerGManager.stopcode = 0;
    }

    void Update()
    {
        if (transform.position.y < 0.6) //0.6
        {
            animator.SetBool("Jumped", false);
            airTime = 0;
        }
        if (isFloor == true)
        {
            animator.SetBool("Jumped", false);
            roll = false;
            airTime = 0;
        }
        if (transform.position.y < 0.51) //0.3
        {
            roll = false;
        }
        if (transform.position.y > 0.6 && isFloor == false)
        {
            animator.SetBool("Jumped", true);
            airTime = 1;
        }
        if (transform.position.x > -31.5f)
        {
            noDetek = false; //biar ga ke dinohit kecepatan cahaya per detik
        }
        if (transform.position.x < -31.5f && noDetek == false) // supaya bug mundur tak terjadi
        {
            noDetek = true;
            RunnerGManager.stopcode = 1;
            animator.SetBool("ded", true);
            Handheld.Vibrate();
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 900, 0);
        }
        if (Input.GetKey("s"))
        {
            nunduklul();
        }
        if (roll == true)
        {
            animator.SetBool("roll", true);
        }
        if (roll == false)
        {
            animator.SetBool("roll", false);
        }

        stopcode = RunnerGManager.stopcode;
        if (stopcode == 0)
        {
            animator.SetBool("ded", false);
        }
        if (stopcode == 2)
        {
            noDetek = true;
            charac.transform.position = target.transform.position;
            StartCoroutine(Respawned());
            animator.SetBool("ded", false);
            animator.SetBool("roll", false);
            animator.SetBool("sleded", false);
        }
    }
}
