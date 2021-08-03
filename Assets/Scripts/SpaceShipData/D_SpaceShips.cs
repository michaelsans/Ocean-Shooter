using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Space Ship Data", menuName = "Data/SpaceShip")]
public class D_SpaceShips : ScriptableObject
{
    public int health = 100;
    public int speed = 20;
    public int damage = 100;
}
