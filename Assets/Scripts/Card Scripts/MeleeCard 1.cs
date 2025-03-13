
using UnityEngine;

public class MeleeCard : Card
{
    private Vector2 _range = new Vector2(); //SphereCast distance
    private float _damage = 1f; //Amount of health entities returned by SphereCast will lose
    public GameObject holder;
    
    public MeleeCard() {}

    public MeleeCard(string name, string type, bool inHand, bool active, Vector2 range, float damage)
    {
        Name = name;
        Type = type;
        //InHand = inHand;
        
        _range = range;
        _damage = damage;
    }

    public void Hit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(holder.transform.position, _range, 0f);
        
    }
    
    
}
