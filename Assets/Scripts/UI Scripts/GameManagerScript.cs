using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverUI;
    public GameObject cardCanvasUI;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        cardCanvasUI.SetActive(false);
        Image panelImage = gameOverUI.GetComponent<Image>();
        StartCoroutine((animation(panelImage)));
        

    }





    public IEnumerator animation(Image imgf)
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Title");
    }

    private IEnumerator AnimateImage(Image imgf)
    {
        int iterations = 0;

        while (iterations < 10)
        {
            Debug.Log("Loop");
            // Your animation code here, e.g., modifying imgf.color

            iterations++;
        }

        Debug.Log("Animation complete after 10 iterations.");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Title");

    }
    

}