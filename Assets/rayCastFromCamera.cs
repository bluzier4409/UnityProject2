using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using Vector3 = UnityEngine.Vector3;

public class rayCastFromCamera : MonoBehaviour
{

    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        //draw ray
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 100f;
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

    }
}
