using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateSelectedCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Indicate(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            Indicate(2);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            Indicate(3);
        }
    }

    private void Indicate(int keyNum){
        //set grid layout inactive
        //refer to child object
        //move child object back up
        //turn back on
    }
}
