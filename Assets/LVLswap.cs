using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LVLswap : MonoBehaviour
{
[SerializeField] private int lvlEnemiesNum;
private int numDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numDead >= lvlEnemiesNum){
            SceneManager.LoadScene (sceneName:"DEMO 2");
        }
    }

    public void addToDead(){
        numDead++;
        Debug.Log("swap went up");
    }
}
