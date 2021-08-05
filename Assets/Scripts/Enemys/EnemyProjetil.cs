using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjetil : MonoBehaviour
{
    private Transform target;
    private Transform myTransform;
    private Rigidbody2D rb;
    private Tutubarao tubarao;
    void Start()
    {
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rb.freezeRotation = true;
        BoxCollider2D box = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        box.isTrigger = true;
        rb = GetComponent<Rigidbody2D>();
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        rb.velocity = (target.transform.position - transform.position).normalized * 50f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null && (collision.tag == "Player"))
        {
            damageable.TakeDamage(5, false);
                Die();
        }

        if (collision.tag == "Colisao" || collision.tag == "Projetil")
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
