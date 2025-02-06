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

   private void Update()
   {
      Vector3 targetPos = target.position + offset;
      transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, timeToSmooth);
   }
}
