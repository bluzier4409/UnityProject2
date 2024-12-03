using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;


public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverUI;

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
        Image panelImage = gameOverUI.GetComponent<Image>();
        animation(panelImage);

    }





    public void animation(Image imgf)
    {
        StartCoroutine(AnimateImage(imgf));
    }

    private IEnumerator AnimateImage(Image imgf)
    {
        int iterations = 0;

        while (iterations < 10)
        {
            Debug.Log("Loop");
            // Your animation code here, e.g., modifying imgf.color

            iterations++;
            yield return new WaitForSeconds(0.1f);
        }

        Debug.Log("Animation complete after 10 iterations.");
    }


}