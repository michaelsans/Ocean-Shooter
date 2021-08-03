using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : CoreCommponents
{
    public Rigidbody2D RB2D { get; private set; }

    private Vector2 workSpace;
    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        RB2D = GetComponentInParent<Rigidbody2D>();

        FacingDirection = 1;
    }

    public void LogicUpdate()
    {
        CurrentVelocity = RB2D.velocity;
    }

    #region Set Functions

    public void SetVelocityToZero()
    {
        RB2D.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        RB2D.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelocity.y);
        RB2D.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, velocity);
        RB2D.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    #endregion
}
