using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    private NewPlayer player;
    private PlayerManager score;
    private Rigidbody2D rb;
    private Animator anim;
    private CircleCollider2D boxCol;
    private bool isAnimationFinished;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<NewPlayer>();
        score = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        boxCol = GetComponent<CircleCollider2D>();
        Invoke("Die", 4f);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, 50f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
       
        if (damageable != null && collision.tag != "Player")
        {
            damageable.TakeDamage(player.damage, false);
            anim.SetBool("estourar", true);
            rb.velocity = Vector2.zero;
            score.updateScore += 10;
            if (isAnimationFinished)
                Die();
        }

        if(collision.tag == "Wall")
        {
            anim.SetBool("estourar", true);
            boxCol.enabled = false;
            rb.velocity = Vector2.zero;
            if (isAnimationFinished)
                Die();
        }
    }

    private void FinishAnim()
    {
        isAnimationFinished = true;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
