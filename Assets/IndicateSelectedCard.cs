using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Mathematics;
using UnityEngine;


public class indicateSelectedCard : MonoBehaviour
{

    public float moveDistance = 20f;
    public RectTransform handPlace;

    public void indicate(int index, Card card)
    {
        Transform cardTransform = handPlace.GetChild(index);
        cardTransform.localPosition += Vector3.up * moveDistance;
    }

    public void goBackDown(int index, Card card)
    {
        Transform cardTransform = handPlace.GetChild(index);
        cardTransform.localPosition -= Vector3.up * moveDistance;
    } 

}
