using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScale : MonoBehaviour
{
    public void pointerTouch()
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
    }

    public void pointerRelease()
    {
        transform.localScale = new Vector2(1f, 1f);
    }
}
