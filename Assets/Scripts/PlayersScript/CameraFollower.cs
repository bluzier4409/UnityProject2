using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
   Vector3 offset = new Vector3(0f, 0f, -10f);
   private float timeToSmooth = 0.35f;
   private Vector3 velocity = Vector3.zero;
   
   public Transform target;
   public Camera camera;

   private void Update()
   {
      Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
      Vector3 targetPos = Vector3.Lerp(target.position, mousePos, 0.2f) + offset;
      transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, timeToSmooth);
   }
}
