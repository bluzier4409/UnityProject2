using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
 void Damage(float damageAmount);

 void Die();
 
 float MaxHealth { get; set; }
 
 float CurrentHealth { get; set; }
}
