using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBrain : MonoBehaviour
{
    public GameObject theRotator;
    private float waktuTarget = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.unscaledTime > waktuTarget)
        {
            theRotator.transform.Rotate(0, 1, 0, Space.World);
            waktuTarget = Time.unscaledTime + 0.03f;
        }
    }
}
