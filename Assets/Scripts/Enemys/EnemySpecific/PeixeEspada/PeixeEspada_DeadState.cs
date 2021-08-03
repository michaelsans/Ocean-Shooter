using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeEspada_DeadState : DeadState
{
    private PeixeEspada enemy;
    public PeixeEspada_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, PeixeEspada enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }
}
