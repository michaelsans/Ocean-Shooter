using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Transform spawnPos1;
    [SerializeField] private Transform spawnPos2;

    [SerializeField] private GameObject[] enemy;

    [SerializeField] private Transform newPosx;

    private float startTime;
    [SerializeField]
    private float spawnTime = 1f;
    private int maxSpawn = 0;
    private int rand;
    public bool timeToFlee;
    void Awake()
    {
        PlayerManager.playerManagerInstance.ResetScore();
    }

    void Update()
    {
        timeToFlee = GameObject.Find("tutubarao").GetComponent<Tutubarao>().timeToFlee;
        if (!timeToFlee && Time.time >= startTime + spawnTime && maxSpawn <= 50)
        {
            maxSpawn += 1;
            SpawnEnemy();
        }
        else if(maxSpawn > 50)
        {
            Invoke("ResetSpawn", 5f);
        }
    }

    private void SpawnEnemy()
    {
        rand = Random.Range(0, enemy.Length);
        startTime = Time.time;
        newPosx.transform.position = new Vector3(Random.Range(spawnPos1.transform.position.x, spawnPos2.transform.position.x), 160f,0f);
        Instantiate(enemy[rand], newPosx.transform.position, Quaternion.identity);
    }

    private void ResetSpawn()
    {
        maxSpawn = 0;
    }
}
