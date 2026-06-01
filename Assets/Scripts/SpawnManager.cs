using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManagerScript;
    public List<GameObject> enemyPrefabs;
    public bool isGameActive = true;
    public float spawnRate = 1f;
    public int numberOfEnemies = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        if (isGameActive && numberOfEnemies < 50)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, enemyPrefabs.Count);
            Instantiate(enemyPrefabs[index]);
            numberOfEnemies++;
        }

    } 
}
