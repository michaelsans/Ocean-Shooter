using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float maxHealth = 30f;
    public int damage = 5;
    public float damageHopSpeed = 5f;

    public float wallCheckDistance = 0.2f;

    public float maxAggroRangeDist = 4f;
    public float minAggroRangeDist = 3f;

    public float stunResistence = 3f;
    public float stunRecoveryTime = 2f;

    public float closeRangeActionDistance = 1f;
    public float maxRangeActionDistance = 5f;

    public GameObject hitParticle;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
