using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node origin;
    List<Node> neighbors = new List<Node>();
    
    public float gScore = 0;
    public float hScore = 0;

    public float fScore()
    {
        return gScore + hScore;
    }
}
