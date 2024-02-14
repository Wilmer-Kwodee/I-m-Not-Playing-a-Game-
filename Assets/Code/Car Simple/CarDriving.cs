using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriving : MonoBehaviour
{
    public Rigidbody rb;
    public float speednPowaa = 100f;
    public float DownForce;
    public float maxTurn = 45f;
    public float gravity = 5f;
    public WheelCollider ffwil;
    public Transform visFL;
    public WheelCollider frwil;
    public Transform visFR;
    public WheelCollider rlwil;
    public Transform visRL;
    public WheelCollider rrwil;
    public Transform visRR;
    private float isturning;
    private float speed;

    public Transform LerpTarget;
    public float lerptime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CarSimpleManager.lampujalananMATILAH == true)
        {
            Lerpin();
        }
        if (CarSimpleManager.lampujalananMATILAH == false)
        {
            Turn();
        }

        UpdateVisualWheels();
        downForze();
        pedakStuck();

        if (speed > 140)
        {
            speednPowaa = 140;
        }
    }



    // PRIVATE VOIDS
    private void pedakStuck()
    {
        //rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * speednPowaa * 10);
        ffwil.motorTorque = 1 * speednPowaa; // * Time.deltaTime * 10;
        frwil.motorTorque = 1 * speednPowaa; // * Time.deltaTime * 10;
        rlwil.motorTorque = 1 * speednPowaa; // * Time.deltaTime * 10;
        rrwil.motorTorque = 1 * speednPowaa; // * Time.deltaTime * 10;
        
        //Vector3 localvelocity = transform.InverseTransformDirection(rb.velocity);
        //localvelocity.x = 0;
        //rb.velocity = transform.TransformDirection(localvelocity);
    }
    private void downForze()
    {
        if (speed < 75)
        {
            rb.AddForce(Vector2.down * DownForce);
        }
        if (speed > 75 && speed < 120)
        {
            rb.AddForce(Vector2.down * DownForce * 2);
        }
        if (speed > 120)
        {
            rb.AddForce(Vector2.down * DownForce * 3);
        }
    }
    private void Turn()
    {
        isturning = Steering.steeringInput / 4;

        ffwil.steerAngle = maxTurn * isturning;
        frwil.steerAngle = maxTurn * isturning;
    }
    private void UpdateVisualWheels()
    {
        Vector3 pos;
        Quaternion rot;

        ffwil.GetWorldPose(out pos, out rot);
        visFL.position = pos;
        visFL.rotation = rot;

        frwil.GetWorldPose(out pos, out rot);
        visFR.position = pos;
        visFR.rotation = rot;

        rlwil.GetWorldPose(out pos, out rot);
        visRL.position = pos;
        visRL.rotation = rot;

        rrwil.GetWorldPose(out pos, out rot);
        visRR.position = pos;
        visRR.rotation = rot;
    }
    private void SpeedCalcuV2()
    {
        Debug.Log(speed);
        speed = rb.velocity.magnitude * 3.6f;
    }
    private void Lerpin()
    {
        Vector3 target = new Vector3(LerpTarget.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, lerptime);

        transform.rotation = Quaternion.Lerp(transform.rotation, LerpTarget.rotation, lerptime);
    }
}