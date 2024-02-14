using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriDeeFall : MonoBehaviour
{
    private Renderer Object;
    public Material Material1;
    public Material Material2;
    public int kekuatan;
    public bool launch;
    public bool respawn;

    // Start is called before the first frame update
    void Start()
    {
        Object = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Object.material = Material1;
        Vector3 newPosisi = new Vector3(transform.position.x, transform.position.y - 0.14f, transform.position.z + 0.1f);
        transform.position = newPosisi;
    }
    void OnMouseUp()
    {
        Object.material = Material2;
        Vector3 newPosisi = new Vector3(transform.position.x, transform.position.y + 0.14f, transform.position.z - 0.1f);
        transform.position = newPosisi;

        if (launch == true)
        {
            if (BallFManager.dipersilahkan == true)
            {
                BallFManager.POWAAA = kekuatan;
                BallFManager.LAUNCH = true;
            }
        }
        if (respawn == true)
        {
            if(BallFManager.LAUNCH == false && BallFManager.dipersilahkan == false)
                BallFManager.SPAWN = true;
        }
    }
}
