using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newMeeleAttackStateData", menuName = "Data/State Data/Meele Attack State")]
public class D_MeeleAttack : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10;
    
    public LayerMask whatIsPlayer;
}
