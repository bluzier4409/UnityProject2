using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 0){
            Debug.Log("swap here");
            int thisSceneNum = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(thisSceneNum + 1);
        }

    }
}
