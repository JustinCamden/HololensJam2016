using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    // Variables
    public float enemySpawnTimer = 5f;
    float currSpawnTimer;
    public enum SpawnMode { waiting, spawning };
    SpawnMode spawnMode = SpawnMode.spawning;
    public int maxEnemies;
    List<Monster_AI> enemies;

    // Enemies
    public GameObject enemyPrefab;

    // Enemy spawn positions
    public Transform[] spawnPositions;

	// Use this for initialization
	void Start () {
        currSpawnTimer = enemySpawnTimer;
        enemies = new List<Monster_AI>();
	}
	
	// Update is called once per frame
	void Update () {

        // Check if enemies are dead
        if (enemies.Count < maxEnemies)
        {
            spawnMode = SpawnMode.spawning;
        }
        else
        {
            spawnMode = SpawnMode.waiting;
        }

        // If spawning...
        if (spawnMode == SpawnMode.spawning)
        {
            // Check if the spawn timer has passed
            if (currSpawnTimer >= 0f)
            {
                currSpawnTimer -= Time.deltaTime;
            }
            // Otherwise if it has, spawn enemies and reset the timer
            else
            {
                int min = 0;
                int max = spawnPositions.Length - 1;
                int randomIndex = Random.Range(min, max);
                Debug.Log(randomIndex);
                GameObject enemy = Instantiate(enemyPrefab, spawnPositions[randomIndex].position, spawnPositions[randomIndex].transform.rotation) as GameObject;
                enemies.Add(enemy.GetComponent<Monster_AI>());
                currSpawnTimer = enemySpawnTimer;
            }
        }
	}

    // Remove an enemy from the list. Called by the enemy about to self destruct
    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy.GetComponent<Monster_AI>());
    }
}
