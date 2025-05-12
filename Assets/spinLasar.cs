using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinLasar : MonoBehaviour
{
    [SerializeField]private float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, 2f, Space.Self);
    }

    public void moveTo(Vector3 target){
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }

}
