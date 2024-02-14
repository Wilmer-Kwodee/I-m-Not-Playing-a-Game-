using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleController : MonoBehaviour
{
    public bool engineOn = false;
    public Rigidbody rb;
    public float speednPowaa = 100f;
    private float turnSpeed = 50f;
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
    private int underSteery;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    public static float speed;

    //buat mobile bool
    private bool gass;
    private bool remm;
    private bool kirii;
    private bool kanann;

    // Start is called before the first frame update
    void Start()
    {
        engineOn = true;
        //StartCoroutine(SpeedCalculator());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        MoveMobile();
        TurnMobile();
        understeerMaker();
        UpdateVisualWheels();
        SpeedCalcuV2();
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
    IEnumerator SpeedCalculator()
    {
        bool isplaying = true;
        while(isplaying)
        {
            Vector3 prevPos = transform.position;
            yield return new WaitForFixedUpdate();
            speed = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime);
        }
    }
    private void SpeedCalcuV2()
    {
        speed = rb.velocity.magnitude * 3.6f;
    }




    // TOUCHSCREEN MOBILE CAR DRIVE CONTROL STUFFS
    void MoveMobile()
    {
        if (engineOn == true)
        {
            if (gass == true && isGrounded == true)
            {
                rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * (speednPowaa / underSteery) * 10);
                ffwil.motorTorque = 1;
                frwil.motorTorque = 1;
                rlwil.motorTorque = 1;
                rrwil.motorTorque = 1;
            }
            if (remm == true && isGrounded == true)
            {
                rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * (-speednPowaa / underSteery) * 10);
                ffwil.motorTorque = -1;
                frwil.motorTorque = -1;
                rlwil.motorTorque = -1;
                rrwil.motorTorque = -1;
            }
            Vector3 localvelocity = transform.InverseTransformDirection(rb.velocity);
            localvelocity.x = 0;
            rb.velocity = transform.TransformDirection(localvelocity);
        }
    }
    void understeerMaker()
    {
        if (isturning == 0)
            underSteery = 1;
        if (isturning != 0)
            underSteery = 4;
    }
    void TurnMobile()
    {
        if (engineOn == true)
        {
            isturning = 0;
            if (kirii == true)
            {
                if (speed < 20)
                {
                    isturning = -1;
                }
                if (speed > 20)
                {
                    isturning = -0.75f;
                }
                if (speed > 35)
                {
                    isturning = -0.5f;
                }
                //rb.AddTorque(-Vector3.up * turnSpeed * 10);
            }

            if (kanann == true)
            {
                if (speed < 20)
                {
                    isturning = 1;
                }
                if (speed > 20)
                {
                    isturning = 0.75f;
                }
                if (speed > 35)
                {
                    isturning = 0.5f;
                }
                //rb.AddTorque(Vector3.up * turnSpeed * 10);

            }

            ffwil.steerAngle = maxTurn * isturning;
            frwil.steerAngle = maxTurn * isturning;
        }
    }
    public void GAShold()
    {
        gass = true;
    }
    public void GASlepas()
    {
        gass = false;
    }
    public void REMhold()
    {
        remm = true;
    }
    public void REMlepas()
    {
        remm = false;
    }
    public void KIRIhold()
    {
        kirii = true;
    }
    public void KIRIlepas()
    {
        kirii = false;
    }
    public void KANANhold()
    {
        kanann = true;
    }
    public void KANANlepas()
    {
        kanann = false;
    }
}
