using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] spawners;
    public GameObject ground;
    public Transform spawn;
    
    public bool isGround;
    public bool isEnemy;
    private bool randomReset;

    private float groundTimer;
    private float randomTimer;
    public float lowRange;
    public float highRange;
    // Start is called before the first frame update
    void Start()
    {
        randomReset = true;
    }

    private void Update()
    {
        spawnGround();
        spawnEnemies();
    }

    private void spawnEnemies()
    {
        if (randomReset == true)
        {
            randomTimer = Random.Range(lowRange, highRange);
            randomReset = false;
        }
        randomTimer -= Time.deltaTime;
        if (randomTimer <= 0)
        {
            int randomIndex;
            GameObject spawnedPrefab;
            for (int i = 0; i < spawners.Length; i++)
            {
                randomIndex = Random.Range(0, enemies.Length);
                spawnedPrefab = Instantiate(enemies[randomIndex].gameObject);
                spawnedPrefab.transform.position = new Vector2(spawners[i].transform.position.x, spawners[i].transform.position.y);
            }
            randomReset = true;
        }
    }

    private void spawnGround()
    {
        if (isGround == true)
        {
            groundTimer += Time.deltaTime;
            if (groundTimer > 5)
            {
                Instantiate(ground, spawn.position, transform.rotation);
                groundTimer = 0;
            }
        }
    }
}
