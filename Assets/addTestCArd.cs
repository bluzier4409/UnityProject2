using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addTestCArd : MonoBehaviour
{
    public GameObject cardSystem;
    public GameObject testCardImg;

    // Start is called before the first frame update
    void Start()
    {
                

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name.Equals("mainChar"))
        {
                        Debug.Log("card touch");

            Card tester = new Card("tester", "Melee", false, false, testCardImg);
            PlayerCardScript thing = cardSystem.GetComponent<PlayerCardScript>();
            thing.addCard(tester);
            Destroy(this.gameObject);
        }

    }
}
