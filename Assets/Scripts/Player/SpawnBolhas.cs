using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBolhas : MonoBehaviour
{
    [SerializeField] Transform bolhasEsquerda;

    [SerializeField] Transform bolhasDireita;

    [SerializeField] GameObject bolhas;
    private Rigidbody2D rb;

    private float randy;
    private float randx;
    public float nextFire = .3f;
    public float fireRate = .3f;
    private NewPlayer player;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        player = GetComponentInParent<NewPlayer>();
    }

    private void Update()
    {
        
            if ((rb.velocity.y != 0) || (rb.velocity.x != 0))
                fireRate = 0.01f;
            else
                fireRate = 0.1f;

            if (Time.time > nextFire && fireRate > 0)
            {
                nextFire = Time.time + fireRate;
                SpawnBubbles();
            }

        
    }
    

    void SpawnBubbles()
    {
        randy = Random.Range(0.1f, 0.5f);
        randx = Random.Range(-.5f, .5f);
        Instantiate(bolhas, new Vector3(bolhasEsquerda.transform.position.x + randx, bolhasEsquerda.transform.position.y - randy, 0f), Quaternion.identity);
        Instantiate(bolhas, new Vector3(bolhasDireita.transform.position.x + randx, bolhasDireita.transform.position.y - randy, 0f), Quaternion.identity);
    }
}
