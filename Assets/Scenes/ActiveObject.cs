using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    public void OnDisable()
    {
        Destroy(gameObject);
    }
}
