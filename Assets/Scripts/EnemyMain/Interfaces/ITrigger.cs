using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrigger
{
    bool Aggro { get; set; }
    bool Attackable { get; set; }
    
    void SetAggro(bool aggro);
    
    void SetAttackable(bool attackable);
}
