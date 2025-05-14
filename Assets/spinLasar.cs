using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinLasar : MonoBehaviour
{
    [SerializeField]private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, 1.5f, Space.Self);
    }

    public void moveTo(Vector3 target){
        Debug.Log("move gets called");
        this.GetComponent<Rigidbody2D>().AddForce(target *100000, ForceMode2D.Impulse);
    }

}
