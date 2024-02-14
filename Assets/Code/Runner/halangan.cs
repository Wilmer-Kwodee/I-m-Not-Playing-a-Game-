using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halangan : MonoBehaviour
{
    private float moveSpeed = -7.5f;
    private float stopcode = 0; // game over or no ( karakter nabrak )

    void Update()
    {
        stopcode = RunnerGManager.stopcode;

        if (stopcode == 0)
        {
            Reverse();
        }
    }
    private void Reverse()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

        if (transform.position.x < -5 && gameObject != null)
        {
            gameObject.SetActive(false);
        }             
    }
}
