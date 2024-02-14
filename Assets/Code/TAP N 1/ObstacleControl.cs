using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour {

	public float moveSpeed = -5f;
    private float stopcode = 0;

   
    void Update()
    {
        //stopcode = FBirdManager.stopcode;

        if (transform.position.x < -18.5f) // 2 itu buat respawn dari nyawa
        {
            if (stopcode == 3)
            {
                Destroy(gameObject);
            }
            if (stopcode == 2)
            {
                Destroy(gameObject);
            }
        }
        if (stopcode == 0)
        {
            Reverse();
        }     
	}
    public void Reverse()
    {
        if (FBirdManager.gameStopped == false)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            if (transform.position.x < -10 && gameObject != null)
            {
                gameObject.SetActive(false);
            }
        }     
    }
}
