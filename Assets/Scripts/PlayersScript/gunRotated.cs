using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class gunRotated : MonoBehaviour
{
    private UnityEngine.Vector2 mousePos;
    public Camera camera;
    
    void Start()
    {
        
    }

    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        float angle = MathF.Atan2(mousePos.y - transform.position.y, mousePos.x - 
                                                                     transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = UnityEngine.Quaternion.Euler(0,0, angle);
    }
}
