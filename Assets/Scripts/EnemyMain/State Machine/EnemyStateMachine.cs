using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
   public EnemyState CurrentState { get; set; }

   public void StartState(EnemyState startState)
   {
      CurrentState = startState;
      CurrentState.Enter();
   }

   public void ChageState(EnemyState newState)
   {
      CurrentState.Exit();
      CurrentState = newState;
      CurrentState.Enter();
   }
}
