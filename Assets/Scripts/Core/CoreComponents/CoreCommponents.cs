using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCommponents : MonoBehaviour
{
    protected Core core;

    protected virtual void Awake()
    {
        core = transform.parent.GetComponent<Core>();

        if (core == null)
        {
            Debug.LogError("There is no Core at the parent");
        }
    }
}
