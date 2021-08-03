using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
   public AttackPlayerState attackState;

   public Player player;
   private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }

    private void AnimationFinishTrigger()
    {
        player.AnimationFinishTrigger();
    }
}
