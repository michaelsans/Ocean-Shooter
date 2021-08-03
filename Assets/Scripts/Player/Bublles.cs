using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bublles : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void AnimTrigger()
    {
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
