using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
 using UnityEditor;
#endif

public class HeliControlla : MonoBehaviour
{
    [HideInInspector] // HideInInspector makes sure the default inspector won't show these fields.
    public bool isPurba;
    [HideInInspector]
    public float balingSpeed = 10;
    [HideInInspector]
    public Transform demBaling;
    [HideInInspector]
    public Transform demBaling2;


    private Rigidbody rb;
    public float turbinePowaa = 3.5f;
    private bool isjump = false;
    private bool alreadyCrashed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if(HeliGManager.gameisOva == false)
        {
            PUTARKANBALINGKIPAS();
            Gravity();
            //For pc, matikan touch seerin dan aktifkan ahfukfineanj
            touchSekerin();
            //ahfuklahfineanj();
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            if(alreadyCrashed == false)
            {
                alreadyCrashed = true;
                HeliGManager.Instance.gameOver();
            }
        }
    }

    private void touchSekerin()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            jamping();
        }
        else
        {
            isjump = false;
            balingSpeed = 10;
        }
    }
    private void PUTARKANBALINGKIPAS()
    {
        if(isPurba == true)
        {
            Vector3 newEulerAngles = demBaling.eulerAngles;
            newEulerAngles.y -= balingSpeed;
            demBaling.transform.eulerAngles = newEulerAngles;

            Vector3 newEulerAngles2 = demBaling2.eulerAngles;
            newEulerAngles2.x -= balingSpeed;
            demBaling2.transform.eulerAngles = newEulerAngles2;
        }
    }
    public void Gravity()
    {
        if (isjump == false)
        {
            rb.AddForce(transform.up * -20 * 50 * Time.deltaTime);
        }
    }
    public void jamping()
    {
        balingSpeed = 30;
        rb.AddForce(transform.up * turbinePowaa * 500 * Time.deltaTime);
        isjump = true;
    }



    /// <summary>
    /// //////
    /// </summary>
    private void ahfuklahfineanj()
    {
        if(isjump == true)
        {
            jamping();
        }
    }
    public void virtualTahan()
    {
        isjump = true;
    }
    public void virtualLepas()
    {
        isjump = false;
    }
}

#if UNITY_EDITOR
 [CustomEditor(typeof(HeliControlla))]
 public class HeliControlla_Editor : Editor
 {
     public override void OnInspectorGUI()
     {
         DrawDefaultInspector(); // for other non-HideInInspector fields
 
         HeliControlla script = (HeliControlla)target;
 
         // draw checkbox for the bool yang spawner
         script.isPurba = EditorGUILayout.Toggle("is Purba", script.isPurba);
         if (script.isPurba) // if bool is true, show other fields
         {
             script.demBaling = EditorGUILayout.ObjectField("dem Baling", script.demBaling, typeof(Transform), true) as Transform;
             script.demBaling2 = EditorGUILayout.ObjectField("dem Baling2", script.demBaling2, typeof(Transform), true) as Transform;
             script.balingSpeed = EditorGUILayout.FloatField("baling Speed", script.balingSpeed);
         }
     }
 }
#endif
