using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LVLswap : MonoBehaviour
{
[SerializeField] private int lvlEnemiesNum;
[SerializeField] private string nextLvlName;

private int numDead;

    void Start()
    {
        
    }

    void Update()
    {
        if(numDead >= lvlEnemiesNum){
            SceneManager.LoadScene (sceneName:nextLvlName);
        }
    }

    public void addToDead(){
        numDead++;
        Debug.Log("swap went up");
    }
}
