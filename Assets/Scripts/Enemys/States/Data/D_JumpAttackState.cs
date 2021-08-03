using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newJumpStateData", menuName = "Data/State Data/Jump State")]
public class D_JumpAttackState : ScriptableObject
{
    public float attackDamage;
    public float attackRadius;
    public float jumpTime;
    public LayerMask whatIsPlayer;
}
