using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTest : MonoBehaviour, IDamageable
{
    private Animator anim;

    public void TakeDamage(int amount, bool empty)
    {
        Debug.Log(amount + "Damage Taken");

    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
