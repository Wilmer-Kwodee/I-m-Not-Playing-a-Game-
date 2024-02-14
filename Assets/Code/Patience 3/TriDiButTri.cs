using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriDiButTri : MonoBehaviour
{
    private Renderer Object;
    public Material Material1;
    public Material Material2;
    public float kekuatan;

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
        Vector3 newPosisi = new Vector3(transform.position.x, -0.7509f, -23.373f);
        transform.position = newPosisi;
    }
    void OnMouseUp()
    {
        Object.material = Material2;
        Vector3 newPosisi = new Vector3(transform.position.x, -0.619f, -23.4335f);
        transform.position = newPosisi;

        if (BallManagerTri.controLock == false)
        {
            BallManagerTri.POWAAA = kekuatan;
            BallManagerTri.isLaunching = true;
            BallManagerTri.controLock = true;
        }
    }
}
