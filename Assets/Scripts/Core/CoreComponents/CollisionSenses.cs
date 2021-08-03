using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreCommponents
{

    #region Check Transforms
    public Transform WallCheck {
        get
        {
            if (wallCheck)
                return wallCheck;
            Debug.LogError("No Wall Check on " + core.transform.parent.name);
            return null;
        }
        set =>  wallCheck = value; }
    
    public float WallCheckDistance { get => wallCheckDistance; set => wallCheckDistance = value; }
    public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }
    public LayerMask WhatIsFleeTime { get => whatIsGround; set => whatIsGround = value; }

    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsFleeTime;
    #endregion


    #region Check Functions

    public bool WallFront
    {
        get => (Physics2D.Raycast(WallCheck.position, Vector2.right * core.Movements.FacingDirection, wallCheckDistance, whatIsGround));
    }
    public bool FleeTime
    {
        get => (Physics2D.Raycast(WallCheck.position, Vector2.right * core.Movements.FacingDirection, wallCheckDistance, whatIsFleeTime));
    }

    #endregion
}
