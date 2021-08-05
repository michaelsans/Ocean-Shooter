using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatInSpace : MonoBehaviour
{
    private Rigidbody2D rb;
    public float FloatStrenght;
    public float RandomRotationStrenght;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        rb.AddForce(new Vector2(3f,-3f) * FloatStrenght);
        transform.Rotate(RandomRotationStrenght, RandomRotationStrenght, 0f);
    }
}
