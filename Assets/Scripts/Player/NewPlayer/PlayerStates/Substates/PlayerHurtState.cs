using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerState
{
    public PlayerHurtState(NewPlayer player, PlayerStateMachine stateMachine, NewPlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }

    public override void DoChecks()
    {
        base.DoChecks();
        
    }

    public override void Enter()
    {
        base.Enter();
        core.Movements.SetVelocityToZero();
        player.SetCanShoot();
        player.isInvincible = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetCanShoot();
        player.isInvincible = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isAnimationFinished)
        {
            if (player.currentHealth >= 15)
                stateMachine.ChangeState(player.IdleState);
            else if (player.currentHealth > 5 && player.currentHealth < 15)
                stateMachine.ChangeState(player.Damage1IdleState);
            else if (player.currentHealth == 5)
                stateMachine.ChangeState(player.Damage2IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
