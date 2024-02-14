using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControlla : MonoBehaviour
{
    private Rigidbody rb;
    public float jumPowaa = 7.5f;
    public GameObject youneetiesPartikal;
    private bool rocketOn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //touchSekerin();
        if(FBirdManager.gameStopped == false)
        {
            rokcetCheck();
            Gravity();
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            FBirdManager.Instance.gameOver();
        }
    }

    private void rokcetCheck()
    {
        if (rocketOn == true)
        {
            youneetiesPartikal.SetActive(true);
            rocketOn = false;
        }
        else
            youneetiesPartikal.SetActive(false);       
    }
    private void touchSekerin()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Jump();
        }
    }
    public void Jump()
    {
        if(FBirdManager.gameStopped == false)
        {
            rocketOn = true;
            rb.velocity = Vector2.up * jumPowaa;
        }
    }
    public void Gravity()
    {
        
        if (rb.velocity.y < 3)
        {           
            rb.AddForce(transform.up * -20 * 50 * Time.deltaTime);
        }          
    }
}
