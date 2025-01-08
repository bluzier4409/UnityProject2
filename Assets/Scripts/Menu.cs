using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton(){
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        //Load scene with index of 1 
    }
    public void OnQuitButton(){
        Application.Quit();
    }
}
