using UnityEngine;

public class AnimScript : MonoBehaviour
{
    public GameObject GameObj;
 

    private void RunAnimation() 
    {
      GameObj.GetComponent<Animation>().Play("swordswinganim");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("I did this");
            RunAnimation();
        }
    }
}
