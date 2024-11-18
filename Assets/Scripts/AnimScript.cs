using UnityEngine;

public class AnimScript : MonoBehaviour
{
    private static readonly int ClickDetected = Animator.StringToHash("ClickDetected");
    public Animator animator;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("I did this");
            animator.SetTrigger("Click");
        }
    }
}
