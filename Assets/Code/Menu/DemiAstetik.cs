using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemiAstetik : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject BG1;
    public float moveSpeed = -5f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);

        if (transform.position.y > 3450)
        {
            BG1.transform.position = teleportTarget.transform.position;
        }
    }
}
