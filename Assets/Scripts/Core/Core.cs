using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{

    public Movements Movements
    {
        get
        {
            if(movements != null)
            {
                return movements;
            }
            Debug.LogError("No Movements Core Component on " + transform.parent.name);
            return null;
        }
        set{ movements = value; }
    }
    public CollisionSenses CollisionSenses
    {
        get
        {
            if(collisionSenses != null)
            {
                return collisionSenses;
            }
            Debug.LogError("No Collision Senses Core Component on " + transform.parent.name);
            return null;
        }
        set{collisionSenses = value;}
    }

    private Movements movements;
    private CollisionSenses collisionSenses;
    private void Awake()
    {
        Movements = GetComponentInChildren<Movements>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
    }

    public void LogicUpdate()
    {
        Movements.LogicUpdate();
    }
}
