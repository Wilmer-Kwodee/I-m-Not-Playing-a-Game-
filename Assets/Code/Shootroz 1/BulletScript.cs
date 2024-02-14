using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    public float shootSpeed;

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * shootSpeed);
        if(gameObject.active)
            Invoke("activatingSelfDestruction", 1);
    }
    void OnCollisionEnter(Collision collisioninfo)
    {
        activatingSelfDestruction();
    }
    private void activatingSelfDestruction()
    {
        gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}