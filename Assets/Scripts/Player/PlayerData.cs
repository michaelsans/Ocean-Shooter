using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public D_SpaceShips spaceshipData;
    public int damage;
    public int health;
    public int speed;


    public void OnEnable()
    {
        damage = spaceshipData.damage;
        health = spaceshipData.health;
        speed = spaceshipData.speed;
    }
}
