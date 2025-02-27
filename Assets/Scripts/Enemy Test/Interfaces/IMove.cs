using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    Rigidbody2D rb { get; set; }

    bool isFacingRight { get; set; }
    
    void Move(Vector2 velocity);
    
    void Flip(Vector2 velocity);
}
