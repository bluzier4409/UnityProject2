using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class HeartAction : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite _full, _half;
    [SerializeField] private Image _sprite;

    // Update is called once per frame
    public void setState(int state)
    {
        switch(state){
            //set heart as invisible
            case 0:
                //_sprite.invisible;
                break;
            case 1:
            //set heart as half
                _sprite.sprite = _half;
                break;

            case 2: 
                //set heart as full
                _sprite.sprite = _full;
                break;
        }

        
        
    }
}
