using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
 using UnityEditor;
#endif

public class BackgroundSys : MonoBehaviour
{
    [HideInInspector] // HideInInspector makes sure the default inspector won't show these fields.
    public bool asSpawner;

    [HideInInspector]
    public bool asBackground;

    // component for spawner
    // yang bawah ini hiraukan saja, sayang aja gitu kalo dibuang sapa tau kepake
    //[HideInInspector]
    //public Transform spawnPoint;

    //[HideInInspector]
    //public GameObject theBGround;

    [HideInInspector]
    public float spawnRate;

    private float nextSpawn = 0;

    // component for background
    [HideInInspector]
    public float moveSpeed;



    // Start is called before the first frame update
    void Start()
    {
        if (asSpawner == true)
        {
            spawnBG();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(asSpawner == true)
        {
            spawnBG();
        }
        if(asBackground == true)
        {
            MoveBack();
        }
    }

    private void spawnBG()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            if(transform.position.z > 0)
                ObjectPooler.Instance.SpawnFromPool("backgroundkiri", transform.position, Quaternion.identity);
            if (transform.position.z < 0)
                ObjectPooler.Instance.SpawnFromPool("backgroundkanan", transform.position, Quaternion.identity);

        }
    }
    private void MoveBack()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < 0 && gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }
}

#if UNITY_EDITOR
 [CustomEditor(typeof(BackgroundSys))]
 public class BackgroundSys_Editor : Editor
 {
     public override void OnInspectorGUI()
     {
         DrawDefaultInspector(); // for other non-HideInInspector fields
 
         BackgroundSys script = (BackgroundSys)target;
 
         // draw checkbox for the bool yang spawner
         script.asSpawner = EditorGUILayout.Toggle("as Spawner", script.asSpawner);
         if (script.asSpawner) // if bool is true, show other fields
         {
             //script.theBGround = EditorGUILayout.ObjectField("theBGround", script.theBGround, typeof(GameObject), true) as GameObject;
             //script.spawnPoint = EditorGUILayout.ObjectField("spawnPoint", script.spawnPoint, typeof(Transform), true) as Transform;
             script.spawnRate = EditorGUILayout.FloatField("spawn Rate", script.spawnRate);
         }


         // draw checkbox for the bool yang background
         script.asBackground = EditorGUILayout.Toggle("as Background", script.asBackground);
         if (script.asBackground) // if bool is true, show other fields
         {
             script.moveSpeed = EditorGUILayout.FloatField("move Speed", script.moveSpeed);
         }
     }
 }
#endif
