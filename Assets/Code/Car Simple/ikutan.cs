using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ikutan : MonoBehaviour
{
    public Transform yangDiikutin;

    // Update is called once per frame
    void Update()
    {
        Vector3 thepos = new Vector3(19.2f, 6, yangDiikutin.transform.position.z);
        transform.position = thepos;
    }
}
