using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class NewPlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Dash State")]
    public float dashCooldown = 0.5f;
    public float dashSpeed = 30f;
    public float drag = 10f;
    public float dashTime = 1f;

    [Header("Attack State")]
    public GameObject projetil;
    public int Damage = 100;

    [Header("HurtState")]
    public GameObject[] pedacos;
}
