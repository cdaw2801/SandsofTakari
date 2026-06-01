using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenSpawns = 5f;
    private float timeSinceLastSpawn;

    [SerializeField] Enemy enemyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeSinceLastSpawn)
        {
            timeSinceLastSpawn = Time.time + timeBetweenSpawns;
        }
    }
}
