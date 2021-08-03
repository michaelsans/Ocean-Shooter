using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private ItemData data;
    private PlayerManager score;
    public int itemValue;

    void Awake()
    {
        itemValue = data.value;
        score = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            score.updateMoney += itemValue;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
